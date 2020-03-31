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
using OMS.DAL;
using OMS.Framework;
using System.Collections.Generic;
using OMS.Facade;

namespace OMS.WebClient.UIAccount
{
    public partial class ProfitAndLossView : System.Web.UI.Page
    {
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
                if (!IsPostBack)
                {
                    //if (Session["UserID"] != null)
                    //{
                    //    AccessHelper helper = new AccessHelper();
                    //    bool hasAccess = helper.HasAccess(Convert.ToInt64(Session["UserID"].ToString()),
                    //                                      Convert.ToInt64(Session["RoleID"].ToString()),
                    //                                      Convert.ToBoolean(Session["IsRoleBased"].ToString()),
                    //                                      this.Page.Title.ToString());
                    //    if (!hasAccess)
                    //    {
                    //        Response.Redirect("~/NoPermission.aspx");
                    //    }
                    //}

                    //else
                    //{
                    //    Response.Redirect("~/login.aspx");
                    //}
                    if (Convert.ToInt32(Session["RoleID"].ToString()) == Convert.ToInt32(EnumCollection.UserType.Admin))//admin
                    {
                        CurrentBranchID = -1;
                    }
                    else
                    {
                        CurrentBranchID = Convert.ToInt32(Session["BranchID"].ToString());

                    }
                    CompanyInfo com = new CompanyInfo();
                    using (TheFacade facade = new TheFacade())
                    {
                        com = facade.CommonFacade.GetCompanyInfoAll().FirstOrDefault();
                    }
                    imgLogo.ImageUrl = com.LogoLocation;
                    lblCompany.Text = com.Name;
                    LoadListView();
                    decimal balance = income - expense;
                    lblBalanceTotal.Text = "Profit/Loss = " + balance.ToString("0.00");
                    //if (balance > 0)
                    //{
                    //    lblBalanceTotal.Text = "Profit = " + balance.ToString("0.00");
                    //}
                    //else
                    //{
                    //    lblBalanceTotal.Text = "Loss = " + balance.ToString("0.00");
                    //}
                    lblDate.Text = "For year ended " + DateTime.Now.ToString("dd/MM/yyyy"); ;
                }
            }
        }

        private void LoadListView()
        {
            List<Acc_Class> classList = new List<Acc_Class>();
            using (TheFacade _facade = new TheFacade())
            {
                classList = _facade.AccountsFacade.GetAcc_ClassAll().Where(c => c.IID != 1 && c.IID != 2).ToList();
            }
            if (classList.Count > 0)
            {
                lvBalanceSheet.DataSource = classList;
                lvBalanceSheet.DataBind();
            }
        }

        decimal income = 0;
        decimal expense = 0;
        protected void lvBalanceSheet_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            if (e.Item.ItemType == ListViewItemType.DataItem)
            {
                ListViewDataItem currentItem = (ListViewDataItem)e.Item;

                Acc_Class acc_class = (Acc_Class)((ListViewDataItem)(e.Item)).DataItem;

                Label lblClass = (Label)currentItem.FindControl("lblClass");
                ListView lvAccountsDetails = (ListView)currentItem.FindControl("lvAccountsDetails");
                Label lblBalanceHead = (Label)currentItem.FindControl("lblBalanceHead");
                
                lblClass.Text = acc_class.Name;
                
                decimal totalBalance = 0;
                List<Acc_ChartOfAccount> chartOfAccountList = new List<Acc_ChartOfAccount>();
                using (TheFacade _facade = new TheFacade())
                {
                    List<Acc_ChartOfAccount> coaParentList = new List<Acc_ChartOfAccount>();
                    List<Acc_ChartOfAccount> coaChildList = new List<Acc_ChartOfAccount>();
                    List<Acc_ChartOfAccount> coaGroupList = new List<Acc_ChartOfAccount>();
                    List<Acc_ChartOfAccount> coaGroupParentList = new List<Acc_ChartOfAccount>();

                    coaParentList = _facade.AccountsFacade.GetAcc_ChartOfAccountAll().Where(c => c.ParentID == -1 && c.Gparent == acc_class.IID && c.Name != "Sales" && c.Name != "Purchase" && c.Name != "Sale Return").ToList();
                    foreach (Acc_ChartOfAccount coa in coaParentList)
                    {
                        coaChildList = _facade.AccountsFacade.GetAcc_ChartOfAccountBalanceNew(coa.IID);
                        coaGroupList = new List<Acc_ChartOfAccount>();
                        coaGroupList = coaChildList.Where(c => c.ParentID == coa.IID).ToList();
                        foreach (Acc_ChartOfAccount coaGP in coaGroupList)
                        {
                            coaGroupParentList.Add(coaGP);
                            coa.Balance += coaGP.Balance;
                            
                        }

                        totalBalance += coa.Balance;       
                    }

                    lvAccountsDetails.DataSource = coaParentList;
                    lvAccountsDetails.DataBind();
                }
                lblBalanceHead.Text = totalBalance.ToString();
                if (acc_class.IID == 3)
                {
                    income = totalBalance;
                }
                else
                {
                    expense = totalBalance;
                }
            }
            //if (e.Item.ItemType == ListViewItemType.DataItem)
            //{
            //    ListViewDataItem currentItem = (ListViewDataItem)e.Item;

            //    Acc_Class acc_class = (Acc_Class)((ListViewDataItem)(e.Item)).DataItem;

            //    Label lblClass = (Label)currentItem.FindControl("lblClass");
            //    ListView lvAccountsDetails = (ListView)currentItem.FindControl("lvAccountsDetails");

            //    lblClass.Text = acc_class.Name;

            //    List<Acc_ChartOfAccount> chartOfAccountList = new List<Acc_ChartOfAccount>();
            //    using (TheFacade _facade = new TheFacade())
            //    {
            //        chartOfAccountList = _facade.AccountsFacade.GetAcc_ChartOfAccountListByGParetntIDAndAccountTypeID(acc_class.IID, Convert.ToInt32(EnumCollection.AccountType.Transactable));
            //        List<Acc_ChartOfAccount> chartOfAccountListForListView = new List<Acc_ChartOfAccount>();
            //        if (chartOfAccountList.Count > 0)
            //        {
            //            #region Balance Calculation

            //            foreach (Acc_ChartOfAccount chartOfAccount in chartOfAccountList)
            //            {
            //                List<Acc_TransactionDetail> transactionDetailList = new List<Acc_TransactionDetail>();
            //                Decimal balance = 0;
            //                transactionDetailList = _facade.AccountsFacade.GetAcc_TransactionDetailAll().Where(td => td.AccountID == chartOfAccount.IID
            //                    && (CurrentBranchID <= 0 || (CurrentBranchID > 0 && td.BranchID == CurrentBranchID))).ToList();
            //                if (transactionDetailList.Count > 0)
            //                {
            //                    foreach (Acc_TransactionDetail td in transactionDetailList)
            //                    {
            //                        if (td.Acc_ChartOfAccount.Acc_Class.AccountNature == Convert.ToInt32(EnumCollection.TransactionNature.Debit))
            //                        {
            //                            if (td.TransactionNature == Convert.ToInt32(EnumCollection.TransactionNature.Debit))
            //                            {
            //                                balance += td.Amount;
            //                            }
            //                            else
            //                            {
            //                                balance -= td.Amount;
            //                            }

            //                        }
            //                        else
            //                        {
            //                            if (td.TransactionNature == Convert.ToInt32(EnumCollection.TransactionNature.Debit))
            //                            {
            //                                balance -= td.Amount;
            //                            }
            //                            else
            //                            {
            //                                balance += td.Amount;
            //                            }
            //                        }
            //                    }
            //                }
            //                chartOfAccount.Balance = balance;
            //                //if (chartOfAccount.Acc_Class.AccountNature == Convert.ToInt32(EnumCollection.TransactionNature.Debit))
            //                //{
            //                //    chartOfAccount.DebitAmount = balance;
            //                //    balanceDebit += balance;
            //                //}
            //                //else
            //                //{
            //                //    chartOfAccount.CreditAmount = balance;
            //                //    balanceCredit += balance;
            //                //}

            //                chartOfAccountListForListView.Add(chartOfAccount);
            //            }

            //            #endregion

            //            lvAccountsDetails.DataSource = chartOfAccountListForListView;
            //            lvAccountsDetails.DataBind();
            //        }
            //    }
            //}
        }

        protected void lvAccountsDetails_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            if (e.Item.ItemType == ListViewItemType.DataItem)
            {
                ListViewDataItem currentItem = (ListViewDataItem)e.Item;

                Acc_ChartOfAccount acc_chartOfAccount = (Acc_ChartOfAccount)((ListViewDataItem)(e.Item)).DataItem;

                Label lblAccount = (Label)currentItem.FindControl("lblAccount");
                Label lblAmount = (Label)currentItem.FindControl("lblAmount");
                ListView lvGroupAccounts = (ListView)currentItem.FindControl("lvGroupAccounts");
                lblAccount.Text = acc_chartOfAccount.Name + " [" + acc_chartOfAccount.AccountNo + "]";
                lblAmount.Text = acc_chartOfAccount.Balance.ToString();

                using (TheFacade _facade = new TheFacade())
                {
                    List<Acc_ChartOfAccount> coaParentList = new List<Acc_ChartOfAccount>();
                    List<Acc_ChartOfAccount> coaChildList = new List<Acc_ChartOfAccount>();
                    List<Acc_ChartOfAccount> coaGroupList = new List<Acc_ChartOfAccount>();
                    List<Acc_ChartOfAccount> coaGroupParentList = new List<Acc_ChartOfAccount>();
                    List<Acc_ChartOfAccount> coaLedgerList = new List<Acc_ChartOfAccount>();

                    coaChildList = _facade.AccountsFacade.GetAcc_ChartOfAccountBalanceNew(acc_chartOfAccount.IID);
                    //coaGroupList = new List<Acc_ChartOfAccount>();
                    coaGroupList = coaChildList.Where(c => c.ParentID == acc_chartOfAccount.IID).ToList();
                    //foreach (Acc_ChartOfAccount coaGP in coaGroupList)
                    //{
                    //    coaGroupParentList.Add(coaGP);
                    //    coa.Balance += coaGP.Balance;
                    //}
                    coaLedgerList = coaChildList.Where(c => c.AccountTypeID == Convert.ToInt32(EnumCollection.AccountType.Transactable)).ToList();

                    lvGroupAccounts.DataSource = coaGroupList;
                    lvGroupAccounts.DataBind();
                }
            }
        }

        protected void lvGroupAccounts_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            if (e.Item.ItemType == ListViewItemType.DataItem)
            {
                ListViewDataItem currentItem = (ListViewDataItem)e.Item;

                Acc_ChartOfAccount acc_chartOfAccount = (Acc_ChartOfAccount)((ListViewDataItem)(e.Item)).DataItem;

                Label lblGroupAccount = (Label)currentItem.FindControl("lblGroupAccount");
                Label lblGroupAmount = (Label)currentItem.FindControl("lblGroupAmount");
                ListView lvGroupAccounts = (ListView)currentItem.FindControl("lvGroupAccounts");
                lblGroupAccount.Text = acc_chartOfAccount.Name + " [" + acc_chartOfAccount.AccountNo + "]";
                lblGroupAmount.Text = acc_chartOfAccount.Balance.ToString();
            }
        }


        protected void btnPrint_Click(object sender, EventArgs e)
        {
            Session["ctrl"] = pnlPrint;
            Session["header"] = this.Page.Title;
            //Session["header"] = string.Empty;
            ClientScript.RegisterStartupScript(this.GetType(), "onclick", "<script language=javascript>window.open('Print.aspx','PrintMe','height=1280px,width=800px,scrollbars=1');</script>");
        }
    }
}
