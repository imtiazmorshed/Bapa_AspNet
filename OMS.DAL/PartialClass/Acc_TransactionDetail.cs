using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OMS.DAL
{
    public partial class Acc_TransactionDetail
    {
        private Decimal _debitAmount;
        private Decimal _creditAmount;
        private Decimal _balance;
        private string _accountName;
        private string _accountNo;

        public string AccountNo
        {
            get
            {
                if (_accountNo == string.Empty)
                {
                    _accountNo = "";
                }
                return _accountNo;
            }
            set
            {
                _accountNo = value;
            }
        }

        public string AccountName
        {
            get
            {
                if (_accountName == string.Empty)
                {
                    _accountName = "";
                }
                return _accountName;
            }
            set
            {
                _accountName = value;
            }
        }

        public Decimal DebitAmount
        {
            get
            {
                if (_debitAmount == 0 || _debitAmount == null)
                {
                    _debitAmount = 0;
                }
                return _debitAmount;
            }
            set
            {
                _debitAmount = value;
            }

        }

        public Decimal CreditAmount
        {
            get
            {
                if (_creditAmount == 0 || _creditAmount == null)
                {
                    _creditAmount = 0;
                }
                return _creditAmount;
            }
            set
            {
                _creditAmount = value;
            }

        }

        public Decimal Balance
        {
            get
            {
                if (_balance == 0 || _balance == null)
                {
                    _balance = 0;
                }
                return _balance;
            }
            set
            {
                _balance = value;
            }

        }
    }
}
