using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OMS.DAL;
using OMS.Framework;

namespace OMS.Facade
{
    public interface IAccountsFacade 
    {
        //BalanceSheetItem
        List<Acc_ChartOfAccount> GetCOABalanceSheetItemAll();
        //BalanceSheetItem GetBalanceSheetItemByID(int id);
        //List<BalanceSheetItem> GetBalanceSheetItemAll();


        //Class
        List<Acc_Class> GetAcc_ClassAll();
        Acc_Class GetAcc_ClassByID(int id);

        //ChartOfAccount
        List<Acc_ChartOfAccount> GetAcc_ChartOfAccountAll();
        List<Acc_ChartOfAccount> GetAcc_ChartOfAccountAll(int accountType);
        List<Acc_ChartOfAccount> GetAcc_ChartOfAccountLedgerAll();
        List<Acc_ChartOfAccount> GetAcc_ChartOfAccountTransactableAll();
        Acc_ChartOfAccount GetAcc_ChartOfAccountByID(long id);
        Acc_ChartOfAccount GetAcc_ChartOfAccountByParentID(long id);
        List<Acc_ChartOfAccount> GetAcc_ChartOfAccountListByParetntID(long ParentID);
        List<Acc_ChartOfAccount> GetAcc_ChartOfAccountListByGParetntID(int GParentID);
        List<Acc_ChartOfAccount> GetAcc_ChartOfAccountTransactableSingle();
        List<Acc_ChartOfAccount> GetAcc_ChartOfAccountListByGParetntAndParentID(int GParentID, long parentID);
        List<Acc_ChartOfAccount> GetAcc_ChartOfAccountListByGParetntIDAndAccountTypeID(int GParentID, int accountTypeID);
        Acc_ChartOfAccount GetAcc_ChartOfAccountByName(string name);

        Acc_ChartOfAccount GetChartOfAccountByName(string name);

        Acc_ChartOfAccount GetAcc_ChartOfAccountByAccountNo(string accountNo);
        Acc_ChartOfAccount GetAcc_ChartOfAccountBalance(long chartOfAccountID);
        Acc_ChartOfAccount GetAcc_ChartOfAccountByNameAndIID(string name,long iid);
        //TransactionMaster
        List<Acc_TransactionMaster> GetAcc_TransactionMasterAll();
        List<Acc_TransactionMaster> GetAcc_TransactionMasterListView(int transactionStatus);
        List<Acc_TransactionMaster> GetAcc_TransactionMasterListViewByParam(int transactionStatus, DateTime fromDate, DateTime toDate);

        

        List<Acc_TransactionMaster> GetAcc_TransactionMasterListViewByDate(int transactionStatus, DateTime fromDate, DateTime toDate);
        Acc_TransactionMaster GetAcc_TransactionMasterByTransactionMasterID(long transactionMasterID);
        Acc_TransactionMaster GetAcc_TransactionMasterByTransactionCode(string transactionCode);
        Acc_TransactionMaster GetAcc_TransactionMasterByTransactionCodeAndReferenceID(string transactionCode, int refrenceID);
        int GetJurnalNumber(string TransactionType,DateTime date);

        //TransactionDetail
        List<Acc_TransactionDetail> GetAcc_TransactionDetailAll();
        List<Acc_TransactionDetail> GetAcc_TransactionDetailAll(int transactionStatus);
        Acc_TransactionDetail GetAcc_TransactionDetailByTransactionDetailID(long transactionDetailID);
        List<Acc_TransactionDetail> GetAcc_TransactionDetailListByChartOfAccountID(long chartOfAccountID);
        List<Acc_TransactionDetail> GetAcc_TransactionDetailListByTransactionMasterID(long transactionMasterID);
        List<Acc_TransactionDetail> GetLedgerBalanceByChartOfAccountID(long chartOfAccountID);
        List<Acc_TransactionDetail> GetAcc_TransactionDetailListByTransactionMasterID(long transactionMasterID, int transactionStatus);
        Acc_TransactionDetail GetAcc_TransactionDetailByTransactionMasterIDandCOAID(long transactionMasterID, long chartOfAccountID);


        //Transaction Reference
        List<ReferenceType> GetReferenceAll();


        List<Acc_Bank> GetBankAll();
        Acc_Bank GetBankByIID(long iid);

        List<Acc_BankBranch> GetBranchAll();
        List<Acc_BankBranch> GetBranchByBankID(long bankID);
        Acc_BankBranch GetBranchByIID(long iid);

        List<Acc_BankAccount> GetBankAccountAll();
        List<Acc_BankAccount> GetBankAccountByBranchID(long branchID);
        Acc_BankAccount GetBankAccountAllByIID(long iid);

        Acc_BankAccount GetBankAccountByIID(long iid);

        List<Acc_ChequeBook> GetChequeBookAll();
        Acc_ChequeBook GetChequeBookByIID(long iid);

        Acc_ChequeBook GetChequeBookinfoByIID(long iid);

        List<Acc_ChequeLeaf> GetChequeLeafAll();
        Acc_ChequeLeaf GetChequeLeafByIID(long iid);
        List<Acc_ChequeLeaf> GetChequeLeafAll(int status);
        List<Acc_ChequeLeaf> GetChequeLeafByBankAccountID(int status, long bankAccountID);
        List<Acc_ChequeLeaf> GetChequeLeafByCheckBookID(long checkBookID);
        List<Acc_ChequeLeaf> GetChequeLeafByCriteria(long startno,long endno);
        void Dispose();

