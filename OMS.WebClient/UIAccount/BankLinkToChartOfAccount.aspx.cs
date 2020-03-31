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
using OMS.Web.Helpers;
using OMS.Framework;

namespace OMS.WebClient.UIAccount
{
    public partial class BankLinkToChartOfAccount : System.Web.UI.Page
    {
        public long BankCOA
        {
            get
            {
                if (ViewState["BankCOA"] == null)
                {
                    return -1;
                }
                else
                {
                    return Convert.ToInt64(ViewState["BankCOA"]);
                }
            }
            set { ViewState["BankCOA"] = value; }
        }

        public long currentMapID
        {
            get
            {
                if (ViewState["CurrentMapID"] == null)
                {
                    return -1;
                }
                else
                {
                    return Convert.ToInt64(ViewState["CurrentMapID"]);
                }
            }
            set { ViewState["CurrentMapID"] = value; }
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
                if (!IsPostBack)
                {
                    //AccessHelper helper = new AccessHelper();
                    //bool hasAccess = helper.HasAccess(Convert.ToInt64(Session["UserID"].ToString()), Convert.ToInt64(Session["RoleID"].ToString()), Convert.ToBoolean(Session["IsRoleBased"].ToString()), this.Page.Title.ToString());
                    //if (!hasAccess)
                    //{
                    //    Response.Redirect("~/NoPermission.aspx");
                    //}

                    LoadBankDDL();
                    LoadCOA();
                    LoadListView();
                    if (Session["IsSaved"] != null)
                    {
                        if ((bool)Session["IsSaved"] == true)
                        {
                            Session["IsSaved"] = null;
                            lblErr.Text = "Data saved successfully...";
                        }
                        //else ((bool)Session["IsSaved"] == false)
                        else
                        {
                            Session["IsSaved"] = null;
                            lblErr.Text = "Bank Account is already maped or Problem in Saving Data";
                        }
                    }
                }
            }
        }

        private void LoadListView()
        {
            using (TheFacade facade = new TheFacade())
            {
                List<Acc_BankLinkToChartOfAccount> bankLinkToChartOfAccountList = facade.AccountsFacade.GetBankLinkToChartOfAccountAll();
                lvMap.DataSource = bankLinkToChartOfAccountList;
                lvMap.DataBind();
            }
        }

        private void LoadCOA()
        {
            //List<Acc_ChartOfAccount> chartOfAccountList = new List<Acc_ChartOfAccount>();
            using (TheFacade _facade = new TheFacade())
            {
                Acc_ChartOfAccount coa = _facade.AccountsFacade.GetAcc_ChartOfAccountByName("Bank");
                if (coa != null)
                {
                    BankCOA = coa.IID;
                    lblCOA.Text = coa.Name;
                    List<Acc_ChartOfAccount> coaList = _facade.AccountsFacade.GetAcc_ChartOfAccountListByParetntID(BankCOA);
                    DDLHelper.Bind<Acc_ChartOfAccount>(ddlBankCOA, coaList, "Name", "IID", EnumCollection.ListItemType.Select);
                }
            }
        }

        private void LoadBankDDL()
        {
            using (TheFacade facade = new TheFacade())
            {
                List<Acc_Bank> bankList = facade.AccountsFacade.GetBankAll();
                DDLHelper.Bind<Acc_Bank>(ddlBank, bankList, "Name", "IID", EnumCollection.ListItemType.Bank, true);
                List<Acc_BankBranch> branchList = facade.AccountsFacade.GetBranchAll();
                DDLHelper.Bind<Acc_BankBranch>(ddlBranch, branchList, "Name", "IID", EnumCollection.ListItemType.Select, true);
                List<Acc_BankAccount> bankAccList = facade.AccountsFacade.GetBankAccountAll();
                DDLHelper.Bind<Acc_BankAccount>(ddlAccountName, bankAccList, "Name", "IID", EnumCollection.ListItemType.Select, true);
            }
        }       

