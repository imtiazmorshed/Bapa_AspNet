using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OMS.DAL
{
    public class PaymentHistory
    {

        private long _referenceID;        
        public long ReferenceID
        {
            get
            {
                if (_referenceID == 0)
                {
                    _referenceID = 0;
                }
                return _referenceID;
            }
            set
            {
                _referenceID = value;
            }
        }

        private int _referenceType;
        public int ReferenceType
        {
            get
            {
                if (_referenceType == 0)
                {
                    _referenceType = 0;
                }
                return _referenceType;
            }
            set
            {
                _referenceType = value;
            }
        }

        private string _referenceName;
        public string ReferenceName
        {
            get
            {
                if (_referenceName == string.Empty)
                {
                    _referenceName = "";
                }
                return _referenceName;
            }
            set
            {
                _referenceName = value;
            }
        }

        private Decimal _totalSale;
        public Decimal TotalSale
        {
            get
            {
                if (_totalSale == 0 || _totalSale == null)
                {
                    _totalSale = 0;
                }
                return _totalSale;
            }
            set
            {
                _totalSale = value;
            }

        }

        private Decimal _totalPayment;
        public Decimal TotalPayment
        {
            get
            {
                if (_totalPayment == 0 || _totalPayment == null)
                {
                    _totalPayment = 0;
                }
                return _totalPayment;
            }
            set
            {
                _totalPayment = value;
            }

        }

        private Decimal _totalDue;
        public Decimal TotalDue
        {
            get
            {
                if (_totalDue == 0 || _totalDue == null)
                {
                    _totalDue = 0;
                }
                return _totalDue;
            }
            set
            {
                _totalDue = value;
            }

        }
    }
}
