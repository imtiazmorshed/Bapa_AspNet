using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OMS.DAL
{
    public partial class SystemUser
    {
        List<PagesOnUser> _pagesOnUserList = new List<PagesOnUser>();

        public List<PagesOnUser> PagesOnUserList
        {
            get { return _pagesOnUserList; }
            set { _pagesOnUserList = value; }
        }
    }
}
