using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OMS.DAL;

namespace OMS.Facade
{

    public interface ISupplierFacade
    {
        //Supplier
        List<Supplier> GetSupplierAll();
        int GetSupplierCount();
        Supplier GetSupplierByID(long id);

        void Dispose();
    }

    class SupplierFacade: BaseFacade,ISupplierFacade 
    {
        public SupplierFacade(OMSDataContext database)
            : base(database)
        {
        }

        #region ISupplierFacade Members

        public List<Supplier> GetSupplierAll()
        {
            List<Supplier> supplierList = new List<Supplier>();            
            supplierList = Database.Suppliers.Where(s => s.IsRemoved == 0).ToList();
            
            return supplierList; 
        }

        public int GetSupplierCount()
        {
            Int32 count;
            count = Database.Suppliers.ToList().Count();

            return count; 
        }
        public Supplier GetSupplierByID(long id)
        {
            Supplier supplier = new Supplier();
            supplier = Database.Suppliers.Single(s => s.IID == id && s.IsRemoved == 0);            
            return supplier;
        }

        #endregion
    }
}
