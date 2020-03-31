using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OMS.DAL
{
    public class ReceiptHistory
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

        private Decimal _totalReceivable;
        public Decimal TotalReceivable
        {
            get
            {
                if (_totalReceivable == 0 || _totalReceivable == null)
                {
                    _totalReceivable = 0;
                }
                return _totalReceivable;
            }
            set
            {
                _totalReceivable = value;
            }

        }

        private Decimal _totalReceived;
        public Decimal TotalReceived
        {
            get
            {
                if (_totalReceived == 0 || _totalReceived == null)
                {
                    _totalReceived = 0;
                }
                return _totalReceived;
            }
            set
            {
                _totalReceived = value;
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
