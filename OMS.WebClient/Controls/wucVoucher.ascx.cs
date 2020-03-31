using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using OMS.Facade;
using OMS.DAL;
using OMS.Framework;
using System.Collections.Generic;

namespace OMS.WebClient.Controls
{
    public partial class wucVoucher : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserID"] == null)
            {
                Session.Abandon();
                Response.Redirect("../Login.aspx?" + "&msgSessionOut=1");
            }
            else
            {
                if (Request.QueryString["transactionMasterID"] != null)
                {
                    using (TheFacade _facade = new TheFacade())
                    {
                        //Company Information
                        CompanyInfo com = new CompanyInfo();
                        com = _facade.CommonFacade.GetCompanyInfoAll().FirstOrDefault();
                        imgLogo.ImageUrl = com.LogoLocation;
                        lblCompany.Text = com.Name;
                        lblAddress.Text = com.Address;
                        lblEmail.Text = "E-mail: " + com.Email;
                        lblPhone.Text = "Phone: " + com.Phone;

                        Acc_TransactionMaster acc_TransactionMaster = _facade.AccountsFacade.GetAcc_TransactionMasterByTransactionMasterID(Convert.ToInt64(Request.QueryString["transactionMasterID"].ToString()));
                        txtParticulars.Text = acc_TransactionMaster.Particulars;
                        lblToFrom.Text = acc_TransactionMaster.ToFrom;
                        lblDate.Text = acc_TransactionMaster.TransactionDate.ToString("dd/MM/yyyy");
                        lblTransactionNo.Text = acc_TransactionMaster.JournalCode;
                        if (acc_TransactionMaster.TransactionTypeID == Convert.ToInt32(EnumCollection.TransactionType.Payment))
                        {
                            lblTransactionType.Text = "Payment Voucher";
                        }
                        else if (acc_TransactionMaster.TransactionTypeID == Convert.ToInt32(EnumCollection.TransactionType.Receive))
                        {
                            lblTransactionType.Text = "Receipt Voucher";
                        }
                        else
                        {
                            lblTransactionType.Text = "Journal Voucher";
                        }
                        //lblTransactionType.Text = EnumHelper.EnumToString(acc_TransactionMaster.TransactionTypeID);
                        List<Acc_TransactionDetail> acc_TransactionDetailList = new List<Acc_TransactionDetail>();
                        if (Request.QueryString["status"] != null)
                        {
                            acc_TransactionDetailList = _facade.AccountsFacade.GetAcc_TransactionDetailListByTransactionMasterID(acc_TransactionMaster.IID, Convert.ToInt32(Request.QueryString["status"].ToString()));
                        }
                        else
                        {
                            acc_TransactionDetailList = _facade.AccountsFacade.GetAcc_TransactionDetailListByTransactionMasterID(acc_TransactionMaster.IID, Convert.ToInt32(EnumCollection.TransactionStatus.NonPosted));
                        }
                        List<Acc_TransactionDetail> acc_TransactionDetailListForAmount = new List<Acc_TransactionDetail>();
                        acc_TransactionDetailListForAmount = acc_TransactionDetailList.Where(td => td.TransactionNature == Convert.ToInt32(EnumCollection.TransactionNature.Debit)).ToList();
                        foreach (Acc_TransactionDetail TDetail in acc_TransactionDetailListForAmount)
                        {
                            amount += TDetail.Amount;
                        }
                        lblTotalAmount.Text = amount.ToString("0.00");

                        // Translation number to word
                        string inWord = CommonClass.TranslateNumber(amount);
                        lblTakaInWord.Text = inWord.Substring(0, 1).ToUpper() + inWord.Substring(1).ToLower() + " Only."; // add money unit such as taka or dollar here...

                        lvTransactionDetail.DataSource = acc_TransactionDetailList;
                        lvTransactionDetail.DataBind();
                    }
                }
            }
        }
        
        decimal amount = 0;
        int slNo = 1;
        protected void lvTransactionDetail_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            ListViewDataItem currentItem = (ListViewDataItem)e.Item;

            Acc_TransactionDetail acc_TransactionDetail = (Acc_TransactionDetail)((ListViewDataItem)(e.Item)).DataItem;

            Label lblSLNo = (Label)currentItem.FindControl("lblSLNo");
            Label lblAccountName = (Label)currentItem.FindControl("lblAccountName");
            Label lblParticular = (Label)currentItem.FindControl("lblParticular");
            Label lblBalance = (Label)currentItem.FindControl("lblBalance");
            Label lblDebit = (Label)currentItem.FindControl("lblDebit");
            Label lblCredit = (Label)currentItem.FindControl("lblCredit");

            lblSLNo.Text = slNo.ToString();
            slNo++;
            if (acc_TransactionDetail.Acc_ChartOfAccount != null)
            {
                lblAccountName.Text = acc_TransactionDetail.Acc_ChartOfAccount.Name + "[" + acc_TransactionDetail.Acc_ChartOfAccount.AccountNo + "]";
            }
            lblParticular.Text = acc_TransactionDetail.Particulars;
            if (acc_TransactionDetail.TransactionNature == Convert.ToInt32(EnumCollection.TransactionNature.Debit))
            {
                lblDebit.Text = acc_TransactionDetail.Amount.ToString("0.00");
                lblCredit.Text = "--";
            }
            else
            {
                lblDebit.Text = "--";
                lblCredit.Text = acc_TransactionDetail.Amount.ToString("0.00");
            }
            //if (acc_TransactionDetail.DebitAmount == 0)
            //{
            //    lblDebit.Text = "--";
            //}
            //else
            //{
            //    lblDebit.Text = acc_TransactionDetail.DebitAmount.ToString();
            //}
            //if (acc_TransactionDetail.CreditAmount == 0)
            //{
            //    lblCredit.Text = "--";
            //}
            //else
            //{
            //    lblCredit.Text = acc_TransactionDetail.CreditAmount.ToString();
            //}
        }
    }
}
