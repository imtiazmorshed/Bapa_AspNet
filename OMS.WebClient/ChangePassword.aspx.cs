using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using OMS.DAL;
using OMS.Facade;
using System.Web.Security;

namespace PTech_BIID.Web
{
    public partial class ChangePassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                

                ClearPasswordControl();
            }
        }

        private void ClearPasswordControl()
        {
            //ChangePassword1.PasswordHintText = string.Empty;
            //string dd = ChangePassword1.PasswordHintText;
        }

        protected void ChangePassword1_ChangedPassword(object sender, EventArgs e)
        {

            //SystemUser systemUser = new SystemUser();
            //using (TheFacade facade = new TheFacade())
            //{
            //    systemUser = facade.AdminFacade.GetByUserName(Session["UserName"].ToString());
            //    systemUser.Password = ChangePassword1.NewPassword.ToString();
            //}
            //MembershipProvider p = Membership.Provider;

          

            //MembershipUser membershipUser = p.GetUser(systemUser.UserName, false);

            //try
            //{
            //    membershipUser.ChangePassword(ChangePassword1.CurrentPassword, ChangePassword1.NewPassword);
            //}
            //catch (Exception ex)
            //{

            //}

        }

        protected void ChangePassword1_ContinueButtonClick(object sender, EventArgs e)
        {

            FormsAuthentication.SignOut();
            Roles.DeleteCookie();
            Session.Abandon();
            Response.Redirect("~/Login.aspx");
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (txtpass.Text.Trim() != txtconpass.Text.Trim())
            {
                lblMsg.Text = "Password missmatch";
                lblMsg.ForeColor = System.Drawing.Color.Red;
                return;
            }
            try
            {
                SystemUser systemUser = new SystemUser();
                using (TheFacade facade = new TheFacade())
                {
                    systemUser = facade.AdminFacade.GetByUserName(Session["UserName"].ToString());
                    bool isvalid = facade.AdminFacade.IsValidUser(Session["UserName"].ToString(), txtoldpass.Text.Trim());
                    if (isvalid)
                    {
                        systemUser.Password = txtpass.Text.Trim();
                        facade.Update<SystemUser>(systemUser);
                        lblMsg.Text = "Password changed..";
                        lblMsg.ForeColor = System.Drawing.Color.Green;
                        btnDone.Visible = true;
                        btnSave.Visible = false;
                    }
                    else
                    {
                        lblMsg.Text = "Your provided old password does not match..";
                        lblMsg.ForeColor = System.Drawing.Color.Red;
                        btnDone.Visible = false;
                        btnSave.Visible = true;
                    }
                }
            }
            catch
            {
                lblMsg.Text = "Password not changed..";
                lblMsg.ForeColor = System.Drawing.Color.Red;
                btnDone.Visible = false;
                btnSave.Visible = true;
            }
        }

        protected void btnDone_Click(object sender, EventArgs e)
        {
            FormsAuthentication.SignOut();
            Roles.DeleteCookie();
            Session.Abandon();
            Response.Redirect("~/Login.aspx");
        }
    }
}
