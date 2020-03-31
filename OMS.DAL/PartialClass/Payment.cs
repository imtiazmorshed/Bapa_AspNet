using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OMS.DAL
{
    public partial class Payment
    {
        private long _transactionMasterID;
        public long TransactionMasterID
        {
            get
            {
                if (_transactionMasterID == 0)
                {
                    _transactionMasterID = 0;
                }
                return _transactionMasterID;
            }
            set
            {
                _transactionMasterID = value;
            }
        }
        
        private Customer _customer;
        private Supplier _supplier;

        public Customer Customer
        {
            get
            {
                if (_customer.IID <= 0)
                {
                    _customer = null;
                }
                return _customer;
            }
            set
            {
                _customer = value;
            }

        }

        public Supplier Supplier
        {
            get
            {
                if (_supplier.IID <= 0)
                {
                    _supplier = null;
                }
                return _supplier;
            }
            set
            {
                _supplier = value;
            }

        }
    }
}