        Acc_BankLinkToChartOfAccount GetAcc_BankLinkToChartOfAccountByBankIDAndCOAID(long bankID, long cOAID);

        Acc_BankLinkToChartOfAccount GetAcc_BankLinkToChartOfAccountByBankIDAndCOAIDAndIID(long bankID, long cOAID, long currentMapID);

        List<Acc_BankLinkToChartOfAccount> GetBankLinkToChartOfAccountAll();

        Acc_BankLinkToChartOfAccount GetAcc_BankLinkToChartOfAccountByIID(long currentMapID);
        Acc_BankLinkToChartOfAccount GetAcc_BankLinkToChartOfAccountOnlyByIID(long currentMapID);

        List<Acc_BankTransaction> GetAcc_BankTransactionAll();
        Acc_BankTransaction GetAcc_BankTransactionByIID(long iid);
        Acc_BankTransaction GetAcc_BankTransactionByTransactionMasterID( long transactionMasterID);
        Acc_BankTransaction GetAcc_BankTransactionByJournalCode(string journalCode);
        Acc_BankTransaction GetAcc_BankTransactionByCeequeLeafID(long chequeLeadID, int referenceType);
        List<Acc_BankTransaction> GetAcc_BankTransactionByParam(int referenceType, DateTime fromDate, DateTime toDate);
        List<Acc_ChartOfAccount> GetAcc_ChartOfAccountBalanceNew(long chartOfAccountID);
        decimal GetClassBalance(int classID);
    }

    class AccountsFacade : BaseFacade, IAccountsFacade
    {
        public AccountsFacade(OMSDataContext database): base(database)
        {
        }

        public List<Acc_ChartOfAccount> GetAcc_ChartOfAccountBalanceNew(long chartOfAccountID)
        {

            //Acc_ChartOfAccount chartOfAccount = GetAcc_ChartOfAccountByID(chartOfAccountID);
            Decimal balance = 0;
            List<Acc_ChartOfAccount> list = new List<Acc_ChartOfAccount>();

            list = Database.Acc_ChartOfAccounts.Where(c => c.ParentID == chartOfAccountID && c.IsRemoved == 0).ToList();
            foreach (Acc_ChartOfAccount coa in list)
            {
                //List<Acc_ChartOfAccount> coaNewList = GetAcc_ChartOfAccountBalanceNew(coa.IID);


                GetAcc_ChartOfAccountBalanceNew(coa.IID);
                listCOAAll.Add(coa);
                List<Acc_TransactionDetail> transactionDetailList = new List<Acc_TransactionDetail>();
                if (coa.AccountTypeID == Convert.ToInt32(EnumCollection.AccountType.Transactable))
                {
                    balance = 0;
                    string Op_bal = string.Empty;
                    if (string.IsNullOrEmpty(coa.OpeningBalance.ToString()))
                    {
                        Op_bal = "0.00";
                    }
                    else
                    {
                        Op_bal = coa.OpeningBalance.ToString();
                    }

                    balance += Convert.ToDecimal(Op_bal);
                    transactionDetailList = GetLedgerBalanceByChartOfAccountID(coa.IID);
                    foreach (Acc_TransactionDetail td in transactionDetailList)
                    {
                        if (coa.Acc_Class.AccountNature == Convert.ToInt32(EnumCollection.TransactionNature.Debit))
                        {
                            if (coa.Acc_Class.AccountNature == td.TransactionNature)
                            {
                                balance -= td.Amount;
                            }
                            else
                            {
                                balance += td.Amount;
                            }
                        }
                        else if (coa.Acc_Class.AccountNature == Convert.ToInt32(EnumCollection.TransactionNature.Credit))
                        {
                            if (coa.Acc_Class.AccountNature == td.TransactionNature)
                            {
                                balance -= td.Amount;
                            }
                            else
                            {
                                balance += td.Amount;
                            }
                        }

                    }
                    coa.Balance = balance;
                }
                else
                {
                    List<Acc_ChartOfAccount> listChild = new List<Acc_ChartOfAccount>();

                    listChild = Database.Acc_ChartOfAccounts.Where(c => c.ParentID == coa.IID && c.IsRemoved == 0).ToList();
                    foreach (Acc_ChartOfAccount coaChild in listChild)
                    {
                        coa.Balance += coaChild.Balance;
                    }
                }

            }

            return listCOAAll;
        }
        public decimal GetClassBalance(int classID)
        {
            decimal balance = 0;
            List<Acc_ChartOfAccount> coaList = new List<Acc_ChartOfAccount>();
            coaList = GetAcc_ChartOfAccountAll().Where(c => c.Gparent == classID && c.ParentID == -1 && c.Name != "Sales" && c.Name != "Purchase" && c.Name != "Sale Return").ToList();
            List<Acc_ChartOfAccount> coaBalanceList = new List<Acc_ChartOfAccount>();
            foreach (Acc_ChartOfAccount coa in coaList)
            {
                List<Acc_ChartOfAccount> coaGroupList = new List<Acc_ChartOfAccount>();
                coaGroupList = GetAcc_ChartOfAccountBalanceNew(coa.IID);
                coaGroupList = coaGroupList.Where(c => c.ParentID == coa.IID).ToList();
                foreach (Acc_ChartOfAccount coaGroup in coaGroupList)
                {
                    balance += coaGroup.Balance;
                }
            }
            return balance;
        }
        #region BalanceSheetItem

