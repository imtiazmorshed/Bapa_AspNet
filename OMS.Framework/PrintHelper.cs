using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI;
using System.IO;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Web;

namespace OMS.Framework
{
    public class PrintHelper
    {
        PrintHelper()
        {

        }

        public static void PrintWebControl(Control ctrl,string header)
        {
            PrintWebControl(ctrl, string.Empty, header);
        }

        public static void PrintWebControl(Control ctrl, string Script, string header)
        {
            StringWriter stringWrite = new StringWriter();
            System.Web.UI.HtmlTextWriter htmlWrite = new System.Web.UI.HtmlTextWriter(stringWrite);
            if (ctrl is WebControl)
            {
                Unit w = new Unit(100, UnitType.Percentage); ((WebControl)ctrl).Width = w;
            }
            Page pg = new Page();
            pg.EnableEventValidation = false;
            if (Script != string.Empty)
            {
                pg.ClientScript.RegisterStartupScript(pg.GetType(), "PrintJavaScript", Script);
            }
            HtmlForm frm = new HtmlForm();
            pg.Controls.Add(frm);
            frm.Attributes.Add("runat", "server");
            frm.Controls.Add(ctrl);
            pg.DesignerInitialize();
            pg.RenderControl(htmlWrite);
            string strHTML = stringWrite.ToString();
            HttpContext.Current.Response.Clear();
            string css = string.Format("<link href=\"../App_Themes/Default/_lib/css/style.css\" rel=\"stylesheet\" type=\"text/css\" />");
            HttpContext.Current.Response.Write(css);//("<link href=\"printcss/print.css\" rel=\"Stylesheet\" media=\"print,screen\" type=\"text/css\" />");

            //HttpContext.Current.Response.Write("<TABLE width=100%><TR><TD></TD></TR><TR><TD align=right><INPUT ID='CLOSE' type='button' value='Close' onclick='window.close();'></TD></TR><TR><TD></TD></TR></TABLE>");
            HttpContext.Current.Response.Write("<TABLE class=\"testTable\"  width=100%><TR><TD></TD></TR><TR><TD></TD></TR></TABLE>");
            string strHTMLLogo = " <table width='100%' > "+
                    "<tr> "+
                     "   <td align='center'> "+
                      "  <img alt='" + header + "' src='Images/eHishabLogo.JPG' />" +
                       " </td>"+
                    "</tr>"+
                "</table>";
            HttpContext.Current.Response.Write(strHTMLLogo);
            HttpContext.Current.Response.Write(strHTML);
            
            HttpContext.Current.Response.Write("<script>window.print();</script>");
            HttpContext.Current.Response.End();
        }


    }
}
