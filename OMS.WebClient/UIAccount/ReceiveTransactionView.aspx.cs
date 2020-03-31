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

namespace OMS.WebClient.UIAccount
{
    public partial class ReceiveTransactionView : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            AccessHelper helper = new AccessHelper();
            bool hasAccess = helper.HasAccess(Convert.ToInt64(Session["UserID"].ToString()), Convert.ToInt64(Session["RoleID"].ToString()), Convert.ToBoolean(Session["IsRoleBased"].ToString()), this.Page.Title.ToString());
            if (!hasAccess)
            {
                Response.Redirect("~/NoPermission.aspx");
            }


        }
    }
}