        public List<Acc_ChartOfAccount> GetCOABalanceSheetItemAll()
        {
            List<Acc_ChartOfAccount> list = new List<Acc_ChartOfAccount>();
            list = Database.Acc_ChartOfAccounts.Where(coa => coa.ParentID == -1 && coa.IsRemoved == 0 && coa.Gparent != 3 && coa.Gparent != 4).ToList();
            return list;
        }



        //public BalanceSheetItem GetBalanceSheetItemByID(int id)
        //{
        //    BalanceSheetItem balanceSheetItem = new BalanceSheetItem();
        //    balanceSheetItem = Database.BalanceSheetItems.Where(b => b.IID == id && b.IsRemoved == 0).FirstOrDefault();
        //    return balanceSheetItem;
        //}
        //public List<BalanceSheetItem> GetBalanceSheetItemAll()
        //{
        //    List<BalanceSheetItem> balanceSheetItemList = new List<BalanceSheetItem>();
        //    balanceSheetItemList = Database.BalanceSheetItems.Where(b => b.IsRemoved == 0).ToList();
        //    return balanceSheetItemList;
        //}

        #endregion
        
        #region Acc_BankTransaction

        public List<Acc_BankTransaction> GetAcc_BankTransactionByParam(int referenceType, DateTime fromDate, DateTime toDate)
        {
            List<Acc_BankTransaction> bankTransactionList = new List<Acc_BankTransaction>();
            List<Acc_BankTransaction> bankTransactionListNew = new List<Acc_BankTransaction>();
            bankTransactionList = GetAcc_BankTransactionAll().Where(bt => (referenceType <= 0 || (referenceType > 0 && bt.ReferenceType == referenceType))
                && (fromDate == DateTime.MinValue || (fromDate != DateTime.MinValue && (bt.ChequeDate.Date >= fromDate.Date && bt.ChequeDate.Date <= toDate.Date)))).ToList();
            
            return bankTransactionList;
        }
        public List<Acc_BankTransaction> GetAcc_BankTransactionAll()
        {
            List<Acc_BankTransaction> bankTransactionList = new List<Acc_BankTransaction>();
            bankTransactionList = Database.Acc_BankTransactions.Where(bt => bt.IsRemoved == 0).ToList();
            foreach (Acc_BankTransaction bankTransaction in bankTransactionList)
            {
                Acc_ChequeLeaf chequeLeaf = new Acc_ChequeLeaf();
                if (bankTransaction.ReferenceType == Convert.ToInt32(EnumCollection.TransactionType.Payment))
                {
                    chequeLeaf = GetChequeLeafByIID(bankTransaction.ChequeLeafID);
                    bankTransaction.ChequeLeaf = chequeLeaf;
                }
                bankTransaction.Acc_TransactionMaster = bankTransaction.Acc_TransactionMaster;

            }
            return bankTransactionList;
        }

        private Acc_ChequeLeaf GetChequeLeafByIID(long? iid)
        {
            return GetChequeLeafAll().Where(cl => cl.IID == iid && cl.IsRemoved == 0).FirstOrDefault();
        }

        public Acc_BankTransaction GetAcc_BankTransactionByIID(long iid)
        {
            return GetAcc_BankTransactionAll().Where(bt => bt.IID == iid).FirstOrDefault();
        }

        public Acc_BankTransaction GetAcc_BankTransactionByTransactionMasterID(long transactionMasterID)
        {
            return GetAcc_BankTransactionAll().Where(bt => bt.TransactionMasterID== transactionMasterID).FirstOrDefault();
        }

        public Acc_BankTransaction GetAcc_BankTransactionByJournalCode(string journalCode)
        {
            Acc_TransactionMaster tm = new Acc_TransactionMaster();
            tm = GetAcc_TransactionMasterByTransactionCode(journalCode);
            Acc_BankTransaction bankTransaction = new Acc_BankTransaction();
            try
            {
                bankTransaction = GetAcc_BankTransactionByTransactionMasterID(tm.IID);
            }
            catch
            {

            }
            return bankTransaction;
        }

        public Acc_BankTransaction GetAcc_BankTransactionByCeequeLeafID(long chequeLeadID, int referenceType)
        {
            Acc_BankTransaction bankTransaction = new Acc_BankTransaction();
            try
            {
                bankTransaction =  GetAcc_BankTransactionAll().Where(bt => bt.ChequeLeafID == chequeLeadID && bt.ReferenceType == Convert.ToInt32(EnumCollection.TransactionType.Payment)).FirstOrDefault();
            }
            catch
            {
 
            }
            return bankTransaction;
        }

        #endregion

        #region Acc_TransactionDetail

        public List<Acc_TransactionDetail> GetAcc_TransactionDetailAll()
        {
            List<Acc_TransactionDetail> transactionDetailList = new List<Acc_TransactionDetail>();
            List<Acc_TransactionDetail> transactionDetailListNew = new List<Acc_TransactionDetail>();
            transactionDetailList = Database.Acc_TransactionDetails.Where(td => td.IsRemoved == 0 && td.Acc_TransactionMaster.Status == Convert.ToInt32(EnumCollection.TransactionStatus.Posted)).ToList();
            foreach (Acc_TransactionDetail transactionDetail in transactionDetailList)
            {
                transactionDetail.Acc_TransactionMaster = transactionDetail.Acc_TransactionMaster;
                transactionDetail.Acc_ChartOfAccount = transactionDetail.Acc_ChartOfAccount;
                transactionDetail.Acc_ChartOfAccount.Acc_Class = transactionDetail.Acc_ChartOfAccount.Acc_Class;
                transactionDetailListNew.Add(transactionDetail);
            }
            return transactionDetailListNew;
        }

