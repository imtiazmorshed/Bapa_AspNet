using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Xml.Linq;
using OMS.Facade;
using OMS.DAL;
using OMS.Web.Helpers;
using System.Collections.Generic;
using OMS.Framework;

namespace OMS.WebClient.UIAccount
{
    public partial class BankBranchView : System.Web.UI.Page
    {
        public long CurrentBankBranchID
        {
            get
            {
                if (ViewState["BankBranchID"] == null)
                {
                    return -1;
                }
                else
                {
                    return Convert.ToInt64(ViewState["BankBranchID"]);
                }
            }
            set { ViewState["BankBranchID"] = value; }
        }

        public int CurrentBranchID
        {
            get
            {
                if (ViewState["BranchID"] == null)
                {
                    return -1;
                }
                else
                {
                    return Convert.ToInt32(ViewState["BranchID"]);
                }
            }
            set { ViewState["BranchID"] = value; }
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
                lblMsg.Visible = false;
                if (!IsPostBack)
                {
                    if (Convert.ToInt32(Session["RoleID"].ToString()) == Convert.ToInt32(EnumCollection.UserType.Admin))//admin
                    {
                        CurrentBranchID = -1;
                    }
                    else
                    {
                        CurrentBranchID = Convert.ToInt32(Session["BranchID"].ToString());

                    }
                    //AccessHelper helper = new AccessHelper();
                    //bool hasAccess = helper.HasAccess(Convert.ToInt64(Session["UserID"].ToString()), Convert.ToInt64(Session["RoleID"].ToString()), Convert.ToBoolean(Session["IsRoleBased"].ToString()), this.Page.Title.ToString());
                    //if (!hasAccess)
                    //{
                    //    Response.Redirect("~/NoPermission.aspx");
                    //}

                    LoadListView();
                    LoadBank();
                    if (Session["IsSaved"] != null)
                    {
                        if (Convert.ToBoolean(Session["IsSaved"]) == true)
                        {
                            ShowMsg("Data successfully saved...");
                        }
                        else
                        {
                            ShowMsg("Data not saved...");
                        }
                    }
                }
            }
        }

        private void LoadBank()
        {
            using (TheFacade facade = new TheFacade())
            {
                List<Acc_Bank> bankList = facade.AccountsFacade.GetBankAll();
                DDLHelper.Bind<Acc_Bank>(ddlBank, bankList, "Name", "IID", EnumCollection.ListItemType.Bank,true);
            }
        }

        private void ShowMsg(string msg)
        {
            lblMsg.Text = msg;
            lblMsg.Visible = true;
            Session["IsSaved"] = null;
        }

        private void LoadListView()
        {
            List<Acc_BankBranch> branchList = new List<Acc_BankBranch>();
            using (TheFacade facade = new TheFacade())
            {
                
                branchList = facade.AccountsFacade.GetBranchAll().Where(b => (CurrentBranchID <= 0 || (CurrentBranchID > 0 && b.BranchID == CurrentBranchID))).ToList();
                //branchList = branchList

                lvBranch.DataSource = branchList;
                lvBranch.DataBind();
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (Session["BranchID"] != null)
            {
                if (CurrentBankBranchID <= 0)
                {
                    try
                    {
                        Acc_BankBranch branch = new Acc_BankBranch();
                        branch = CreateBranch(branch);
                        using (TheFacade facade = new TheFacade())
                        {
                            facade.Insert<Acc_BankBranch>(branch);
                        }
                        Session["IsSaved"] = true;
                        Response.Redirect(Request.Url.ToString());
                    }
                    catch
                    {
                        lblMsg.Text = "Data not saved...";
                        lblMsg.Visible = true;
                    }
                }
                else
                {
                    try
                    {
                        using (TheFacade facade = new TheFacade())
                        {
                            Acc_BankBranch branch = facade.AccountsFacade.GetBranchByIID(CurrentBankBranchID);
                            branch = CreateBranch(branch);
                            facade.Update<Acc_BankBranch>(branch);
                        }
                        Session["IsSaved"] = true;
                        Response.Redirect(Request.Url.ToString());
                    }
                    catch
                    {
                        lblMsg.Text = "Data not saved...";
                        lblMsg.Visible = true;
                    }
                }
            }
            else
            {
                FormsAuthentication.SignOut();
                Roles.DeleteCookie();
                Session.Abandon();
                Response.Redirect("~/login.aspx");
            }
        }

        private Acc_BankBranch CreateBranch(Acc_BankBranch branch)
        {
            branch.Name = txtName.Text.Trim();
            branch.BankID = Convert.ToInt64(ddlBank.SelectedValue);
            branch.Address = txtAddress.Text.Trim();
            if (CurrentBankBranchID <= 0)
            {
                branch.CreateBy = 1;
                branch.CreateDate = DateTime.Now;
            }
            branch.UpdateBy = 1;
            branch.UpdateDate = DateTime.Now;
            branch.IsRemoved = 0;
            branch.BranchID = Convert.ToInt32(Session["BranchID"]);
            return branch;
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect(Request.Url.ToString());
        }

        protected void lvBranch_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            if (e.CommandName == "DoDelete")
            {

                using (TheFacade _facade = new TheFacade())
                {
                    Acc_BankBranch branch = new Acc_BankBranch();
                    CurrentBankBranchID = Convert.ToInt64(e.CommandArgument.ToString());
                    branch = _facade.AccountsFacade.GetBranchByIID(Convert.ToInt64(e.CommandArgument.ToString()));
                    branch.IsRemoved = 1;
                    _facade.Update<Acc_BankBranch>(branch);
                    Response.Redirect(Request.Url.ToString());
                }
            }

            else if (e.CommandName == "DoEdit")
            {

                using (TheFacade _facade = new TheFacade())
                {

                    Acc_BankBranch branch = new Acc_BankBranch();
                    CurrentBankBranchID = Convert.ToInt64(e.CommandArgument.ToString());
                    branch = _facade.AccountsFacade.GetBranchByIID(Convert.ToInt64(e.CommandArgument.ToString()));
                    LoadBranch(branch);
                }
            }
        }

        private void LoadBranch(Acc_BankBranch branch)
        {
            txtName.Text = branch.Name;
            txtAddress.Text = branch.Address;
            ddlBank.SelectedValue = branch.BankID.ToString();
        }

        protected void lvBranch_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            {
                ListViewDataItem currentItem = (ListViewDataItem)e.Item;
                Acc_BankBranch branch = (Acc_BankBranch)((ListViewDataItem)(e.Item)).DataItem;
                LinkButton lnkName = (LinkButton)currentItem.FindControl("lnkName");
                Label lblAddress = (Label)currentItem.FindControl("lblAddress");
                Label lblBank = (Label)currentItem.FindControl("lblBank");
                LinkButton lnkEdit = (LinkButton)currentItem.FindControl("lnkEdit");
                LinkButton lnkDelete = (LinkButton)currentItem.FindControl("lnkDelete");

                lnkName.Text = branch.Name;
                lnkName.CommandArgument = branch.IID.ToString();
                lnkName.CommandName = "DoEdit";

                lblAddress.Text = branch.Address;
                lblBank.Text = branch.Acc_Bank.Name;

                lnkEdit.CommandName = "DoEdit";
                lnkEdit.CommandArgument = branch.IID.ToString();

                lnkDelete.CommandName = "DoDelete";
                lnkDelete.CommandArgument = branch.IID.ToString();
            }
        }

        protected void dpList_PreRender(object sender, EventArgs e)
        {
            LoadListView();
        }
    }
}
