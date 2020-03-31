using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using OMS.Facade;

namespace OMS.WebClient.Helpers
{
    public static class CommonHelper
    {
        public static string GenerateSupplierCode()
        {
            string code = "S";
            string numCode = string.Empty;
            using (TheFacade _facade = new TheFacade())
            {
                Int32 count = _facade.SupplierFacade.GetSupplierCount();
                if (count > 0)
                {
                    numCode = (count + 1).ToString().PadLeft(6, '0');
                }
                else
                {
                    numCode = "000001";
                }

            }
            code = code + numCode;
            return code;
        }

        public static string GenerateCustomerCode()
        {
            string code = "C";
            string numCode = string.Empty;
            using (TheFacade _facade = new TheFacade())
            {
                Int32 count = _facade.CustomerFacade.GetCustomerCount();
                if (count > 0)
                {                    
                    numCode = (count+1).ToString().PadLeft(6, '0');
                }
                else
                {
                    numCode = "000001";
                }

            }
            code = code + numCode;
            return code;
        }

        public static string GenerateAssetCode()
        {
            string code = "A";
            string numCode = string.Empty;
            using (TheFacade _facade = new TheFacade())
            {
                Int32 count = _facade.AssetFacade.GetAssectTypeMaxID();
                if (count > 0)
                {
                    numCode = (count + 1).ToString().PadLeft(6, '0');
                }
                else
                {
                    numCode = "000001";
                }

            }
            code = code + numCode;
            return code;
        }

        public static string GenerateChequeBookNo()
        {
            string chequeBookNo = "CB";
            string numCode = string.Empty;
            using (TheFacade _facade = new TheFacade())
            {
                Int32 count = _facade.AccountsFacade.GetChequeBookAll().Count;
                //if (count > 0)
                //{
                    numCode = (count+1).ToString().PadLeft(6, '0');
                //}
                //else
                //{
                //    numCode = "000001";
                //}

            }
            chequeBookNo = chequeBookNo + numCode;
            return chequeBookNo;
        }
    }
}