        public List<Acc_TransactionDetail> GetAcc_TransactionDetailAll(int transactionStatus)
        {
            List<Acc_TransactionDetail> transactionDetailList = new List<Acc_TransactionDetail>();
            List<Acc_TransactionDetail> transactionDetailListNew = new List<Acc_TransactionDetail>();
            transactionDetailList = Database.Acc_TransactionDetails.Where(td => td.IsRemoved == 0
                && (transactionStatus <= 0 || (transactionStatus > 0 && td.Acc_TransactionMaster.Status == transactionStatus))).ToList();
                //&& td.Acc_TransactionMaster.Status == transactionStatus).ToList();
            foreach (Acc_TransactionDetail transactionDetail in transactionDetailList)
            {
                transactionDetail.Acc_TransactionMaster = transactionDetail.Acc_TransactionMaster;
                transactionDetail.Acc_ChartOfAccount = transactionDetail.Acc_ChartOfAccount;
                transactionDetail.Acc_ChartOfAccount.Acc_Class = transactionDetail.Acc_ChartOfAccount.Acc_Class;
                transactionDetailListNew.Add(transactionDetail);                
            }
            return transactionDetailListNew;
        }

        public List<Acc_TransactionDetail> GetAcc_TransactionDetailListByTransactionMasterID(long transactionMasterID, int transactionStatus)
        {
            List<Acc_TransactionDetail> transactionDetailList = new List<Acc_TransactionDetail>();
            transactionDetailList = GetAcc_TransactionDetailAll(transactionStatus).Where(td => td.TransactionMasterID == transactionMasterID).ToList();
            return transactionDetailList;
        }

        public Acc_TransactionDetail GetAcc_TransactionDetailByTransactionMasterIDandCOAID(long transactionMasterID, long chartOfAccountID)
        {
            Acc_TransactionDetail transactionDetail = new Acc_TransactionDetail();
            try
            {

                transactionDetail = GetAcc_TransactionDetailAll().Single(td => td.IID == transactionMasterID && td.AccountID == chartOfAccountID);
            }
            catch (Exception ex)
            {
                transactionDetail = new Acc_TransactionDetail();
            }
            return transactionDetail;
        }

        public Acc_TransactionDetail GetAcc_TransactionDetailByTransactionDetailID(long transactionDetailID)
        {
            Acc_TransactionDetail transactionDetail = new Acc_TransactionDetail();
            //Acc_TransactionDetail transactionDetailNew = new Acc_TransactionDetail();
            transactionDetail = GetAcc_TransactionDetailAll().Single(td => td.IID == transactionDetailID);
            return transactionDetail;
        }
        
        public List<Acc_TransactionDetail> GetAcc_TransactionDetailListByChartOfAccountID(long chartOfAccountID)
        {
            List<Acc_TransactionDetail> transactionDetailList = new List<Acc_TransactionDetail>();
            transactionDetailList = GetAcc_TransactionDetailAll().Where(td => td.AccountID == chartOfAccountID).ToList();
            return transactionDetailList;
        }

        public List<Acc_TransactionDetail> GetAcc_TransactionDetailListByTransactionMasterID(long transactionMasterID)
        {
            List<Acc_TransactionDetail> transactionDetailList = new List<Acc_TransactionDetail>();
            transactionDetailList = GetAcc_TransactionDetailAll().Where(td => td.TransactionMasterID == transactionMasterID).ToList();
            return transactionDetailList;
        }
        
        public List<Acc_TransactionDetail> GetLedgerBalanceByChartOfAccountID(long chartOfAccountID)
        {
            List<Acc_TransactionDetail> transactionDetailList = new List<Acc_TransactionDetail>();
            List<Acc_TransactionDetail> transactionDetailListNew = new List<Acc_TransactionDetail>();
            transactionDetailList = GetAcc_TransactionDetailAll().Where(td => td.AccountID == chartOfAccountID).ToList();
            foreach (Acc_TransactionDetail transactionDetail in transactionDetailList)
            {
                List<Acc_TransactionDetail> transactionDetailListTemp;
                transactionDetailListTemp = GetAcc_TransactionDetailAll().Where(td => td.TransactionMasterID == transactionDetail.TransactionMasterID).ToList();
                foreach (Acc_TransactionDetail trd in transactionDetailListTemp)
                {
                    if (trd.AccountID != chartOfAccountID)
                        transactionDetailListNew.Add(trd);
                }

            }
            return transactionDetailListNew.OrderBy(td=>td.Acc_TransactionMaster.TransactionDate).ToList();
        }

        public Acc_ChartOfAccount GetAcc_ChartOfAccountBalance(long chartOfAccountID)
        {
            List<Acc_TransactionDetail> transactionDetailList = GetLedgerBalanceByChartOfAccountID(chartOfAccountID);
            Acc_ChartOfAccount chartOfAccount = GetAcc_ChartOfAccountByID(chartOfAccountID);
            Decimal balance = 0;

            foreach (Acc_TransactionDetail td in transactionDetailList)
            {
                if (chartOfAccount.Acc_Class.AccountNature == Convert.ToInt32(EnumCollection.TransactionNature.Debit))
                {
                    if (chartOfAccount.Acc_Class.AccountNature == td.TransactionNature)
                    {
                        balance -= td.Amount;
                    }
                    else
                    {
                        balance += td.Amount;
                    }
                }
                else if (chartOfAccount.Acc_Class.AccountNature == Convert.ToInt32(EnumCollection.TransactionNature.Credit))
                {
                    if (chartOfAccount.Acc_Class.AccountNature == td.TransactionNature)
                    {
                        balance -= td.Amount;
                    }
                    else
                    {
                        balance += td.Amount;
                    }
                }
               
            }
            chartOfAccount.Balance = balance;
            return chartOfAccount;
        }
        private List<Acc_ChartOfAccount> listCOAAll = new List<Acc_ChartOfAccount>();
        

