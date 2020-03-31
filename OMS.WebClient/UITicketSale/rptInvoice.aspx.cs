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

namespace OMS.WebClient.UITicketSale
{
    public partial class rptInvoice : System.Web.UI.Page
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
                if (!IsPostBack)
                {
                    if (Request.QueryString["ticketSaleID"] != null)
                    {
                        using (TheFacade _facade = new TheFacade())
                        {

                            TicketSale ticketSale = _facade.TicketSaleFacade.GetTicketSaleByID(Convert.ToInt64(Request.QueryString["ticketSaleID"].ToString()));
                            lblDate.Text = ticketSale.TransactionDate.ToShortDateString();
                            lblTransactionNo.Text = ticketSale.TransactionNo;
                            lblBillTo.Text = ticketSale.Customer.Name;
                            //lblCustomerName.Text = ticketSale.PassengerName;
                            lblAddress.Text = ticketSale.Customer.Address;
                            //lblTAX.Text = ticketSale.TAX.ToString("0.00");
                            //lblTicketAmount.Text = ticketSale.TicketPriceInTaka.ToString("0.00");
                            //lblAirlines.Text = ticketSale.Supplier.Name;
                            //lblTicketNo.Text = ticketSale.TicketNo;
                            //lblDeparture.Text = ticketSale.Departure;
                            //lblDestination.Text = ticketSale.Destination;
                            //lblAmount.Text = (ticketSale.TicketPriceInTaka + ticketSale.TAX).ToString("0.00");
                            lblTotalAmount.Text = (ticketSale.TicketPriceInTaka + ticketSale.TAX).ToString("0.00");
                            lblDiscount.Text = "(" + ticketSale.CustomerDiscountInAmount.ToString("0.00") + ")";
                            lblNetAmount.Text = (ticketSale.TicketPriceInTaka + ticketSale.TAX - ticketSale.CustomerDiscountInAmount).ToString("0.00");
                            //lblPayableAmount.Text = ticketSale.CustomerReceivable.ToString("0.00");
                            //lblPaidAmount.Text = ticketSale.CustomerPaid.ToString("0.00");
                            //lblDueAmount.Text = ticketSale.CustomerDue.ToString();
                            if (ticketSale.IssueDate != null)
                            {
                                string issueDate = ticketSale.IssueDate.ToString();
                                lblIssueDate.Text = Convert.ToDateTime(issueDate).ToShortDateString();
                            }
                            if (ticketSale.DepartureDate != null)
                            {
                                string departureDate = ticketSale.DepartureDate.ToString();
                                lblDepat.Text = Convert.ToDateTime(departureDate).ToShortDateString();
                            }
                            if (ticketSale.ReturnDate != null)
                            {
                                string returnDate = ticketSale.ReturnDate.ToString();
                                lblReturnDate.Text = Convert.ToDateTime(returnDate).ToShortDateString();
                            }
                            if (ticketSale.Sector != null)
                            {
                                lblSector.Text = ticketSale.Sector;
                            }
                            lblCarrier.Text = ticketSale.Supplier.Name;
                            lblClass.Text = ticketSale.TicketClass.Name;

                            string inWord = CommonClass.TranslateNumber(Convert.ToDecimal(lblNetAmount.Text));
                            lblTakaInWord.Text = inWord.Substring(0, 1).ToUpper() + inWord.Substring(1).ToLower()+ " Only.";; // add money unit such as taka or dollar here...

                            if (Session["BranchName"] != null)
                            {
                                lblBranchName.Text = "Name of Branch: " + Session["BranchName"].ToString();
                            }

                            List<TicketSaleDetail> ticketSaleDetailList = new List<TicketSaleDetail>();
                            ticketSaleDetailList = _facade.TicketSaleFacade.GetTicketSaleDetailListByTicketSaleID(ticketSale.IID);
                            lvTicketSaleDetail.DataSource = ticketSaleDetailList;
                            lvTicketSaleDetail.DataBind();
                        }
                    }
                    //string inWord = TranslateNumber(Convert.ToDecimal(1320.20));
                    //string inWord = TranslateNumber(Convert.ToDecimal(198779.00531)); 
                    //lblTakaInWord.Text = inWord.Substring(0,1).ToUpper()+inWord.Substring(1).ToLower();
                }
            }
        }

        int lvRowCountDesig = 0;
        protected void lvTicketSaleDetail_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            if (e.Item.ItemType == ListViewItemType.DataItem)
            {
                lvRowCountDesig += 1;
                ListViewDataItem item = (ListViewDataItem)e.Item;
                TicketSaleDetail ticketSaleDetail = (TicketSaleDetail)((ListViewDataItem)(e.Item)).DataItem;
                Label lblSerial = (Label)item.FindControl("lblSerial");
                Label lblPassengerName = (Label)item.FindControl("lblPassengerName");
                Label lblTicketNo = (Label)item.FindControl("lblTicketNo");
                Label lblTicketFairInUSD = (Label)item.FindControl("lblTicketFairInUSD");
                Label lblTicketFair = (Label)item.FindControl("lblTicketFair");
                Label lblTAXAmount = (Label)item.FindControl("lblTAXAmount");
                Label lblSubTotal = (Label)item.FindControl("lblSubTotal");               

                lblSerial.Text = lvRowCountDesig.ToString();
                lblPassengerName.Text = ticketSaleDetail.PassengerName;
                lblTicketNo.Text = ticketSaleDetail.TicketNo;
                lblTicketFairInUSD.Text = ticketSaleDetail.TicketPriceInUSD.ToString();
                lblTicketFair.Text = ticketSaleDetail.TicketPrice.ToString();
                lblTAXAmount.Text = ticketSaleDetail.Tax.ToString();
                lblSubTotal.Text = ticketSaleDetail.TotalAmount.ToString();         
            }

        }

        protected void btnPrint_Click(object sender, EventArgs e)
        {
            Session["ctrl"] = pnlPrint;
            //Session["header"] = this.Page.Title;
            Session["header"] = string.Empty;
            ClientScript.RegisterStartupScript(this.GetType(), "onclick", "<script language=javascript>window.open('../UIAccount/Print.aspx','PrintMe','height=550px,width=750px,scrollbars=1');</script>");
             
        }
    }
}
