using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OMS.DAL;

namespace OMS.Facade
{
    public interface ISecurityFacade
    {
        List<SystemRole> GetAllRoles();

        List<SystemUser> GetAllUser();
        SystemUser GetUserByIID(long iid);
        SystemUser GetUserByIIDWithRoles(long iid);
        SystemRole GetRoleByIID(long iid);
    }
    class SecurityFacade : BaseFacade, ISecurityFacade
    {
        public SecurityFacade(OMSDataContext database)
            : base(database)
        {
        }

        public SystemRole GetRoleByIID(long iid)
        {
            return Database.SystemRoles.Where(r => r.IID == iid && r.IsRemoved == 0).FirstOrDefault();
        }

        public List<SystemRole> GetAllRoles()
        {
            return Database.SystemRoles.ToList();
        }

        public List<SystemUser> GetAllUser()
        {
            return Database.SystemUsers.Where(s => s.IsRemoved == 0).ToList();
        }


        public SystemUser GetUserByIID(long iid)
        {
            return Database.SystemUsers.Where(s => s.IID == iid && s.IsRemoved == 0).FirstOrDefault();
        }
        public SystemUser GetUserByIIDWithRoles(long iid)
        {
            SystemUser user = Database.SystemUsers.Where(s => s.IID == iid && s.IsRemoved == 0).FirstOrDefault();
            user.PagesOnUserList = Database.PagesOnUsers.Where(u => u.UserID == user.IID && u.IsRemoved == 0).ToList();
            return user;
        }
    }
}
