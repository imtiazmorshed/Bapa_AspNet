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
using System.Collections.Generic;
using OMS.DAL;
using OMS.Facade;
using OMS.Framework;

namespace OMS.WebClient.UIAccount
{
    public partial class TrialBalanceView : System.Web.UI.Page
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
                //AccessHelper helper = new AccessHelper();
                //bool hasAccess = helper.HasAccess(Convert.ToInt64(Session["UserID"].ToString()), Convert.ToInt64(Session["RoleID"].ToString()), Convert.ToBoolean(Session["IsRoleBased"].ToString()), this.Page.Title.ToString());
                //if (!hasAccess)
                //{
                //    Response.Redirect("~/NoPermission.aspx");
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

                lblDate.Text ="As of " + DateTime.Now.ToString("dd-MMM-yyyy");
                LoadTrialBalance();
            }
        }

        private void LoadTrialBalance()
        {
            List<Acc_ChartOfAccount> chartOfAccountList = new List<Acc_ChartOfAccount>();
            List<Acc_ChartOfAccount> chartOfAccountListForListView = new List<Acc_ChartOfAccount>();
            decimal balanceDebit = 0;
            decimal balanceCredit = 0;
            using (TheFacade _facade = new TheFacade())
            {
                chartOfAccountList = _facade.AccountsFacade.GetAcc_ChartOfAccountAll().Where(coa => coa.AccountTypeID == Convert.ToInt32(EnumCollection.AccountType.Transactable)).ToList();
                if (chartOfAccountList.Count > 0)
                {
                    foreach (Acc_ChartOfAccount chartOfAccount in chartOfAccountList)
                    {
                        List<Acc_TransactionDetail> transactionDetailList = new List<Acc_TransactionDetail>();
                        Decimal balance = 0;
                        transactionDetailList = _facade.AccountsFacade.GetAcc_TransactionDetailAll().Where(td => td.AccountID == chartOfAccount.IID
                            && (CurrentBranchID <= 0 || (CurrentBranchID > 0 && td.BranchID == CurrentBranchID))).ToList();
                        if (transactionDetailList.Count > 0)
                        {
                            foreach (Acc_TransactionDetail td in transactionDetailList)
                            {
                                if (td.Acc_ChartOfAccount.Acc_Class.AccountNature == Convert.ToInt32(EnumCollection.TransactionNature.Debit))
                                {
                                    if (td.TransactionNature == Convert.ToInt32(EnumCollection.TransactionNature.Debit))
                                    {
                                        balance += td.Amount;
                                    }
                                    else
                                    {
                                        balance -= td.Amount;
                                    }

                                }
                                else
                                {
                                    if (td.TransactionNature == Convert.ToInt32(EnumCollection.TransactionNature.Debit))
                                    {
                                        balance -= td.Amount;
                                    }
                                    else
                                    {
                                        balance += td.Amount;
                                    }
                                }
                            }
                        }
                        string Op_bal = string.Empty;
                        if (string.IsNullOrEmpty(chartOfAccount.OpeningBalance.ToString()))
                        {
                            Op_bal = "0.00";
                        }
                        else
                        {
                            Op_bal = chartOfAccount.OpeningBalance.ToString();
                        }

                        balance += Convert.ToDecimal(Op_bal);
                        chartOfAccount.Balance = balance;
                        if (chartOfAccount.Acc_Class.AccountNature == Convert.ToInt32(EnumCollection.TransactionNature.Debit))
                        {
                            chartOfAccount.DebitAmount = balance;
                            balanceDebit += balance;
                        }
                        else
                        {
                            chartOfAccount.CreditAmount = balance;
                            balanceCredit += balance;
                        }

                        chartOfAccountListForListView.Add(chartOfAccount);
                    }
                }

            }
            chartOfAccountListForListView.OrderBy(coa => coa.Name).ToList();
            Acc_ChartOfAccount chartOfAccountBalance = new Acc_ChartOfAccount();
            chartOfAccountBalance.Name = "Total:";
            chartOfAccountBalance.DebitAmount = balanceDebit;
            chartOfAccountBalance.CreditAmount = balanceCredit;
            chartOfAccountListForListView.Add(chartOfAccountBalance);
            lvTrialBalance.DataSource = chartOfAccountListForListView;
            lvTrialBalance.DataBind();
        }

        protected void btnTrialBalance_Click(object sender, EventArgs e)
        {
            
            List<Acc_ChartOfAccount> chartOfAccountList = new List<Acc_ChartOfAccount>();
            List<Acc_ChartOfAccount> chartOfAccountListForListView = new List<Acc_ChartOfAccount>();
            decimal balanceDebit = 0;
            decimal balanceCredit = 0;
            using (TheFacade _facade = new TheFacade())
            {
                chartOfAccountList = _facade.AccountsFacade.GetAcc_ChartOfAccountAll().Where(coa => coa.AccountTypeID == Convert.ToInt32(EnumCollection.AccountType.Transactable)).ToList();
                if (chartOfAccountList.Count > 0)
                {
                    foreach (Acc_ChartOfAccount chartOfAccount in chartOfAccountList)
                    {
                        List<Acc_TransactionDetail> transactionDetailList = new List<Acc_TransactionDetail>();
                        Decimal balance = 0;
                        transactionDetailList = _facade.AccountsFacade.GetAcc_TransactionDetailAll().Where(td => td.AccountID == chartOfAccount.IID).ToList();
                        if (transactionDetailList.Count > 0)
                        {
                            foreach (Acc_TransactionDetail td in transactionDetailList)
                            {
                                if (td.Acc_ChartOfAccount.Acc_Class.AccountNature == Convert.ToInt32(EnumCollection.TransactionNature.Debit))
                                {
                                    if (td.TransactionNature == Convert.ToInt32(EnumCollection.TransactionNature.Debit))
                                    {
                                        balance += td.Amount;
                                    }
                                    else
                                    {
                                        balance -= td.Amount;
                                    }

                                }
                                else
                                {
                                    if (td.TransactionNature == Convert.ToInt32(EnumCollection.TransactionNature.Debit))
                                    {
                                        balance -= td.Amount;
                                    }
                                    else
                                    {
                                        balance += td.Amount;
                                    }
                                }
                            }
                        }
                        chartOfAccount.Balance = balance;
                        if (chartOfAccount.Acc_Class.AccountNature == Convert.ToInt32(EnumCollection.TransactionNature.Debit))
                        {
                            chartOfAccount.DebitAmount = balance;
                            balanceDebit += balance;
                        }
                        else
                        {
                            chartOfAccount.CreditAmount = balance;
                            balanceCredit += balance;
                        }

                        chartOfAccountListForListView.Add(chartOfAccount);
                    }
                }
                ;
            }
            Acc_ChartOfAccount chartOfAccountBalance = new Acc_ChartOfAccount();
            chartOfAccountBalance.DebitAmount = balanceDebit;
            chartOfAccountBalance.CreditAmount = balanceCredit;
            chartOfAccountListForListView.Add(chartOfAccountBalance);
            lvTrialBalance.DataSource = chartOfAccountListForListView;
            lvTrialBalance.DataBind();
        }

        protected void lvTrialBalance_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            if (e.Item.ItemType == ListViewItemType.DataItem)
            {
                ListViewDataItem currentItem = (ListViewDataItem)e.Item;

                Acc_ChartOfAccount chartOfAccount = (Acc_ChartOfAccount)((ListViewDataItem)(e.Item)).DataItem;

                Label lblAccount = (Label)currentItem.FindControl("lblAccount");                
                Label lblDebit = (Label)currentItem.FindControl("lblDebit");
                Label lblCredit = (Label)currentItem.FindControl("lblCredit");
                //Label lblBalance = (Label)currentItem.FindControl("lblBalance");

                if (chartOfAccount.Name != null && chartOfAccount.Name != "Total:")
                {
                    lblAccount.Text = chartOfAccount.Name + "[" + chartOfAccount.AccountNo + "]";
                }
                else
                {
                    lblAccount.Text = chartOfAccount.Name;
                }
                if (chartOfAccount.DebitAmount == 0)
                {
                    lblDebit.Text = "--";
                }
                else
                {
                    lblDebit.Text = chartOfAccount.DebitAmount.ToString();
                }
                if (chartOfAccount.CreditAmount == 0)
                {
                    lblCredit.Text = "--";
                }
                else
                {
                    lblCredit.Text = chartOfAccount.CreditAmount.ToString();
                }

                //lblBalance.Text = chartOfAccount.Balance.ToString();
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
