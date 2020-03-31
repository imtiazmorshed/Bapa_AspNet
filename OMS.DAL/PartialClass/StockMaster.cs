using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OMS.DAL
{
    public partial class StockMaster
    {
        private Supplier _supplier;
        private Customer _customer;

        public Supplier Supplier
        {
            get
            {
                if (_supplier != null)
                    return _supplier;
                else
                {
                    return _supplier;
                }
            }
            set { _supplier = value; }
        }

        public Customer Customer
        {
            get
            {
                if (_customer != null)
                    return _customer;
                else
                {
                    return _customer;
                }
            }
            set { _customer = value; }
        }
    }
}
