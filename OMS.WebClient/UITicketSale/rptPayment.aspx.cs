﻿using System;
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
using System.Collections.Generic;
using OMS.Framework;

namespace OMS.WebClient.UITicketSale
{
    public partial class rptPayment : System.Web.UI.Page
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
                    if (Request.QueryString["paymentID"] != null)
                    {
                        using (TheFacade _facade = new TheFacade())
                        {

                            Payment payment = _facade.TicketSaleFacade.GetPaymentByID(Convert.ToInt64(Request.QueryString["paymentID"].ToString()), Convert.ToInt32(EnumCollection.ReferenceType.Supplier));
                            lblDate.Text = payment.PaymentDate.ToShortDateString();
                            lblPaymentNo.Text = payment.PaymentNo;
                            //lblBillNo.Text = payment.TicketSale.BillNo;


                            //TicketSale ticketSale = new TicketSale();
                            //ticketSale = _facade.TicketSaleFacade.GetTicketSaleByID(payment.TicketSaleID);
                            lblAddress.Text = payment.Supplier.Address;
                            lblAirlines.Text = payment.Supplier.Name;
                            //lblTicketNo.Text = payment.TicketSale.TicketNo;


                            List<Payment> list = new List<Payment>();
                            decimal paidAmount = 0;
                            //list = _facade.TicketSaleFacade.GetPaymentListByTicketSaleID(ticketSale.IID, Convert.ToInt32(EnumCollection.ReferenceType.Airlines));
                            //if (list.Count > 0)
                            //{
                            //    foreach (Payment _payment in list)
                            //    {
                            //        paidAmount += _payment.PaidAmount;
                            //    }
                            //}
                            //if (paidAmount > 0)
                            //    lblPayableAmount.Text = (ticketSale.CustomerReceivable - paidAmount + payment.PaidAmount).ToString();
                            //else
                            //    lblPayableAmount.Text = string.Empty;

                            lblPaidAmount.Text = payment.PaidAmount.ToString("0.00");
                            lblDueAmount.Text = payment.LastDueAmount.ToString();
                            lblPayableAmount.Text = (payment.PaidAmount + payment.LastDueAmount).ToString();


                            string inWord = CommonClass.TranslateNumber(payment.PaidAmount);
                            lblTakaInWord.Text = inWord.Substring(0, 1).ToUpper() + inWord.Substring(1).ToLower() + " Only."; ; // add money unit such as taka or dollar here...

                            if (Session["BranchName"] != null)
                            {
                                lblBranchName.Text = "Name of Branch: " + Session["BranchName"].ToString();
                            }
                        }
                    }
                }
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
