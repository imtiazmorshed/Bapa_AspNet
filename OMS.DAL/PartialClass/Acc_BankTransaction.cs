using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OMS.DAL
{
    public partial class Acc_BankTransaction
    {
        Acc_ChequeLeaf _chequeLeaf = new Acc_ChequeLeaf();

        public Acc_ChequeLeaf ChequeLeaf
        {
            get { return _chequeLeaf; }
            set { _chequeLeaf = value; }
        }
    }
}
