using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OMS.DAL;
using OMS.Framework;

namespace OMS.Facade
{
    public interface ITicketSaleFacade
    {
        //TicketSale
        List<TicketSale> GetTicketSaleAll();
        TicketSale GetTicketSaleByID(long id);
        List<TicketSale> GetTicketSaleBySearchParam(string transactionNo, DateTime fromDate, DateTime toDate);
        //TicketSaleDetail
        List<TicketSaleDetail> GetTicketSaleDetailListByTicketSaleID(long ticketSaleID);

        //Payment
        List<Payment> GetPaymentAll();
        Payment GetPaymentByID(long id);
        Payment GetPaymentByID(long id, int referenceTypeID);
        List<Payment> GetPaymentBySearchParam(string paymentNo, string transactionNo, DateTime fromDate, DateTime toDate, int referenceTypeID, long referenceID, int branchID);
        //List<Payment> GetPaymentListByTicketSaleID(long ticketSaleID, int referenceTypeID);
        PaymentHistory GetPaymentHistoryByAirlinedID(DateTime fromDate, DateTime toDate, int referenceTypeID, long referenceID,int branchID);
        ReceiptHistory GetReceiptHistoryByCustomerID(DateTime fromDate, DateTime toDate, int referenceTypeID, long referenceID, int branchID);
        Payment GetPaymentByPaymentNo(string paymentNo, int referenceTypeID);
        Payment GetPaymentByReferenceBillNo(string referenceBillNo);

        //AirlinesCmmission        
        AirlinesCommission GetAirlinesCommission(long airlinesID);
        AirlinesCommission GetAirlinesCommission(long airlinesID, int ticketClassID);
        List<AirlinesCommission> GetAirlinesCommissionList(long airlinesID);

        
        //TicketClass
        List<TicketClass> GetTicketClassAll();
        TicketClass GetTicketClassByID(int id);
        List<TicketSale> GetTicketSaleByReferenceID(long referenceID, DateTime fromDate, DateTime toDate, int branchID);
        List<TicketSale> GetTicketSaleByCustomerID(long referenceID, DateTime fromDate, DateTime toDate, int branchID);
        void Dispose();

        //TransactionMaster
        Acc_TransactionMaster GetTransactionMasterByTransactionNo(string transactionNo);
    }


    class TicketSaleFacade : BaseFacade, ITicketSaleFacade
    {
        public TicketSaleFacade(OMSDataContext database)
            : base(database)
        {
        }

        public List<TicketSaleDetail> GetTicketSaleDetailListByTicketSaleID(long ticketSaleID)
        {
            List<TicketSaleDetail> ticketSaleDetailList = new List<TicketSaleDetail>();
            ticketSaleDetailList = Database.TicketSaleDetails.Where(t => t.TicketSaleID == ticketSaleID && t.IsRemoved == 0).ToList();
            return ticketSaleDetailList;
        }

        public TicketClass GetTicketClassByID(int id)
        {
            TicketClass ticketClass = new TicketClass();
            ticketClass = Database.TicketClasses.Where(t => t.IID == id).FirstOrDefault();
            return ticketClass;
        }
        public List<TicketClass> GetTicketClassAll()
        {
            List<TicketClass> ticketClassList = new List<TicketClass>();
            ticketClassList = Database.TicketClasses.ToList();
            return ticketClassList; 
        }

        #region AirlinesCommission

        public AirlinesCommission GetAirlinesCommission(long airlinesID)
        {
            AirlinesCommission item = new AirlinesCommission();
            item = Database.AirlinesCommissions.Where(ac => ac.SupplierID == airlinesID && ac.IsActive == true && ac.IsRemoved == 0).FirstOrDefault();
            return item;

        }

        public AirlinesCommission GetAirlinesCommission(long airlinesID, int ticketClassID)
        {
            AirlinesCommission item = new AirlinesCommission();
            item = Database.AirlinesCommissions.Where(ac => ac.SupplierID == airlinesID && ac.IsActive == true && ac.IsRemoved == 0 && ac.TicketClassID == ticketClassID).FirstOrDefault();
            return item;
        }

        public List<AirlinesCommission> GetAirlinesCommissionList(long airlinesID)
        {
            List<AirlinesCommission> airlinesCommissionList = new List<AirlinesCommission>();
            airlinesCommissionList = Database.AirlinesCommissions.Where(ac => ac.SupplierID == airlinesID && ac.IsRemoved == 0 && ac.IsActive == true).ToList();
            foreach (AirlinesCommission airCom in airlinesCommissionList)
            {
                airCom.TicketClass = airCom.TicketClass;
            }
            return airlinesCommissionList;
              
        }

        #endregion


