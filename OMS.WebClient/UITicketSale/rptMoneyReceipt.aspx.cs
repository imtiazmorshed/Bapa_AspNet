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

namespace OMS.WebClient.UITicketSale
{
    public partial class rptMoneyReceipt : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

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
