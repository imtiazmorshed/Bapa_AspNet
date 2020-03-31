using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OMS.DAL
{
    public partial class SystemRole
    {
        List<PagesOnRole> _pagesOnRoleList = new List<PagesOnRole>();

        public List<PagesOnRole> PagesOnRoleList
        {
            get { return _pagesOnRoleList; }
            set { _pagesOnRoleList = value; }
        }
    }
}
