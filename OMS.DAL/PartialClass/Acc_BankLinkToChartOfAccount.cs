using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OMS.DAL
{
    public partial class Acc_BankLinkToChartOfAccount
    {
        Acc_Bank _bank = new Acc_Bank();

        public Acc_Bank Bank
        {
            get { return _bank; }
            set { _bank = value; }
        }

        Acc_BankBranch _branch = new Acc_BankBranch();

        public Acc_BankBranch Branch
        {
            get { return _branch; }
            set { _branch = value; }
        }

        Acc_ChartOfAccount _cOABank = new Acc_ChartOfAccount();

        public Acc_ChartOfAccount COABank
        {
            get { return _cOABank; }
            set { _cOABank = value; }
        }

        Acc_ChartOfAccount _cOABranch = new Acc_ChartOfAccount();

        public Acc_ChartOfAccount COABranch
        {
            get { return _cOABranch; }
            set { _cOABranch = value; }
        }

    }
}
