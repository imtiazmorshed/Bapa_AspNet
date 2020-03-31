using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using OMS.Framework;
using OMS.DAL;
namespace OMS.Facade
{
    public interface IAdminFacade
    {
        #region System User
        bool IsValidUser(string userName, string password);
        SystemUser GetByUserName(string userName);
        SystemUser GetySystemUserID(long systemUserID);
        SystemUser GetySystemUserByIDForUserStatus(long systemUserID);
        List<SystemUser> GetSystemUserAll();
        List<SystemPage> GetSystemPageAll();
        List<PagesOnUser> GetSystemPageByUserID(long lnUserID);
        List<SystemRole> GetSystemRoleAll();
        SystemRole GetRoleByIIDWithPages(long iid);
        List<PagesOnRole> GetSystemPageByRoleID(long lnRoleID);
        #endregion



        List<SystemPage> GetPageListByRole(long roleID);

        List<SystemPage> GetPageListByUser(long userID);

        SystemPage GetPageByRoleAndPageName(long roleID,string pageName);

        SystemPage GetPageByUserAndPageName(long roleID, string pageName);
        SystemUser IsValidUserorPass(string userName, string password);
    }
    class AdminFacade : BaseFacade, IAdminFacade
    {
        public AdminFacade(OMSDataContext database)
            : base(database)
        {
        }

        public bool IsValidUser(string userName, string password)
        {
            bool isValid = false;
            SystemUser user = Database.SystemUsers.Where(u => u.UserName.ToLower() == userName.ToLower() && password  == u.Password).FirstOrDefault();
            if (user != null)
            {
                isValid = true;
            }
            return isValid;
        }

        public SystemUser IsValidUserorPass(string userName, string password)
        {            
            //SystemUser user = Database.SystemUsers.Where(u => u.UserName.ToLower() == userName.ToLower() && password == u.Password.ToLower()).FirstOrDefault();
            return  Database.SystemUsers.Where(u => u.UserName.ToLower() == userName.ToLower() && password == u.Password).FirstOrDefault(); 
        }

        public SystemPage GetPageByRoleAndPageName(long roleID, string pageName)
        {
            return Database.PagesOnRoles.Where(p => p.RoleID == roleID && p.SystemPage.PageName==pageName && p.IsRemoved == 0).Select(p => p.SystemPage).FirstOrDefault();
        }

        public SystemPage GetPageByUserAndPageName(long userID, string pageName)
        {
            return Database.PagesOnUsers.Where(p => p.UserID == userID && p.SystemPage.PageName == pageName && p.IsRemoved == 0).Select(p => p.SystemPage).FirstOrDefault();
        }

        public List<SystemPage> GetPageListByRole(long roleID)
        {
            return Database.PagesOnRoles.Where(p => p.RoleID == roleID && p.IsRemoved==0).Select(p => p.SystemPage).ToList();
        }

        public List<SystemPage> GetPageListByUser(long userID)
        {
            return Database.PagesOnUsers.Where(p => p.UserID == userID && p.IsRemoved == 0).Select(p => p.SystemPage).ToList();
        }

        public List<PagesOnRole> GetSystemPageByRoleID(long lnRoleID)
        {
            return Database.PagesOnRoles.Where(r => r.RoleID == lnRoleID && r.IsRemoved == 0).ToList();
        }

        public List<PagesOnUser> GetSystemPageByUserID(long lnUserID)
        {
            return Database.PagesOnUsers.Where(s => s.UserID == lnUserID && s.IsRemoved==0).ToList();
        }

        public List<SystemPage> GetSystemPageAll()
        {
            return Database.SystemPages.Where(sp=>sp.IsRemoved ==0).ToList();
        }

        

        #region System User
        public SystemUser GetByUserName(string userName)
        {
            return Database.SystemUsers.Where(sysUser => sysUser.UserName.ToUpper().Equals(userName.ToUpper()) && sysUser.IsRemoved != 1).FirstOrDefault();
        }
        SystemUser IAdminFacade.GetySystemUserID(long systemUserID)
        {
            return Database.SystemUsers.Where(su => su.IID == systemUserID && su.IsRemoved != 1).FirstOrDefault();
        }
        public SystemUser GetySystemUserByIDForUserStatus(long systemUserID)
        {
            return Database.SystemUsers.Where(su => su.IID == systemUserID).FirstOrDefault();
        }

        public List<SystemUser> GetSystemUserAll()
        {
            return Database.SystemUsers.Where(su => su.UserName != string.Empty && su.IsRemoved==0).ToList();
        }
        #endregion

        #region System Role
        public List<SystemRole> GetSystemRoleAll()
        {
            return Database.SystemRoles.ToList();
        }

        public SystemRole GetRoleByIIDWithPages(long iid)
        {
            SystemRole role = Database.SystemRoles.Where(s => s.IID == iid && s.IsRemoved == 0).FirstOrDefault();
            role.PagesOnRoleList = Database.PagesOnRoles.Where(r => r.RoleID == role.IID && r.IsRemoved == 0).ToList();
            return role;
        }

        #endregion

    }
}
