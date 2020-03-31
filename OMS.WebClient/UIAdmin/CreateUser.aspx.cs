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
    public partial class CreateUser : System.Web.UI.Page
    {
        public long UserID
        {
            get { return Convert.ToInt64(ViewState["CurrentUserID"]); }
            set { ViewState["CurrentUserID"] = value; }
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
                lblError.Visible = false;
                if (!IsPostBack)
                {
                    AccessHelper helper = new AccessHelper();
                    bool hasAccess = helper.HasAccess(Convert.ToInt64(Session["UserID"].ToString()), Convert.ToInt64(Session["RoleID"].ToString()), Convert.ToBoolean(Session["IsRoleBased"].ToString()), this.Page.Title.ToString());
                    if (!hasAccess)
                    {
                        Response.Redirect("~/NoPermission.aspx");
                    }

                    refreshGridData();
                    LoadDDL();
                    LoadRoleDDL();
                    LoadPages();
                    btnAdd.Visible = true;
                    btnUpdate.Visible = false;
                    lblError.ForeColor = System.Drawing.Color.Green;
                    if (Session["err"] != null)
                    {
                        lblError.Text = Session["err"].ToString();
                    }
                }
            }
        }

        private void LoadDDL()
        {
            using (TheFacade facade = new TheFacade())
            {
                List<BranchInfo> list = facade.CommonFacade.GetBranchInfoAll();

                DDLHelper.Bind<BranchInfo>(ddlBranch, list, "Name", "IID", EnumCollection.ListItemType.Select, true);

            }
            //DDLHelper.Bind(ddlUserType, EnumHelper.EnumToList<EnumCollection.UserType>());//, EnumCollection.ListItemType.TransactionMode);
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

        private void LoadRoleDDL()
        {
            using (TheFacade facade = new TheFacade())
            {
                List<SystemRole> roleList = facade.SecurityFacade.GetAllRoles();
                chkRole.DataSource = roleList;
                chkRole.DataTextField = "RoleName";
                chkRole.DataValueField = "IID";
                chkRole.DataBind();
            }

            using (TheFacade facade = new TheFacade())
            {
                List<SystemRole> roleList = facade.SecurityFacade.GetAllRoles();
                //ddlCenter.DataSource = roleList;
                //ddlCenter.DataTextField = "RoleName";
                //ddlCenter.DataValueField = "IID";
                //ddlCenter.DataBind();
                DDLHelper.Bind<SystemRole>(ddlCenter, roleList, "RoleName", "IID", EnumCollection.ListItemType.Select, true);

            }

        }

        private void refreshGridData()
        {
            using (TheFacade faade = new TheFacade())
            {
                grdUserInfo.DataSource = faade.SecurityFacade.GetAllUser();
                grdUserInfo.DataBind();
            }

        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            ClearControls();
        }

        private void ClearControls()
        {
            Response.Redirect(Request.Url.ToString());
        }

        protected void grdUserInfo_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                SystemUser user = (SystemUser)e.Row.DataItem;

                ((Label)e.Row.FindControl("lblUserName")).Text = user.UserName.ToString();
                ((Label)e.Row.FindControl("lblFirstName")).Text = user.FirstName.ToString();
                ((Label)e.Row.FindControl("lblLastName")).Text = user.LastName.ToString();
                ((Label)e.Row.FindControl("lblStatus")).Text = EnumHelper.EnumToString<EnumCollection.UserStatus>(Convert.ToInt32(user.Status));
                ((LinkButton)e.Row.FindControl("lnkEdit")).CommandName = "DoEdit";
                //((LinkButton)e.Row.FindControl("lnkDelete")).CommandName = "DoDelete";

                ((LinkButton)e.Row.FindControl("lnkEdit")).CommandArgument = user.IID.ToString();
                //((LinkButton)e.Row.FindControl("lnkDelete")).CommandArgument = user.IID.ToString();

                
                string theRole = "";
                if (user.Roles != null)
                {
                    string[] roles = user.Roles.Split(',');
                    int count = 0;
                    foreach (string role in roles)
                    {
                        if (!string.IsNullOrEmpty(role.Trim()))
                            try
                            {

                                if (count > 0)
                                {
                                    theRole = theRole + ",";
                                }
                                theRole = theRole + EnumHelper.EnumToString<EnumCollection.UserType>(Convert.ToInt32(role.Trim()));
                                count++;
                            }
                            catch
                            {
                            }
                    }
                }
                ((Label)e.Row.FindControl("lblRoles")).Text = theRole;
            }
        }

        protected void ShowErrorMessage(string ErrorMessage)
        {
            lblError.Text = ErrorMessage;
            lblError.Visible = true;
            lblError.ForeColor = System.Drawing.Color.Red;
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {

            if (edtPassword.Text != edtConfirmPassword.Text)
            {
                ShowErrorMessage("Passwords don't match. Please re-enter");
                return;
            }
            if (edtPassword.Text.Trim() == "" || edtConfirmPassword.Text.Trim() == "")
            {
                ShowErrorMessage("Please enter password and Confirm Password");
                return;
            }
            if (edtLoginName.Text.Trim() == "")
            {
                ShowErrorMessage("Please enter Login Name");
                return;
            }

           // MembershipUser memuser = Membership.GetUser(edtLoginName.Text.Trim());

            //if (memuser == null)
            //{
                //MembershipUser memUser = Membership.CreateUser(edtLoginName.Text.Trim(), edtPassword.Text);
                //foreach (ListItem item in chkRole.Items)
                //{
                //    if (item.Selected)
                //    {
                //        Roles.AddUserToRole(edtLoginName.Text.Trim(), item.Text);
                //    }
                //}
                using (TheFacade userFacade = new TheFacade())
                {
                    SystemUser user = new SystemUser();
                    user = LoadUser(user, true);
                    try
                    {

                        userFacade.Insert<SystemUser>(user);
                        foreach(ListItem item in chkPageList.Items)
                        {
                            if (item.Selected)
                            {
                                PagesOnUser pagesOnUser = new PagesOnUser();
                                pagesOnUser.PageID = Convert.ToInt64(item.Value);
                                pagesOnUser.UserID = user.IID;
                                pagesOnUser.IsRemoved = 0;

                                userFacade.Insert<PagesOnUser>(pagesOnUser);
                            }

                        }
                        lblMsg.Text = "User Successfully Added";
                        lblError.Text = "";
                    }
                    catch
                    {
                        lblMsg.Text = "";
                        ShowErrorMessage("Fail to Add User");
                    }
                }
                refreshGridData();
                //Response.Redirect(Request.Url.ToString());
            //}

            //else
            //{
            //    ShowErrorMessage("user already exist... ");
            //}
        }

        private SystemUser LoadUser(SystemUser user, bool isForSave)
        {
            if (!isForSave)
            {
                user.IID = UserID;
            }
            user.ProviderKey = "";// UserKey;
            user.CreatedDate = DateTime.Now;
            //user.DESCRIPTION = edtDescription.Text.Trim();
            user.FirstName = edtFName.Text.Trim();
            user.LastName = edtLName.Text.Trim();
            user.UserName = edtLoginName.Text.Trim();
            user.Email = "";
            int count = 0;
            string value = "";
            //foreach (ListItem item in chkRole.Items)
            //{
            //    if (item.Selected)
            //    {
            //        value = value + item.Value;
            //        count++;
            //        value = value + ",";
            //    }
            //
            user.RoleID = Convert.ToInt64(ddlCenter.SelectedValue);
            user.Roles = ddlCenter.SelectedItem.Text;
            //if (value.EndsWith(","))
            //{
            //    user.Roles = value.Substring(0, value.Length - 1);
            //}
            user.IsRoleBased = !chkIsRoleBased.Checked;
            user.Status = chkEnabled.Checked;
            user.IsRemoved = 0;
            user.UpdatedBy = 1;
            user.UpdatedDate = DateTime.Now;
            if (isForSave)
            user.Password = edtPassword.Text.Trim();
            user.UserTypeID = Convert.ToInt32(ddlCenter.SelectedValue);
            user.BranchID = Convert.ToInt32(ddlBranch.SelectedValue);
            return user;
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            //MembershipUser memuser = Membership.GetUser(edtLoginName.Text);

            if ( UserID > 0)
            {
               // MembershipUser memUser = Membership.GetUser(edtLoginName.Text.Trim());

              //  string[] roles = Roles.GetRolesForUser(edtLoginName.Text.Trim());

                //if (roles.Count()>0)
                //Roles.RemoveUserFromRoles(edtLoginName.Text.Trim(), roles);



                //foreach (ListItem item in chkRole.Items)
                //{
                //    if (item.Selected)
                //    {
                //        Roles.AddUserToRole(edtLoginName.Text.Trim(), item.Text);
                //    }
                //}
                //Roles.AddUserToRole(edtLoginName.Text.Trim(), ddlCenter.SelectedItem.Text);

                //memUser.IsApproved = chkEnabled.Checked;
                //Membership.UpdateUser(memUser);

               
                using (TheFacade userFacade = new TheFacade())
                {
                    SystemUser user = userFacade.SecurityFacade.GetUserByIID(UserID);
                    user = LoadUser(user, false);
                    try
                    {

                        userFacade.Update<SystemUser>(user);

                        if (!user.IsRoleBased)
                        {
                            List<PagesOnUser> pagesOnUserList = userFacade.AdminFacade.GetSystemPageByUserID(user.IID);

                            foreach (PagesOnUser pageonuser in pagesOnUserList)
                            {
                                pageonuser.IsRemoved = 1;
                                userFacade.Update<PagesOnUser>(pageonuser);
                            }

                            foreach (ListItem item in chkPageList.Items)
                            {
                                if (item.Selected)
                                {
                                    PagesOnUser pagesOnUser = new PagesOnUser();
                                    pagesOnUser.PageID = Convert.ToInt64(item.Value);
                                    pagesOnUser.UserID = user.IID;
                                    pagesOnUser.IsRemoved = 0;

                                    userFacade.Insert<PagesOnUser>(pagesOnUser);
                                }

                            }
                        }
                        lblMsg.Text = "User Successfully Updated";
                    }
                    catch
                    {
                        ShowErrorMessage("Fail to Updated User");
                    }
                }
                //Response.Redirect(Request.Url.ToString());
            }
            else
            {
                ShowErrorMessage("Fail to Updated User");
            }
            refreshGridData();
        }

        protected void grdUserInfo_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            long useriD = Convert.ToInt64(e.CommandArgument);
            if (e.CommandName == "DoEdit")
            {
                using (TheFacade userFacade = new TheFacade())
                {

                    SystemUser user = userFacade.SecurityFacade.GetUserByIIDWithRoles(useriD);
                    FillUser(user);
                    UserID = user.IID;
                    btnAdd.Visible = false;
                    btnUpdate.Visible = true;
                }
            }
        }

        private void FillUser(SystemUser user)
        {
            //edtDescription.Text = user.DESCRIPTION;
            edtFName.Text = user.FirstName;
            edtLName.Text = user.LastName;
            edtLoginName.Text = user.UserName;
            //String[] roleList = user.Roles.Split(',');
            ddlCenter.SelectedValue = user.RoleID.ToString();
            //foreach (string role in roleList)
            //{
            //    foreach (ListItem item in chkRole.Items)
            //    {
            //        if (item.Value == role.Trim())
            //        {
            //            item.Selected = true;
            //        }
            //    }
            //}
            if (user.BranchID != null)
            {
                ddlBranch.SelectedValue = user.BranchID.ToString();
            }
            else
            {
                ddlBranch.SelectedValue = "-1";
            }
            chkEnabled.Checked = Convert.ToBoolean(user.Status);
            if (!user.IsRoleBased)
            {
                chkIsRoleBased.Checked = true;
            }
            else
            {
                chkIsRoleBased.Checked = false;
            }

            chkIsRoleBased_CheckedChanged(null, null);

            foreach (ListItem item in chkPageList.Items)
            {
                
                    item.Selected = false;
               
            }


            foreach (ListItem item in chkPageList.Items)
            {
                foreach (PagesOnUser poe in user.PagesOnUserList)
                {
                    if (item.Value == poe.PageID.ToString())
                    {
                        item.Selected = true;
                        break;
                    }
                }
            }
        }

        protected void chkIsRoleBased_CheckedChanged(object sender, EventArgs e)
        {
            if (chkIsRoleBased.Checked)
            {
                divPaged.Visible = true;
            }
            else
            {
                divPaged.Visible = false;
            }
        }
    }
}
