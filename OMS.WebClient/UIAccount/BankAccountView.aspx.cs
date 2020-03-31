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
using System.Collections.Generic;
using OMS.Framework;
using OMS.Web.Helpers;

namespace OMS.WebClient.UIAccount
{
    public partial class BankAccountView : System.Web.UI.Page
    {
        public long CurrentBankAccountID
        {
            get
            {
                if (ViewState["BankAccountID"] == null)
                {
                    return -1;
                }
                else
                {
                    return Convert.ToInt64(ViewState["BankAccountID"]);
                }
            }
            set { ViewState["BankAccountID"] = value; }
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
                    LoadDDL();
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

        private void LoadDDL()
        {
            using (TheFacade facade = new TheFacade())
            {
                List<Acc_Bank> bankList = facade.AccountsFacade.GetBankAll();
                DDLHelper.Bind<Acc_Bank>(ddlBank, bankList, "Name", "IID", EnumCollection.ListItemType.Bank, true);
                
                List<Acc_BankBranch> branchList = facade.AccountsFacade.GetBranchAll().Where(b => (CurrentBranchID <= 0 || (CurrentBranchID > 0 && b.BranchID == CurrentBranchID))).ToList();
                DDLHelper.Bind<Acc_BankBranch>(ddlBranch, branchList, "Name", "IID", EnumCollection.ListItemType.Select, true);
                
                DDLHelper.Bind(ddlAccountType, EnumHelper.EnumToList<EnumCollection.BankAccountType>(), EnumCollection.ListItemType.Select);
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
            using (TheFacade facade = new TheFacade())
            {
                lvBankAccount.DataSource = facade.AccountsFacade.GetBankAccountAll().Where(b => (CurrentBranchID <= 0 || (CurrentBranchID > 0 && b.BranchID == CurrentBranchID))).ToList();
                lvBankAccount.DataBind();
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (Session["BranchID"] != null)
            {
                if (CurrentBankAccountID <= 0)
                {
                    try
                    {
                        Acc_BankAccount bankAcc = new Acc_BankAccount();
                        bankAcc = CreateBankAccount(bankAcc);
                        using (TheFacade facade = new TheFacade())
                        {
                            facade.Insert<Acc_BankAccount>(bankAcc);
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
                            Acc_BankAccount bankAcc = facade.AccountsFacade.GetBankAccountByIID(CurrentBankAccountID);
                            bankAcc = CreateBankAccount(bankAcc);
                            facade.Update<Acc_BankAccount>(bankAcc);
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

        private Acc_BankAccount CreateBankAccount(Acc_BankAccount bankAcc)
        {
            bankAcc.Name = txtName.Text.Trim();
            bankAcc.AccountNumber = txtAccountNo.Text.Trim();
            bankAcc.BankBranchID = Convert.ToInt64(ddlBranch.SelectedValue);
            bankAcc.BankAccountType = Convert.ToInt32(ddlAccountType.SelectedValue);
            if (CurrentBankAccountID <= 0)
            {
                bankAcc.CreateBy = 1;
                bankAcc.CreateDate = DateTime.Now;
            }
            bankAcc.UpdateBy = 1;
            bankAcc.UpdateDate = DateTime.Now;
            bankAcc.IsRemoved = 0;
            bankAcc.BranchID = Convert.ToInt32(Session["BranchID"]);
            return bankAcc;
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect(Request.Url.ToString());
        }

        protected void lvBankAccount_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            if (e.CommandName == "DoDelete")
            {

                using (TheFacade _facade = new TheFacade())
                {
                    Acc_BankAccount bankAcc = new Acc_BankAccount();
                    CurrentBankAccountID = Convert.ToInt64(e.CommandArgument.ToString());
                    bankAcc = _facade.AccountsFacade.GetBankAccountByIID(Convert.ToInt64(e.CommandArgument.ToString()));
                    bankAcc.IsRemoved = 1;
                    _facade.Update<Acc_BankAccount>(bankAcc);
                    Response.Redirect(Request.Url.ToString());
                }
            }

            else if (e.CommandName == "DoEdit")
            {

                using (TheFacade _facade = new TheFacade())
                {

                    Acc_BankAccount bankAcc = new Acc_BankAccount();
                    CurrentBankAccountID = Convert.ToInt64(e.CommandArgument.ToString());
                    bankAcc = _facade.AccountsFacade.GetBankAccountAllByIID(Convert.ToInt64(e.CommandArgument.ToString()));
                    LoadBankAccount(bankAcc);
                }
            }
        }

        private void LoadBankAccount(Acc_BankAccount bankAcc)
        {
            txtName.Text = bankAcc.Name;
            txtAccountNo.Text = bankAcc.AccountNumber;
            ddlAccountType.SelectedValue = bankAcc.BankAccountType.ToString();
            using (TheFacade facade = new TheFacade())
            {
                Acc_Bank bank = facade.AccountsFacade.GetBankByIID(bankAcc.Acc_BankBranch.BankID);
                ddlBank.SelectedValue = bank.IID.ToString();
                ddlBank_SelectedIndexChanged(null, null);
            }
            ddlBranch.SelectedValue = bankAcc.BankBranchID.ToString();
        }

        protected void lvBankAccount_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            if (e.Item.ItemType == ListViewItemType.DataItem)
            {
                ListViewDataItem currentItem = (ListViewDataItem)e.Item;
                Acc_BankAccount bankAcc = (Acc_BankAccount)((ListViewDataItem)(e.Item)).DataItem;
                LinkButton lnkName = (LinkButton)currentItem.FindControl("lnkName");

                Label lblBranch = (Label)currentItem.FindControl("lblBranch");
                Label lblAccountNo = (Label)currentItem.FindControl("lblAccountNo");
                Label lblAccountType = (Label)currentItem.FindControl("lblAccountType");
                Label lblBank = (Label)currentItem.FindControl("lblBank");

                LinkButton lnkEdit = (LinkButton)currentItem.FindControl("lnkEdit");
                LinkButton lnkDelete = (LinkButton)currentItem.FindControl("lnkDelete");

                lnkName.Text = bankAcc.Name;
                lnkName.CommandArgument = bankAcc.IID.ToString();
                lnkName.CommandName = "DoEdit";

                lblBank.Text = bankAcc.Acc_BankBranch.Acc_Bank.Name;
                lblAccountNo.Text = bankAcc.AccountNumber;
                lblBranch.Text = bankAcc.Acc_BankBranch.Name;
                lblAccountType.Text = EnumHelper.EnumToString<EnumCollection.BankAccountType>(bankAcc.BankAccountType);

                lnkEdit.CommandName = "DoEdit";
                lnkEdit.CommandArgument = bankAcc.IID.ToString();

                lnkDelete.CommandName = "DoDelete";
                lnkDelete.CommandArgument = bankAcc.IID.ToString();
            }
        }

        protected void dpList_PreRender(object sender, EventArgs e)
        {
            LoadListView();
        }

        protected void ddlBank_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlBank.SelectedValue != "-1")
            {
                using (TheFacade facade = new TheFacade())
                {
                    ddlBranch.Items.Clear();
                    List<Acc_BankBranch> branchList = facade.AccountsFacade.GetBranchByBankID(Convert.ToInt64(ddlBank.SelectedValue)).Where(b => (CurrentBranchID <= 0 || (CurrentBranchID > 0 && b.BranchID == CurrentBranchID))).ToList(); 
                    DDLHelper.Bind<Acc_BankBranch>(ddlBranch, branchList, "Name", "IID", EnumCollection.ListItemType.Select, true);
                }
            }
        }
    }
}
