using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

//using Data.SMSMoney;
using OMS.DAL;

namespace OMS.Facade
{
    class BaseFacade :IDisposable
    {
        private OMSDataContext _Database;

        public OMSDataContext Database
        {
            get
            {
                return _Database;
            }
        }

        public BaseFacade(OMSDataContext database)
        {
            _Database = database;
        }
        public void Dispose()
        {
            _Database.Dispose();
        }
    }
}
