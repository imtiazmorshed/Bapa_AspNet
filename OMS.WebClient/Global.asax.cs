using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using OMS.DAL;
using OMS.Facade;
using OMS.Framework;

namespace OMS.WebClient
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {

        }

        protected void Session_Start(object sender, EventArgs e)
        {
            //Session.Timeout = 60;
            //if (!Roles.RoleExists("Admin"))
            //{
            //    Roles.CreateRole("Admin");
            //}

            //MembershipUser adminUser = Membership.GetUser("admin");

            //if (adminUser == null)
            //{
            //    MembershipUser newuser = Membership.CreateUser("admin", "admin123", "admin@admin.com");
            //    Roles.AddUserToRole("admin", "Admin");
            //    using (TheFacade facade = new TheFacade())
            //    {
            //        SystemUser admin = new SystemUser();
            //        admin.UserName = "admin";

            //        admin.UserTypeID = (int)EnumCollection.UserType.Admin;
            //        admin.IsRemoved = 0;
            //        admin.CreatedDate = DateTime.Now;
            //        admin.ProviderKey = newuser.ProviderUserKey.ToString();

            //        admin.FirstName = "Admin";
            //        admin.LastName = "Admin";
            //        admin.Email = "admin@admin.com";
            //        admin.CreatedDate = DateTime.Now;
            //        admin.CreatedBy = -1;
            //        admin.UpdatedDate = DateTime.Now;
            //        admin.UpdatedBy = -1;
            //        admin.IsRoleBased = true;
            //        admin.Roles = "Admin";
            //        admin.Status = true;
            //        facade.Insert<SystemUser>(admin);                    
            //    }
            //}
            //using (TheFacade facade = new TheFacade())
            //{
            //    List<SystemRole> roleList = facade.SecurityFacade.GetAllRoles();
            //    if (roleList.Count == 0)
            //    {
            //        string[] roles = Roles.GetAllRoles();
            //        foreach (string memrole in roles)
            //        {
            //            SystemRole role = new SystemRole();
            //            role.RoleName = memrole;
            //            role.IsRemoved = 0;
            //            facade.Insert<SystemRole>(role);
            //        }
            //    }
            //}
        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {
            //Exception err = Server.GetLastError();
            //if (err.GetType() == typeof(System.Security.SecurityException))
            //{
            //    Session["SecurityErr"] = "You have no access right to view the page ";
            //    Session["url"] = Request.Path;
            //    Response.Redirect("~/NoPermission.aspx?url=" + Request.Path);

            //}
            //else
            //{
            //    Response.Redirect("~/login.aspx");
            //}
        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}