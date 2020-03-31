using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OMS.DAL
{
    public partial class Inv_Detail
    {
        private Decimal _totalPrice;
        
        public Decimal TotalPrice
        {
            get
            {
                return Quantity * UnitPrice;
            }
            set
            {
                _totalPrice = value;
            }

        }
        
    }
}