        #endregion

        #region Acc_TransactionMaster

        public List<Acc_TransactionMaster> GetAcc_TransactionMasterAll()
        {
            List<Acc_TransactionMaster> transactionMasterList = new List<Acc_TransactionMaster>();
            transactionMasterList = Database.Acc_TransactionMasters.Where(tm => tm.IsRemoved == 0).ToList();
            return transactionMasterList;
        }

        public List<Acc_TransactionMaster> GetAcc_TransactionMasterListView(int transactionStatus)
        {
            List<Acc_TransactionMaster> transactionMasterList = new List<Acc_TransactionMaster>();
            transactionMasterList = Database.Acc_TransactionMasters.Where(tm => tm.IsRemoved == 0 && tm.Status == transactionStatus).ToList();
            return transactionMasterList;
        }

        public List<Acc_TransactionMaster> GetAcc_TransactionMasterListViewByParam(int status, DateTime fromDate, DateTime toDate)
        {          

            List<Acc_TransactionMaster> transactionMasterList = new List<Acc_TransactionMaster>();
            transactionMasterList = Database.Acc_TransactionMasters.Where(tm => tm.IsRemoved == 0
                && (status <= 0 || (status > 0 && tm.Status == status))
                && (fromDate == DateTime.MinValue || (fromDate != DateTime.MinValue && (tm.TransactionDate.Date >= fromDate.Date && tm.TransactionDate.Date <= toDate.Date)))).ToList();
            return transactionMasterList;
        }

        public List<Acc_TransactionMaster> GetAcc_TransactionMasterListViewByDate(int transactionStatus, DateTime fromDate, DateTime toDate)
        {
            List<Acc_TransactionMaster> transactionMasterList = new List<Acc_TransactionMaster>();
            transactionMasterList = Database.Acc_TransactionMasters.Where(tm => tm.TransactionDate >= fromDate.Date && tm.TransactionDate <= toDate.Date &&  tm.IsRemoved == 0 && tm.Status == transactionStatus).ToList();
            return transactionMasterList;
        }

        public Acc_TransactionMaster GetAcc_TransactionMasterByTransactionMasterID(long transactionMasterID)
        {
            Acc_TransactionMaster transactionMaster = new Acc_TransactionMaster();
            transactionMaster = GetAcc_TransactionMasterAll().Single(tm => tm.IID == transactionMasterID);
            return transactionMaster;
        }

        public Acc_TransactionMaster GetAcc_TransactionMasterByTransactionCodeAndReferenceID(string transactionCode, int refrenceID)
        {
            Acc_TransactionMaster transactionMaster = new Acc_TransactionMaster();
            try
            {
                transactionMaster = GetAcc_TransactionMasterAll().Single(tm => tm.JournalCode == transactionCode && tm.ReferenceType == refrenceID);
            }
            catch (Exception ex)
            {
                transactionMaster = new Acc_TransactionMaster();
            }
            return transactionMaster;
        }

        public Acc_TransactionMaster GetAcc_TransactionMasterByTransactionCode(string transactionCode)
        {
            Acc_TransactionMaster transactionMaster = new Acc_TransactionMaster();
            transactionMaster = GetAcc_TransactionMasterAll().Single(tm => tm.JournalCode == transactionCode);
            return transactionMaster;
        }

        public int GetJurnalNumber(string TransactionType,DateTime date)
        {
            int MAX = 0;
            List<Acc_TransactionMaster> transactionMasterList = new List<Acc_TransactionMaster>();
            transactionMasterList = Database.Acc_TransactionMasters.Where(tm => tm.IsRemoved == 0 && tm.TransactionDate >= Convert.ToDateTime(date.ToShortDateString() + " 12:00:00 AM") && tm.TransactionDate <= Convert.ToDateTime(date.ToShortDateString() + " 11:59:59 PM") && tm.JournalCode.StartsWith(TransactionType)).ToList();
            List<int> numberlist = new List<int>();
            if (transactionMasterList.Count > 0)
            {
                foreach (Acc_TransactionMaster master in transactionMasterList)
                {
                    numberlist.Add(Convert.ToInt32(master.JournalCode.Substring(master.JournalCode.Length - 3, 3)));

                }
                MAX = numberlist.Max();
            }
            return MAX;
        }

        #endregion

        #region Acc_Class

        public List<Acc_Class> GetAcc_ClassAll()
        {
            List<Acc_Class> Acc_ClassList = new List<Acc_Class>();
            Acc_ClassList = Database.Acc_Classes.ToList();
            return Acc_ClassList;
        }

        public Acc_Class GetAcc_ClassByID(int id)
        {
            Acc_Class aclass = new Acc_Class();
            aclass = Database.Acc_Classes.Single(a => a.IID == id );
            return aclass;
        }

        #endregion

        #region Acc_ChartOfAccount

