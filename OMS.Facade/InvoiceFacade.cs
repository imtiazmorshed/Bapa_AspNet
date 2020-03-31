using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OMS.DAL;

namespace OMS.Facade
{
    public interface IInvoiceFacade
    {
        //Invoice
        List<Inv_Master> GetInvoiceAll();
        Inv_Master GetInvoiceByID(long id);
        Inv_Master GetInvoiceByIDForUpdate(long id);
        Inv_Detail GetInvoiceDetailByID(long id);
        List<Inv_Detail> GetInvoiceDetailAll();
        List<Inv_Detail> GetInvoiceDetailByInvoiceId(long invoiceId);


        void Dispose();
        bool IsExistInvoiceNo(long invoiceId, string invoiceNo);
    }

    class InvoiceFacade:BaseFacade, IInvoiceFacade
    {
        public InvoiceFacade(OMSDataContext database)
            : base(database)
        {
        }

        #region IInvoiceFacade Members
        #region Invoice
        public List<Inv_Master> GetInvoiceAll()
        {
            
            List<Inv_Master> invoiceList = Database.Inv_Masters.Where(i => i.IsRemoved == 0).ToList();
            //foreach(Invoice Invoice in InvoiceList)
            //{
            //    Invoice.MeasurementUnit = Invoice.MeasurementUnit;
            //    Invoice.InvoiceQuantity = Invoice.InvoiceQuantity;
            //    Invoice.Inv_Category = Invoice.Inv_Category;
            //    Invoice.Inv_Category.Inv_Department = Invoice.Inv_Category.Inv_Department; 
            //    InvoiceListNew.Add(Invoice);
            //}
            return invoiceList;
        }
        public bool IsExistInvoiceNo(long invoiceId, string invoiceNo)
        {
            bool isExist = false;
            var item = Database.Inv_Masters.FirstOrDefault(i => i.Number == invoiceNo);
            if (item != null)
            {
                if(item.IID != invoiceId)
                    isExist = true;
            }
            return isExist;
        }

        public Inv_Master GetInvoiceByID(long id)
        {
            Inv_Master Invoice = new Inv_Master();
            Invoice= Database.Inv_Masters.Single(i => i.IID == id && i.IsRemoved == 0);
            Invoice.Currency = Invoice.Currency;
            Invoice.InvoiceDetailList = Invoice.Inv_Details.ToList();
            return Invoice;
        }
        public Inv_Master GetInvoiceByIDForUpdate(long id)
        {
            Inv_Master Invoice = new Inv_Master();
            Invoice = Database.Inv_Masters.Single(i => i.IID == id && i.IsRemoved == 0);
            return Invoice;
        }
        

        public Inv_Detail GetInvoiceDetailByID(long id)
        {
            Inv_Detail invDetail = new Inv_Detail();
            invDetail = Database.Inv_Details.Single(i => i.IID == id && i.IsRemoved == 0);
            return invDetail;
        }

        public List<Inv_Detail> GetInvoiceDetailAll()
        {

            List<Inv_Detail> invoiceDetailList = Database.Inv_Details.Where(i => i.IsRemoved == 0).ToList();
            return invoiceDetailList;
        }

        public List<Inv_Detail> GetInvoiceDetailByInvoiceId(long invoiceId)
        {
            List<Inv_Detail> invoiceDetailList = Database.Inv_Details.Where(i => i.InvMasterId == invoiceId &&  i.IsRemoved == 0).ToList();
            foreach (var invDetail in invoiceDetailList)
            {
                invDetail.Ins_MemberItem = invDetail.Ins_MemberItem;
            }
            return invoiceDetailList;
        }

        #endregion
        #endregion
    }
}
