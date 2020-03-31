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
using OMS.Web.Helpers;
using OMS.Framework;
using OMS.Facade;
using System.Collections.Generic;
using OMS.DAL;

namespace OMS.WebClient.Controls
{
    public partial class wucCustomerReceivable : System.Web.UI.UserControl
    {
        public long CurrentTicketSaleID
        {
            get
            {
                if (ViewState["TicketSaleID"] == null)
                {
                    return -1;
                }
                else
                {
                    return Convert.ToInt64(ViewState["TicketSaleID"]);
                }
            }
            set { ViewState["TicketSaleID"] = value; }
        }
       
        public long CurrentRefID
        {
            get
            {
                if (ViewState["RefID"] == null)
                {
                    return -1;
                }
                else
                {
                    return Convert.ToInt64(ViewState["RefID"]);
                }
            }
            set { ViewState["RefID"] = value; }
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
                    string paymentNo = string.Empty;
                    //DateTime fromDate = Convert.ToDateTime(DateTime.Now.ToShortDateString() + " 12:00:00 AM");
                    //DateTime toDate = Convert.ToDateTime(DateTime.Now.ToShortDateString() + " 11:59:59 PM");
                    DateTime fromDate = DateTime.MinValue;
                    DateTime toDate = DateTime.MinValue;
                    LoadPaymentListView(paymentNo, fromDate, toDate);

                    dvChequeReceipt.Visible = false;
                    dvChequeDate.Visible = false;
                    dvChequePayment.Visible = false;
                    LoadDDL();
                }
            }
        }

        private void LoadDDL()
        {
            LoadPaymentMode();
            LoadBankDDL();
            LoadCustomer();

        }

        private void LoadCustomer()
        {
            List<Customer> customerList = new List<Customer>();
            using (TheFacade _facade = new TheFacade())
            {
                customerList = _facade.CustomerFacade.GetCustomerAll().Where(ts => (CurrentBranchID <= 0 || (CurrentBranchID > 0 && ts.BranchID == CurrentBranchID))).ToList(); 
            }
            DDLHelper.Bind<Customer>(ddlCustomer, customerList, "Name", "IID", EnumCollection.ListItemType.CustomerName);
            
        }

        private void LoadBankDDL()
        {
            using (TheFacade facade = new TheFacade())
            {
                List<Acc_Bank> bankList = facade.AccountsFacade.GetBankAll();
                bankList = bankList.Where(b => (CurrentBranchID <= 0 || (CurrentBranchID > 0 && b.BranchID == CurrentBranchID))).ToList();
                DDLHelper.Bind<Acc_Bank>(ddlBank, bankList, "Name", "IID", EnumCollection.ListItemType.Bank, true);
                
                List<Acc_BankBranch> branchList = facade.AccountsFacade.GetBranchAll();
                branchList = branchList.Where(b => (CurrentBranchID <= 0 || (CurrentBranchID > 0 && b.BranchID == CurrentBranchID))).ToList();
                DDLHelper.Bind<Acc_BankBranch>(ddlBranch, branchList, "Name", "IID", EnumCollection.ListItemType.Select, true);
                
                List<Acc_BankAccount> bankAccList = facade.AccountsFacade.GetBankAccountAll();
                bankAccList.Where(b => (CurrentBranchID <= 0 || (CurrentBranchID > 0 && b.BranchID == CurrentBranchID))).ToList();
                DDLHelper.Bind<Acc_BankAccount>(ddlAccountName, bankAccList, "Name", "IID", EnumCollection.ListItemType.Select, true);                
            }
        }       

        private void LoadPaymentMode()
        {
            DDLHelper.Bind(ddlReceivableMode, EnumHelper.EnumToList<EnumCollection.TransactionMode>(), EnumCollection.ListItemType.TransactionMode);
            ddlReceivableMode.SelectedIndex = -1;
            //ddlTransactionMode.Enabled = false;

        }

        private void LoadPaymentListView(string paymentNo, DateTime fromDate, DateTime toDate)
        {
            List<Payment> list = new List<Payment>();

            //if(!string.IsNullOrEmpty(txtStartDate.Text))
            //    fromDate = Convert.ToDateTime(DateTime.Now.ToShortDateString() + " 12:00:00 AM");
            //if(!string.IsNullOrEmpty(txtEndDate.Text))
            //    toDate = Convert.ToDateTime(DateTime.Now.ToShortDateString() + " 11:59:59 PM");

            using (TheFacade _facade = new TheFacade())
            {
                list = _facade.TicketSaleFacade.GetPaymentBySearchParam(string.Empty, string.Empty, fromDate, toDate, Convert.ToInt32(EnumCollection.ReferenceType.Customer), 0, CurrentBranchID);
            }

            lvReceivable.DataSource = list.OrderByDescending(p => p.PaymentDate).ToList();
            lvReceivable.DataBind();
        }

        protected void btnShow_Click(object sender, EventArgs e)
        {
            int branchID = 0;
            if (Session["RoleID"].ToString() == "1")//admin
            {
                branchID = -1;
                LoadListView(branchID);
            }
            else
            {
                branchID = Convert.ToInt32(Session["BranchID"]);
                LoadListView(branchID);
            }
        }

        private void LoadListView(int branchID)
        {
            ReceiptHistory ph = new ReceiptHistory();

            DateTime fromDate = DateTime.MinValue;
            DateTime toDate = DateTime.MinValue;
            //if (!string.IsNullOrEmpty(txtStartDate.Text))
            //    fromDate = Convert.ToDateTime(txtStartDate.Text + " 12:00:00 AM");
            //if (!string.IsNullOrEmpty(txtEndDate.Text))
            //    toDate = Convert.ToDateTime(txtEndDate.Text + " 11:59:59 PM");

            using (TheFacade _facade = new TheFacade())
            {
                ph = _facade.TicketSaleFacade.GetReceiptHistoryByCustomerID(fromDate, toDate, Convert.ToInt32(EnumCollection.ReferenceType.Customer), Convert.ToInt64(ddlCustomer.SelectedValue), branchID);
            }
            if (ph != null)
            {
                txtTotalReceivableAmount.Text = ph.TotalReceivable.ToString();
                txtTotalReceivedAmount.Text = ph.TotalReceived.ToString();
                txtTotalDueAmount.Text = ph.TotalDue.ToString();
                txtReceiveAmount.Text = ph.TotalDue.ToString();
                txtDue.Text = "0.00";
            }
            //List<TicketSale> list = new List<TicketSale>();

            //DateTime fromDate = DateTime.MinValue;
            //DateTime toDate = DateTime.MinValue;
            //if (!string.IsNullOrEmpty(txtStartDate.Text))
            //    fromDate = Convert.ToDateTime(txtStartDate.Text + " 12:00:00 AM");
            //if (!string.IsNullOrEmpty(txtEndDate.Text))
            //    toDate = Convert.ToDateTime(txtEndDate.Text + " 11:59:59 PM");
            //using (TheFacade _facade = new TheFacade())
            //{
            //    //list = _facade.TicketSaleFacade.GetTicketSaleBySearchParam(txtTransactionNo.Text, fromDate, toDate,Convert.ToInt32(EnumCollection.ReferenceType.Customer));
            //    list = _facade.TicketSaleFacade.GetTicketSaleBySearchParam(txtTransactionNo.Text, fromDate, toDate);
            //}
            ////list = list.Where(ts => ts.TransactionNo.Contains(txtTransactionNo.Text)  && ts.TransactionDate.Date >= fromDate && ts.TransactionDate.Date <= toDate).ToList();
            //lvTicketSale.DataSource = list.OrderByDescending(ts => ts.TransactionDate).ToList();
            //lvTicketSale.DataBind();
        }

        protected void lvTicketSale_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            if (e.Item.ItemType == ListViewItemType.DataItem)
            {
                ListViewDataItem item = (ListViewDataItem)e.Item;

                Label lblDate = (Label)item.FindControl("lblDate");
                LinkButton lnkbtnTransactionNo = (LinkButton)item.FindControl("lnkbtnTransactionNo");
                Label lblAirlinesName = (Label)item.FindControl("lblAirlinesName");
                Label lblCustomerName = (Label)item.FindControl("lblCustomerName");
                Label lblTicketPrice = (Label)item.FindControl("lblTicketPrice");
                Label lblTAXAmount = (Label)item.FindControl("lblTAXAmount");
                
                Label lblCustomerReceivable = (Label)item.FindControl("lblCustomerReceivable");
                Label lblCustomerDue = (Label)item.FindControl("lblCustomerDue");
                Label lblReceivableDate = (Label)item.FindControl("lblReceivableDate");
                TicketSale ticketSale = (TicketSale)((ListViewDataItem)(e.Item)).DataItem;
                //LinkButton lnkbtnTransactionNo = (LinkButton)item.FindControl("lnkbtnTransactionNo");

                lblDate.Text = ticketSale.TransactionDate.ToShortDateString();                
                lblCustomerName.Text = ticketSale.Customer.Name;
                lblAirlinesName.Text = ticketSale.Supplier.Name;
                //using (TheFacade _facade = new TheFacade())
                //{
                //    Customer customer = new Customer();
                //    customer = _facade.CustomerFacade.GetCustomerByID(ticketSale.ReferenceID);
                //    if (customer != null)
                //        lblCustomerName.Text = customer.Name;
                //}

                lblTicketPrice.Text = ticketSale.TicketPriceInTaka.ToString();
                lblTAXAmount.Text = ticketSale.TAX.ToString();
                lblCustomerReceivable.Text = ticketSale.CustomerReceivable.ToString();
                lblCustomerDue.Text = ticketSale.CustomerDue.ToString();
                if (ticketSale.CustomerReceivableDate != null)
                {
                    string date = ticketSale.CustomerReceivableDate.ToString();
                    lblReceivableDate.Text = Convert.ToDateTime(date).ToShortDateString();
                }
                lnkbtnTransactionNo.Text = ticketSale.TransactionNo;
                lnkbtnTransactionNo.CommandArgument = ticketSale.IID.ToString();
                lnkbtnTransactionNo.CommandName = "DoEdit";

            }
        }

        protected void lvTicketSale_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            if (e.CommandName == "DoEdit")
            {

                using (TheFacade _facade = new TheFacade())
                {
                    TicketSale ticketSale = new TicketSale();

                    ticketSale = _facade.TicketSaleFacade.GetTicketSaleByID(Convert.ToInt64(e.CommandArgument.ToString()));
                    CurrentTicketSaleID = ticketSale.IID;
                    //CurrentCustomerID = ticketSale.CustomerID;
                    CurrentRefID = ticketSale.CustomerID;
                    FillTicketSale(ticketSale);
                }
            }

         
        }

        private void FillTicketSale(TicketSale ticketSale)
        {
            //txtTransactionNo2.Text = ticketSale.TransactionNo;
            //txtReceivableAmount.Text = ticketSale.CustomerReceivable.ToString();

            //List<Payment> list = new List<Payment>();
            //decimal paidAmount = 0;
            //using (TheFacade _facade = new TheFacade())
            //{
            //    list = _facade.TicketSaleFacade.GetPaymentListByTicketSaleID(ticketSale.IID, Convert.ToInt32(EnumCollection.ReferenceType.Customer));
            //    if (list.Count > 0)
            //    {
            //        foreach (Payment payment in list)
            //        {
            //            paidAmount += payment.PaidAmount;
            //        }
            //    }
            //}

            //if (paidAmount > 0)
            //    txtReceivedAmount.Text = paidAmount.ToString();
            //else
            //    txtReceivedAmount.Text = string.Empty;

            //txtReceiveAmount.Text = (ticketSale.CustomerReceivable- paidAmount).ToString();
            //txtDue.Text = "0.00";
            //decimal payable = Convert.ToDecimal(txtReceivableAmount.Text);

            ////decimal paid = 0;
            ////if (!string.IsNullOrEmpty(txtPaidAmount.Text))
            ////    paid = Convert.ToDecimal(txtPaidAmount.Text);

            //if (payable == paidAmount)
            //{
            //    btnPay.Enabled = false;
            //    lblMSGReceivableStatus.Text = "Payment Done!";
            //}
            //else
            //{
            //    btnPay.Enabled = true;
            //    lblMSGReceivableStatus.Text = string.Empty;
            //}


        }

        protected void btnPay_Click(object sender, EventArgs e)
        {
            if (Session["UserID"] != null)
            {
                Payment payment = new Payment();
                payment = LoadPayment(payment);
                Acc_TransactionMaster master = new Acc_TransactionMaster();
                using (TheFacade _facade = new TheFacade())
                {
                    _facade.Insert<Payment>(payment);

                    //Accounts Payable
                    //TicketSale ticketSale = new TicketSale();
                    //ticketSale = _facade.TicketSaleFacade.GetTicketSaleByID(payment.TicketSaleID);

                    
                    master = LoadTransactionMaster(master, payment, ddlCustomer.SelectedItem.Text, Convert.ToInt32(EnumCollection.TransactionType.Receive));
                    _facade.Insert<Acc_TransactionMaster>(master);

                    Acc_ChartOfAccount coaRef = _facade.AccountsFacade.GetChartOfAccountByName(ddlCustomer.SelectedItem.Text);
                    Acc_TransactionDetail details = new Acc_TransactionDetail();
                    decimal amount = payment.PaidAmount;
                    details = LoadTransactionDetails(details, master, coaRef, amount, Convert.ToInt32(EnumCollection.TransactionNature.Credit));
                    _facade.Insert<Acc_TransactionDetail>(details);

                    if (payment.PaymentMode == Convert.ToInt32(EnumCollection.TransactionMode.Cheque))
                    {
                        coaRef = _facade.AccountsFacade.GetChartOfAccountByName(ddlAccountName.Text);
                        details = new Acc_TransactionDetail();
                        amount = payment.PaidAmount;
                        details = LoadTransactionDetails(details, master, coaRef, amount, Convert.ToInt32(EnumCollection.TransactionNature.Debit));
                        _facade.Insert<Acc_TransactionDetail>(details);


                        //Bank Transaction
                        Acc_BankTransaction bankTransaction = new Acc_BankTransaction();
                        bankTransaction = LoadBankTransaction(bankTransaction, master.IID, amount);

                        //bankTransaction.ChequeLeafID = Convert.ToInt64(ddlChequeLeaf.SelectedValue);
                        _facade.Insert<Acc_BankTransaction>(bankTransaction);
                    }
                    else
                    {
                        coaRef = _facade.AccountsFacade.GetChartOfAccountByName("Cash In Hand");
                        details = new Acc_TransactionDetail();
                        amount = payment.PaidAmount;
                        details = LoadTransactionDetails(details, master, coaRef, amount, Convert.ToInt32(EnumCollection.TransactionNature.Debit));
                        _facade.Insert<Acc_TransactionDetail>(details);
                    }
                }
                Session["IsSaved"] = true;
                //ListView
                string paymentNo = string.Empty;
                DateTime fromDate = DateTime.MinValue;
                DateTime toDate = DateTime.MinValue;
                LoadPaymentListView(paymentNo, fromDate, toDate);
                //ListView
                ClearControl();
                string data = string.Format("<script language=javascript>window.open('rptVoucher.aspx?{0}{1}','PrintMe','height=600px,width=800px,scrollbars=1');</script>", "transactionMasterID=" + master.IID.ToString(), "&status=" + Convert.ToInt32(EnumCollection.TransactionStatus.Posted));
                Page.ClientScript.RegisterStartupScript(this.GetType(), "onclick", data);
                //string data = string.Format("<script language=javascript>window.open('rptReceipt.aspx?{0}','PrintMe','height=600px,width=800px,scrollbars=1');</script>", "receiptID=" + payment.IID.ToString());
                //Page.ClientScript.RegisterStartupScript(this.GetType(), "onclick", data);
                //Response.Redirect("~/UITicketSale/CustomerReceivableView.aspx");
            }
            else
            {
                //OMS.callforLogout();
                FormsAuthentication.SignOut();
                Roles.DeleteCookie();
                Session.Abandon();
                Response.Redirect("~/login.aspx");
            }
            //DateTime fromDate = Convert.ToDateTime(DateTime.Now.ToShortDateString() + " 12:00:00 AM");
            //DateTime toDate = Convert.ToDateTime(DateTime.Now.ToShortDateString() + " 11:59:59 PM");
            //LoadPaymentListView(string.Empty, fromDate, toDate);
        }
        private void ClearControl()
        {
            ddlCustomer.SelectedValue = "-1";
            ddlAccountName.SelectedValue = "-1";
            txtReceiptDate.Text = string.Empty;
            txtTotalReceivableAmount.Text = string.Empty;
            txtTotalReceivedAmount.Text = string.Empty;
            txtTotalDueAmount.Text = string.Empty;
            txtReceiveAmount.Text = string.Empty;
            txtDue.Text = string.Empty;
            txtNextReceivableDate.Text = string.Empty;
            ddlReceivableMode.SelectedValue = "-1";
            dvChequeDate.Visible = false;
            dvChequePayment.Visible = false;
        }
        private Acc_TransactionDetail LoadTransactionDetails(Acc_TransactionDetail details, Acc_TransactionMaster master, Acc_ChartOfAccount coaRef, decimal amount, int accNature)
        {
            details.TransactionMasterID = master.IID;
            details.AccountID = coaRef.IID;
            details.Amount = amount;
            details.TransactionNature = accNature;

            details.Particulars = "Ticket Sale";
            if (details.IID <= 0)
            {
                details.CreateBy = Convert.ToInt64(Session["UserID"]);
                details.CreateDate = DateTime.Now;
            }
            details.UpdateBy = Convert.ToInt64(Session["UserID"]);
            details.UpdateDate = DateTime.Now;
            details.IsRemoved = 0;
            details.BranchID = Convert.ToInt32(Session["BranchID"]);
            return details;
        }

        private Acc_TransactionMaster LoadTransactionMaster(Acc_TransactionMaster master, Payment payment, string name, int referenceType)
        {

            string time = Convert.ToString(DateTime.Now.TimeOfDay);
            master.TransactionDate = Convert.ToDateTime(txtReceiptDate.Text + " " + time);

            master.PayReason = "Ticket Sale";
            master.ReferenceType = referenceType;
            master.ReferenceID = Convert.ToInt64(payment.ReferenceID);
            if (master.ReferenceType == Convert.ToInt32(EnumCollection.ReferenceType.Customer))
            {                
                master.Particulars = "Ticket Sale receivable from " + name;
            }
            else if (master.ReferenceType == Convert.ToInt32(EnumCollection.ReferenceType.Supplier))
            {
                master.Particulars = "Ticket Sale payment to " + name;
            }
            else
            {
                master.ReferenceID = -1;
            }
            master.TransactionReference = string.Empty;
            master.Status = Convert.ToInt32(EnumCollection.TransactionStatus.Posted);
            master.ToFrom = string.Empty;
            master.ToFromAddress = string.Empty;
            master.ToFromName = string.Empty;
            master.TransactionModeID = Convert.ToInt32(EnumCollection.TransactionMode.Cash);
            master.TransactionReference = "N/A";
            master.TransactionTypeID = referenceType;
            master.UpdateBy = Convert.ToInt64(Session["UserID"]);
            master.UpdateDate = DateTime.Now;
            if (master.IID <= 0)
            {
                master.JournalCode = payment.PaymentNo;
                master.CreateBy = Convert.ToInt64(Session["UserID"]);
                master.CreateDate = DateTime.Now;
            }
            master.IsRemoved = 0;

            master.BranchID = Convert.ToInt32(Session["BranchID"]);
            return master;
        }

        private Acc_BankTransaction LoadBankTransaction(Acc_BankTransaction bankTransaction, long transactionMasterID, decimal amount)
        {
            bankTransaction.TransactionMasterID = transactionMasterID;
            bankTransaction.ReferenceType = Convert.ToInt32(EnumCollection.TransactionType.Payment);
            bankTransaction.Amount = amount;
            if (bankTransaction.IID <= 0)
            {
                bankTransaction.CreateBy = Convert.ToInt64(Session["UserID"]);
                bankTransaction.CreateDate = DateTime.Now;
            }
            bankTransaction.UpdateBy = Convert.ToInt64(Session["UserID"]);
            bankTransaction.UpdateDate = DateTime.Now;
            bankTransaction.IsRemoved = 0;
            bankTransaction.ChequeDate = Convert.ToDateTime(txtChequeDate.Text);
            bankTransaction.BranchID = Convert.ToInt32(Session["BranchID"]);
            return bankTransaction;
        }


        private Payment LoadPayment(Payment payment)
        {

            payment.BranchID = Convert.ToInt32(Session["BranchID"].ToString());
            payment.ReferenceTypeID = Convert.ToInt32(EnumCollection.ReferenceType.Customer);
            payment.ReferenceID = Convert.ToInt64(ddlCustomer.SelectedValue); 
            //payment.TicketSaleID = CurrentTicketSaleID;
            payment.PaymentNo = GetLastPaymentNo();
            payment.ReferenceBillNo = string.Empty;
            payment.PaymentMode = Convert.ToInt32(ddlReceivableMode.SelectedValue);
            payment.TotalDueAmount = Convert.ToDecimal(txtTotalReceivableAmount.Text) - Convert.ToDecimal(txtTotalReceivedAmount.Text) - Convert.ToDecimal(txtReceiveAmount.Text);
            payment.PaidAmount = Convert.ToDecimal(txtReceiveAmount.Text);
            payment.LastDueAmount = Convert.ToDecimal(txtDue.Text);
            //payment.PaymentDate = Convert.ToDateTime(txtPaymentDate.Text) + DateTime.Now.TimeOfDay;
            payment.PaymentDate = Convert.ToDateTime(txtReceiptDate.Text);
            
            if (!string.IsNullOrEmpty(txtNextReceivableDate.Text))
                payment.NextPaymentDate = Convert.ToDateTime(txtNextReceivableDate.Text);
            
            payment.Status = 1;
            payment.CreateBy = Convert.ToInt64(Session["UserID"]);
            payment.CreateDate = DateTime.Now;
            payment.UpdateBy = Convert.ToInt64(Session["UserID"]);
            payment.UpdateDate = DateTime.Now;
            payment.IsRemoved = 0;
            return payment;
        }

        private string GetLastPaymentNo()
        {
            string newCode = "RN";

            //Last Order
            List<Payment> paymentList = new List<Payment>();
            using (TheFacade _facade = new TheFacade())
            {
                paymentList = _facade.TicketSaleFacade.GetPaymentAll();
            }
            //DateTime startDate = Convert.ToDateTime(DateTime.Now.ToShortDateString() + " 12:00:00 AM");
            //DateTime endDate = Convert.ToDateTime(DateTime.Now.ToShortDateString() + " 11:59:59 PM");
            DateTime startDate = Convert.ToDateTime("01/" + DateTime.Now.Month.ToString()+"/" + DateTime.Now.Year.ToString() + " 12:00:00 AM");
            DateTime endDate = Convert.ToDateTime(DateTime.Now.ToShortDateString() + " 11:59:59 PM");
            paymentList = paymentList.Where(ts => (ts.PaymentDate >= startDate && ts.PaymentDate <= endDate) && (ts.PaymentNo.StartsWith("RN"))).ToList();

            int count = paymentList.Count;
            int lastnumber = 0;

            if (count != 0)
            {
                string TrLastCode = paymentList.LastOrDefault().PaymentNo;
                lastnumber = int.Parse(TrLastCode.Substring(6));
            }
            newCode += DateTime.Now.Year.ToString().Substring(2);
            if (DateTime.Now.Month < 10)
            {
                newCode += "0" + DateTime.Now.Month.ToString();
            }
            else
                newCode += DateTime.Now.Month.ToString();
            //if (DateTime.Now.Day < 10)
            //{
            //    newCode += "0" + DateTime.Now.Day.ToString();
            //}
            //else
            //    newCode += DateTime.Now.Day.ToString();

            if (lastnumber == 9999 || count == 0)
                newCode += "9001";
            else
                newCode += (lastnumber + 1).ToString();
            //JCode = newCode;
            return newCode;
        }

        protected void txtReceiveAmount_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtReceiveAmount.Text))
            {
                decimal paidAmount = 0;
                if (!string.IsNullOrEmpty(txtTotalReceivedAmount.Text))
                    paidAmount = Convert.ToDecimal(txtTotalReceivedAmount.Text);
                txtDue.Text = (Convert.ToDecimal(txtTotalReceivableAmount.Text) - Convert.ToDecimal(txtReceiveAmount.Text) - paidAmount).ToString();
            }
            else
                txtDue.Text = Convert.ToDecimal(txtTotalReceivableAmount.Text).ToString();
        }

        protected void lvReceivable_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            if (e.Item.ItemType == ListViewItemType.DataItem)
            {
                ListViewDataItem item = (ListViewDataItem)e.Item;

                Label lblDate = (Label)item.FindControl("lblDate");
                LinkButton lnkbtnPaymentNo = (LinkButton)item.FindControl("lnkbtnPaymentNo");                
                Label lblCustomerName = (Label)item.FindControl("lblCustomerName");
                Label lblReceivedAmount = (Label)item.FindControl("lblReceivedAmount");
                Label lblDueAmount = (Label)item.FindControl("lblDueAmount");                
                Label lblNextReceivableDate = (Label)item.FindControl("lblNextReceivableDate");
                Payment payment = (Payment)((ListViewDataItem)(e.Item)).DataItem;
                LinkButton lnkbtnMoneyReceipt= (LinkButton)item.FindControl("lnkbtnMoneyReceipt");

                lblDate.Text = payment.PaymentDate.ToShortDateString();
                //lblTransactionNo.Text = payment.TicketSale.TransactionNo;
                lblCustomerName.Text = payment.Customer.Name;
                //lblTicketPrice.Text = payment.TicketSale.TicketPriceInTaka.ToString();
                //lblAirlinesPayable.Text = payment.TicketSale.AirlinesPayable.ToString();
                lblReceivedAmount.Text = payment.PaidAmount.ToString();
                lblDueAmount.Text = payment.LastDueAmount.ToString();
                if (payment.NextPaymentDate == null)
                    lblNextReceivableDate.Text = string.Empty;
                else
                {
                    string date = payment.NextPaymentDate.ToString();
                    lblNextReceivableDate.Text = Convert.ToDateTime(date).ToShortDateString();
                }
                lnkbtnPaymentNo.Text = payment.PaymentNo;
                lnkbtnPaymentNo.CommandArgument = payment.TransactionMasterID.ToString();
                lnkbtnPaymentNo.CommandName = "ShowVoucher";

                lnkbtnMoneyReceipt.Text = "Money Receipt";
                lnkbtnMoneyReceipt.CommandArgument = payment.IID.ToString();
                lnkbtnMoneyReceipt.CommandName = "ShowMoneyReceipt";

            }
        }

        protected void lvReceivable_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            //if (e.CommandName == "DoEdit")
            //{

            //    using (TheFacade _facade = new TheFacade())
            //    {
            //        Payment payment = new Payment();

            //        payment = _facade.TicketSaleFacade.GetPaymentByID(Convert.ToInt64(e.CommandArgument.ToString()));
            //        CurrentTicketSaleID = payment.IID;
            //        FillPayment(payment);
            //    }
            //}
            if (e.CommandName == "ShowVoucher")
            {
                Acc_TransactionMaster acc_TransactionMaster = new Acc_TransactionMaster();
                Int64 transactionMasterID = Convert.ToInt64(e.CommandArgument);
                if (transactionMasterID > 0)
                {
                    using (TheFacade _facade = new TheFacade())
                    {
                        acc_TransactionMaster = _facade.AccountsFacade.GetAcc_TransactionMasterByTransactionMasterID(transactionMasterID);
                        if (acc_TransactionMaster.IID > 0) // && Convert.ToInt32(ddlTransactionStatus.SelectedValue)>0)
                        {
                            string data = string.Format("<script language=javascript>window.open('rptVoucher.aspx?{0}{1}','PrintMe','height=600px,width=800px,scrollbars=1');</script>", "transactionMasterID=" + acc_TransactionMaster.IID.ToString(), "&status=" + Convert.ToInt32(EnumCollection.TransactionStatus.Posted));
                            Page.ClientScript.RegisterStartupScript(this.GetType(), "onclick", data);
                        }
                    }
                }
            }
            if (e.CommandName == "ShowMoneyReceipt")
            {
                Payment payment = new Payment();
                Int64 paymentID = Convert.ToInt64(e.CommandArgument);
                if (paymentID > 0)
                {
                    using (TheFacade _facade = new TheFacade())
                    {
                        payment= _facade.TicketSaleFacade.GetPaymentByID(paymentID, Convert.ToInt32(EnumCollection.ReferenceType.Customer));
                        if (payment.IID > 0) // && Convert.ToInt32(ddlTransactionStatus.SelectedValue)>0)
                        {
                            string data = string.Format("<script language=javascript>window.open('rptMoneyReceipt.aspx?{0}','PrintMe','height=600px,width=800px,scrollbars=1');</script>", "paymentID=" + payment.IID.ToString());
                            Page.ClientScript.RegisterStartupScript(this.GetType(), "onclick", data);
                        }
                    }
                }
            }
        }

        private void FillPayment(Payment payment)
        {

        }
                
        protected void ddlReceivableMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlReceivableMode.SelectedValue != "")
            {
                int mode = Convert.ToInt32(ddlReceivableMode.SelectedValue);
                if (mode == Convert.ToInt32(EnumCollection.TransactionMode.Cheque))
                {
                    switch (mode)
                    {
                        case 2:
                            dvChequeReceipt.Visible = true;
                            dvChequeDate.Visible = true;
                            dvChequePayment.Visible = true;
                            break;
                        default:
                            dvChequeReceipt.Visible = false;
                            dvChequeDate.Visible = false;
                            dvChequePayment.Visible = false;
                            break;
                    }
                }
                else
                {
                    switch (mode)
                    {
                        case 2:
                            dvChequeReceipt.Visible = false;
                            dvChequeDate.Visible = true;
                            dvChequePayment.Visible = false;
                            break;
                        default:
                            dvChequeReceipt.Visible = false;
                            dvChequeDate.Visible = false;
                            dvChequePayment.Visible = false;
                            break;
                    }
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
    }
}