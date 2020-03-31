using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OMS.DAL;

namespace OMS.Facade
{
    public interface ICustomerFacade
    {
        //Customer
        List<Customer> GetCustomerAll();
        Int32 GetCustomerCount();
        List<Customer> GetCustomerByNameAndCode(string Name,string Code);
        Customer GetCustomerByName(string Name);
        Customer GetCustomerByID(long id);
        Customer GetCustomerByNameAndIID(string Name,long iid);
        //Supplier
        List<Supplier> GetSupplierAll();
        List<Supplier> GetSupplierByNameAndCode(string Name, string Code);
        Supplier GetSupplierByName(string Name);
        Supplier GetSupplierByNameAndIID(string Name,long iid);
        Supplier GetSupplierByIID(long iid);
        void Dispose();
    }

    class CustomerFacade: BaseFacade,ICustomerFacade 
    {
        public CustomerFacade(OMSDataContext database)
            : base(database)
        {
        }

        #region ICustomerFacade Members
        public Int32 GetCustomerCount()
        {
            return Database.Customers.ToList().Count();
        }

        public Customer GetCustomerByName(string Name)
        {
            return Database.Customers.Where(c => c.Name == Name && c.IsRemoved == 0).FirstOrDefault();
        }

        public Customer GetCustomerByNameAndIID(string Name, long iid)
        {
            return Database.Customers.Where(c => c.Name == Name && c.IID !=iid && c.IsRemoved == 0).FirstOrDefault();
        }

        public List<Customer> GetCustomerAll()
        {
            List<Customer> customerList = new List<Customer>();
            customerList = Database.Customers.Where(c => c.IsRemoved == 0).ToList();

            return customerList;
        }

        public List<Customer> GetCustomerByNameAndCode(string Name,string Code)
        {
            List<Customer> customerList = new List<Customer>();
            customerList = Database.Customers.Where(c => c.IsRemoved == 0 && c.Name==Name &&c.Code==Code).ToList();

            return customerList;
        }

        public Customer GetCustomerByID(long id)
        {
            Customer customer = new Customer();
            customer = Database.Customers.Single(c => c.IID == id && c.IsRemoved == 0);
            return customer;
        }

        #endregion

        #region Supplier

        public Supplier GetSupplierByName(string Name)
        {
            return Database.Suppliers.Where(s => s.Name == Name).FirstOrDefault();
        }

        public Supplier GetSupplierByNameAndIID(string Name, long iid)
        {
            return Database.Suppliers.Where(s => s.Name == Name && s.IID!=iid).FirstOrDefault();
        }

        public Supplier GetSupplierByIID(long iid)
        {
            return Database.Suppliers.Where(s => s.IID == iid && s.IsRemoved==0).FirstOrDefault();
        }

        public List<Supplier> GetSupplierAll()
        {
            List<Supplier> SupplierList = new List<Supplier>();
            SupplierList = Database.Suppliers.Where(c => c.IsRemoved == 0).ToList();

            return SupplierList;
        }

        public List<Supplier> GetSupplierByNameAndCode(string Name, string Code)
        {
            List<Supplier> SupplierList = new List<Supplier>();
            SupplierList = Database.Suppliers.Where(c => c.IsRemoved == 0 && c.Name==Name && c.Code==Code).ToList();

            return SupplierList;
        }

        #endregion
    }
}
