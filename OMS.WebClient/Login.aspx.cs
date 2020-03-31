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


public partial class LogIn : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["msgSessionOut"] != null && Request.QueryString["msgSessionOut"].ToString() != string.Empty)
        {
            lblMgs.Text = "Your Session Time Out !!! Please Login Again.";

        }
    }

    protected void btnLogin_Click(object sender, EventArgs e)
    {
        //if (txtUserName.Text == "admin")
        //{
        //    if (txtPassword.Text == "admin123")
        //    {
        //        Response.Redirect("UIAccount\\ChartOfAccountView.aspx");
        //    }
        //}
        
        //lblMgs.Text = "";
        //if (Membership.ValidateUser(txtUserName.Text.Trim(), txtPassword.Text.Trim()))
        //{
            bool success = false;
            string userName = txtUserName.Text.Trim();
            //FormsAuthentication.SetAuthCookie(userName.Trim(), false);
            using (TheFacade facade = new TheFacade())
            {
                if (facade.AdminFacade.IsValidUser(userName, txtPassword.Text.Trim()))
                {
                    try
                    {
                        //string uP = Membership.GetUser("admin").ProviderUserKey.ToString();

                        SystemUser lUser = facade.AdminFacade.GetByUserName(userName);

                        Session["UserID"] = lUser.IID.ToString();
                        Session["UserTypeID"] = lUser.UserTypeID.ToString();
                        Session["UserName"] = lUser.UserName;
                        Session["RoleID"] = lUser.RoleID.ToString();
                        Session["IsRoleBased"] = lUser.IsRoleBased.ToString();
                        if(lUser.BranchID!=null)
                        {
                            BranchInfo branchInfo = new BranchInfo();
                            branchInfo = facade.CommonFacade.GetBranchInfoByID(lUser.BranchID);
                            if (branchInfo != null)
                            {
                                Session["BranchID"] = branchInfo.IID.ToString();
                                Session["BranchName"] = branchInfo.Name;
                            }
                        }
                        //FormsAuthentication.SetAuthCookie(userName, false);

                        success = true;

                    }
                    catch
                    {
                        Response.Redirect(Request.Url.ToString() + "?fault=true");
                    }
                    if (!success)
                    {
                        Response.Redirect(Request.Url.ToString() + "?fault=true");
                    }
                    else
                    {
                        Response.Redirect("EHishabHome.aspx");
                    }
                }
                else
                {
                    Response.Redirect(Request.Url.ToString() + "?fault=true");
                }
            }

        //}
        //else
        //{
        //    Response.Redirect(Request.Url.ToString() + "?fault=true");
        //}
        //lblMgs.Text = "Invalid Username/Password.";
         

    }
    
}
