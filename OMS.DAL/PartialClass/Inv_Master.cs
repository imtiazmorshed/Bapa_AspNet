using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OMS.DAL
{
    public partial class Inv_Master
    {
        private List<Inv_Detail> _invoiceDetailList;
        
        public List<Inv_Detail> InvoiceDetailList
        {
            get
            {
                if (_invoiceDetailList.Count <= 0)
                {
                    _invoiceDetailList = null;
                }
                return _invoiceDetailList;
            }
            set
            {
                _invoiceDetailList = value;
            }

        }

         
        
    }
}
