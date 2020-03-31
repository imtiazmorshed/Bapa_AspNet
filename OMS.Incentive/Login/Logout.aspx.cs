using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OMS.Incentive.Login
{
    public partial class Logout : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Session.Abandon();
                Response.Redirect("~/Login/login.aspx");
            }
        }
        public long MemberID
        {
            get
            {
                if (Session["MemberID"] == null)
                    return 0;
                else
                    return Convert.ToInt64(Session["MemberID"]);
            }
        }
    }
}