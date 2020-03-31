using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

//using Data.SMSMoney;
using OMS.DAL;

namespace OMS.Facade
{
    public class TheFacade :IDisposable
    {
        public TheFacade()
        {
            _Database = DatabaseHelper.GetData();
        }

        private OMSDataContext _Database;
        public OMSDataContext Database
        {
            get
            {
                if (_Database == null)
                    _Database = DatabaseHelper.GetData();

                return _Database;
            }
        }

        #region insert, update and delete method (common for all facade)
        public void Insert<T>(T obj) where T : class
        {
            DatabaseHelper.Insert<T>(obj);
        }

        public void Update<T>(T obj) where T : class
        {
            DatabaseHelper.Update<T>(Database, obj);
        }

        public void Delete<T>(T obj) where T : class, new()
        {
            DatabaseHelper.Delete<T>(Database, obj);
        }

        #endregion

       public void Dispose()
       {
           _Database.Dispose();
           //InventoryGeneralFacade.Dispose();
       }

       //private IGeneralFacade _generalFacade = null;
       //public IGeneralFacade GeneralFacade
       //{
       //    get
       //    {
       //        if (_generalFacade == null)
       //            _generalFacade = new GeneralFacade(Database);

       //        return _generalFacade;
       //    }
       //}

       private ITicketSaleFacade _ticketSaleFacade = null;
       public ITicketSaleFacade TicketSaleFacade
       {
           get
           {
               if (_ticketSaleFacade == null)
                   _ticketSaleFacade = new TicketSaleFacade(Database);

               return _ticketSaleFacade;
           }
       }

       private IAdminFacade _adminFacade = null;
       public IAdminFacade AdminFacade
       {
           get
           {
               if (_adminFacade == null)
                   _adminFacade = new AdminFacade(Database);

               return _adminFacade;
           }
       }

       private IInventoryGeneralFacade _inventoryGeneralFacade = null;
       public IInventoryGeneralFacade InventoryGeneralFacade
       {
           get
           {
               if (_inventoryGeneralFacade == null)
                   _inventoryGeneralFacade = new InventoryGeneralFacade(Database);

               return _inventoryGeneralFacade;
           }
       }

       private IItemFacade _itemFacade = null;
       public IItemFacade ItemFacade
       {
           get
           {
               if (_itemFacade == null)
                   _itemFacade = new ItemFacade(Database);

               return _itemFacade;
           }
       }

       private IChannelFacade _channelFacade = null;

       
        public IChannelFacade ChannelFacade
       {
           get
           {
               if (_channelFacade == null)
                   _channelFacade = new ChannelFacade(Database);

               return _channelFacade;
           }
       }

        

        private ICommonFacade _commonFacade = null;
       public ICommonFacade CommonFacade
       {
           get
           {
               if (_commonFacade == null)
                   _commonFacade = new CommonFacade(Database);

               return _commonFacade;
           }
       }

       private IOrderFacade _orderFacade = null;
       public IOrderFacade OrderFacade
       {
           get
           {
               if (_orderFacade == null)
                   _orderFacade = new OrderFacade(Database);

               return _orderFacade;
           }
       }

       private ISupplierFacade _supplierFacade = null;
       public ISupplierFacade SupplierFacade
       {
           get
           {
               if (_supplierFacade == null)
                   _supplierFacade = new SupplierFacade(Database);

               return _supplierFacade;
           }
       }

       private IStockFacade _stockFacade = null;
       public IStockFacade StockFacade
       {
           get
           {
               if (_stockFacade == null)
                   _stockFacade = new StockFacade(Database);

               return _stockFacade;
           }
       }

       private IMemberFacade _memberFacade = null;
       public IMemberFacade MemberFacade
        {
           get
           {
               if (_memberFacade == null)
                    _memberFacade = new MemberFacade(Database);

               return _memberFacade;
           }
       }

       private ICustomerFacade _customerFacade = null;
       public ICustomerFacade CustomerFacade
       {
           get
           {
               if (_customerFacade == null)
                   _customerFacade = new CustomerFacade(Database);

               return _customerFacade;
           }
       }

       private IEmployeeFacade _employeeFacade = null;
       public IEmployeeFacade EmployeeFacade
       {
           get
           {
               if (_employeeFacade == null)
                   _employeeFacade = new EmployeeFacade(Database);

               return _employeeFacade;
           }
       }

       private IAccountsFacade _accountFacade = null;
       public IAccountsFacade AccountsFacade
       {
           get
           {
               if (_accountFacade == null)
                   _accountFacade = new AccountsFacade(Database);

               return _accountFacade;
           }
       }

       private ISecurityFacade _securityFacade = null;
       public ISecurityFacade SecurityFacade
       {
           get
           {
               if (_securityFacade == null)
                   _securityFacade = new SecurityFacade(Database);

               return _securityFacade;
           }
       }

       private IAssetFacade _assetFacade = null;
       public IAssetFacade AssetFacade
       {
           get
           {
               if (_assetFacade == null)
                   _assetFacade = new AssetFacade(Database);

               return _assetFacade;
           }
       }

       private IInsentiveFacade _insentiveFacade = null;
       public IInsentiveFacade InsentiveFacade
       {
           get
           {
               if (_insentiveFacade == null)
                   _insentiveFacade = new InsentiveFacade(Database);

               return _insentiveFacade;
           }
       }

        private IInvoiceFacade _invoiceFacade = null;
        public IInvoiceFacade InvoiceFacade
        {
            get
            {
                if (_invoiceFacade == null)
                    _invoiceFacade = new InvoiceFacade(Database);

                return _invoiceFacade;
            }
        }
    }
}