        public Acc_ChartOfAccount GetAcc_ChartOfAccountByNameAndIID(string name, long iid)
        {
            return Database.Acc_ChartOfAccounts.Where(ca => ca.Name == name && ca.IID != iid && ca.IsRemoved == 0).FirstOrDefault();
        }

        public List<Acc_ChartOfAccount> GetAcc_ChartOfAccountAll(int accountType)
        {
            return GetAcc_ChartOfAccountAll().Where(ca => ca.AccountTypeID == accountType).ToList();
        }

        public List<Acc_ChartOfAccount> GetAcc_ChartOfAccountLedgerAll()
        {
            return GetAcc_ChartOfAccountAll().Where(ca => ca.AccountTypeID == Convert.ToInt32(EnumCollection.AccountType.Transactable)).ToList();
        }

        public List<Acc_ChartOfAccount> GetAcc_ChartOfAccountAll()
        {
            List<Acc_ChartOfAccount> Acc_ChartOfAccountList = new List<Acc_ChartOfAccount>();
            Acc_ChartOfAccountList = Database.Acc_ChartOfAccounts.Where(c=>c.IsRemoved==0).ToList();
            return Acc_ChartOfAccountList;
        }

        public List<Acc_ChartOfAccount> GetAcc_ChartOfAccountTransactableAll()
        {
            List<Acc_ChartOfAccount> Acc_ChartOfAccountList = new List<Acc_ChartOfAccount>();
            Acc_ChartOfAccountList = Database.Acc_ChartOfAccounts.Where(c => c.IsRemoved == 0 && c.AccountTypeID==1).ToList();
            return Acc_ChartOfAccountList;
        }

        public List<Acc_ChartOfAccount> GetAcc_ChartOfAccountTransactableSingle()
        {
            List<Acc_ChartOfAccount> Acc_ChartOfAccountList = new List<Acc_ChartOfAccount>();
            List<Acc_ChartOfAccount> Acc_ChartOfAccountListNew = new List<Acc_ChartOfAccount>();
            Acc_ChartOfAccountList = Database.Acc_ChartOfAccounts.Where(c => c.IsRemoved == 0 && c.AccountTypeID == 1).ToList();
            for(int i=0;i<1;i++)
            {
                Acc_ChartOfAccountListNew.Add(Acc_ChartOfAccountList[i]);
            }
            return Acc_ChartOfAccountListNew;
        }

        public Acc_ChartOfAccount GetAcc_ChartOfAccountByID(long id)
        {
            Acc_ChartOfAccount cacc = new Acc_ChartOfAccount();
            try
            {
                cacc = Database.Acc_ChartOfAccounts.Single(c => c.IID == id && c.IsRemoved == 0);
            }
            catch (Exception ex)
            {
 
            }
            return cacc; 
        }

        public Acc_ChartOfAccount GetChartOfAccountByName(string name)
        {
            Acc_ChartOfAccount cacc = new Acc_ChartOfAccount();
            try
            {
                cacc = Database.Acc_ChartOfAccounts.Where(c => c.Name == name && c.IsRemoved == 0).FirstOrDefault();
                cacc.Acc_Class = cacc.Acc_Class;
            }
            catch (Exception ex)
            {

            }
            return cacc;
        }

        public Acc_ChartOfAccount GetAcc_ChartOfAccountByName(string name)
        {
            Acc_ChartOfAccount cacc = new Acc_ChartOfAccount();
            try
            {
                cacc = Database.Acc_ChartOfAccounts.Where(c => c.Name == name && c.IsRemoved == 0).FirstOrDefault();
                cacc.Acc_Class = cacc.Acc_Class;
                Acc_ChartOfAccount parentCOA = GetAcc_ChartOfAccountByID(cacc.ParentID);
                cacc.ParentChartOfAccount = parentCOA;
            }
            catch (Exception ex)
            {

            }
            return cacc;
        }

        public Acc_ChartOfAccount GetAcc_ChartOfAccountByAccountNo(string accountNo)
        {
            Acc_ChartOfAccount cacc = new Acc_ChartOfAccount();
            try
            {
                cacc = Database.Acc_ChartOfAccounts.Single(c => c.AccountNo == accountNo && c.IsRemoved == 0);
                cacc.Acc_Class = cacc.Acc_Class;
                Acc_ChartOfAccount parentCOA = GetAcc_ChartOfAccountByID(cacc.ParentID);
                cacc.ParentChartOfAccount = parentCOA;
            }
            catch (Exception ex)
            {

            }
            return cacc;
        }

        public Acc_ChartOfAccount GetAcc_ChartOfAccountByParentID(long parentid)
        {
            Acc_ChartOfAccount cacc = new Acc_ChartOfAccount();
            cacc = Database.Acc_ChartOfAccounts.Where(c => c.ParentID == parentid && c.IsRemoved == 0).FirstOrDefault();
            if (cacc != null)
            {
                cacc.Acc_Class = cacc.Acc_Class;
            }
            return cacc;
        }

        public List<Acc_ChartOfAccount> GetAcc_ChartOfAccountListByParetntID(long parentID)
        {
            List<Acc_ChartOfAccount> Acc_ChartOfAccountList = new List<Acc_ChartOfAccount>();
            Acc_ChartOfAccountList = Database.Acc_ChartOfAccounts.Where(c => c.IsRemoved == 0 && c.ParentID == parentID).ToList();
            return Acc_ChartOfAccountList;
        }

