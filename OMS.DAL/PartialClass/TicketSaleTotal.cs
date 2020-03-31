using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OMS.DAL
{
    public class TicketSaleTotal
    {
        private Decimal _totalAmountInUSD;
        public Decimal TotalAmountInUSD
        {
            get
            {
                if (_totalAmountInUSD == 0 || _totalAmountInUSD == null)
                {
                    _totalAmountInUSD = 0;
                }
                return _totalAmountInUSD;
            }
            set
            {
                _totalAmountInUSD = value;
            }

        }

        private Decimal _totalAmountInTaka;
        public Decimal TotalAmountInTaka
        {
            get
            {
                if (_totalAmountInTaka == 0 || _totalAmountInTaka == null)
                {
                    _totalAmountInTaka = 0;
                }
                return _totalAmountInTaka;
            }
            set
            {
                _totalAmountInTaka = value;
            }

        }

        private Decimal _totalTaxAmount;
        public Decimal TotalTaxAmount
        {
            get
            {
                if (_totalTaxAmount == 0 || _totalTaxAmount == null)
                {
                    _totalTaxAmount = 0;
                }
                return _totalTaxAmount;
            }
            set
            {
                _totalTaxAmount = value;
            }

        }

        private Decimal _totalAmount;
        public Decimal TotalAmount
        {
            get
            {
                if (_totalAmount == 0 || _totalAmount == null)
                {
                    _totalAmount = 0;
                }
                return _totalAmount;
            }
            set
            {
                _totalAmount = value;
            }

        }
    }
}