using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using OMS.Web.Helpers;
using OMS.Facade;
using OMS.DAL;
using OMS.Framework;

namespace OMS.WebClient.Controls
{
    public partial class wucReportCustomerReceivable : System.Web.UI.UserControl
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
                    if (Convert.ToInt32(Session["RoleID"].ToString()) == Convert.ToInt32(EnumCollection.UserType.Admin))//admin
                    {
                        CurrentBranchID = -1;
                    }
                    else
                    {
                        CurrentBranchID = Convert.ToInt32(Session["BranchID"].ToString());

                    }
                    LoadDDL();
                }
            }
        }

        private void LoadDDL()
        {
            List<Customer> customerList = new List<Customer>();
            using (TheFacade _facade = new TheFacade())
            {
                customerList = _facade.CustomerFacade.GetCustomerAll().Where(ts => (CurrentBranchID <= 0 || (CurrentBranchID > 0 && ts.BranchID == CurrentBranchID))).ToList();            
            }            
            DDLHelper.Bind<Customer>(ddlCustomer, customerList, "Name", "IID", EnumCollection.ListItemType.CustomerName);            
        }

        protected void btnShow_Click(object sender, EventArgs e)
        {
            DateTime fromDate = Convert.ToDateTime(txtStartDate.Text + " 12:00:00 AM");
            DateTime toDate = Convert.ToDateTime(txtEndDate.Text + " 11:59:59 PM");


            LoadPaymentListView(fromDate, toDate);
        }

        private void LoadPaymentListView(DateTime fromDate, DateTime toDate)
        {
            List<Payment> list = new List<Payment>();

            //if(!string.IsNullOrEmpty(txtStartDate.Text))
            //    fromDate = Convert.ToDateTime(DateTime.Now.ToShortDateString() + " 12:00:00 AM");
            //if(!string.IsNullOrEmpty(txtEndDate.Text))
            //    toDate = Convert.ToDateTime(DateTime.Now.ToShortDateString() + " 11:59:59 PM");

            using (TheFacade _facade = new TheFacade())
            {
                list = _facade.TicketSaleFacade.GetPaymentBySearchParam(txtReceived.Text, txtTransactionNo.Text, fromDate, toDate, Convert.ToInt32(EnumCollection.ReferenceType.Customer), Convert.ToInt64(ddlCustomer.SelectedValue), CurrentBranchID);
            }
            if (Convert.ToInt32(Session["UserTypeID"].ToString()) == Convert.ToInt32(EnumCollection.UserType.Admin))
            {

            }
            else if (Convert.ToInt32(Session["UserTypeID"].ToString()) == Convert.ToInt32(EnumCollection.UserType.Branch_User))
            {
                list = list.Where(l => l.BranchID == Convert.ToInt32(Session["BranchID"].ToString())).ToList();
            }
            lvReceivable.DataSource = list.OrderByDescending(p => p.PaymentDate).ToList();
            lvReceivable.DataBind();
        }

        protected void lvReceivable_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            if (e.Item.ItemType == ListViewItemType.DataItem)
            {
                ListViewDataItem item = (ListViewDataItem)e.Item;

                Label lblDate = (Label)item.FindControl("lblDate");
                LinkButton lnkbtnReceivedNo = (LinkButton)item.FindControl("lnkbtnReceivedNo");
                Label lblTransactionNo = (Label)item.FindControl("lblTransactionNo");
                Label lblCustomerName = (Label)item.FindControl("lblCustomerName");
                Label lblTicketPrice = (Label)item.FindControl("lblTicketPrice");
                Label lblTAXAmount = (Label)item.FindControl("lblTAXAmount");
                Label lblCustomerReceivable = (Label)item.FindControl("lblCustomerReceivable");                
                Label lblCustomerReceived = (Label)item.FindControl("lblCustomerReceived");
                Label lblCustomerDue = (Label)item.FindControl("lblCustomerDue");
                Label lblNextReceivableDate = (Label)item.FindControl("lblNextReceivableDate");
                Payment payment = (Payment)((ListViewDataItem)(e.Item)).DataItem;
                //LinkButton lnkbtnTransactionNo = (LinkButton)item.FindControl("lnkbtnTransactionNo");

                lblDate.Text = payment.PaymentDate.ToShortDateString();
                //lblTransactionNo.Text = payment.TicketSale.TransactionNo;
                lblCustomerName.Text = payment.Customer.Name;
                //lblTicketPrice.Text = payment.TicketSale.TicketPriceInTaka.ToString();
                //lblTAXAmount.Text = payment.TicketSale.TAX.ToString();
                //lblCustomerReceivable.Text = payment.TicketSale.CustomerReceivable.ToString();                
                lblCustomerReceived.Text = payment.PaidAmount.ToString();
                lblCustomerDue.Text = payment.LastDueAmount.ToString();
                if (payment.NextPaymentDate != null)
                {
                    if (payment.NextPaymentDate == DateTime.MinValue)
                        lblNextReceivableDate.Text = string.Empty;
                    else
                    {
                        string date = payment.NextPaymentDate.ToString();
                        lblNextReceivableDate.Text = Convert.ToDateTime(date).ToShortDateString();
                    }
                }
                else
                {
                    lblNextReceivableDate.Text = string.Empty;
                }
                lnkbtnReceivedNo.Text = payment.PaymentNo;
                lnkbtnReceivedNo.CommandArgument = payment.IID.ToString();
                lnkbtnReceivedNo.CommandName = "DoEdit";

            }
        }
    }
}