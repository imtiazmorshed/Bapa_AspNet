using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OMS.DAL
{
    public class ItemBatch
    {
        private long _iid;
        private string _batchNo;
        private decimal _costPrice;
        private decimal _sellPrice;
        private decimal _quantity;

        public long IID
        {
            get
            {
                if (_iid == 0)
                {
                    _iid = 0;
                }
                return _iid;
            }
            set
            {
                _iid = value;
            }
        }

        public string BatchNo 
        {
            get
            {
                if (_batchNo == string.Empty)
                {
                    _batchNo = "";
                }
                return _batchNo;
            }
            set
            {
                _batchNo = value;
            }
        }

        public Decimal CostPrice
        {
            get
            {
                if (_costPrice == 0 || _costPrice == null)
                {
                    _costPrice = 0;
                }
                return _costPrice;
            }
            set
            {
                _costPrice = value;
            }

        }

        public Decimal SellPrice
        {
            get
            {
                if (_sellPrice == 0 || _sellPrice == null)
                {
                    _sellPrice = 0;
                }
                return _sellPrice;
            }
            set
            {
                _sellPrice = value;
            }

        }

        public Decimal Quantity
        {
            get
            {
                if (_quantity == 0 || _quantity == null)
                {
                    _quantity = 0;
                }
                return _quantity;
            }
            set
            {
                _quantity = value;
            }

        }
    }
}
