using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using OMS.DAL;
using OMS.Facade;
using OMS.Framework;

namespace OMS.WebClient.Controls
{
    public partial class wucReportSale : System.Web.UI.UserControl
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
                }
            }
        }

        protected void btnPrint_Click(object sender, EventArgs e)
        {
            Session["ctrl"] = pnlPrint;
            //Session["header"] = this.Page.Title;
            Session["header"] = string.Empty;
            Page.ClientScript.RegisterStartupScript(this.GetType(), "onclick", "<script language=javascript>window.open('../UIAccount/Print.aspx','PrintMe','height=550px,width=750px,scrollbars=1');</script>");
        }

        protected void btnShow_Click(object sender, EventArgs e)
        {
            LoadListView();
            DateTime fromDate = DateTime.Now;
            DateTime toDate = DateTime.Now;
            if (!string.IsNullOrEmpty(txtStartDate.Text))
                fromDate = Convert.ToDateTime(txtStartDate.Text + " 12:00:00 AM");
            if (!string.IsNullOrEmpty(txtEndDate.Text))
                toDate = Convert.ToDateTime(txtEndDate.Text + " 11:59:59 PM");

            lblDate.Text = Convert.ToDateTime(fromDate).ToString("dd/MM/yyyy") + " to " + Convert.ToDateTime(toDate).ToString("dd/MM/yyyy"); 
        }

        private void LoadListView()
        {
            List<BranchInfo> branchList = new List<BranchInfo>();
            using (TheFacade _facade = new TheFacade())
            {
                branchList = _facade.CommonFacade.GetBranchInfoAll();
            }
            if (CurrentBranchID >= 1)
            {
                branchList = branchList.Where(b => b.IID == CurrentBranchID).ToList();
            }
            lvBranch.DataSource = branchList;
            lvBranch.DataBind();
            //List<TicketSale> list = new List<TicketSale>();

            //DateTime fromDate = DateTime.MinValue;
            //DateTime toDate = DateTime.MinValue;
            //if (!string.IsNullOrEmpty(txtStartDate.Text))
            //    fromDate = Convert.ToDateTime(txtStartDate.Text + " 12:00:00 AM");
            //if (!string.IsNullOrEmpty(txtEndDate.Text))
            //    toDate = Convert.ToDateTime(txtEndDate.Text + " 11:59:59 PM");

            //using (TheFacade _facade = new TheFacade())
            //{
            //    list = _facade.TicketSaleFacade.GetTicketSaleBySearchParam(txtTransactionNo.Text, fromDate, toDate);
            //}
            ////list = list.Where(ts => ts.TransactionNo.Contains(txtTransactionNo.Text)  && ts.TransactionDate.Date >= fromDate && ts.TransactionDate.Date <= toDate).ToList();
            //list = list.Where(ts => (CurrentBranchID <= 0 || (CurrentBranchID > 0 && ts.BranchID == CurrentBranchID))).ToList();
            //lvTicketSale.DataSource = list.OrderByDescending(ts => ts.TransactionDate).ToList();
            //lvTicketSale.DataBind();
        }

        protected void lvBranch_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            if (e.Item.ItemType == ListViewItemType.DataItem)
            {
                ListViewDataItem currentItem = (ListViewDataItem)e.Item;

                BranchInfo branch = (BranchInfo)((ListViewDataItem)(e.Item)).DataItem;

                Label lblBranch = (Label)currentItem.FindControl("lblBranch");                
                ListView lvTicketSale = (ListView)currentItem.FindControl("lvTicketSale");

                lblBranch.Text = "Branch Name: "+ branch.Name;
                
                //TicketSale
                List<TicketSale> list = new List<TicketSale>();
                DateTime fromDate = DateTime.Now;
                DateTime toDate = DateTime.Now;
                if (!string.IsNullOrEmpty(txtStartDate.Text))
                    fromDate = Convert.ToDateTime(txtStartDate.Text + " 12:00:00 AM");
                if (!string.IsNullOrEmpty(txtEndDate.Text))
                    toDate = Convert.ToDateTime(txtEndDate.Text + " 11:59:59 PM");

                using (TheFacade _facade = new TheFacade())
                {
                    list = _facade.TicketSaleFacade.GetTicketSaleBySearchParam(txtTransactionNo.Text, fromDate, toDate);


                    list = list.Where(ts => (branch.IID <= 0 || (branch.IID > 0 && ts.BranchID == branch.IID))).ToList();

                    lvTicketSale.DataSource = list.OrderByDescending(ts => ts.TransactionDate).ToList();
                    lvTicketSale.DataBind();


                    //Label lblTotalQty = (Label)currentItem.FindControl("lblTotalQty");
                    Label lblTotalTaxAmount = (Label)currentItem.FindControl("lblTotalTaxAmount");
                    Label lblTotalTicketFair = (Label)currentItem.FindControl("lblTotalTicketFair");
                    Label lblTotalTotal = (Label)currentItem.FindControl("lblTotalTotal");
                    Label lblTotalNormalCommission = (Label)currentItem.FindControl("lblTotalNormalCommission");
                    Label lblTotalExcessCommission = (Label)currentItem.FindControl("lblTotalExcessCommission");
                    Label lblTotalTotalDiscount = (Label)currentItem.FindControl("lblTotalTotalDiscount");

                    Label lblTotalNetCommission = (Label)currentItem.FindControl("lblTotalNetCommission");
                    Label lblTotalNetTicketValue = (Label)currentItem.FindControl("lblTotalNetTicketValue");

                    Label lblTotalDueAmount = (Label)currentItem.FindControl("lblTotalDueAmount");

                    decimal totalTaxAmount = 0;
                    decimal totalTicketFair = 0;
                    decimal totalAmount = 0;
                    decimal totalNormalCommission = 0;
                    decimal totalExcessCommission = 0;
                    decimal totalDiscount = 0;
                    decimal totalNetCommission = 0;
                    decimal totalNetTicketValue = 0;

                    decimal totalDueAmount = 0;

                    foreach (TicketSale ts in list)
                    {
                        totalTaxAmount += ts.TAX;
                        totalTicketFair += ts.TicketPriceInTaka;
                        totalAmount += ts.TAX + ts.TicketPriceInTaka;
                        totalDiscount += ts.TotalDiscount;
                        
                        totalNetTicketValue += (ts.TAX + ts.TicketPriceInTaka) - ts.TotalDiscount;
                        totalDueAmount += ts.CustomerDue;

                        AirlinesCommission airCom = new AirlinesCommission();
                        airCom = _facade.TicketSaleFacade.GetAirlinesCommission(ts.AirlinesID);

                        decimal airLinesCom = 0;
                        //Add Normal Commission
                        if (airCom != null && airCom.IID > 0)
                        {
                            if (airCom.NormalCommissionType == Convert.ToInt32(EnumCollection.AmountType.In_Percentage))
                            {
                                airLinesCom = (airCom.NormalCommission * ts.TicketPriceInTaka) / 100;
                            }
                            else
                            {
                                airLinesCom = airCom.NormalCommission;
                            }
                            totalNormalCommission += airLinesCom;
                            decimal airPrice = ts.TicketPriceInTaka - airLinesCom;
                            //Add Excess Commission
                            airLinesCom = 0;
                            if (airCom.ExcessCommissionType != null && airCom.ExcessCommissionType > 0)
                            {
                                if (airCom.ExcessCommissionType == Convert.ToInt32(EnumCollection.AmountType.In_Percentage))
                                {
                                    //Null Check   // check null //DBnull Check
                                    airLinesCom = (Convert.ToDecimal(airCom.ExcessCommission == null ? 0 : airCom.ExcessCommission) * airPrice) / 100;
                                }
                                else
                                {
                                    airLinesCom = Convert.ToDecimal(airCom.ExcessCommission == null ? 0 : airCom.ExcessCommission);
                                }
                            }
                        }
                        totalExcessCommission += airLinesCom;
                    }
                    if (list.Count > 0)
                    {
                        //totalNetCommission += totalNormalCommission + totalExcessCommission;
                        //lblTotalTaxAmount.Text = "Tax: " + totalTaxAmount.ToString("0.00");
                        //lblTotalTicketFair.Text = "Ticket Fair: " + totalTicketFair.ToString("0.00");
                        //lblTotalTotal.Text = "Total: " + totalAmount.ToString("0.00");
                        //lblTotalNormalCommission.Text = "Normal Comm:" + totalNormalCommission.ToString("0.00");
                        //lblTotalExcessCommission.Text = "Excess Comm: " + totalExcessCommission.ToString("0.00");
                        //lblTotalTotalDiscount.Text = "Discount: " + totalDiscount.ToString("0.00");
                        //lblTotalNetCommission.Text = "Net Comm: " + (totalNormalCommission + totalExcessCommission - totalDiscount).ToString("0.00");
                        //lblTotalNetTicketValue.Text = "Net Ticket Value: " + totalNetTicketValue.ToString("0.00");
                        //lblTotalDueAmount.Text = "Due Amount: " + totalDueAmount.ToString("0.00");

                        lblTotalTaxAmount.Text = totalTaxAmount.ToString("0.00");
                        lblTotalTicketFair.Text = totalTicketFair.ToString("0.00");
                        lblTotalTotal.Text = totalAmount.ToString("0.00");
                        lblTotalNormalCommission.Text = totalNormalCommission.ToString("0.00");
                        lblTotalExcessCommission.Text = totalExcessCommission.ToString("0.00");
                        lblTotalTotalDiscount.Text = totalDiscount.ToString("0.00");
                        lblTotalNetCommission.Text = (totalNormalCommission + totalExcessCommission - totalDiscount).ToString("0.00");
                        lblTotalNetTicketValue.Text =totalNetTicketValue.ToString("0.00");
                        lblTotalDueAmount.Text = totalDueAmount.ToString("0.00");
                    }
                }
            }
            
        }

        int lvRowCountDesig = 0;
        protected void lvTicketSale_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            if (e.Item.ItemType == ListViewItemType.DataItem)
            {
                ListViewDataItem item = (ListViewDataItem)e.Item;

                lvRowCountDesig += 1;
                Label lblSerial = (Label)item.FindControl("lblSerial");
                lblSerial.Text = lvRowCountDesig.ToString();

                LinkButton lnkbtnTransactionNo = (LinkButton)item.FindControl("lnkbtnTransactionNo");
                Label lblCustomerName = (Label)item.FindControl("lblCustomerName");
                //Label lblAirliesName = (Label)item.FindControl("lblAirlinesName");
                Label lblDeparture = (Label)item.FindControl("lblDeparture");
                Label lblDestination = (Label)item.FindControl("lblDestination");
                //Label lblAmountInUSD= (Label)item.FindControl("lblAmountInUSD");
                //Label lblUSDRate = (Label)item.FindControl("lblUSDRate");

                //Label lblQty = (Label)item.FindControl("lblQty");
                Label lblTaxAmount = (Label)item.FindControl("lblTaxAmount");
                Label lblAmountInTaka = (Label)item.FindControl("lblAmountInTaka");                
                Label lblNormalCommission = (Label)item.FindControl("lblNormalCommission");
                Label lblExcessCommission = (Label)item.FindControl("lblExcessCommission");
                //Label lblCustomerDiscount = (Label)item.FindControl("lblCustomerDiscount");
                Label lblNetCommission = (Label)item.FindControl("lblNetCommission");
                Label lblTotalDiscount = (Label)item.FindControl("lblTotalDiscount");
                //Label lblAirlinesNetPayable = (Label)item.FindControl("lblAirlinesNetPayable");
                Label lblNetTicketValue = (Label)item.FindControl("lblNetTicketValue");
                //Label lblCustomerReceivableDate = (Label)item.FindControl("lblCustomerReceivableDate");
               // Label lblAirlinesPayableDate = (Label)item.FindControl("lblAirlinesPayableDate");
                TicketSale ticketSale = (TicketSale)((ListViewDataItem)(e.Item)).DataItem;
                //LinkButton lnkbtnTransactionNo = (LinkButton)item.FindControl("lnkbtnTransactionNo");

                //lblDate.Text = ticketSale.TransactionDate.ToShortDateString();                
                //lblAirlinesName.Text = ticketSale.Supplier.Name;
                lblCustomerName.Text = ticketSale.Customer.Name;
                lblDeparture.Text = ticketSale.Departure;
                lblDestination.Text = ticketSale.Destination;
                //using (TheFacade _facade = new TheFacade())
                //{
                //    Customer customer = new Customer();
                //    customer = _facade.CustomerFacade.GetCustomerByID(ticketSale.ReferenceID);
                //    if (customer != null)
                //        lblCustomerName.Text = customer.Name;
                //}
                //lblAmountInUSD.Text = ticketSale.TicketPriceInUSD.ToString();
                //lblUSDRate.Text = ticketSale.USDRate.ToString();
                //lblQty.Text = "1";
                lblTaxAmount.Text = ticketSale.TAX.ToString();
                lblAmountInTaka.Text = ticketSale.TicketPriceInTaka.ToString();
                //lblCustomerDiscount.Text = ticketSale.CustomerDiscount.ToString();
                lblNetCommission.Text = ticketSale.AirLinesCommissionInAmount.ToString();
                lblTotalDiscount.Text = ticketSale.CustomerDiscountInAmount.ToString();
                lblNetTicketValue.Text = ticketSale.CustomerReceivable.ToString();

                //lblCustomerReceivableDate.Text = ticketSale.CustomerReceivableDate.ToString();
                //lblAirlinesNetPayable.Text = ticketSale.AirlinesPayable.ToString();
                //lblAirlinesPayableDate.Text = ticketSale.AirlinesPaymentDate.ToShortDateString();
                
                lnkbtnTransactionNo.Text = ticketSale.TransactionNo;
                lnkbtnTransactionNo.CommandArgument = ticketSale.IID.ToString();
                lnkbtnTransactionNo.CommandName = "DoEdit";

                using (TheFacade _facade = new TheFacade())
                {
                    AirlinesCommission airCom = new AirlinesCommission();
                    airCom = _facade.TicketSaleFacade.GetAirlinesCommission(ticketSale.AirlinesID);
                    
                    decimal airLinesCom = 0;
                    //Add Normal Commission
                    if (airCom != null && airCom.IID > 0)
                    {
                        if (airCom.NormalCommissionType == Convert.ToInt32(EnumCollection.AmountType.In_Percentage))
                        {
                            airLinesCom = (airCom.NormalCommission * ticketSale.TicketPriceInTaka) / 100;
                        }
                        else
                        {
                            airLinesCom = airCom.NormalCommission;
                        }
                        lblNormalCommission.Text = airLinesCom.ToString();
                        decimal airPrice = ticketSale.TicketPriceInTaka - airLinesCom;
                        //Add Excess Commission
                        airLinesCom = 0;
                        if (airCom.ExcessCommissionType != null && airCom.ExcessCommissionType > 0)
                        {
                            if (airCom.ExcessCommissionType == Convert.ToInt32(EnumCollection.AmountType.In_Percentage))
                            {
                                //Null Check   // check null //DBnull Check
                                airLinesCom = (Convert.ToDecimal(airCom.ExcessCommission == null ? 0 : airCom.ExcessCommission) * airPrice) / 100;
                            }
                            else
                            {
                                airLinesCom = Convert.ToDecimal(airCom.ExcessCommission == null ? 0 : airCom.ExcessCommission);
                            }
                        }
                    }
                    lblExcessCommission.Text = airLinesCom.ToString();
                }
            }
        }

        
    }
}