        #region Payment
        public ReceiptHistory GetReceiptHistoryByCustomerID(DateTime fromDate, DateTime toDate, int referenceTypeID, long referenceID, int branchID)
        {
            List<Payment> list = new List<Payment>();
            ReceiptHistory receiptHistory = new ReceiptHistory();
            List<TicketSale> ticketSaleList = new List<TicketSale>();
            list = GetPaymentAll().Where(ts => ((fromDate == DateTime.MinValue || (fromDate != DateTime.MinValue && ts.PaymentDate.Date >= fromDate.Date))
                    && (toDate == DateTime.MinValue || (toDate != DateTime.MinValue && ts.PaymentDate.Date <= toDate.Date))
                    && (referenceTypeID <= 0 || (referenceTypeID > 0 && ts.ReferenceTypeID == referenceTypeID))
                    && (referenceID <= 0 || (referenceID > 0 && ts.ReferenceID == referenceID))
                    && (branchID<= 0 || (branchID> 0 && ts.BranchID == branchID))
                //&& (ts.Status != Convert.ToInt32(EnumCollection.PaymentStatus.Paid))
                    )).ToList();
    
                ticketSaleList = GetTicketSaleByCustomerID(referenceID, fromDate, toDate, branchID);
                if (ticketSaleList.Count > 0)
                {
                    decimal totalCustomerReceivable = 0;
                    foreach (TicketSale ticketSale in ticketSaleList)
                    {
                        totalCustomerReceivable += ticketSale.CustomerReceivable;
                    }
                    decimal totalReceived = 0;
                    foreach (Payment payment in list)
                    {
                        totalReceived += payment.PaidAmount;
                    }

                    receiptHistory.TotalReceivable = totalCustomerReceivable;
                    receiptHistory.TotalReceived = totalReceived;
                    receiptHistory.TotalDue = totalCustomerReceivable - totalReceived;
                    receiptHistory.ReferenceType = referenceTypeID;
                    receiptHistory.ReferenceID = referenceID;
                    receiptHistory.ReferenceName = ticketSaleList[0].Customer.Name;
                }
            return receiptHistory;
        }
        public PaymentHistory GetPaymentHistoryByAirlinedID(DateTime fromDate, DateTime toDate, int referenceTypeID, long referenceID, int branchID)
        {
            List<Payment> list = new List<Payment>();
            List<TicketSale> ticketSaleList = new List<TicketSale>();
            PaymentHistory paymentHistory = new PaymentHistory();

            list = GetPaymentAll().Where(ts => ((fromDate == DateTime.MinValue || (fromDate != DateTime.MinValue && ts.PaymentDate.Date >= fromDate.Date))
                    && (toDate == DateTime.MinValue || (toDate != DateTime.MinValue && ts.PaymentDate.Date <= toDate.Date))
                    && (referenceTypeID <= 0 || (referenceTypeID > 0 && ts.ReferenceTypeID == referenceTypeID))
                    && (referenceID <= 0 || (referenceID > 0 && ts.ReferenceID == referenceID))
                    && (branchID <= 0 || (branchID > 0 && ts.BranchID == branchID))
                    //&& (ts.Status != Convert.ToInt32(EnumCollection.PaymentStatus.Paid))
                    )).ToList();

            
                ticketSaleList = GetTicketSaleByReferenceID(referenceID, fromDate, toDate,branchID);
                if (ticketSaleList.Count > 0)
                {
                    decimal totalTicketSale = 0;
                    foreach (TicketSale ticketSale in ticketSaleList)
                    {
                        //totalTicketSale += ticketSale.AirlinesPayable + ticketSale.TAX;
                        totalTicketSale += ticketSale.AirlinesPayable;
                    }
                    decimal totalPayment = 0;
                    foreach (Payment payment in list)
                    {
                        totalPayment += payment.PaidAmount;
                    }

                    paymentHistory.TotalSale = totalTicketSale;
                    paymentHistory.TotalPayment = totalPayment;
                    paymentHistory.TotalDue = totalTicketSale - totalPayment;
                    paymentHistory.ReferenceType = referenceTypeID;
                    paymentHistory.ReferenceID = referenceID;
                    paymentHistory.ReferenceName = ticketSaleList[0].Supplier.Name;
                }
            return paymentHistory;
        }

        public List<TicketSale> GetTicketSaleByReferenceID(long referenceID, DateTime fromDate, DateTime toDate, int branchID)
        {
            List<TicketSale> list = new List<TicketSale>();
            list = GetTicketSaleAll().Where(ts => (fromDate == DateTime.MinValue || (fromDate != DateTime.MinValue && ts.TransactionDate.Date >= fromDate.Date))
                    && (toDate == DateTime.MinValue || (toDate != DateTime.MinValue && ts.TransactionDate.Date <= toDate.Date))                                        
                    && (referenceID <= 0 || (referenceID > 0 && ts.AirlinesID == referenceID))
                    && (branchID <= 0 || (branchID > 0 && ts.BranchID == branchID))
                    //&& (ts.Status != Convert.ToInt32(EnumCollection.TicketSaleStatus.Paid))
                          ).ToList();
            foreach (TicketSale item in list)
            {
                item.Customer = item.Customer;
                item.Supplier = item.Supplier;
                item.TicketClass = item.TicketClass;
            }
            return list;
        }

