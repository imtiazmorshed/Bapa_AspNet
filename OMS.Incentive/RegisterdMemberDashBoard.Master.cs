using OMS.DAL;
using OMS.Facade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OMS.Incentive
{
    public partial class RegisterdMemberDashBoard : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["MemberID"] == null)
                {
                    Session.Abandon();
                    //Response.Redirect("~/Login/login.aspx?returnurl="+Request.Url );
                    Response.Redirect("~/Login/login.aspx");
                }
                else
                {
                    GetMemberName();
                }
            }
           
            //lblMemberName.Text = MemberID.ToString();
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


        public void GetMemberName()
        {            
            Member member = new Member();
            using (TheFacade facade = new TheFacade())
            {
                member = facade.MemberFacade.GetMemberById(MemberID);
                lblMemberName.Text = member.Email;
            }
        }
    }
}