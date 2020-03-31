using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OMS.DAL
{
    public partial class TicketClass
    {
        private AirlinesCommission _airlinesCommission;
        public AirlinesCommission AirlinesCommissionSingle
        {
            get
            {
                if (_airlinesCommission == null)
                {
                    _airlinesCommission = null;
                }
                else if(_airlinesCommission != null)
                {
                    if (_airlinesCommission.IID <= 0)
                    {
                        _airlinesCommission = null;
                    }
                }
                return _airlinesCommission;
            }
            set
            {
                _airlinesCommission = value;
            }

        }

        //private Decimal _totalSale;
        //public Decimal TotalSale
        //{
        //    get
        //    {
        //        if (_totalSale == 0 || _totalSale == null)
        //        {
        //            _totalSale = 0;
        //        }
        //        return _totalSale;
        //    }
        //    set
        //    {
        //        _totalSale = value;
        //    }

        //}
    }
}