        public List<TicketSale> GetTicketSaleByCustomerID(long referenceID, DateTime fromDate, DateTime toDate, int branchID)
        {
            List<TicketSale> list = new List<TicketSale>();
            list = GetTicketSaleAll().Where(ts => (fromDate == DateTime.MinValue || (fromDate != DateTime.MinValue && ts.TransactionDate.Date >= fromDate.Date))
                    && (toDate == DateTime.MinValue || (toDate != DateTime.MinValue && ts.TransactionDate.Date <= toDate.Date))
                    && (referenceID <= 0 || (referenceID > 0 && ts.CustomerID== referenceID))
                    && (branchID <= 0 || (branchID > 0 && ts.BranchID == branchID))
                //&& (ts.Status != Convert.ToInt32(EnumCollection.TicketSaleStatus.Paid))
                          ).ToList();
            foreach (TicketSale item in list)
            {
                item.Customer = item.Customer;
                item.Supplier = item.Supplier;
                item.TicketClass = item.TicketClass;
            }
            return list;
        }

        //public List<Payment> GetPaymentListByTicketSaleID(long ticketSaleID, int referenceTypeID)
        //{
        //    List<Payment> list = new List<Payment>();
        //    list = GetPaymentAll().Where(p => p.TicketSaleID == ticketSaleID && p.ReferenceTypeID == referenceTypeID).ToList();       

        //    return list;
        //}

        public List<Payment> GetPaymentAll()
        {
            List<Payment> list = new List<Payment>();
            list = Database.Payments.Where(p => p.IsRemoved == 0).ToList();
            foreach (Payment payment in list)
            {
                //payment.TicketSale = payment.TicketSale;
                if (payment.ReferenceTypeID == Convert.ToInt32(EnumCollection.ReferenceType.Customer))
                {
                    Customer customer = new Customer();
                    customer = Database.Customers.Where(c => c.IID == payment.ReferenceID && c.IsRemoved == 0).FirstOrDefault();
                    payment.Customer = customer;
                }
                if (payment.ReferenceTypeID == Convert.ToInt32(EnumCollection.ReferenceType.Supplier))
                {
                    Supplier supplier = new Supplier();
                    supplier = Database.Suppliers.Where(s => s.IID == payment.ReferenceID && s.IsRemoved == 0).FirstOrDefault();
                    payment.Supplier = supplier;
                }
                Acc_TransactionMaster tmMaster = new Acc_TransactionMaster();
                tmMaster = GetTransactionMasterByTransactionNo(payment.PaymentNo);
                if (tmMaster != null)
                {
                    payment.TransactionMasterID = tmMaster.IID;
                }
            }
            return list;
        }

        public Acc_TransactionMaster GetTransactionMasterByTransactionNo(string transactionNo)
        {
            Acc_TransactionMaster tmMaster = new Acc_TransactionMaster();
            tmMaster = Database.Acc_TransactionMasters.Where(tm => tm.JournalCode == transactionNo && tm.IsRemoved == 0).FirstOrDefault();
            return tmMaster;
        }

        public Payment GetPaymentByReferenceBillNo(string referenceBillNo)
        {
            Payment payment = new Payment();
            try
            {                
                payment = Database.Payments.Where(p => p.ReferenceBillNo == referenceBillNo && p.IsRemoved == 0).FirstOrDefault();                
            }
            catch (Exception ex)
            {
                payment = new Payment();
            }
            return payment;
        }

        public Payment GetPaymentByPaymentNo(string paymentNo, int referenceTypeID)
        {
            Payment payment = new Payment();
            try
            {
                //payment = GetPaymentAll().Where(p => p.IID == id).FirstOrDefault();
                payment = Database.Payments.Where(p => p.PaymentNo== paymentNo && p.ReferenceTypeID == referenceTypeID && p.IsRemoved == 0).FirstOrDefault();
                if (referenceTypeID == Convert.ToInt32(EnumCollection.ReferenceType.Customer))
                {
                    Customer customer = new Customer();
                    customer = Database.Customers.Where(c => c.IID == payment.ReferenceID && c.IsRemoved == 0).FirstOrDefault();
                    payment.Customer = customer;
                }
                if (referenceTypeID == Convert.ToInt32(EnumCollection.ReferenceType.Supplier))
                {
                    Supplier supplier = new Supplier();
                    supplier = Database.Suppliers.Where(s => s.IID == payment.ReferenceID && s.IsRemoved == 0).FirstOrDefault();
                    payment.Supplier = supplier;
                }
            }
            catch (Exception ex)
            {
                payment = new Payment();
            }

            return payment;
        }