        public List<Acc_ChartOfAccount> GetAcc_ChartOfAccountListByGParetntID(int GParentID)
        {
            List<Acc_ChartOfAccount> Acc_ChartOfAccountList = new List<Acc_ChartOfAccount>();
            Acc_ChartOfAccountList = Database.Acc_ChartOfAccounts.Where(c => c.IsRemoved == 0 && c.Gparent == GParentID ).ToList();
            return Acc_ChartOfAccountList;
        }

        public List<Acc_ChartOfAccount> GetAcc_ChartOfAccountListByGParetntAndParentID(int GParentID,long parentID)
        {
            List<Acc_ChartOfAccount> acc_ChartOfAccountList = new List<Acc_ChartOfAccount>();
            acc_ChartOfAccountList = GetAcc_ChartOfAccountListByGParetntID(GParentID).Where(c => c.IsRemoved == 0 && c.ParentID == parentID).ToList();
            return acc_ChartOfAccountList;
        }

        public List<Acc_ChartOfAccount> GetAcc_ChartOfAccountListByGParetntIDAndAccountTypeID(int GParentID, int accountTypeID)
        {
            List<Acc_ChartOfAccount> acc_ChartOfAccountList = new List<Acc_ChartOfAccount>();
            acc_ChartOfAccountList = GetAcc_ChartOfAccountListByGParetntID(GParentID).Where(c => c.IsRemoved == 0 && c.AccountTypeID == accountTypeID).ToList();
            return acc_ChartOfAccountList;
        }

        #endregion

        #region Transaction Reference

        public List<ReferenceType> GetReferenceAll()
        {
            List<ReferenceType> RefeenceList = new List<ReferenceType>();
            RefeenceList = Database.ReferenceTypes.ToList();
            return RefeenceList;
        }

        #endregion

        #region Bank

        public List<Acc_Bank> GetBankAll()
        {
            return Database.Acc_Banks.Where(b => b.IsRemoved == 0).ToList();
        }

        public Acc_Bank GetBankByIID(long iid)
        {
            return Database.Acc_Banks.Where(b => b.IID == iid && b.IsRemoved == 0).FirstOrDefault();
        }

        #endregion

        #region Branch

        public List<Acc_BankBranch> GetBranchAll()
        {
            List<Acc_BankBranch> branchList= Database.Acc_BankBranches.Where(b => b.IsRemoved == 0).ToList();
            foreach (Acc_BankBranch branch in branchList)
            {
                branch.Acc_Bank = branch.Acc_Bank;
            }
            return branchList;
        }

        public List<Acc_BankBranch> GetBranchByBankID(long bankID)
        {
            return Database.Acc_BankBranches.Where(b => b.BankID == bankID && b.IsRemoved == 0).ToList();
        }

        public Acc_BankBranch GetBranchByIID(long iid)
        {
            return Database.Acc_BankBranches.Where(b => b.IID == iid && b.IsRemoved == 0).FirstOrDefault();
        }

        #endregion

        #region Bank Account

        public List<Acc_BankAccount> GetBankAccountAll()
        {
            List<Acc_BankAccount> bAccList = Database.Acc_BankAccounts.Where(b => b.IsRemoved == 0).ToList();
            foreach (Acc_BankAccount bAcc in bAccList)
            {
                bAcc.Acc_BankBranch = bAcc.Acc_BankBranch;
                bAcc.Acc_BankBranch.Acc_Bank = bAcc.Acc_BankBranch.Acc_Bank;
            }
            return bAccList;
        }

        public List<Acc_BankAccount> GetBankAccountByBranchID(long branchID)
        {
            List<Acc_BankAccount> bAccList = Database.Acc_BankAccounts.Where(b =>b.BankBranchID==branchID && b.IsRemoved == 0).ToList();
            return bAccList;
        }

        public Acc_BankAccount GetBankAccountAllByIID(long iid)
        {
            Acc_BankAccount bAcc = Database.Acc_BankAccounts.Where(b => b.IID == iid && b.IsRemoved == 0).FirstOrDefault();
            bAcc.Acc_BankBranch = bAcc.Acc_BankBranch;
            return bAcc;
        }

        public Acc_BankAccount GetBankAccountByIID(long iid)
        {
            Acc_BankAccount bAcc= Database.Acc_BankAccounts.Where(b => b.IID == iid && b.IsRemoved == 0).FirstOrDefault();
            
            return bAcc;
        }

        #endregion

        #region ChequeBook

        public List<Acc_ChequeBook> GetChequeBookAll()
        {
            return Database.Acc_ChequeBooks.Where(c => c.IsRemoved == 0).ToList();
        }

        public Acc_ChequeBook GetChequeBookByIID(long iid)
        {
            return Database.Acc_ChequeBooks.Where(c =>c.IID== iid && c.IsRemoved == 0).FirstOrDefault();
        }

        public Acc_ChequeBook GetChequeBookinfoByIID(long iid)
        {
            Acc_ChequeBook chkBook= Database.Acc_ChequeBooks.Where(c => c.IID == iid && c.IsRemoved == 0).FirstOrDefault();
            chkBook.Acc_BankAccount = chkBook.Acc_BankAccount;
            return chkBook;
        }
        #endregion

        #region ChequeBook
        public List<Acc_ChequeLeaf> GetChequeLeafAll()
        {
            return Database.Acc_ChequeLeafs.Where(cl =>  cl.IsRemoved == 0).ToList();
        }

        public Acc_ChequeLeaf GetChequeLeafByIID(long iid)
        {
            return GetChequeLeafAll().Where(cl => cl.IID == iid && cl.IsRemoved == 0).FirstOrDefault();
        }