        protected void ddlBankCOA_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlBankCOA.SelectedValue != "-1")
            {
                using (TheFacade _facade = new TheFacade())
                {
                    List<Acc_ChartOfAccount> coaList = _facade.AccountsFacade.GetAcc_ChartOfAccountListByParetntID(Convert.ToInt64(ddlBankCOA.SelectedValue));
                    DDLHelper.Bind<Acc_ChartOfAccount>(ddlBranchCOA, coaList, "Name", "IID", EnumCollection.ListItemType.Select);
                    
                }
            }
        }

        protected void ddlBranchCOA_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlBranchCOA.SelectedValue != "-1")
            {
                using (TheFacade _facade = new TheFacade())
                {
                    List<Acc_ChartOfAccount> coaList = _facade.AccountsFacade.GetAcc_ChartOfAccountListByParetntID(Convert.ToInt64(ddlBranchCOA.SelectedValue));
                    DDLHelper.Bind<Acc_ChartOfAccount>(ddlBankAccountCOA, coaList, "Name", "IID", EnumCollection.ListItemType.Select);

                }
            }
        }

        protected void ddlBank_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlBank.SelectedValue != "-1")
            {
                using (TheFacade facade = new TheFacade())
                {
                    ddlBranch.Items.Clear();
                    ddlAccountName.Items.Clear();
                    List<Acc_BankBranch> branchList = facade.AccountsFacade.GetBranchByBankID(Convert.ToInt64(ddlBank.SelectedValue));
                    DDLHelper.Bind<Acc_BankBranch>(ddlBranch, branchList, "Name", "IID", EnumCollection.ListItemType.Select, true);
                }
            }
        }

        protected void ddlBranch_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlBranch.SelectedValue != "-1")
            {
                using (TheFacade facade = new TheFacade())
                {
                    ddlAccountName.Items.Clear();
                    List<Acc_BankAccount> bankAccList = facade.AccountsFacade.GetBankAccountByBranchID(Convert.ToInt64(ddlBranch.SelectedValue));
                    DDLHelper.Bind<Acc_BankAccount>(ddlAccountName, bankAccList, "Name", "IID", EnumCollection.ListItemType.Select, true);
                }
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (Session["BranchID"] != null)
            {
                using (TheFacade facade = new TheFacade())
                {
                    try
                    {
                        if (currentMapID <= 0)
                        {

                            Acc_BankLinkToChartOfAccount bankLinkToChartOfAccountOld = facade.AccountsFacade.GetAcc_BankLinkToChartOfAccountByBankIDAndCOAID(Convert.ToInt64(ddlAccountName.SelectedValue), Convert.ToInt64(ddlBankAccountCOA.SelectedValue));
                            if (bankLinkToChartOfAccountOld == null)
                            {
                                Acc_BankLinkToChartOfAccount bankLinkToChartOfAccount = new Acc_BankLinkToChartOfAccount();
                                bankLinkToChartOfAccount = FillBankLinkToChartOfAccount(bankLinkToChartOfAccount);
                                facade.Insert<Acc_BankLinkToChartOfAccount>(bankLinkToChartOfAccount);
                                Session["IsSaved"] = true;
                                Response.Redirect("~/UIAccount/BankLinkToChartOfAccount.aspx", false);
                            }
                            else
                            {
                                Session["IsSaved"] = false;
                                Response.Redirect("~/UIAccount/BankLinkToChartOfAccount.aspx", false);
                            }
                        }
                        else
                        {
                            Acc_BankLinkToChartOfAccount bankLinkToChartOfAccountOld = facade.AccountsFacade.GetAcc_BankLinkToChartOfAccountByBankIDAndCOAIDAndIID(Convert.ToInt64(ddlAccountName.SelectedValue), Convert.ToInt64(ddlBankAccountCOA.SelectedValue), currentMapID);
                            if (bankLinkToChartOfAccountOld == null)
                            {
                                Acc_BankLinkToChartOfAccount bankLinkToChartOfAccount = facade.AccountsFacade.GetAcc_BankLinkToChartOfAccountOnlyByIID(currentMapID);
                                bankLinkToChartOfAccount = FillBankLinkToChartOfAccount(bankLinkToChartOfAccount);
                                facade.Update<Acc_BankLinkToChartOfAccount>(bankLinkToChartOfAccount);
                                Session["IsSaved"] = true;
                                Response.Redirect("~/UIAccount/BankLinkToChartOfAccount.aspx",false);
                            }
                            else
                            {
                                Session["IsSaved"] = false;
                                Response.Redirect("~/UIAccount/BankLinkToChartOfAccount.aspx", false);
                            }
                        }

                    }
                    catch (Exception ex)
                    {
                        ShowErrMsg("Data not saved...");
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

        private void ShowErrMsg(string ResultMessage)
        {
            string ResultScript = @"<script language=""JavaScript"">alert(""" + ResultMessage + @""");</script>";
            Page.RegisterStartupScript("SuccessResultScript", ResultScript);
        }

        private Acc_BankLinkToChartOfAccount FillBankLinkToChartOfAccount(Acc_BankLinkToChartOfAccount bankLinkToChartOfAccount)
        {
            bankLinkToChartOfAccount.BankAccountID = Convert.ToInt64(ddlAccountName.SelectedValue);
            bankLinkToChartOfAccount.ChartOfAccountID = Convert.ToInt64(ddlBankAccountCOA.SelectedValue);
            bankLinkToChartOfAccount.Status = 1;
            if (bankLinkToChartOfAccount.IID <= 0)
            {
                bankLinkToChartOfAccount.CreateBy = 1;
                bankLinkToChartOfAccount.CreateDate = DateTime.Now;
            }
            bankLinkToChartOfAccount.UpdateBy = 1;
            bankLinkToChartOfAccount.UpdateDate = DateTime.Now;
            bankLinkToChartOfAccount.IsRemoved = 0;
            bankLinkToChartOfAccount.BranchID = Convert.ToInt32(Session["BranchID"]);
            return bankLinkToChartOfAccount;
        }

        protected void lvMap_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            if (e.CommandName == "DoEdit")
            {
                currentMapID = Convert.ToInt64(e.CommandArgument.ToString());
                using (TheFacade facade = new TheFacade())
                {
                    Acc_BankLinkToChartOfAccount blCOA = facade.AccountsFacade.GetAcc_BankLinkToChartOfAccountByIID(currentMapID);
                    LoadControl(blCOA);
                }
            }
        }

        private void LoadControl(Acc_BankLinkToChartOfAccount blCOA)
        {
            ddlBank.SelectedValue = blCOA.Bank.IID.ToString();
            ddlBank_SelectedIndexChanged(null, null);
            ddlBranch.SelectedValue = blCOA.Branch.IID.ToString();
            ddlBranch_SelectedIndexChanged(null, null);
            ddlAccountName.SelectedValue = blCOA.BankAccountID.ToString();

            ddlBankCOA.SelectedValue = blCOA.COABank.IID.ToString();
            ddlBankCOA_SelectedIndexChanged(null, null);
            ddlBranchCOA.SelectedValue = blCOA.COABranch.IID.ToString();
            ddlBranchCOA_SelectedIndexChanged(null, null);
            ddlBankAccountCOA.SelectedValue = blCOA.ChartOfAccountID.ToString();
        }

        //private int itemSerial = 0;
        protected void lvMap_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            if (e.Item.ItemType == ListViewItemType.DataItem)
            {
                ListViewDataItem currentItem = (ListViewDataItem)e.Item;
                Acc_BankLinkToChartOfAccount blCOA = (Acc_BankLinkToChartOfAccount)((ListViewDataItem)(e.Item)).DataItem;
                ////Serial Number
                //itemSerial++;
                //Label lblSerialNo = (Label)currentItem.FindControl("lblSerialNo");
                //lblSerialNo.Text = itemSerial.ToString();

                Label lblBank = (Label)currentItem.FindControl("lblBank");
                Label lblBranch = (Label)currentItem.FindControl("lblBranch");
                Label lblBankCOA = (Label)currentItem.FindControl("lblBankCOA");
                Label lblBranchCOA = (Label)currentItem.FindControl("lblBranchCOA");

                LinkButton lnkAccoutName = (LinkButton)currentItem.FindControl("lnkAccoutName");
                LinkButton lnkAccoutNameCOA = (LinkButton)currentItem.FindControl("lnkAccoutNameCOA");

                lblBank.Text = blCOA.Bank.Name;
                lblBranch.Text = blCOA.Branch.Name;
                lnkAccoutName.Text = blCOA.Acc_BankAccount.Name;

                lblBankCOA.Text = blCOA.COABank.Name;
                lblBranchCOA.Text = blCOA.COABranch.Name;
                lnkAccoutNameCOA.Text = blCOA.Acc_ChartOfAccount.Name;

                lnkAccoutName.CommandName = "DoEdit";
                lnkAccoutNameCOA.CommandName = "DoEdit";
                lnkAccoutName.CommandArgument = blCOA.IID.ToString();
                lnkAccoutNameCOA.CommandArgument = blCOA.IID.ToString();
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect(Request.Url.ToString());
        }
    }
}
