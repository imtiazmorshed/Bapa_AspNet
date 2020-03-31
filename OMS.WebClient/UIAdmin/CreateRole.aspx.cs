using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using OMS.DAL;
using OMS.Facade;
using OMS.Web.Helpers;
using OMS.Framework;
using System.Web.Security;

namespace OMS.WebClient.UIAdmin
{
    public partial class CreateRole : System.Web.UI.Page
    {
        public long RoleID
        {
            get { return Convert.ToInt64(ViewState["CurrentRoleID"]); }
            set { ViewState["CurrentRoleID"] = value; }
        } 

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserID"] == null)
            {
                Session.Abandon();
                Response.Redirect("../Login.aspx?" + "&msgSessionOut=1");
            }
            else
            {
                lblMsg.Text = "";
                if (!IsPostBack)
                {
                    AccessHelper helper = new AccessHelper();
                    bool hasAccess = helper.HasAccess(Convert.ToInt64(Session["UserID"].ToString()), 
                        Convert.ToInt64(Session["RoleID"].ToString()), 
                        Convert.ToBoolean(Session["IsRoleBased"].ToString()), 
                        this.Page.Title.ToString());
                    if (!hasAccess)
                    {
                        Response.Redirect("~/NoPermission.aspx");
                    }

                    refreshGridData();
                    //LoadRoleDDL();
                    LoadPages();
                    btnAdd.Visible = true;
                    btnUpdate.Visible = false;
                    lblMsg.ForeColor = System.Drawing.Color.Green;
                    if (Session["IsSaved"] != null)
                    {
                        lblMsg.Text = Session["IsSaved"].ToString();
                        Session["IsSaved"] = null;

                    }
                }
            }
        }


        private void LoadPages()
        {
            using (TheFacade facade = new TheFacade())
            {
                List<SystemPage> pageList = facade.AdminFacade.GetSystemPageAll();

                chkPageList.DataSource = pageList;
                chkPageList.DataTextField = "PageName";
                chkPageList.DataValueField = "IID";
                chkPageList.DataBind();
            }
        }

        private void refreshGridData()
        {
            using (TheFacade facade = new TheFacade())
            {
                grdRoleInfo.DataSource = facade.AdminFacade.GetSystemRoleAll();
                grdRoleInfo.DataBind();
            }

        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {

            if (edtRole.Text.Trim() == "")
            {
                //ShowErrorMessage("Please enter Role");
                return;
            }
            try
            {


                using (TheFacade userFacade = new TheFacade())
                {
                    SystemRole role = new SystemRole();
                    role.RoleName = edtRole.Text.Trim();
                    role.IsRemoved = 0;

                    userFacade.Insert<SystemRole>(role);
                    foreach (ListItem item in chkPageList.Items)
                    {
                        if (item.Selected)
                        {
                            PagesOnRole pagesOnRole = new PagesOnRole();
                            pagesOnRole.PageID = Convert.ToInt64(item.Value);
                            pagesOnRole.RoleID = role.IID;
                            pagesOnRole.IsRemoved = 0;

                            userFacade.Insert<PagesOnRole>(pagesOnRole);
                        }

                    }
                }
                Session["IsSaved"] = "Role Successfully Added";
            }

            catch
            {
                Session["IsSaved"] ="Role Not Added";
            }

            finally
            {
                Response.Redirect(Request.Url.ToString());
            }
        }




        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {


                using (TheFacade facade = new TheFacade())
                {
                    
                    SystemRole role = facade.SecurityFacade.GetRoleByIID(RoleID);
                    role.RoleName = edtRole.Text.Trim();
                    facade.Update<SystemRole>(role);

                    // delete previous pages on role  (loop)
                    // insert new  pages on role (loop)

                    List<PagesOnRole> PagesonRoleList = facade.AdminFacade.GetSystemPageByRoleID(RoleID);

                    foreach (PagesOnRole pageonRole in PagesonRoleList)
                    {
                        pageonRole.IsRemoved = 1;
                        facade.Update<PagesOnRole>(pageonRole);
                    }


                    foreach (ListItem item in chkPageList.Items)
                    {
                        if (item.Selected)
                        {
                            PagesOnRole pageonRole = new PagesOnRole();
                            pageonRole.PageID = Convert.ToInt64(item.Value);
                            pageonRole.RoleID = role.IID;
                            pageonRole.IsRemoved = 0;
                            facade.Insert<PagesOnRole>(pageonRole);
                        }
                    }

                }
                Session["IsSaved"] = "Role Successfully Updated";
            }

            catch
            {
                Session["IsSaved"] = "Role Not Updated";
            }

            finally
            {
                Response.Redirect(Request.Url.ToString());
            }
        }

        protected void grdRoleInfo_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                SystemRole role = (SystemRole)e.Row.DataItem;
                //SystemUser user = (SystemUser)e.Row.DataItem;

                ((Label)e.Row.FindControl("lblRole")).Text = role.RoleName.ToString();


                ((LinkButton)e.Row.FindControl("lnkEdit")).CommandName = "DoEdit";
                //((LinkButton)e.Row.FindControl("lnkDelete")).CommandName = "DoDelete";

                ((LinkButton)e.Row.FindControl("lnkEdit")).CommandArgument = role.IID.ToString();
                //((LinkButton)e.Row.FindControl("lnkDelete")).CommandArgument = user.IID.ToString();



            }
        }



        private void FillRole(SystemRole role)
        {
            edtRole.Text = role.RoleName;




            foreach (ListItem item in chkPageList.Items)
            {

                item.Selected = false;

            }


            foreach (ListItem item in chkPageList.Items)
            {
                foreach (PagesOnRole por in role.PagesOnRoleList)
                {
                    if (item.Value == por.PageID.ToString())
                    {
                        item.Selected = true;
                        break;
                    }
                }

            }
        }



        protected void grdRoleInfo_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            RoleID = Convert.ToInt64(e.CommandArgument);
            if (e.CommandName == "DoEdit")
            {
                using (TheFacade userFacade = new TheFacade())
                {

                    SystemRole role = userFacade.AdminFacade.GetRoleByIIDWithPages(RoleID);
                    FillRole(role);

                    btnAdd.Visible = false;
                    btnUpdate.Visible = true;
                }
            }
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            Response.Redirect(Request.Url.ToString());
        }



    }
}

