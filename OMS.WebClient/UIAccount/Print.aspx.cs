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
using OMS.Framework;

namespace OMS.WebClient.UIAccount
{
    public partial class Print : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            System.Web.UI.Control ctrl = (System.Web.UI.Control)Session["ctrl"];
            PrintHelper.PrintWebControl(ctrl, Session["header"].ToString());
        }
    }
}
