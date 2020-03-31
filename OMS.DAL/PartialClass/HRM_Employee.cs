using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OMS.DAL
{
    public partial class HRM_Employee
    {
        private string _displayName;
        
        public string DisplayName 
        {
            get
            {
                if (_displayName == string.Empty)
                {
                    _displayName = "";
                }
                return _displayName = this.FirstName + " " + this.MiddleName +" "+this.LastName;
            }
            set
            {
                _displayName = value;
            }
        }
    }
}
