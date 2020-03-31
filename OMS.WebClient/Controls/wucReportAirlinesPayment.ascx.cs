using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using OMS.Facade;
using OMS.DAL;
using OMS.Framework;
using OMS.Web.Helpers;

namespace OMS.WebClient.Controls
{
    public partial class wucReportAirlinesPayment : System.Web.UI.UserControl
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
            List<Supplier> list = new List<Supplier>();
            using(TheFacade _facade= new TheFacade())
            {
                list = _facade.SupplierFacade.GetSupplierAll().Where(s=>s.SupplierType == Convert.ToInt32(EnumCollection.SupplierType.Airlines)).ToList();
            }
            DDLHelper.Bind<Supplier>(ddlAirlinesName, list, "Name", "IID", EnumCollection.ListItemType.SupplierName);
        }

        protected void btnShow_Click(object sender, EventArgs e)
        {
            DateTime fromDate = Convert.ToDateTime(txtStartDate.Text + " 12:00:00 AM");
            DateTime toDate = Convert.ToDateTime(txtEndDate.Text + " 11:59:59 PM");


            LoadPaymentListView(fromDate,toDate);
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
                list = _facade.TicketSaleFacade.GetPaymentBySearchParam(txtPayment.Text, txtTransactionNo.Text, fromDate, toDate, Convert.ToInt32(EnumCollection.ReferenceType.Supplier), Convert.ToInt64(ddlAirlinesName.SelectedValue), CurrentBranchID);
            }

            lvPayment.DataSource = list.OrderByDescending(p => p.PaymentDate).ToList();
            lvPayment.DataBind();
        }

        protected void lvPayment_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            if (e.Item.ItemType == ListViewItemType.DataItem)
            {
                ListViewDataItem item = (ListViewDataItem)e.Item;

                Label lblDate = (Label)item.FindControl("lblDate");
                LinkButton lnkbtnPaymentNo = (LinkButton)item.FindControl("lnkbtnPaymentNo");
                Label lblTransactionNo = (Label)item.FindControl("lblTransactionNo");
                Label lblAirlinesName = (Label)item.FindControl("lblAirlinesName");
                Label lblTicketPrice = (Label)item.FindControl("lblTicketPrice");
                Label lblAirlinesPayable = (Label)item.FindControl("lblAirlinesPayable");
                Label lblTAXAmount = (Label)item.FindControl("lblTAXAmount");
                Label lblAirlinesPaid = (Label)item.FindControl("lblAirlinesPaid");
                Label lblAirlinesDue = (Label)item.FindControl("lblAirlinesDue");
                Label lblNextPaymentDate = (Label)item.FindControl("lblNextPaymentDate");
                Payment payment = (Payment)((ListViewDataItem)(e.Item)).DataItem;
                //LinkButton lnkbtnTransactionNo = (LinkButton)item.FindControl("lnkbtnTransactionNo");

                lblDate.Text = payment.PaymentDate.ToShortDateString();
                //lblTransactionNo.Text = payment.TicketSale.TransactionNo;
                lblAirlinesName.Text = payment.Supplier.Name;
                //lblTicketPrice.Text = payment.TicketSale.TicketPriceInTaka.ToString();
                //lblAirlinesPayable.Text = payment.TicketSale.AirlinesPayable.ToString();
                //lblTAXAmount.Text = payment.TicketSale.TAX.ToString();
                lblAirlinesPaid.Text = payment.PaidAmount.ToString();
                lblAirlinesDue.Text = payment.LastDueAmount.ToString();
                if (payment.NextPaymentDate != null)
                {
                    if (payment.NextPaymentDate == DateTime.MinValue)
                        lblNextPaymentDate.Text = string.Empty;
                    else
                    {
                        string date = payment.NextPaymentDate.ToString();
                        lblNextPaymentDate.Text = Convert.ToDateTime(date).ToShortDateString();
                    }
                }
                else                
                {
                    lblNextPaymentDate.Text = string.Empty;
                }
                lnkbtnPaymentNo.Text = payment.PaymentNo;
                lnkbtnPaymentNo.CommandArgument = payment.IID.ToString();
                lnkbtnPaymentNo.CommandName = "DoEdit";

            }
        }

    }
}