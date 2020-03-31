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
using OMS.Web.Helpers;
using OMS.Facade;
using System.Collections.Generic;
using OMS.Framework;
using OMS.DAL;

namespace OMS.WebClient.UITicketSale
{
    public partial class TicketSaleView : System.Web.UI.Page
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

        public long CurrentTicketSaleDetailID
        {
            get
            {
                if (ViewState["CurrentTicketSaleDetailID"] == null)
                {
                    return -1;
                }
                else
                {
                    return Convert.ToInt64(ViewState["CurrentTicketSaleDetailID"]);
                }
            }
            set { ViewState["CurrentTicketSaleDetailID"] = value; }
        }

        public long CurrentPaymentID
        {
            get
            {
                if (ViewState["CurrentPaymentID"] == null)
                {
                    return -1;
                }
                else
                {
                    return Convert.ToInt64(ViewState["CurrentPaymentID"]);
                }
            }
            set { ViewState["CurrentPaymentID"] = value; }
        }

        public string CurrentTicketNo
        {
            get
            {
                if (ViewState["CurrentTicketNo"] == null)
                    return string.Empty;
                else
                    return ViewState["CurrentTicketNo"].ToString();
            }
            set
            {
                ViewState["CurrentTicketNo"] = value;
            }
        }

        public int CurrentAirlinesTypeID
        {
            get
            {
                if (ViewState["AirlinesTypeID"] == null)
                {
                    return -1;
                }
                else
                {
                    return Convert.ToInt32(ViewState["AirlinesTypeID"]);
                }
            }
            set { ViewState["AirlinesTypeID"] = value; }
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
                    //AccessHelper helper = new AccessHelper();
                    //bool hasAccess = helper.HasAccess(Convert.ToInt64(Session["UserID"].ToString()), Convert.ToInt64(Session["RoleID"].ToString()), Convert.ToBoolean(Session["IsRoleBased"].ToString()), this.Page.Title.ToString());
                    //if (!hasAccess)
                    //{
                    //    Response.Redirect("~/NoPermission.aspx");
                    //}

                    LoadDDL();
                    LoadListView();
                    divNonIATA.Visible = false;
                    if (Session["IsSaved"] != null)
                    {
                        if (Convert.ToBoolean(Session["IsSaved"]) == true)
                        {

                            ShowMsg("Data successfully saved...");
                            if (Request.QueryString["ticketSaleID"] != null)
                            {
                                long ticketSaleID = Convert.ToInt64(Request.QueryString["ticketSaleID"]);
                                string data = string.Format("<script language=javascript>window.open('rptInvoice.aspx?{0}','PrintMe','height=600px,width=800px,scrollbars=1');</script>", "ticketSaleID=" + ticketSaleID.ToString());
                                Page.ClientScript.RegisterStartupScript(this.GetType(), "onclick", data);
                            }
                        }
                        else
                        {
                            ShowMsg("Data not saved...");
                        }
                    }
                }
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
            List<TicketSale> list = new List<TicketSale>();
            using (TheFacade _facade = new TheFacade())
            {
                list = _facade.TicketSaleFacade.GetTicketSaleAll();
            }
            list = list.Where(ts => (CurrentBranchID <= 0 || (CurrentBranchID > 0 && ts.BranchID == CurrentBranchID))).ToList();
            lvTicketSale.DataSource = list.OrderByDescending(ts => ts.TransactionDate).ToList();
            lvTicketSale.DataBind();
        }

        //private void ShowMsg(string msg)
        //{
        //    lblMsg.Text = msg;
        //    lblMsg.Visible = true;
        //    Session["IsSaved"] = null;
        //}

        private void LoadDDL()
        {
            List<HRM_Employee> employeeList = new List<HRM_Employee>();
            List<Country> countryList = new List<Country>();
            List<Customer> customerList = new List<Customer>();
            List<Supplier> supplierList = new List<Supplier>();
            List<TicketClass> ticketClassList = new List<TicketClass>();
            using (TheFacade _facade = new TheFacade())
            {
                countryList = _facade.CommonFacade.GetCountryAll();
                customerList = _facade.CustomerFacade.GetCustomerAll().Where(ts => (CurrentBranchID <= 0 || (CurrentBranchID > 0 && ts.BranchID == CurrentBranchID))).ToList();
                supplierList = _facade.SupplierFacade.GetSupplierAll().Where(s=>s.SupplierType == Convert.ToInt32(EnumCollection.SupplierType.Airlines)).ToList();
                employeeList = _facade.EmployeeFacade.GetEmployeeAll();
                ticketClassList = _facade.TicketSaleFacade.GetTicketClassAll();
            }
            DDLHelper.Bind<Country>(ddlCountry, countryList, "Name", "IID", EnumCollection.ListItemType.Country);
            DDLHelper.Bind<Customer>(ddlCustomer, customerList, "Name", "IID", EnumCollection.ListItemType.CustomerName);
            DDLHelper.Bind<Supplier>(ddlAirlines, supplierList, "Name", "IID", EnumCollection.ListItemType.SupplierName);
            DDLHelper.Bind<HRM_Employee>(ddlSalesPerson, employeeList, "DisplayName", "IID", EnumCollection.ListItemType.EmployeeName);
            DDLHelper.Bind<TicketClass>(ddlTicketClass, ticketClassList, "Name", "IID", EnumCollection.ListItemType.Select);           
              
        }
        
        protected void rbPercentageCommission_CheckedChanged(object sender, EventArgs e)
        {
            //if (rbAmountCommission.Checked)
            //{
 
            //}
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (Session["BranchID"] != null)
            {
                TicketSale ticketSale = new TicketSale();
                AirlinesCommission airlinesCommission = new AirlinesCommission();
                Payment payment = new Payment();
                Acc_TransactionMaster master = new Acc_TransactionMaster();
                Acc_TransactionDetail details = new Acc_TransactionDetail();
                Acc_ChartOfAccount coaRef = new Acc_ChartOfAccount();
                try
                {
                    using (TheFacade facade = new TheFacade())
                    {
                        TicketSaleTotal ticketSaleTotal = GetTicketSaleTotal();
                        if (CurrentAirlinesTypeID == Convert.ToInt32(EnumCollection.AirlinesType.IATA))
                        {
                            airlinesCommission = facade.TicketSaleFacade.GetAirlinesCommission(Convert.ToInt64(ddlAirlines.SelectedValue), Convert.ToInt32(ddlTicketClass.SelectedValue));
                            if (airlinesCommission == null)
                            {
                                lblMsg.Text = "Please Fixed the Airline Commission!!!";
                                return;
                            }
                        }
                        if (CurrentTicketSaleID <= 0)
                        {
                            if (CurrentAirlinesTypeID == Convert.ToInt32(EnumCollection.AirlinesType.IATA))
                            {
                                ticketSale = LoadTicketSale(ticketSale, airlinesCommission, ticketSaleTotal);
                            }
                            else
                            {
                                ticketSale = LoadTicketSale(ticketSale, ticketSaleTotal);
                            }
                            facade.Insert<TicketSale>(ticketSale);
                            if (ticketSale.IID > 0)
                            {
                                //TicketSaleDetail
                                List<TicketSaleDetail> ticketSaleDetailList = GetExistingTicketSaleDetailList();
                                foreach (TicketSaleDetail ticketSaleDetail in ticketSaleDetailList)
                                {                                    
                                    ticketSaleDetail.TicketSaleID = ticketSale.IID;
                                    facade.Insert<TicketSaleDetail>(ticketSaleDetail);
                                }

                                //Payment
                                if (Convert.ToDecimal(txtCustomerPaid.Text) > 0)
                                {
                                    payment = LoadPayment(payment, ticketSale);
                                    facade.Insert<Payment>(payment);
                                }

                                //Accounts Payable
                                Supplier supplier = new Supplier();
                                supplier = facade.SupplierFacade.GetSupplierByID(ticketSale.AirlinesID);


                                master = new Acc_TransactionMaster();
                                master = LoadTransactionMaster(master, ticketSale, supplier.Name, Convert.ToInt32(EnumCollection.ReferenceType.Supplier));
                                facade.Insert<Acc_TransactionMaster>(master);

                                coaRef = facade.AccountsFacade.GetChartOfAccountByName(supplier.Name);
                                details = new Acc_TransactionDetail();
                                decimal amount = ticketSale.AirlinesPayable;
                                details = LoadTransactionDetails(details, master, coaRef, amount, Convert.ToInt32(EnumCollection.TransactionNature.Credit));
                                facade.Insert<Acc_TransactionDetail>(details);

                                coaRef = facade.AccountsFacade.GetChartOfAccountByName("Airlines Commission");
                                details = new Acc_TransactionDetail();
                                amount = ticketSale.AirLinesCommissionInAmount;
                                details = LoadTransactionDetails(details, master, coaRef, amount, Convert.ToInt32(EnumCollection.TransactionNature.Credit));
                                facade.Insert<Acc_TransactionDetail>(details);

                                coaRef = facade.AccountsFacade.GetChartOfAccountByName("Ticket Purchase");
                                details = new Acc_TransactionDetail();
                                amount = ticketSale.TicketPriceInTaka + ticketSale.TAX;
                                details = LoadTransactionDetails(details, master, coaRef, amount, Convert.ToInt32(EnumCollection.TransactionNature.Debit));
                                facade.Insert<Acc_TransactionDetail>(details);

                                //Accounts Receivable
                                Customer customer = new Customer();
                                customer = facade.CustomerFacade.GetCustomerByID(ticketSale.CustomerID);

                                master = new Acc_TransactionMaster();
                                master = LoadTransactionMaster(master, ticketSale, customer.Name, Convert.ToInt32(EnumCollection.ReferenceType.Customer));
                                facade.Insert<Acc_TransactionMaster>(master);

                                if (!string.IsNullOrEmpty(txtCustomerPaid.Text))
                                {
                                    if (ticketSale.CustomerPaid > 0)
                                    {
                                        coaRef = facade.AccountsFacade.GetChartOfAccountByName("Cash In Hand");
                                        details = new Acc_TransactionDetail();
                                        amount = ticketSale.CustomerPaid;
                                        details = LoadTransactionDetails(details, master, coaRef, amount, Convert.ToInt32(EnumCollection.TransactionNature.Debit));
                                        facade.Insert<Acc_TransactionDetail>(details);
                                    }
                                    if (ticketSale.CustomerDue > 0)
                                    {
                                        coaRef = facade.AccountsFacade.GetChartOfAccountByName(customer.Name);
                                        details = new Acc_TransactionDetail();
                                        amount = ticketSale.CustomerDue;
                                        details = LoadTransactionDetails(details, master, coaRef, amount, Convert.ToInt32(EnumCollection.TransactionNature.Debit));
                                        facade.Insert<Acc_TransactionDetail>(details);
                                    }
                                }
                                else
                                {
                                    coaRef = facade.AccountsFacade.GetChartOfAccountByName(customer.Name);
                                    details = new Acc_TransactionDetail();
                                    amount = ticketSale.CustomerReceivable;
                                    details = LoadTransactionDetails(details, master, coaRef, amount, Convert.ToInt32(EnumCollection.TransactionNature.Debit));
                                    facade.Insert<Acc_TransactionDetail>(details);
                                }
                                if (ticketSale.CustomerDiscountInAmount > 0)
                                {
                                    coaRef = facade.AccountsFacade.GetChartOfAccountByName("Customer Discount");
                                    details = new Acc_TransactionDetail();
                                    amount = ticketSale.CustomerDiscountInAmount;
                                    details = LoadTransactionDetails(details, master, coaRef, amount, Convert.ToInt32(EnumCollection.TransactionNature.Debit));
                                    facade.Insert<Acc_TransactionDetail>(details);
                                }
                                coaRef = facade.AccountsFacade.GetChartOfAccountByName("Ticket Sales");
                                details = new Acc_TransactionDetail();
                                amount = (ticketSale.TicketPriceInTaka + ticketSale.TAX);
                                details = LoadTransactionDetails(details, master, coaRef, amount, Convert.ToInt32(EnumCollection.TransactionNature.Credit));
                                facade.Insert<Acc_TransactionDetail>(details);
                            }
                        }
                        else if (CurrentTicketSaleID > 0)
                        {
                            ticketSale = facade.TicketSaleFacade.GetTicketSaleByID(CurrentTicketSaleID);
                            if (ticketSale.Supplier.AirlinesType == Convert.ToInt32(EnumCollection.AirlinesType.IATA))
                            {
                                ticketSale = LoadTicketSale(ticketSale, airlinesCommission, ticketSaleTotal);
                            }
                            else
                            {
                                ticketSale = LoadTicketSale(ticketSale, ticketSaleTotal);
                            }
                            facade.Update<TicketSale>(ticketSale);
                            
                            //TicketSaleDetail
                            List<TicketSaleDetail> ticketSaleDetailListForDelete = facade.TicketSaleFacade.GetTicketSaleDetailListByTicketSaleID(ticketSale.IID);
                            foreach (TicketSaleDetail ticketSaleDetail in ticketSaleDetailListForDelete)
                            {
                                TicketSaleDetail TSD = new TicketSaleDetail();
                                ticketSaleDetail.IsRemoved= 1;
                                facade.Update<TicketSaleDetail>(ticketSaleDetail);
                            }

                            List<TicketSaleDetail> ticketSaleDetailList = GetExistingTicketSaleDetailList();
                            foreach (TicketSaleDetail ticketSaleDetail in ticketSaleDetailList)
                            {
                                //TicketSaleDetail TSD = new TicketSaleDetail();
                                //TSD = ticketSaleDetail;
                                //TSD.TicketSaleID = ticketSale.IID;
                                ticketSaleDetail.TicketSaleID = ticketSale.IID;
                                facade.Insert<TicketSaleDetail>(ticketSaleDetail);
                            }

                            //Payment
                            if (Convert.ToDecimal(txtCustomerPaid.Text) > 0)
                            {
                                payment = facade.TicketSaleFacade.GetPaymentByReferenceBillNo(ticketSale.TransactionNo);
                                payment = LoadPayment(payment, ticketSale);
                                facade.Update<Payment>(payment);
                            }

                            //Accounts Payable
                            Supplier supplier = new Supplier();
                            supplier = facade.SupplierFacade.GetSupplierByID(ticketSale.AirlinesID);

                            master = new Acc_TransactionMaster();
                            master = facade.AccountsFacade.GetAcc_TransactionMasterByTransactionCodeAndReferenceID(ticketSale.TransactionNo, Convert.ToInt32(EnumCollection.ReferenceType.Supplier));
                            if (master.IID > 0)
                            {
                                master = LoadTransactionMaster(master, ticketSale, supplier.Name, Convert.ToInt32(EnumCollection.ReferenceType.Supplier));
                                facade.Update<Acc_TransactionMaster>(master);
                            }
                            

                            coaRef = facade.AccountsFacade.GetChartOfAccountByName(supplier.Name);
                            details = new Acc_TransactionDetail();
                            details = facade.AccountsFacade.GetAcc_TransactionDetailByTransactionMasterIDandCOAID(master.IID, coaRef.IID);
                            decimal amount = 0;
                            if (details.IID > 0)
                            {
                                amount = ticketSale.AirlinesPayable;
                                details = LoadTransactionDetails(details, master, coaRef, amount, Convert.ToInt32(EnumCollection.TransactionNature.Credit));
                                facade.Update<Acc_TransactionDetail>(details);
                            }
                            coaRef = facade.AccountsFacade.GetChartOfAccountByName("Airlines Commission");
                            details = new Acc_TransactionDetail();
                            details = facade.AccountsFacade.GetAcc_TransactionDetailByTransactionMasterIDandCOAID(master.IID, coaRef.IID);
                            if (details.IID > 0)
                            {
                                amount = ticketSale.AirLinesCommissionInAmount;
                                details = LoadTransactionDetails(details, master, coaRef, amount, Convert.ToInt32(EnumCollection.TransactionNature.Credit));
                                facade.Update<Acc_TransactionDetail>(details);
                            }

                            coaRef = facade.AccountsFacade.GetChartOfAccountByName("Ticket Purchase");
                            details = new Acc_TransactionDetail();
                            details = facade.AccountsFacade.GetAcc_TransactionDetailByTransactionMasterIDandCOAID(master.IID, coaRef.IID);
                            if (details.IID > 0)
                            {
                                amount = ticketSale.TicketPriceInTaka + ticketSale.TAX;
                                details = LoadTransactionDetails(details, master, coaRef, amount, Convert.ToInt32(EnumCollection.TransactionNature.Debit));
                                facade.Update<Acc_TransactionDetail>(details);
                            }

                            //Accounts Receivable
                            Customer customer = new Customer();
                            customer = facade.CustomerFacade.GetCustomerByID(ticketSale.CustomerID);

                            master = new Acc_TransactionMaster();
                            master = facade.AccountsFacade.GetAcc_TransactionMasterByTransactionCodeAndReferenceID(ticketSale.TransactionNo, Convert.ToInt32(EnumCollection.ReferenceType.Customer));
                            if (master.IID > 0)
                            {
                                master = LoadTransactionMaster(master, ticketSale, customer.Name, Convert.ToInt32(EnumCollection.ReferenceType.Customer));
                                facade.Update<Acc_TransactionMaster>(master);
                            }
                            if (!string.IsNullOrEmpty(txtCustomerPaid.Text))
                            {
                                if (ticketSale.CustomerPaid > 0)
                                {
                                    coaRef = facade.AccountsFacade.GetChartOfAccountByName("Cash In Hand");
                                    details = new Acc_TransactionDetail();
                                    details = facade.AccountsFacade.GetAcc_TransactionDetailByTransactionMasterIDandCOAID(master.IID, coaRef.IID);
                                    if (details.IID > 0)
                                    {
                                        amount = ticketSale.CustomerPaid;
                                        details = LoadTransactionDetails(details, master, coaRef, amount, Convert.ToInt32(EnumCollection.TransactionNature.Debit));
                                        facade.Update<Acc_TransactionDetail>(details);
                                    }
                                }
                                if (ticketSale.CustomerDue > 0)
                                {
                                    coaRef = facade.AccountsFacade.GetChartOfAccountByName(customer.Name);
                                    details = new Acc_TransactionDetail();
                                    details = facade.AccountsFacade.GetAcc_TransactionDetailByTransactionMasterIDandCOAID(master.IID, coaRef.IID);
                                    if (details.IID > 0)
                                    {
                                        amount = ticketSale.CustomerDue;
                                        details = LoadTransactionDetails(details, master, coaRef, amount, Convert.ToInt32(EnumCollection.TransactionNature.Debit));
                                        facade.Update<Acc_TransactionDetail>(details);
                                    }
                                }
                            }
                            else
                            {
                                coaRef = facade.AccountsFacade.GetChartOfAccountByName(customer.Name);
                                details = new Acc_TransactionDetail();
                                details = facade.AccountsFacade.GetAcc_TransactionDetailByTransactionMasterIDandCOAID(master.IID, coaRef.IID);
                                if (details.IID > 0)
                                {
                                    amount = ticketSale.CustomerReceivable;
                                    details = LoadTransactionDetails(details, master, coaRef, amount, Convert.ToInt32(EnumCollection.TransactionNature.Debit));
                                    facade.Update<Acc_TransactionDetail>(details);
                                }
                            }
                            if (ticketSale.CustomerDiscountInAmount > 0)
                            {
                                coaRef = facade.AccountsFacade.GetChartOfAccountByName("Customer Discount");
                                details = new Acc_TransactionDetail();
                                details = facade.AccountsFacade.GetAcc_TransactionDetailByTransactionMasterIDandCOAID(master.IID, coaRef.IID);
                                if (details.IID > 0)
                                {
                                    amount = ticketSale.CustomerDiscountInAmount;
                                    details = LoadTransactionDetails(details, master, coaRef, amount, Convert.ToInt32(EnumCollection.TransactionNature.Debit));
                                    facade.Update<Acc_TransactionDetail>(details);
                                }
                            }
                            coaRef = facade.AccountsFacade.GetChartOfAccountByName("Ticket Sales");
                            details = new Acc_TransactionDetail();
                            details = facade.AccountsFacade.GetAcc_TransactionDetailByTransactionMasterIDandCOAID(master.IID, coaRef.IID);
                            if (details.IID > 0)
                            {
                                amount = (ticketSale.TicketPriceInTaka + ticketSale.TAX);
                                details = LoadTransactionDetails(details, master, coaRef, amount, Convert.ToInt32(EnumCollection.TransactionNature.Credit));
                                facade.Update<Acc_TransactionDetail>(details);
                            }
                        }
                        Session["IsSaved"] = true;

                        //LoadListView();
                        //ClearControl();
                        //string data = string.Format("<script language=javascript>window.open('rptInvoice.aspx?{0}','PrintMe','height=600px,width=800px,scrollbars=1');</script>", "ticketSaleID=" + ticketSale.IID.ToString());
                        //Page.ClientScript.RegisterStartupScript(this.GetType(), "onclick", data);
                    }
                }
                catch
                {
                    Session["IsSaved"] = false;
                }
                finally
                {
                    if (ticketSale.IID > 0)
                    {
                        Response.Redirect("~/UITicketSale/TicketSaleView.aspx?ticketSaleID=" + ticketSale.IID.ToString());
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

        private void ClearControl()
        {
            txtDate.Text = string.Empty;
            txtRefernce.Text = string.Empty;
            txtSector.Text = string.Empty;
            txtDepartureFrom.Text = string.Empty;
            txtDepartureDate.Text = string.Empty;
            txtIssueDate.Text = string.Empty;
            txtReturnDate.Text = string.Empty;
            txtDestination.Text = string.Empty;
            txtBillNo.Text = string.Empty;
            txtUSDRate.Text = string.Empty;
            txtNonIATACommissionAmount.Text = string.Empty;
            txtCustomerDiscount.Text = string.Empty;
            txtCustomerReceivable.Text = string.Empty;
            txtCustomerPaid.Text = string.Empty;
            txtCustomerDue.Text = string.Empty;
            txtCustomerReceivableDate.Text = string.Empty;
            txtAirlinesPaymentDate.Text = string.Empty;
            ddlSalesPerson.SelectedValue = "-1";
            ddlCustomer.SelectedValue = "-1";
            ddlCountry.SelectedValue = "-1";
            ddlAirlines.SelectedValue = "-1";
            ddlTicketClass.SelectedValue = "-1";
            
            lvTicketSaleDetail.DataSource = null;
            lvTicketSaleDetail.DataBind();
            
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

        private Acc_TransactionMaster LoadTransactionMaster(Acc_TransactionMaster master, TicketSale ticketSale, string name, int referenceType)
        {            

            string time = Convert.ToString(DateTime.Now.TimeOfDay);
            master.TransactionDate = Convert.ToDateTime(txtDate.Text + " " + time);
            
            master.PayReason = "Ticket Sale";
            master.ReferenceType = referenceType;

            if (master.ReferenceType == Convert.ToInt32(EnumCollection.ReferenceType.Customer))
            {
                master.ReferenceID = Convert.ToInt64(ddlCustomer.SelectedValue);
                master.Particulars = "Ticket Sale to " + name;
            }
            else if (master.ReferenceType == Convert.ToInt32(EnumCollection.ReferenceType.Supplier))
            {
                master.ReferenceID = Convert.ToInt64(ddlAirlines.SelectedValue);
                master.Particulars = "Ticket Sale from " + name;
            }
            else
            {
                master.ReferenceID = -1;
            }
            master.TransactionReference = string.Empty;
            master.Status = Convert.ToInt32(EnumCollection.TransactionStatus.Posted); //Means it has not paid
            master.ToFrom = string.Empty;
            master.ToFromAddress = string.Empty;
            master.ToFromName = string.Empty;
            master.TransactionModeID = Convert.ToInt32(EnumCollection.TransactionMode.Cash);
            master.TransactionReference = "N/A";
            master.TransactionTypeID = Convert.ToInt32(EnumCollection.TransactionType.Voucher);
            master.UpdateBy = Convert.ToInt64(Session["UserID"]);
            master.UpdateDate = DateTime.Now;            
            if (master.IID <= 0)
            {
                master.JournalCode = ticketSale.TransactionNo;
                master.CreateBy = Convert.ToInt64(Session["UserID"]);
                master.CreateDate = DateTime.Now;
            }
            master.IsRemoved = 0;

            master.BranchID = Convert.ToInt32(Session["BranchID"]);
            return master;
        }

        //private string CreateJurnalCode(string page, DateTime date)
        //{
        //    string code = "";
        //    int number = 0;
        //    string day = string.Empty;
        //    string month = "";
        //    using (TheFacade _facade = new TheFacade())
        //    {
        //        day = GetDate(date, day);
        //        month = GetMonth(date, month);

        //        switch (page)
        //        {
        //            case "ASP.uiaccount_paymenttransactionview_aspx":

        //                //code = "CD" + date.Year.ToString().Substring(2, 2) + month + date.Day.ToString() + "9";
        //                code = "CD" + date.Year.ToString().Substring(2, 2) + month + day + "9";
        //                number = _facade.AccountsFacade.GetJurnalNumber("CD", date);
        //                if (number <= 8)
        //                {
        //                    code = code + "00" + (number + 1);
        //                }
        //                else if (number <= 98)
        //                {
        //                    code = code + "0" + (number + 1);
        //                }
        //                else if (number > 98)
        //                {
        //                    code = code + (number + 1);
        //                }
        //                break;

        //            case "ASP.uiaccount_receivetransactionview_aspx":

        //                //code = "CR" + date.Year.ToString().Substring(2, 2) + month + date.Day.ToString() + "9";
        //                code = "CR" + date.Year.ToString().Substring(2, 2) + month + day + "9";
        //                number = _facade.AccountsFacade.GetJurnalNumber("CR", date);
        //                if (number <= 8)
        //                {
        //                    code = code + "00" + (number + 1);
        //                }
        //                else if (number <= 98)
        //                {
        //                    code = code + "0" + (number + 1);
        //                }
        //                else if (number > 98)
        //                {
        //                    code = code + (number + 1);
        //                }
        //                break;

        //            case "ASP.uiaccount_vouchertransactionfrom_aspx":

        //                //code = "JV" + date.Year.ToString().Substring(2, 2) + month + date.Day.ToString() + "9";
        //                code = "JV" + date.Year.ToString().Substring(2, 2) + month + day + "9";
        //                number = _facade.AccountsFacade.GetJurnalNumber("Jv", date);
        //                if (number <= 8)
        //                {
        //                    code = code + "00" + (number + 1);
        //                }
        //                else if (number <= 98)
        //                {
        //                    code = code + "0" + (number + 1);
        //                }
        //                else if (number > 98)
        //                {
        //                    code = code + (number + 1);
        //                }
        //                break;
        //            default:
        //                code = "";
        //                break;
        //        }
        //    }
        //    return code;
        //}

        private Payment LoadPayment(Payment payment, TicketSale ticketSale)
        {
            payment.ReferenceTypeID = Convert.ToInt32(EnumCollection.ReferenceType.Customer);            
            payment.ReferenceID = Convert.ToInt64(ddlCustomer.SelectedValue);            
            
            payment.ReferenceBillNo = ticketSale.TransactionNo;
            payment.PaymentMode = Convert.ToInt32(EnumCollection.TransactionMode.Cash);
            payment.PaidAmount = Convert.ToDecimal(txtCustomerPaid.Text);
            payment.LastDueAmount = Convert.ToDecimal(txtCustomerDue.Text);
            //payment.PaymentDate = Convert.ToDateTime(txtPaymentDate.Text) + DateTime.Now.TimeOfDay;
            payment.PaymentDate = Convert.ToDateTime(txtDate.Text);
            if (!string.IsNullOrEmpty(txtCustomerReceivableDate.Text))
                payment.NextPaymentDate = Convert.ToDateTime(txtCustomerReceivableDate.Text);
            //else
            //    payment.NextPaymentDate = DateTime.MinValue;
            if(payment.LastDueAmount>0)
                payment.Status = Convert.ToInt32(EnumCollection.TicketSaleStatus.Partial);
            else
                payment.Status = Convert.ToInt32(EnumCollection.TicketSaleStatus.Paid);
            if (payment.IID <= 0)
            {
                //payment.TicketSaleID = ticketSale.IID;
                payment.PaymentNo = GetLastPaymentNo();
                payment.CreateBy = Convert.ToInt64(Session["UserID"]);
                payment.CreateDate = DateTime.Now;
            }
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
            DateTime startDate = Convert.ToDateTime("01/" + DateTime.Now.Month.ToString() + "/" + DateTime.Now.Year.ToString() + " 12:00:00 AM");
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

        private TicketSale LoadTicketSale(TicketSale ticketSale, AirlinesCommission airCom, TicketSaleTotal ticketSaleTotal)
        {
            ticketSale.BranchID = Convert.ToInt32(Session["BranchID"]);
            ticketSale.TransactionDate = Convert.ToDateTime(txtDate.Text);            
            ticketSale.AirlinesID = Convert.ToInt64(ddlAirlines.SelectedValue);
            ticketSale.CustomerID = Convert.ToInt64(ddlCustomer.SelectedValue);
            ticketSale.SaleBy = Convert.ToInt64(ddlSalesPerson.SelectedValue);
            ticketSale.DestinationCountry = Convert.ToInt64(ddlCountry.SelectedValue);
            if (ticketSale.IID <= 0)
            {
                ticketSale.TransactionNo = GetLastTransactionNo();
                ticketSale.CreateBy = Convert.ToInt64(Session["UserID"]);
                ticketSale.CreateDate = DateTime.Now;
            }
            //ticketSale.TicketNo = txtTicketNo.Text;            
            ticketSale.Departure = txtDepartureFrom.Text;
            ticketSale.Destination= txtDestination.Text;
            ticketSale.BillNo= txtBillNo.Text;
            ticketSale.TotalDiscount = 0;
            ticketSale.SpecialDiscount = 0;
            ticketSale.VAT= 0;
            if(ticketSaleTotal.TotalTaxAmount>0)
                ticketSale.TAX = ticketSaleTotal.TotalTaxAmount;
            else
                ticketSale.TAX = 0;

            if (ticketSaleTotal.TotalAmountInTaka> 0)
                ticketSale.TicketPriceInTaka= ticketSaleTotal.TotalAmountInTaka;
            else
                ticketSale.TicketPriceInTaka = 0;

            if (ticketSaleTotal.TotalAmountInUSD > 0)
                ticketSale.TicketPriceInUSD = ticketSaleTotal.TotalAmountInUSD;
            else
                ticketSale.TicketPriceInUSD = 0;
            //ticketSale.TicketPriceInUSD= Convert.ToDecimal(txtTIcketPriceInUSD.Text);
            ticketSale.USDRate = Convert.ToDecimal(txtUSDRate.Text);
            //ticketSale.TicketPriceInTaka = Convert.ToDecimal(txtTicketPriceInTaka.Text);
            decimal airLinesCom = 0;
            //Add Normal Commission
            if (airCom.NormalCommissionType == Convert.ToInt32(EnumCollection.AmountType.In_Percentage))
            {
                airLinesCom = (airCom.NormalCommission * ticketSale.TicketPriceInTaka) / 100;
            }
            else
            {
                airLinesCom = airCom.NormalCommission;
            }
            decimal airPrice = ticketSale.TicketPriceInTaka-airLinesCom;
            //Add Excess Commission
            if (airCom.ExcessCommissionType != null && airCom.ExcessCommissionType > 0)
            {
                if (airCom.ExcessCommissionType == Convert.ToInt32(EnumCollection.AmountType.In_Percentage))
                {
                    //Null Value Check
                    airLinesCom += (Convert.ToDecimal(airCom.ExcessCommission == null ? 0 : airCom.ExcessCommission) * airPrice) / 100;
                }
                else
                {
                    airLinesCom += Convert.ToDecimal(airCom.ExcessCommission == null ? 0 : airCom.ExcessCommission);
                }
            }
            ticketSale.AirLinesCommissionInAmount = airLinesCom;
            ticketSale.AirlinesPayable = (ticketSale.TicketPriceInTaka - ticketSale.AirLinesCommissionInAmount) + ticketSale.TAX;
            ticketSale.AirlinesPaymentDate = Convert.ToDateTime(txtAirlinesPaymentDate.Text);
            ticketSale.CustomerDiscountType= Convert.ToInt32(rdoAmountType.SelectedValue);
            
            decimal discount = 0;
            if (!string.IsNullOrEmpty(txtCustomerDiscount.Text))
            {
                discount = Convert.ToDecimal(txtCustomerDiscount.Text);
            
            }
            ticketSale.CustomerDiscount = discount;
            if (rdoAmountType.SelectedValue == "1")
            {
                ticketSale.CustomerDiscountInAmount = (discount * ticketSale.TicketPriceInTaka) / 100;
            }
            else
            {
                ticketSale.CustomerDiscountInAmount = discount;
            }
            if (!string.IsNullOrEmpty(txtCustomerReceivable.Text))
                ticketSale.CustomerReceivable = Convert.ToDecimal(txtCustomerReceivable.Text);
            else
                ticketSale.CustomerReceivable = 0;

            if (!string.IsNullOrEmpty(txtCustomerDue.Text))
                ticketSale.CustomerDue = Convert.ToDecimal(txtCustomerDue.Text);
            else
                ticketSale.CustomerDue = 0;

            if (!string.IsNullOrEmpty(txtCustomerPaid.Text))
                ticketSale.CustomerPaid = Convert.ToDecimal(txtCustomerPaid.Text);
            else
                ticketSale.CustomerPaid = 0;
            
            if(!string.IsNullOrEmpty(txtCustomerReceivableDate.Text))
                ticketSale.CustomerReceivableDate = Convert.ToDateTime(txtCustomerReceivableDate.Text);            
            
            ticketSale.Refernce = txtRefernce.Text;
            ticketSale.Hold = false;
            ticketSale.FinancialYearID = 1;
            ticketSale.Status = Convert.ToInt32(EnumCollection.TicketSaleStatus.Due);
            ticketSale.UpdateBy = Convert.ToInt64(Session["UserID"]);
            ticketSale.UpdateDate = DateTime.Now;
            ticketSale.IsRemoved = 0;
            ticketSale.Remarks= string.Empty;
            ticketSale.TicketClassID = Convert.ToInt32(ddlTicketClass.SelectedValue);
            ticketSale.IssueDate = Convert.ToDateTime(txtIssueDate.Text);
            ticketSale.DepartureDate = Convert.ToDateTime(txtDepartureDate.Text);
            ticketSale.ReturnDate = Convert.ToDateTime(txtReturnDate.Text);
            ticketSale.Sector = txtSector.Text;
            //ticketSale.PassengerName = txtPassengerName.Text;
            return ticketSale;
        }


        private TicketSale LoadTicketSale(TicketSale ticketSale, TicketSaleTotal ticketSaleTotal)
        {
            ticketSale.BranchID = Convert.ToInt32(Session["BranchID"]);
            ticketSale.TransactionDate = Convert.ToDateTime(txtDate.Text);
            ticketSale.AirlinesID = Convert.ToInt64(ddlAirlines.SelectedValue);
            ticketSale.CustomerID = Convert.ToInt64(ddlCustomer.SelectedValue);
            ticketSale.SaleBy = Convert.ToInt64(ddlSalesPerson.SelectedValue);
            ticketSale.DestinationCountry = Convert.ToInt64(ddlCountry.SelectedValue);
            if (ticketSale.IID <= 0)
            {
                ticketSale.TransactionNo = GetLastTransactionNo();
                ticketSale.CreateBy = Convert.ToInt64(Session["UserID"]);
                ticketSale.CreateDate = DateTime.Now;
            }
            //ticketSale.TicketNo = txtTicketNo.Text;
            ticketSale.Departure = txtDepartureFrom.Text;
            ticketSale.Destination = txtDestination.Text;
            ticketSale.BillNo = txtBillNo.Text;
            ticketSale.TotalDiscount = 0;
            ticketSale.SpecialDiscount = 0;
            ticketSale.VAT = 0;
            if (ticketSaleTotal.TotalTaxAmount > 0)
                ticketSale.TAX = ticketSaleTotal.TotalTaxAmount;
            else
                ticketSale.TAX = 0;

            if (ticketSaleTotal.TotalAmountInTaka > 0)
                ticketSale.TicketPriceInTaka = ticketSaleTotal.TotalAmountInTaka;
            else
                ticketSale.TicketPriceInTaka = 0;

            if (ticketSaleTotal.TotalAmountInUSD > 0)
                ticketSale.TicketPriceInUSD = ticketSaleTotal.TotalAmountInUSD;
            else
                ticketSale.TicketPriceInUSD = 0; 
            ticketSale.USDRate = Convert.ToDecimal(txtUSDRate.Text);
            //ticketSale.TicketPriceInTaka = Convert.ToDecimal(txtTicketPriceInTaka.Text);
            if (!string.IsNullOrEmpty(txtNonIATACommissionAmount.Text))
            {
                ticketSale.AirLinesCommissionInAmount = Convert.ToDecimal(txtNonIATACommissionAmount.Text);
            }
            else
            {
                ticketSale.AirLinesCommissionInAmount = 0;
            }
            ticketSale.AirlinesPayable = (ticketSale.TicketPriceInTaka - ticketSale.AirLinesCommissionInAmount) + ticketSale.TAX;
            if (!string.IsNullOrEmpty(txtAirlinesPaymentDate.Text))
            {
                ticketSale.AirlinesPaymentDate = Convert.ToDateTime(txtAirlinesPaymentDate.Text);
            }
            ticketSale.CustomerDiscountType = Convert.ToInt32(rdoAmountType.SelectedValue);

            decimal discount = 0;
            if (!string.IsNullOrEmpty(txtCustomerDiscount.Text))
            {
                discount = Convert.ToDecimal(txtCustomerDiscount.Text);

            }
            ticketSale.CustomerDiscount = discount;
            if (rdoAmountType.SelectedValue == "1")
            {
                ticketSale.CustomerDiscountInAmount = (discount * ticketSale.TicketPriceInTaka) / 100;
            }
            else
            {
                ticketSale.CustomerDiscountInAmount = discount;
            }
            
            if (!string.IsNullOrEmpty(txtCustomerReceivable.Text))
                ticketSale.CustomerReceivable = Convert.ToDecimal(txtCustomerReceivable.Text);
            else
                ticketSale.CustomerReceivable = 0;
            
            if (!string.IsNullOrEmpty(txtCustomerDue.Text))
                ticketSale.CustomerDue = Convert.ToDecimal(txtCustomerDue.Text);
            else
                ticketSale.CustomerDue = 0;

            if (!string.IsNullOrEmpty(txtCustomerPaid.Text))
                ticketSale.CustomerPaid = Convert.ToDecimal(txtCustomerPaid.Text);
            else
                ticketSale.CustomerPaid = 0;

            if (!string.IsNullOrEmpty(txtCustomerReceivableDate.Text))
                ticketSale.CustomerReceivableDate = Convert.ToDateTime(txtCustomerReceivableDate.Text);

            ticketSale.Refernce = txtRefernce.Text;
            ticketSale.Hold = false;
            ticketSale.FinancialYearID = 1;
            ticketSale.Status = Convert.ToInt32(EnumCollection.TicketSaleStatus.Due);
            ticketSale.UpdateBy = Convert.ToInt64(Session["UserID"]);
            ticketSale.UpdateDate = DateTime.Now;
            ticketSale.IsRemoved = 0;
            ticketSale.Remarks = string.Empty;
            ticketSale.TicketClassID = Convert.ToInt32(ddlTicketClass.SelectedValue);
            ticketSale.IssueDate = Convert.ToDateTime(txtIssueDate.Text);
            ticketSale.DepartureDate = Convert.ToDateTime(txtDepartureDate.Text);
            ticketSale.ReturnDate = Convert.ToDateTime(txtReturnDate.Text);
            ticketSale.Sector = txtSector.Text;
            //ticketSale.PassengerName = txtPassengerName.Text;
            return ticketSale;
        }

        private string GetLastTransactionNo()
        {
            string newCode = "TS";
            string branchName = Session["BranchName"].ToString();
            branchName = branchName.Substring(0, 3);
            newCode += "-" + branchName + "-"; 
            //Last Order
            List<TicketSale> ticketSaleList = new List<TicketSale>();
            using (TheFacade _facade = new TheFacade())
            {
                ticketSaleList = _facade.TicketSaleFacade.GetTicketSaleAll();
            }
            //ticketSaleList = ticketSaleList.Where(ts => (CurrentBranchID <= 0 || (CurrentBranchID > 0 && ts.BranchID == CurrentBranchID))).ToList();
            ticketSaleList = ticketSaleList.Where(ts => ts.BranchInfo.Name.Contains(branchName)).ToList();
            //DateTime startDate = Convert.ToDateTime(DateTime.Now.ToShortDateString() + " 12:00:00 AM");
            //DateTime endDate = Convert.ToDateTime(DateTime.Now.ToShortDateString() + " 11:59:59 PM");
            DateTime startDate = Convert.ToDateTime("01/" + DateTime.Now.Month.ToString() + "/" + DateTime.Now.Year.ToString() + " 12:00:00 AM");
            DateTime endDate = Convert.ToDateTime(DateTime.Now.ToShortDateString() + " 11:59:59 PM");
            ticketSaleList = ticketSaleList.Where(ts => (ts.TransactionDate >= startDate && ts.TransactionDate <= endDate) && (ts.TransactionNo.StartsWith("TS-" + branchName))).ToList();

            int count = ticketSaleList.Count;
            int lastnumber = 0;
   
            if (count != 0)
            {
                string TrLastCode = ticketSaleList.LastOrDefault().TransactionNo;
                lastnumber = int.Parse(TrLastCode.Substring(10));
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

        int lvRowCount = 0;
        protected void lvTicketSale_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            if (e.Item.ItemType == ListViewItemType.DataItem)
            {
                ListViewDataItem item = (ListViewDataItem)e.Item;
                //Serial Number
                lvRowCount += 1;
                Label lblSerial = (Label)item.FindControl("lblSerial");
                lblSerial.Text = lvRowCount.ToString();

                Label lblDate = (Label)item.FindControl("lblDate");
                LinkButton lnkbtnTransactionNo = (LinkButton)item.FindControl("lnkbtnTransactionNo");
                Label lblAirlinesName = (Label)item.FindControl("lblAirlinesName");
                Label lblCustomerName = (Label)item.FindControl("lblCustomerName");
                Label lblTicketPrice = (Label)item.FindControl("lblTicketPrice");
                Label lblAirlinesPayable = (Label)item.FindControl("lblAirlinesPayable");
                Label lblCustomerReceivable = (Label)item.FindControl("lblCustomerReceivable");
                TicketSale ticketSale = (TicketSale)((ListViewDataItem)(e.Item)).DataItem;
                LinkButton lnkbtnEdit = (LinkButton)item.FindControl("lnkbtnEdit");

                lblDate.Text = ticketSale.TransactionDate.ToShortDateString();
                lblAirlinesName.Text = ticketSale.Supplier.Name;
                lblCustomerName.Text = ticketSale.Customer.Name;
                //using (TheFacade _facade = new TheFacade())
                //{
                //    Customer customer = new Customer();
                //    customer = _facade.CustomerFacade.GetCustomerByID(ticketSale.ReferenceID);
                //    if(customer != null)
                //        lblCustomerName.Text = customer.Name;
                //}

                lblTicketPrice.Text = ticketSale.TicketPriceInTaka.ToString();
                //lblAirlinesPayable.Text = ticketSale.AirlinesPayable.ToString();

                lblCustomerReceivable.Text = ticketSale.CustomerReceivable.ToString();

                lnkbtnTransactionNo.Text = ticketSale.TransactionNo;
                lnkbtnTransactionNo.CommandArgument = ticketSale.IID.ToString();
                lnkbtnTransactionNo.CommandName = "ShowInvoice";

                lnkbtnEdit.Text = "Edit";
                lnkbtnEdit.CommandArgument = ticketSale.IID.ToString();
                lnkbtnEdit.CommandName = "DoEdit";
            }
        }

        protected void lvTicketSale_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            if (e.CommandName == "DoEdit")
            {
                using (TheFacade _facade = new TheFacade())
                {
                    TicketSale ticketSale = new TicketSale();
                    Int64 ticketSaleID = Convert.ToInt64(e.CommandArgument);

                    ticketSale = _facade.TicketSaleFacade.GetTicketSaleByID(ticketSaleID);
                    if (ticketSale.IID > 0) // && Convert.ToInt32(ddlTransactionStatus.SelectedValue)>0)
                    {
                        CurrentTicketSaleID = ticketSale.IID;
                        FillControl(ticketSale);
                        List<TicketSaleDetail> ticketSaleDetailList = new List<TicketSaleDetail>();
                        ticketSaleDetailList = _facade.TicketSaleFacade.GetTicketSaleDetailListByTicketSaleID(ticketSale.IID);
                        BindTicketSaleDetail(ticketSaleDetailList);
                        Payment payment = _facade.TicketSaleFacade.GetPaymentByReferenceBillNo(ticketSale.TransactionNo);
                        if (payment != null && payment.IID > 0)
                        {
                            CurrentPaymentID = payment.IID;
                        }

                    }
                }
            }
            else if (e.CommandName =="ShowInvoice")
            {

                using (TheFacade _facade = new TheFacade())
                {
                    TicketSale ticketSale = new TicketSale();
                    Int64 ticketSaleID = Convert.ToInt64(e.CommandArgument);

                    ticketSale = _facade.TicketSaleFacade.GetTicketSaleByID(ticketSaleID);
                    if (ticketSale.IID > 0) // && Convert.ToInt32(ddlTransactionStatus.SelectedValue)>0)
                    {
                        string data = string.Format("<script language=javascript>window.open('rptInvoice.aspx?{0}','PrintMe','height=600px,width=800px,scrollbars=1');</script>", "ticketSaleID=" + ticketSale.IID.ToString());
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "onclick", data);
                    }



                    //StockMaster stockMaster = new StockMaster();

                    //stockMaster = _facade.StockFacade.GetStockMasterByID(Convert.ToInt64(e.CommandArgument.ToString()));
                    //CurrentStockMasterID = stockMaster.IID;

                    //ddlSupplier.SelectedValue = stockMaster.Supplier.IID.ToString();
                    //txtBillNo.Text = stockMaster.BillNo;
                    //txtDate.Text = stockMaster.Date.ToShortDateString();
                    ////Load Item 
                    //List<StockDetail> stockDetailList = _facade.StockFacade.GetStockDetailListByStockMatserID(stockMaster.IID);
                    //lvItem.DataSource = stockDetailList;
                    //lvItem.DataBind();

                    //IsNew = 0;
                }
            }
        }

        private void FillControl(TicketSale ticketSale)
        {
            txtDate.Text = ticketSale.TransactionDate.ToShortDateString();
            ddlSalesPerson.SelectedValue = ticketSale.SaleBy.ToString();
            ddlCustomer.SelectedValue = ticketSale.CustomerID.ToString();
            txtRefernce.Text = ticketSale.Refernce;
            ddlAirlines.SelectedValue = ticketSale.AirlinesID.ToString();
            txtDepartureFrom.Text = ticketSale.Departure;
            txtDestination.Text = ticketSale.Destination;
            txtBillNo.Text = ticketSale.BillNo;
            if (ticketSale.DestinationCountry != null)
                ddlCountry.SelectedValue = ticketSale.DestinationCountry.ToString();
            txtUSDRate.Text = ticketSale.USDRate.ToString();
            txtAirlinesPaymentDate.Text = ticketSale.AirlinesPaymentDate.ToShortDateString();
            rdoAmountType.SelectedValue = ticketSale.CustomerDiscountType.ToString();
            txtCustomerDiscount.Text = ticketSale.CustomerDiscount.ToString();
            txtCustomerReceivable.Text = ticketSale.CustomerReceivable.ToString();
            txtCustomerDue.Text = ticketSale.CustomerDue.ToString();
            txtCustomerPaid.Text = ticketSale.CustomerPaid.ToString();

            // Null date Check Null Date
            string date = (ticketSale.CustomerReceivableDate == null) ? "" : ticketSale.CustomerReceivableDate.ToString();
            if (!string.IsNullOrEmpty(date))
            {
                txtCustomerReceivableDate.Text = Convert.ToDateTime(date).ToString("dd/MM/yyyy");

            }
            else
            {
                txtCustomerReceivableDate.Text = string.Empty;

            }
            
            ddlTicketClass.SelectedValue = ticketSale.TicketClassID.ToString();
            
            string issueDate = (ticketSale.IssueDate == null) ? "" : ticketSale.IssueDate.ToString();
            if (!string.IsNullOrEmpty(issueDate))
            {
                txtIssueDate.Text = Convert.ToDateTime(issueDate).ToString("dd/MM/yyyy");
            }
            else
            {
                txtIssueDate.Text = String.Empty;
            }
            
            string departDate = (ticketSale.DepartureDate == null) ? "" : ticketSale.DepartureDate.ToString();
            if (!string.IsNullOrEmpty(departDate))
            {
                txtDepartureDate.Text = Convert.ToDateTime(departDate).ToString("dd/MM/yyyy");
            }
            else
            {
                txtDepartureDate.Text = string.Empty;
            }
            
            string returnDate = (ticketSale.ReturnDate == null) ? "" : ticketSale.ReturnDate.ToString();
            if (!string.IsNullOrEmpty(returnDate))
            {
                txtReturnDate.Text = Convert.ToDateTime(departDate).ToString("dd/MM/yyyy");
            }
            else
            {
                txtReturnDate.Text = string.Empty;
            }
            
            txtSector.Text = ticketSale.Sector;

            if (ticketSale.Supplier.AirlinesType == Convert.ToInt32(EnumCollection.AirlinesType.Non_IATA))
            {
                CurrentAirlinesTypeID = Convert.ToInt32(EnumCollection.AirlinesType.Non_IATA);
                divNonIATA.Visible = true;
            }
            else
            {
                CurrentAirlinesTypeID = Convert.ToInt32(EnumCollection.AirlinesType.IATA);
                divNonIATA.Visible = false;
            }
        }

        int CurrentPage = 0;
        protected void dpTicketSale_PreRender(object sender, EventArgs e)
        {
            lvRowCount = CurrentPage * 20;
            if (IsPostBack)
                LoadListView();
        }

        protected void lvTicketSale_PagePropertiesChanging(object sender, PagePropertiesChangingEventArgs e)
        {
            CurrentPage = (e.StartRowIndex / e.MaximumRows) + 0;
        }

        //protected void txtAirlinesCommission_TextChanged(object sender, EventArgs e)
        //{
        //    if (!string.IsNullOrEmpty(txtAirlinesCommission.Text))
        //            txtAirlinesPayable.Text = (Convert.ToDecimal(txtTicketPriceInTaka.Text) - ((Convert.ToDecimal(txtTicketPriceInTaka.Text) * Convert.ToDecimal(txtAirlinesCommission.Text)) / 100)).ToString();
        //        //if (rbPercentageCommission.Checked)
        //        //    txtAirlinesPayable.Text = (Convert.ToDecimal(txtTicketPriceInTaka.Text) - ((Convert.ToDecimal(txtTicketPriceInTaka.Text) * Convert.ToDecimal(txtAirlinesCommission.Text)) / 100)).ToString();
        //        //else
        //        //    txtAirlinesPayable.Text = (Convert.ToDecimal(txtTicketPriceInTaka.Text) - Convert.ToDecimal(txtAirlinesCommission.Text)).ToString();
        //    else
        //        txtAirlinesPayable.Text = "0.00";
        //}

        
        //protected void txtAirlinesPaid_TextChanged(object sender, EventArgs e)
        //{
        //    if (!string.IsNullOrEmpty(txtAirlinesPaid.Text))
        //        txtAirlinesDue.Text = (Convert.ToDecimal(txtAirlinesPayable.Text) - Convert.ToDecimal(txtAirlinesPaid.Text)).ToString();
        //    else
        //        txtAirlinesDue.Text = "0.00";
        //}

        //protected void txtAirlinesPayable_TextChanged(object sender, EventArgs e)
        //{
        //    if (!string.IsNullOrEmpty(txtAirlinesPayable.Text))
        //        txtAirlinesPaid.Text = txtAirlinesPayable.Text;
        //    else
        //        txtAirlinesPaid.Text = "0.00";
        //}

        

        

        protected void btnClose_Click(object sender, EventArgs e)
        {
            //GetLastTransactionNo();
            Response.Redirect("~/UITicketSale/TicketSaleView.aspx");
        }

        protected void ddlAirlines_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlAirlines.SelectedValue != "" && ddlAirlines.SelectedValue != "-1")
            {
                Supplier supllier = new Supplier();
                using (TheFacade _facade = new TheFacade())
                {
                    supllier = _facade.SupplierFacade.GetSupplierByID(Convert.ToInt64(ddlAirlines.SelectedValue));
                    if (supllier.IID != null )
                    {
                        if (supllier.AirlinesType == Convert.ToInt32(EnumCollection.AirlinesType.Non_IATA))
                        {
                            CurrentAirlinesTypeID = Convert.ToInt32(EnumCollection.AirlinesType.Non_IATA);
                            divNonIATA.Visible = true;
                        }
                        else
                        {
                            CurrentAirlinesTypeID = Convert.ToInt32(EnumCollection.AirlinesType.IATA);
                            divNonIATA.Visible = false;
                        }
                    }
                }
                
            }
            else
            {
                divNonIATA.Visible = false;
            }
        }

        protected void btnAddPost_Click(object sender, EventArgs e)
        {
            List<TicketSaleDetail> ticketSaleDetailList = GetExistingTicketSaleDetailList();
            TicketSaleDetail ticketSaleDetail = new TicketSaleDetail();

            if (CurrentTicketSaleDetailID == -1)
            {
                ticketSaleDetail.TicketSaleID = CurrentTicketSaleID;
                ticketSaleDetail.PassengerName = txtPassengerName.Text;
                ticketSaleDetail.TicketNo = txtTicketNo.Text;
                ticketSaleDetail.TicketPriceInUSD =Convert.ToDecimal(txtTIcketPriceInUSD.Text);
                ticketSaleDetail.TicketPrice = Convert.ToDecimal(txtTicketPriceInTaka.Text);
                ticketSaleDetail.Tax = Convert.ToDecimal(txtTAXAmount.Text);
                ticketSaleDetail.TotalAmount = Convert.ToDecimal(txtSubTotal.Text);
                ticketSaleDetail.IsRemoved = 0;
                ticketSaleDetail.CreateBy = Convert.ToInt64(Session["UserID"]);
                ticketSaleDetail.CreateDate = DateTime.Now;
                ticketSaleDetail.UpdateBy = Convert.ToInt64(Session["UserID"]);
                ticketSaleDetail.UpdateDate = DateTime.Now;
                ticketSaleDetail.Status = 1;
                ticketSaleDetail.UpdateDate = DateTime.Now;
                
                ticketSaleDetailList.Add(ticketSaleDetail);
            }
            else
            {
                ticketSaleDetail = ticketSaleDetailList.Single(dd => dd.IID == CurrentTicketSaleDetailID);

                ticketSaleDetailList.Remove(ticketSaleDetail);

                ticketSaleDetail.IID = CurrentTicketSaleDetailID;
                ticketSaleDetail.PassengerName = txtPassengerName.Text;
                ticketSaleDetail.TicketNo = txtTicketNo.Text;
                ticketSaleDetail.TicketPriceInUSD = Convert.ToDecimal(txtTIcketPriceInUSD.Text);
                ticketSaleDetail.TicketPrice = Convert.ToDecimal(txtTicketPriceInTaka.Text);
                ticketSaleDetail.Tax = Convert.ToDecimal(txtTAXAmount.Text);
                ticketSaleDetail.TotalAmount = Convert.ToDecimal(txtSubTotal.Text);
                ticketSaleDetail.IsRemoved = 0;
                ticketSaleDetail.UpdateBy = Convert.ToInt64(Session["UserID"]);
                ticketSaleDetail.UpdateDate = DateTime.Now;
                ticketSaleDetail.Status = 1;
                ticketSaleDetail.UpdateDate = DateTime.Now;
                ticketSaleDetailList.Add(ticketSaleDetail);
            }
            BindTicketSaleDetail(ticketSaleDetailList);
            
            TicketSaleTotal ticketSaleTotal = new TicketSaleTotal();
            ticketSaleTotal = GetTicketSaleTotal();

            txtCustomerReceivable.Text = ticketSaleTotal.TotalAmount.ToString();
            txtCustomerPaid.Text = txtCustomerReceivable.Text;
            txtCustomerDue.Text = "0.00";
            //TicketSale ts = new TicketSale();
            //if (ticketSaleDetail.IID > 0)
            //{
            //    using (TheFacade _facade = new TheFacade())
            //    {
            //        ts = _facade.TicketSaleFacade.GetTicketSaleByID(ticketSaleDetail.TicketSaleID);
            //        if (ts.IID > 0)
            //        {
            //            if(
            //            txtCustomerPaid.Text = ts.CustomerPaid.ToString();
            //            txtCustomerDue.Text = ts.CustomerDue.ToString();
            //        }
            //    }
            //}
            //if (!String.IsNullOrEmpty(txtCustomerPaid.Text))
            //{
            //    //txtCustomerPaid.Text =  (Convert.ToDecimal(txtCustomerReceivable.Text) - Convert.ToDecimal(txtCustomerDue.Text)).ToString();
            //}
            //else
            //{
            //    if (!String.IsNullOrEmpty(txtCustomerDiscount.Text))
            //    {
            //        txtCustomerReceivable.Text = (Convert.ToDecimal(txtCustomerReceivable.Text)-((Convert.ToDecimal(txtCustomerReceivable.Text) * Convert.ToDecimal(txtCustomerDiscount.Text)) / 100)).ToString();
            //        txtCustomerPaid.Text = txtCustomerReceivable.Text;
                    
            //    }
            //    else
            //    {
            //        txtCustomerPaid.Text = txtCustomerReceivable.Text;
            //    }
            //}
            //if (!String.IsNullOrEmpty(txtCustomerDue.Text))
            //{
            //    txtCustomerDue.Text = (Convert.ToDecimal(txtCustomerReceivable.Text) - Convert.ToDecimal(txtCustomerPaid.Text)).ToString();
            //}
            //else
            //{
            //    txtCustomerDue.Text = "0.00";
            //}
            ClearControlSub();
        }

        private void ClearControlSub()
        {
            txtPassengerName.Text = string.Empty;
            txtTicketNo.Text = string.Empty;
            txtTIcketPriceInUSD.Text = string.Empty;
            txtTicketPriceInTaka.Text = string.Empty;
            txtTAXAmount.Text = string.Empty;
            txtSubTotal.Text = string.Empty;
        }
        
        private List<TicketSaleDetail> GetExistingTicketSaleDetailList()
        {
            List<TicketSaleDetail> ticketSaleDetailList = new List<TicketSaleDetail>();
            foreach (ListViewDataItem item in lvTicketSaleDetail.Items)
            {
                Label lblPassengerName = (Label)item.FindControl("lblPassengerName");
                Label lblTicketNo = (Label)item.FindControl("lblTicketNo");
                Label lblTicketFairInUSD = (Label)item.FindControl("lblTicketFairInUSD");
                Label lblTicketFair = (Label)item.FindControl("lblTicketFair");
                Label lblTAXAmount = (Label)item.FindControl("lblTAXAmount");
                Label lblSubTotal = (Label)item.FindControl("lblSubTotal");
                Label lblObjID = (Label)item.FindControl("lblObjID");
                LinkButton lnkEdit = (LinkButton)item.FindControl("lnkEdit");
                LinkButton lnkDelete = (LinkButton)item.FindControl("lnkDelete");

                TicketSaleDetail ticketSaleDetail = new TicketSaleDetail();
                string ticketNo = lnkDelete.CommandArgument.ToString();
                string[] ticketArr = ticketNo.Split('_');
                long ddID = 0;
                if(ticketArr[0] == "0")
                    ddID = Convert.ToInt64(ticketArr[1]);
                ticketSaleDetail.IID = ddID;
                ticketSaleDetail.PassengerName= lblPassengerName.Text;
                ticketSaleDetail.TicketNo = lblTicketNo.Text;
                ticketSaleDetail.TicketPriceInUSD = Convert.ToDecimal(lblTicketFairInUSD.Text);
                ticketSaleDetail.TicketPrice = Convert.ToDecimal(lblTicketFair.Text);
                ticketSaleDetail.Tax= Convert.ToDecimal(lblTAXAmount.Text);
                ticketSaleDetail.TotalAmount= Convert.ToDecimal(lblSubTotal.Text);
                ticketSaleDetail.IsRemoved = 0;
        
                ticketSaleDetail.CreateBy = Convert.ToInt64(Session["UserID"]);
                ticketSaleDetail.CreateDate = DateTime.Now;
                ticketSaleDetail.UpdateBy= Convert.ToInt64(Session["UserID"]);
                ticketSaleDetail.UpdateDate = DateTime.Now;
                
                ticketSaleDetail.Status = 1;
                ticketSaleDetailList.Add(ticketSaleDetail);
            }
            return ticketSaleDetailList;
        }

        private void BindTicketSaleDetail(List<TicketSaleDetail> ticketSaleDetailList)
        {
            lvTicketSaleDetail.DataSource = ticketSaleDetailList;
            lvTicketSaleDetail.DataBind();
        }

        int lvRowCountDesig = 0;
        protected void lvTicketSaleDetail_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            if (e.Item.ItemType == ListViewItemType.DataItem)
            {
                lvRowCountDesig += 1;
                ListViewDataItem item = (ListViewDataItem)e.Item;
                TicketSaleDetail ticketSaleDetail= (TicketSaleDetail)((ListViewDataItem)(e.Item)).DataItem;
                Label lblSerial = (Label)item.FindControl("lblSerial");
                Label lblPassengerName = (Label)item.FindControl("lblPassengerName");
                Label lblTicketNo = (Label)item.FindControl("lblTicketNo");
                Label lblTicketFairInUSD = (Label)item.FindControl("lblTicketFairInUSD");
                Label lblTicketFair = (Label)item.FindControl("lblTicketFair");
                Label lblTAXAmount = (Label)item.FindControl("lblTAXAmount");
                Label lblSubTotal = (Label)item.FindControl("lblSubTotal");
                Label lblObjID = (Label)item.FindControl("lblObjID");

                lblSerial.Text = lvRowCountDesig.ToString();
                LinkButton lnkEdit = (LinkButton)item.FindControl("lnkEdit");
                LinkButton lnkDelete = (LinkButton)item.FindControl("lnkDelete");

                lblPassengerName.Text = ticketSaleDetail.PassengerName;
                lblTicketNo.Text = ticketSaleDetail.TicketNo;
                //lblTicketNo.ToolTip = ticketSaleDetail.TicketNo;
                lblObjID.Text = ticketSaleDetail.TicketNo;
                lblTicketFairInUSD.Text = ticketSaleDetail.TicketPriceInUSD.ToString();
                lblTicketFair.Text = ticketSaleDetail.TicketPrice.ToString();
                lblTAXAmount.Text = ticketSaleDetail.Tax.ToString();
                lblSubTotal.Text = ticketSaleDetail.TotalAmount.ToString();

                lnkEdit.CommandName = "DoEdit";
                lnkEdit.CommandArgument = lblObjID.Text;
                
                //lnkEdit.SkinID = departmentDesignation.IID.ToString();
                lnkDelete.CommandName = "DoDelete";
                if (ticketSaleDetail.IID > 0)
                {                    
                    lnkDelete.CommandArgument = "0_"+ ticketSaleDetail.IID.ToString();
                    //lnkDelete.ToolTip = "0";
                }
                else
                {
                    lnkDelete.CommandArgument = "1_" + lblObjID.Text;
                    //lnkDelete.ToolTip = "1";
                }
            }

        }

        protected void lvTicketSaleDetail_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            TicketSaleDetail ticketSaleDetail = new TicketSaleDetail();
            List<TicketSaleDetail> ticketSaleDetailList = new List<TicketSaleDetail>();
            if (e.CommandName == "DoEdit")
            {
                string ticketNo = e.CommandArgument.ToString();

                using (TheFacade facade = new TheFacade())
                {
                    ticketSaleDetail = GetExistingTicketSaleDetailList().Where(td=>td.TicketNo == e.CommandArgument.ToString()).FirstOrDefault();
                    if (ticketSaleDetail != null)
                    {
                        if (ticketSaleDetail.IID > 0)
                            CurrentTicketSaleDetailID = ticketSaleDetail.IID;
                        else
                            CurrentTicketSaleDetailID = -1;

                        txtPassengerName.Text = ticketSaleDetail.PassengerName;
                        txtTicketNo.Text = ticketSaleDetail.TicketNo;
                        txtTIcketPriceInUSD.Text = ticketSaleDetail.TicketPriceInUSD.ToString();
                        txtTicketPriceInTaka.Text = ticketSaleDetail.TicketPrice.ToString();
                        txtTAXAmount.Text = ticketSaleDetail.Tax.ToString();
                        txtSubTotal.Text = ticketSaleDetail.TotalAmount.ToString();
                    }
                }                
            }
            if (e.CommandName == "DoDelete")
            {
                string ticketNo = e.CommandArgument.ToString();
                string[] ticketArr = ticketNo.Split('_');                
                using (TheFacade facade = new TheFacade())
                {
                    ticketSaleDetailList = GetExistingTicketSaleDetailList();
                    if(ticketArr[0] =="1")
                        ticketSaleDetail = ticketSaleDetailList.Where(td => td.TicketNo == ticketArr[1]).FirstOrDefault();
                    else
                        ticketSaleDetail = ticketSaleDetailList.Where(td => td.IID == Convert.ToInt64(ticketArr[1])).FirstOrDefault();
                    if (ticketSaleDetail != null)
                    {
                        if (ticketSaleDetail.IID > 0)
                            CurrentTicketSaleDetailID = ticketSaleDetail.IID;
                        else
                            CurrentTicketSaleDetailID = -1;
                        ticketSaleDetailList.Remove(ticketSaleDetail);
                        BindTicketSaleDetail(ticketSaleDetailList);                        
                    }
                }  

            }
        }

        protected void txtTIcketPriceInUSD_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txtTIcketPriceInUSD.Text))
                {

                    txtTicketPriceInTaka.Text = (Convert.ToDecimal(txtTIcketPriceInUSD.Text) * Convert.ToDecimal(txtUSDRate.Text)).ToString();
                    if (!string.IsNullOrEmpty(txtTAXAmount.Text))
                    {
                        txtSubTotal.Text = (Convert.ToDecimal(txtTicketPriceInTaka.Text) + Convert.ToDecimal(txtTAXAmount.Text)).ToString();

                    }
                    else
                    {
                        txtSubTotal.Text = (Convert.ToDecimal(txtTicketPriceInTaka.Text)).ToString();

                    }

                    //txtCustomerReceivable.Text = (GetExistingTicketSaleAmount() + Convert.ToDecimal(txtSubTotal.Text)).ToString();
                    //txtCustomerPaid.Text = txtCustomerReceivable.Text;
                    //txtCustomerDue.Text = "0.00";
                }
                else
                {
                    txtTicketPriceInTaka.Text = "0.00";
                    //txtCustomerReceivable.Text = "0.00";
                    //txtCustomerPaid.Text = "0.00";
                    //txtCustomerDue.Text = "0.00";
                }
                ShowMsg("");
            }
            catch (Exception ex)
            {
                ShowMsg("Please Enter Numeric value or Input USD rate !!!");
                return;
            }
        }

        protected void txtTAXAmount_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txtTAXAmount.Text))
                {
                    txtTicketPriceInTaka.Text = (Convert.ToDecimal(txtTIcketPriceInUSD.Text) * Convert.ToDecimal(txtUSDRate.Text)).ToString();
                    txtSubTotal.Text = (Convert.ToDecimal(txtTicketPriceInTaka.Text) + Convert.ToDecimal(txtTAXAmount.Text)).ToString();

                    //txtCustomerReceivable.Text = (GetExistingTicketSaleAmount() + Convert.ToDecimal(txtSubTotal.Text)).ToString();
                    //txtCustomerPaid.Text = txtCustomerReceivable.Text;
                    //txtCustomerDue.Text = "0.00";
                }
                else
                {
                    txtTicketPriceInTaka.Text = (Convert.ToDecimal(txtTIcketPriceInUSD.Text) * Convert.ToDecimal(txtUSDRate.Text)).ToString();
                    txtSubTotal.Text = (Convert.ToDecimal(txtTicketPriceInTaka.Text)).ToString();
                    //txtCustomerReceivable.Text = (GetExistingTicketSaleAmount() + Convert.ToDecimal(txtSubTotal.Text)).ToString();
                    //txtCustomerPaid.Text = txtCustomerReceivable.Text;
                    //txtCustomerDue.Text = "0.00";
                }
                ShowMsg("");
            }
            catch (Exception ex)
            {
                ShowMsg("Please Enter Numeric value or Input USD rate !!!");
                return;
            }
        }


        //decimal totalAmount = 0;
        //private decimal GetExistingTicketSaleAmount()
        //{
        //    List<TicketSaleDetail> ticketSaleDetailList = new List<TicketSaleDetail>();
        //    foreach (ListViewDataItem item in lvTicketSaleDetail.Items)
        //    {

        //        Label lblSubTotal = (Label)item.FindControl("lblSubTotal");

        //        totalAmount += Convert.ToDecimal(lblSubTotal.Text);

        //    }
        //    return totalAmount;
        //}

        private TicketSaleTotal GetTicketSaleTotal()
        {
            TicketSaleTotal ticketSaleTotal = new TicketSaleTotal();
            decimal totalTicketPriceInUSD = 0;
            decimal totalTicketPriceInTaka = 0;
            decimal totalTaxAmount = 0;
            decimal totalTicketPrice = 0;
            List<TicketSaleDetail> ticketSaleDetailList = new List<TicketSaleDetail>();
            foreach (ListViewDataItem item in lvTicketSaleDetail.Items)
            {
                Label lblTicketFairInUSD = (Label)item.FindControl("lblTicketFairInUSD");
                Label lblTicketFair = (Label)item.FindControl("lblTicketFair");
                Label lblTAXAmount = (Label)item.FindControl("lblTAXAmount");
                Label lblSubTotal = (Label)item.FindControl("lblSubTotal");

                totalTicketPriceInUSD += Convert.ToDecimal(lblTicketFairInUSD.Text);
                totalTicketPriceInTaka += Convert.ToDecimal(lblTicketFair.Text);
                totalTaxAmount += Convert.ToDecimal(lblTAXAmount.Text);
                totalTicketPrice += Convert.ToDecimal(lblSubTotal.Text);

            }
            ticketSaleTotal.TotalAmountInUSD = totalTicketPriceInUSD;
            ticketSaleTotal.TotalAmountInTaka = totalTicketPriceInTaka;
            ticketSaleTotal.TotalTaxAmount = totalTaxAmount;
            ticketSaleTotal.TotalAmount = totalTicketPrice;

            return ticketSaleTotal;
        }
        protected void txtUSDRate_TextChanged(object sender, EventArgs e)
        {
            //if (!string.IsNullOrEmpty(txtUSDRate.Text))
            //{
            //    txtTicketPriceInTaka.Text = (Convert.ToDecimal(txtTIcketPriceInUSD.Text) * Convert.ToDecimal(txtUSDRate.Text)).ToString();
            //    txtCustomerReceivable.Text = txtTicketPriceInTaka.Text;
            //    txtCustomerPaid.Text = txtTicketPriceInTaka.Text;
            //    txtCustomerDue.Text = "0.00";
            //}
            //else
            //{
            //    txtTicketPriceInTaka.Text = "0.00";
            //    txtCustomerReceivable.Text = "0.00";
            //    txtCustomerPaid.Text = "0.00";
            //    txtCustomerDue.Text = "0.00";
            //}

        }

        protected void txtCustomerDiscount_TextChanged(object sender, EventArgs e)
        {
            TicketSaleTotal ticketSaleTotal = new TicketSaleTotal();
            ticketSaleTotal = GetTicketSaleTotal();
            if (!string.IsNullOrEmpty(txtCustomerDiscount.Text))
            {
                
                
                decimal discount = 0;
                
                if (rdoAmountType.SelectedValue == "1") //Percentage
                {

                    //if (!string.IsNullOrEmpty(txtCustomerDiscount.Text))
                    discount = ticketSaleTotal.TotalAmountInTaka * Convert.ToDecimal(txtCustomerDiscount.Text) / 100;
                }
                else
                {
                    discount = Convert.ToDecimal(txtCustomerDiscount.Text);
                }
                txtCustomerReceivable.Text = (ticketSaleTotal.TotalAmountInTaka - discount + ticketSaleTotal.TotalTaxAmount).ToString();
                txtCustomerPaid.Text = txtCustomerReceivable.Text;
                txtCustomerDue.Text = "0.00";
            }
            //if (rbPercentageDiscount.Checked)
            //    txtCustomerReceivable.Text = (Convert.ToDecimal(txtTicketPriceInTaka.Text) - ((Convert.ToDecimal(txtTicketPriceInTaka.Text) * Convert.ToDecimal(txtCustomerDiscount.Text)) / 100)).ToString();
            //else
            //    txtCustomerReceivable.Text = (Convert.ToDecimal(txtTicketPriceInTaka.Text) - Convert.ToDecimal(txtCustomerDiscount.Text)).ToString();
            //else
            //{
            //    decimal taxAmount = 0;
            //    if (!string.IsNullOrEmpty(txtTAXAmount.Text))
            //        taxAmount = Convert.ToDecimal(txtTAXAmount.Text);

            //    decimal discount = 0;
            //    if (!string.IsNullOrEmpty(txtCustomerDiscount.Text))
            //        discount = (Convert.ToDecimal(txtTicketPriceInTaka.Text) * Convert.ToDecimal(txtCustomerDiscount.Text)) / 100;

            //    txtCustomerReceivable.Text = (Convert.ToDecimal(txtTicketPriceInTaka.Text) - discount + taxAmount).ToString();
            //    txtCustomerPaid.Text = txtCustomerReceivable.Text;
            //    txtCustomerDue.Text = "0.00";
            //}
        }

        protected void txtCustomerPaid_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtCustomerPaid.Text))
                txtCustomerDue.Text = (Convert.ToDecimal(txtCustomerReceivable.Text) - Convert.ToDecimal(txtCustomerPaid.Text)).ToString();
            else
                txtCustomerDue.Text = "0.00";
        }


        //protected void txtCustomerReceivable_TextChanged(object sender, EventArgs e)
        //{
        //    if (!string.IsNullOrEmpty(txtCustomerReceivable.Text))
        //        txtCustomerPaid.Text = txtCustomerReceivable.Text;
        //    else
        //        txtCustomerPaid.Text = "0.00";
        //}

        
    }
}
