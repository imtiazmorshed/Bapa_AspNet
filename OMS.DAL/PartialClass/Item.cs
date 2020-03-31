using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OMS.DAL
{
    public partial class Item
    {
        private List<ItemBatch> _itemBatchList;
        private Decimal _itemQuantity;
        private Decimal _purchaseQuantity;
        private Decimal _purchaseReturnQuantity;
        private Decimal _saleQuantity;
        private Decimal _saleReturnQuantity;


        public List<ItemBatch> ItemBatchList
        {
            get
            {
                if (_itemBatchList.Count <= 0)
                {
                    _itemBatchList = null;
                }
                return _itemBatchList;
            }
            set
            {
                _itemBatchList = value;
            }

        }


        public Decimal ItemQuantity 
        {
            get 
            {
                if (_itemQuantity == 0 || _itemQuantity == null)
                {
                    _itemQuantity = 0;
                }
                return _itemQuantity;
            }
            set
            {
                _itemQuantity = value;
            }           

        }

        public Decimal PurchaseQuantity
        {
            get
            {
                if (_purchaseQuantity == 0 || _purchaseQuantity == null)
                {
                    _purchaseQuantity = 0;
                }
                return _purchaseQuantity;
            }
            set
            {
                _purchaseQuantity = value;
            }

        }

        public Decimal PurchaseReturnQuantity
        {
            get
            {
                if (_purchaseReturnQuantity == 0 || _purchaseReturnQuantity == null)
                {
                    _purchaseReturnQuantity = 0;
                }
                return _purchaseReturnQuantity;
            }
            set
            {
                _purchaseReturnQuantity = value;
            }

        }

        public Decimal SaleQuantity
        {
            get
            {
                if (_saleQuantity == 0 || _saleQuantity == null)
                {
                    _saleQuantity = 0;
                }
                return _saleQuantity;
            }
            set
            {
                _saleQuantity = value;
            }

        }

        public Decimal SaleReturnQuantity
        {
            get
            {
                if (_saleReturnQuantity == 0 || _saleReturnQuantity == null)
                {
                    _saleReturnQuantity = 0;
                }
                return _saleReturnQuantity;
            }
            set
            {
                _saleReturnQuantity = value;
            }

        }
    }
}