        public Payment GetPaymentByID(long id)
        {
            Payment payment = new Payment();
            try
            {
                //payment = GetPaymentAll().Where(p => p.IID == id).FirstOrDefault();
                payment = Database.Payments.Where(p => p.IID == id).FirstOrDefault();
            }
            catch (Exception ex)
            {
                payment = new Payment();
            }

            return payment;
        }

        public Payment GetPaymentByID(long id, int referenceTypeID)
        {
            Payment payment = new Payment();
            try
            {
                payment = GetPaymentAll().Where(p => p.IID == id && p.ReferenceTypeID == referenceTypeID).FirstOrDefault();
                //payment.TicketSale = payment.TicketSale;
                if (referenceTypeID == Convert.ToInt32(EnumCollection.ReferenceType.Customer))
                {
                    Customer customer = new Customer();                    
                    customer = Database.Customers.Where(c=> c.IID == payment.ReferenceID && c.IsRemoved == 0).FirstOrDefault();
                    payment.Customer = customer;
                }
                if (referenceTypeID == Convert.ToInt32(EnumCollection.ReferenceType.Supplier))
                {
                    Supplier supplier = new Supplier();
                    supplier = Database.Suppliers.Where(s=> s.IID == payment.ReferenceID && s.IsRemoved == 0).FirstOrDefault();
                    payment.Supplier = supplier;
                }
            }
            catch (Exception ex)
            {
                payment = new Payment();
            }

            return payment;
        }

        public List<Payment> GetPaymentBySearchParam(string paymentNo, string transactionNo, DateTime fromDate, DateTime toDate, int referenceTypeID, long referenceID, int branchID)
        {
            List<Payment> list = new List<Payment>();
            list = GetPaymentAll().Where(ts => (paymentNo == string.Empty || (paymentNo != string.Empty && (ts.PaymentNo.Trim().ToLower().Contains(paymentNo.ToLower().Trim()))))
                    //&& (transactionNo == string.Empty || (transactionNo != string.Empty && (ts.TicketSale.TransactionNo.Trim().ToLower().Contains(transactionNo.ToLower().Trim()))))
                    && (fromDate == DateTime.MinValue || (fromDate != DateTime.MinValue && ts.PaymentDate.Date >= fromDate.Date))
                    && (toDate == DateTime.MinValue || (toDate != DateTime.MinValue && ts.PaymentDate.Date <= toDate.Date))
                    && (referenceTypeID <= 0 || (referenceTypeID > 0 && ts.ReferenceTypeID == referenceTypeID))
                    && (referenceID <= 0 || (referenceID > 0 && ts.ReferenceID == referenceID))
                    && (branchID <= 0 || (branchID > 0 && ts.BranchID == branchID))
                          ).ToList();
            



            return list;
        }
        
        #endregion

        public List<TicketSale> GetTicketSaleBySearchParam(string transactionNo, DateTime fromDate, DateTime toDate)
        {
            List<TicketSale> list = new List<TicketSale>();
            list = GetTicketSaleAll().Where(ts => (transactionNo == string.Empty || (transactionNo != string.Empty && (ts.TransactionNo.Trim().ToLower().Contains(transactionNo.ToLower().Trim()))))
                    && (fromDate == DateTime.MinValue || (fromDate != DateTime.MinValue && ts.TransactionDate.Date >= fromDate.Date))
                    && (toDate == DateTime.MinValue || (toDate != DateTime.MinValue && ts.TransactionDate.Date <= toDate.Date))

                          ).ToList();
            return list;
        }

        public List<TicketSale> GetTicketSaleAll()
        {
            List<TicketSale> list = new List<TicketSale>();
            list = Database.TicketSales.Where(ts => ts.IsRemoved == 0).ToList();
            foreach (TicketSale item in list)
            {
                item.Customer = item.Customer;
                item.Supplier = item.Supplier;
                item.TicketClass = item.TicketClass;
                item.BranchInfo = item.BranchInfo;
            }
            return list;
        }

        public TicketSale GetTicketSaleByID(long id)
        {
            TicketSale item = new TicketSale();
            try
            {
                item = Database.TicketSales.Where(ts => ts.IID == id && ts.IsRemoved == 0).FirstOrDefault();
                item.Supplier = item.Supplier;
                item.Customer = item.Customer;
            }
            catch (Exception ex)
            {
 
            }
            return item;
        }
    }
}