        public List<Acc_ChequeLeaf> GetChequeLeafAll(int status)
        {
            return GetChequeLeafAll().Where(cl => cl.Status == status).ToList();
        }

        public List<Acc_ChequeLeaf> GetChequeLeafByBankAccountID(int status, long bankAccountID)
        {
            List<Acc_ChequeBook> chequeBookList = new List<Acc_ChequeBook>();
            List<Acc_ChequeLeaf> chequeLeafList = new List<Acc_ChequeLeaf>();
            chequeBookList = Database.Acc_ChequeBooks.Where(cb => cb.BankAccountID == bankAccountID && cb.IsActive == true && cb.IsRemoved == 0).ToList();
            foreach (Acc_ChequeBook chequeBook in chequeBookList)
            {
                List<Acc_ChequeLeaf> chequeLeafListNew = new List<Acc_ChequeLeaf>();
                chequeLeafListNew = GetChequeLeafAll(status).Where(cl => cl.ChequeBookID == chequeBook.IID).ToList();
                if (chequeLeafListNew.Count > 0)
                {
                    foreach(Acc_ChequeLeaf chequeLeaf in chequeLeafListNew)
                    {
                        chequeLeafList.Add(chequeLeaf);
                    }                    
                }
            }
            return chequeLeafList;
        }

        public List<Acc_ChequeLeaf> GetChequeLeafByCheckBookID(long checkBookID)
        {
            return Database.Acc_ChequeLeafs.Where(l => l.ChequeBookID == checkBookID && l.IsRemoved == 0).ToList();
        }

        public List<Acc_ChequeLeaf> GetChequeLeafByCriteria(long startno, long endno)
        {
            return Database.Acc_ChequeLeafs.Where(l => l.LeafNumber == startno.ToString().Trim() && l.LeafNumber == endno.ToString().Trim()).ToList();
        }

        #endregion

        #region BankLinkToChartOfAccount

        public Acc_BankLinkToChartOfAccount GetAcc_BankLinkToChartOfAccountByBankIDAndCOAID(long bankID, long cOAID)
        {
            return Database.Acc_BankLinkToChartOfAccounts.Where(b => b.BankAccountID == bankID || b.ChartOfAccountID == cOAID).FirstOrDefault();
        }

        public Acc_BankLinkToChartOfAccount GetAcc_BankLinkToChartOfAccountByBankIDAndCOAIDAndIID(long bankID, long cOAID, long currentMapID)
        {
            return Database.Acc_BankLinkToChartOfAccounts.Where(b => b.BankAccountID == bankID || b.ChartOfAccountID == cOAID && b.IID!=currentMapID).FirstOrDefault();
        }

        public List<Acc_BankLinkToChartOfAccount> GetBankLinkToChartOfAccountAll()
        {
            List<Acc_BankLinkToChartOfAccount> list = Database.Acc_BankLinkToChartOfAccounts.Where(b => b.IsRemoved == 0 && b.Status == 1).ToList();
            foreach (Acc_BankLinkToChartOfAccount blCOA in list)
            {
                blCOA.Acc_BankAccount = blCOA.Acc_BankAccount;
                blCOA.Acc_ChartOfAccount = blCOA.Acc_ChartOfAccount;
                blCOA.Branch = blCOA.Acc_BankAccount.Acc_BankBranch;
                blCOA.Bank = blCOA.Acc_BankAccount.Acc_BankBranch.Acc_Bank;
                blCOA.COABranch = Database.Acc_ChartOfAccounts.Where(c => c.IID == blCOA.Acc_ChartOfAccount.ParentID).FirstOrDefault();
                if(blCOA.COABranch!=null)
                {
                    blCOA.COABank = Database.Acc_ChartOfAccounts.Where(c => c.IID == blCOA.COABranch.ParentID).FirstOrDefault();
                }
            }
            return list;
        }

        public Acc_BankLinkToChartOfAccount GetAcc_BankLinkToChartOfAccountByIID(long currentMapID)
        {
            Acc_BankLinkToChartOfAccount blCOA = Database.Acc_BankLinkToChartOfAccounts.Where(b => b.IID == currentMapID && b.IsRemoved == 0 && b.Status == 1).FirstOrDefault();
            if (blCOA != null)
                blCOA.Acc_BankAccount = blCOA.Acc_BankAccount;
                blCOA.Acc_ChartOfAccount = blCOA.Acc_ChartOfAccount;
                blCOA.Branch = blCOA.Acc_BankAccount.Acc_BankBranch;
                blCOA.Bank = blCOA.Acc_BankAccount.Acc_BankBranch.Acc_Bank;
                
                blCOA.COABranch = Database.Acc_ChartOfAccounts.Where(c => c.IID == blCOA.Acc_ChartOfAccount.ParentID).FirstOrDefault();
                if (blCOA.COABranch != null)
                {
                    blCOA.COABank = Database.Acc_ChartOfAccounts.Where(c => c.IID == blCOA.COABranch.ParentID).FirstOrDefault();
                }

                return blCOA;
        }

        public Acc_BankLinkToChartOfAccount GetAcc_BankLinkToChartOfAccountOnlyByIID(long currentMapID)
        {
            Acc_BankLinkToChartOfAccount blCOA = Database.Acc_BankLinkToChartOfAccounts.Where(b => b.IID == currentMapID && b.IsRemoved == 0 && b.Status == 1).FirstOrDefault();
            return blCOA;
        }

        #endregion
    }
}
