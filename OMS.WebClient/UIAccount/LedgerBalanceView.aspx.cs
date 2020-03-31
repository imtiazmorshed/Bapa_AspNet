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
using System.Collections.Generic;
using OMS.Facade;
using OMS.Web.Helpers;
using OMS.Framework;

namespace OMS.WebClient.UIAccount
{
    public partial class LedgerBalanceView : System.Web.UI.Page
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
                    if (Session["UserID"] != null)
                    {

                        AccessHelper helper = new AccessHelper();
                        bool hasAccess = helper.HasAccess(Convert.ToInt64(Session["UserID"].ToString()), Convert.ToInt64(Session["RoleID"].ToString()), Convert.ToBoolean(Session["IsRoleBased"].ToString()), this.Page.Title.ToString());
                        if (!hasAccess)
                        {
                            Response.Redirect("~/NoPermission.aspx");
                        }

                    }
                    else
                    {
                        Response.Redirect("~/login.aspx");
                    }
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
                    LoadDDL();
                }
            }
        }

        private void LoadDDL()
        {
            List<Acc_ChartOfAccount> chartOfAccountList = new List<Acc_ChartOfAccount>();
            using (TheFacade _facade = new TheFacade())
            {
                chartOfAccountList = _facade.AccountsFacade.GetAcc_ChartOfAccountLedgerAll();
            }
            
            //DDLHelper.Bind(ddlProductTypeP, EnumHelper.EnumToList<EnumCollection.ProductType>(), EnumCollection.ListItemType.ProductType);

            DDLHelper.Bind<Acc_ChartOfAccount>(ddlAccountName, chartOfAccountList.OrderBy(coa => coa.Name).ToList(), "Name", "IID", EnumCollection.ListItemType.AccountName);
            DDLHelper.Bind<Acc_ChartOfAccount>(ddlAccountNo, chartOfAccountList.OrderBy(coa => coa.AccountNo).ToList(), "AccountNo", "IID", EnumCollection.ListItemType.AccountCode);            
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            if (ddlAccountNo.SelectedValue != "")
            {
                List<Acc_TransactionDetail> transactionDetailList = new List<Acc_TransactionDetail>();
                List<Acc_TransactionDetail> transactionDetailListForListView = new List<Acc_TransactionDetail>();
                Acc_ChartOfAccount chartOfAccount = new Acc_ChartOfAccount();
                using (TheFacade _facade = new TheFacade())
                {
                    Decimal balance = 0;
                    transactionDetailList = _facade.AccountsFacade.GetLedgerBalanceByChartOfAccountID(Convert.ToInt64(ddlAccountNo.SelectedValue));
                    chartOfAccount = _facade.AccountsFacade.GetAcc_ChartOfAccountByID(Convert.ToInt64(ddlAccountNo.SelectedValue));
                    if (chartOfAccount.IID <= 0)
                        return;
                    //DateTime previousDate;
                    //Int32 previousDay = Convert.ToDateTime(txtToDate.Text).Day - 1;
                    //Int32 month = Convert.ToDateTime(txtFromDate.Text).Month;
                    //Int32 year = Convert.ToDateTime(txtToDate.Text).Year;
                    //previousDate = Convert.ToDateTime(month + "/" + previousDay.ToString() + "/" + year + " 11:59:59 PM");

                    Acc_TransactionDetail transactionDetailOpeningBalance = new Acc_TransactionDetail();
                    transactionDetailOpeningBalance.AccountName = ddlAccountName.SelectedItem.ToString();
                    transactionDetailOpeningBalance.AccountName = "Opening Balance";
                    transactionDetailOpeningBalance.Particulars = "Opening Balance of the Account";
                    string Op_bal = string.Empty;
                    if (string.IsNullOrEmpty(chartOfAccount.OpeningBalance.ToString()))
                    {
                        Op_bal = "0.00";
                    }
                    else
                    {
                        Op_bal = chartOfAccount.OpeningBalance.ToString();
                    }
                    transactionDetailOpeningBalance.Balance = Convert.ToDecimal(Op_bal);//(chartOfAccount.OpeningBalance == null)? 0: chartOfAccount.OpeningBalance;
                    balance += transactionDetailOpeningBalance.Balance;
                    transactionDetailListForListView.Add(transactionDetailOpeningBalance);

                    lblAccountName.Text = chartOfAccount.Name + "(" + chartOfAccount.AccountNo + ")";
                    DateTime fromDate = Convert.ToDateTime(txtFromDate.Text + " 12:00:00 AM");
                    DateTime toDate = Convert.ToDateTime(txtToDate.Text + " 11:59:59 PM");

                    #region Previous balance calculation
                    
                    List<Acc_TransactionDetail> transactionDetailListForPreviousBalane = new List<Acc_TransactionDetail>();
                    transactionDetailListForPreviousBalane = transactionDetailList.Where(td => td.Acc_TransactionMaster.TransactionDate.Date < fromDate && (CurrentBranchID <= 0 || (CurrentBranchID > 0 && td.BranchID == CurrentBranchID))).ToList(); ;
                    
                    Acc_TransactionDetail transactionDetailPreviousBalance = new Acc_TransactionDetail();
                    //transactionDetailPreviousBalance = _facade.AccountsFacade.GetAcc_TransactionDetailListByChartOfAccountID(Convert.ToInt64(ddlAccountNo.SelectedValue)).FirstOrDefault();
                    
                    
                    
                    foreach (Acc_TransactionDetail td in transactionDetailListForPreviousBalane)
                    {
                        if (chartOfAccount.Acc_Class.AccountNature == Convert.ToInt32(EnumCollection.TransactionNature.Debit))
                        {
                            if (chartOfAccount.Acc_Class.AccountNature == td.TransactionNature)
                            {
                                //balance += td.Amount;
                                balance -= td.Amount;
                            }
                            else
                            {
                                //balance -= td.Amount;
                                balance += td.Amount;
                            }
                        }
                        else if (chartOfAccount.Acc_Class.AccountNature == Convert.ToInt32(EnumCollection.TransactionNature.Credit))
                        {
                            if (chartOfAccount.Acc_Class.AccountNature == td.TransactionNature)
                            {
                                //balance += td.Amount;
                                balance -= td.Amount;
                            }
                            else
                            {
                                //balance -= td.Amount;
                                balance += td.Amount;
                            }
                        }
                        //if (td.Acc_ChartOfAccount.Acc_Class.AccountNature == Convert.ToInt32(EnumCollection.TransactionNature.Debit))
                        //{
                        //    if (td.TransactionNature == Convert.ToInt32(EnumCollection.TransactionNature.Debit))
                        //    {
                        //        //balance -= td.Amount;
                        //        balance += td.Amount;
                        //    }
                        //    else
                        //    {
                        //        //balance += td.Amount;
                        //        balance -= td.Amount;
                        //    }
                        //}
                        //else
                        //{
                        //    if (td.TransactionNature == Convert.ToInt32(EnumCollection.TransactionNature.Debit))
                        //    {
                        //        //balance -= td.Amount;
                        //        balance += td.Amount;
                        //    }
                        //    else
                        //    {
                        //        //balance += td.Amount;
                        //        balance -= td.Amount;
                        //    }
                        //}
                    }
                    transactionDetailPreviousBalance.AccountName = ddlAccountName.SelectedItem.ToString();
                    transactionDetailPreviousBalance.AccountName = "Previous Balance";
                    transactionDetailPreviousBalance.Particulars ="Previous Balance before selected date";
                    transactionDetailPreviousBalance.Balance = balance;
                    
                    #endregion
                    transactionDetailListForListView.Add(transactionDetailPreviousBalance);

                    List<Acc_TransactionDetail> transactionDetailListForTotalTransaction = new List<Acc_TransactionDetail>();
                    transactionDetailListForTotalTransaction = transactionDetailList.Where(td => td.Acc_TransactionMaster.TransactionDate.Date >= fromDate && td.Acc_TransactionMaster.TransactionDate.Date <= toDate && (CurrentBranchID <= 0 || (CurrentBranchID > 0 && td.BranchID == CurrentBranchID))).ToList();

                    foreach (Acc_TransactionDetail td in transactionDetailListForTotalTransaction)
                    {
                        Acc_TransactionDetail tdNew = new Acc_TransactionDetail();
                        tdNew = td;
                        if (td.Acc_ChartOfAccount.Acc_Class.AccountNature == Convert.ToInt32(EnumCollection.TransactionNature.Debit))
                        {
                            if (td.TransactionNature == Convert.ToInt32(EnumCollection.TransactionNature.Debit))
                            {
                                //balance -= td.Amount;
                                tdNew.CreditAmount= td.Amount;
                            }
                            else
                            {
                                //balance += td.Amount;
                                tdNew.DebitAmount = td.Amount;
                            }

                            if (chartOfAccount.Acc_Class.AccountNature == td.TransactionNature)
                            {
                                //balance += td.Amount;
                                balance -= td.Amount;
                            }
                            else
                            {
                                //balance -= td.Amount;
                                balance += td.Amount;
                            }
                        }
                        else
                        {
                            if (td.TransactionNature == Convert.ToInt32(EnumCollection.TransactionNature.Debit))
                            {
                                //balance -= td.Amount;
                                tdNew.CreditAmount = td.Amount;
                            }
                            else
                            {
                                //balance += td.Amount;
                                tdNew.DebitAmount= td.Amount;
                            }
                            if (chartOfAccount.Acc_Class.AccountNature == td.TransactionNature)
                            {
                                //balance += td.Amount;
                                balance -= td.Amount;
                            }
                            else
                            {
                                //balance -= td.Amount;
                                balance += td.Amount;
                            }
                        }
                        tdNew.Balance = balance;
                        
                        transactionDetailListForListView.Add(tdNew);
                    }
                    Acc_TransactionDetail transactionDetailCurrentBalance = new Acc_TransactionDetail();
                    transactionDetailCurrentBalance.AccountName = "Current Balance";
                    transactionDetailCurrentBalance.Balance = balance;
                    transactionDetailCurrentBalance.Particulars = "Current Balance for selected date";
                    
                    transactionDetailListForListView.Add(transactionDetailCurrentBalance);

                }
                
                //stockMasterList = stockMasterList.Where(s => (s.Date >= startDate && s.Date <= endDate) && (s.TransactionNo.StartsWith("PU"))).ToList();
                lvLedgerBalance.DataSource = transactionDetailListForListView;
                lvLedgerBalance.DataBind();
            }
        }

        protected void ddlAccountNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlAccountNo.SelectedValue != "")
            {
                ddlAccountName.SelectedValue = ddlAccountNo.SelectedValue;
            }
        }

        protected void ddlAccountName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlAccountNo.SelectedValue != "")
            {
                ddlAccountNo.SelectedValue = ddlAccountName.SelectedValue;
            }
        }

        protected void lvLedgerBalance_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            if (e.Item.ItemType == ListViewItemType.DataItem)
            {
                ListViewDataItem currentItem = (ListViewDataItem)e.Item;
                
                Acc_TransactionDetail transactionDetail = (Acc_TransactionDetail)((ListViewDataItem)(e.Item)).DataItem;
                                
                Label lblTransactionDate = (Label)currentItem.FindControl("lblTransactionDate");
                Label lblVoucherNo = (Label)currentItem.FindControl("lblVoucherNo");
                Label lblAccountName = (Label)currentItem.FindControl("lblAccountName");
                Label lblDescription = (Label)currentItem.FindControl("lblDescription");
                Label lblDebit = (Label)currentItem.FindControl("lblDebit");
                Label lblCredit = (Label)currentItem.FindControl("lblCredit");
                Label lblBalance = (Label)currentItem.FindControl("lblBalance");
                if (transactionDetail.TransactionMasterID > 0)
                {
                    //using (TheFacade _facade = new TheFacade())
                    //{
                    //    Acc_TransactionMaster tm = new Acc_TransactionMaster();
                    //    tm = _facade.AccountsFacade.GetAcc_TransactionMasterByTransactionMasterID(transactionDetail.TransactionMasterID);
                    //    transactionDetail.Acc_TransactionMaster = tm;
                    //    lblTransactionDate.Text = transactionDetail.Acc_TransactionMaster.TransactionDate.ToShortDateString();
                    //}
                    lblTransactionDate.Text = transactionDetail.Acc_TransactionMaster.TransactionDate.ToShortDateString();
                }
                else
                {
                    lblTransactionDate.Text = "--";
                }
                //if (transactionDetail.Acc_TransactionMaster.TransactionDate.ToShortDateString() == "1/1/0001")
                //{
                //    lblTransactionDate.Text = "--";
                //}
                //else
                //{
                //    lblTransactionDate.Text = transactionDetail.Acc_TransactionMaster.TransactionDate.ToShortDateString();
                //}
                if (transactionDetail.Acc_TransactionMaster == null)
                {
                    lblVoucherNo.Text = "--";
                }
                else
                {
                    lblVoucherNo.Text = transactionDetail.Acc_TransactionMaster.JournalCode;
                }
                if (transactionDetail.Acc_ChartOfAccount == null)
                {
                    lblAccountName.Text= transactionDetail.AccountName;
                }
                else
                {
                    lblAccountName.Text = transactionDetail.Acc_ChartOfAccount.Name;
                }
                
                lblDescription.Text = transactionDetail.Particulars;
                
                if (transactionDetail.DebitAmount == 0)
                {
                    lblDebit.Text = "--";
                }
                else
                {
                    lblDebit.Text = transactionDetail.DebitAmount.ToString();
                }
                if (transactionDetail.CreditAmount == 0)
                {
                    lblCredit.Text = "--";
                }
                else
                {
                    lblCredit.Text = transactionDetail.CreditAmount.ToString();
                }

                lblBalance.Text = transactionDetail.Balance.ToString();

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
