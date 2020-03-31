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
    public partial class wucMoneyReceipt : System.Web.UI.UserControl
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
                if (Request.QueryString["paymentID"] != null)
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

                        Payment payment = _facade.TicketSaleFacade.GetPaymentByID(Convert.ToInt64(Request.QueryString["paymentID"].ToString()), Convert.ToInt32(EnumCollection.ReferenceType.Customer));
                        txtParticulars.Text = "Money Received from Mr. " + payment.Customer.Name;

                        lblToFrom.Text = payment.Customer.Name;
                        lblAmount.Text = "Tk. " + payment.PaidAmount.ToString("0.00");
                        lblDate.Text = payment.PaymentDate.ToString("MMMM dd, yyyy");
                        lblVoucherNo.Text = "V. No.: " + payment.PaymentNo;

                        if (payment.PaymentMode == Convert.ToInt32(EnumCollection.TransactionMode.Cheque))
                        {
                            lblPaymentMode.Text = EnumHelper.EnumToString<EnumCollection.TransactionMode>(payment.PaymentMode);
                        }
                        else
                        {
                            lblPaymentMode.Text = EnumHelper.EnumToString<EnumCollection.TransactionMode>(payment.PaymentMode);
                        }
                        ReceiptHistory ph = new ReceiptHistory();

                        DateTime fromDate = DateTime.MinValue;
                        DateTime toDate = DateTime.MinValue;
                        ph = _facade.TicketSaleFacade.GetReceiptHistoryByCustomerID(fromDate, toDate, Convert.ToInt32(EnumCollection.ReferenceType.Customer), payment.Customer.IID,-1);

                        //lblTransactionType.Text = EnumHelper.EnumToString(acc_TransactionMaster.TransactionTypeID);
                        decimal paidAmount = payment.PaidAmount;
                        decimal totalAmount = ph.TotalReceivable - ph.TotalReceived + paidAmount;
                        lblTotalAmount.Text = totalAmount.ToString("0.00");
                        lblPaidAmount.Text = paidAmount.ToString("0.00");
                        lblBalanceDue.Text = ph.TotalDue.ToString("0.00");
                        // Translation number to word
                        string inWord = CommonClass.TranslateNumber(paidAmount);
                        lblTakaInWord.Text = inWord.Substring(0, 1).ToUpper() + inWord.Substring(1).ToLower() + " Only."; // add money unit such as taka or dollar here...
                        //lblBranchName.Text = "Branch :" + Session["BranchName"].ToString();
                    }
                }
            }
        }

    }
}