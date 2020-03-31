using OMS.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OMS.Facade
{

    public interface IAssetFacade
    {
        void Dispose();
        List<Asset_Type> GetAllAssetType();

        Asset_Type GetAssetTypeByName(string name);
        List<AssetInformation> GetAllAssetInformation();

        List<AssetDepriciationRatio> GetAllAssetDepriciationRatio();

        //CompanyInfo GetCompanyLocation(string latitude, string longitude);
        
        List<Asset_Type> GetAssetInfoAll();
        AssetDepriciationRatio GetAssetDepriciationRatioByIID(long AssetDepriciationRatioID);
        Asset_Type GetAssetTypeByID(long iid);
        AssetInformation GetAssetInformationByID(long iid);
        AssetDepriciationRatio GetAssetDepriciationRatioById(long iid);
        bool IsAssetNameAlreadyExist(string name);
        int GetAssectTypeMaxID();
    }
    class AssetFacade:BaseFacade,IAssetFacade
    {
        public AssetFacade(OMSDataContext database)
            : base(database)
        {
        }

        public bool IsAssetNameAlreadyExist(string name)
        {
            bool retVal = false;
            Asset_Type type = GetAssetTypeByName(name);

            if (type != null && type.IID > 0)
            {
                retVal = true;
            }
            return retVal;

        }

        public int GetAssectTypeMaxID()
        {
            int id = 0;
            var itemId = Database.Asset_Types.Max(i => i.IID);
            if (itemId != null)
            {
                id = Convert.ToInt32(itemId);
            }

            return id;
        }

        public Asset_Type GetAssetTypeByName(string name)
        {
            return Database.Asset_Types.Where(b => b.Name.ToUpper() == name.Trim().ToUpper() && b.IsRemoved == 0).FirstOrDefault();
        }

        public List<Asset_Type> GetAssetInfoAll()
        {
            List<Asset_Type> assetList = new List<Asset_Type>();
            assetList = Database.Asset_Types.Where(a => a.IsRemoved == 0).ToList();
            return assetList;
        }

        public AssetDepriciationRatio GetAssetDepriciationRatioByIID(long iid)
        {
            return Database.AssetDepriciationRatios.Where(b => b.IID == iid && b.IsRemoved == 0).FirstOrDefault();
        }

        public List<Asset_Type> GetAllAssetType()
        {
            return Database.Asset_Types.Where(b => b.IsRemoved == 0).ToList();
        }

        public List<AssetInformation> GetAllAssetInformation()
        {
            return Database.AssetInformations.Where(b => b.IsRemoved == 0).ToList();
        }

        public Asset_Type GetAssetTypeByID(long iid)
        {
            return Database.Asset_Types.Where(b => b.IID == iid && b.IsRemoved == 0).FirstOrDefault();
        }

        public AssetInformation GetAssetInformationByID(long iid)
        {
            return Database.AssetInformations.Where(b => b.IID == iid && b.IsRemoved == 0).FirstOrDefault();
        }

        public AssetDepriciationRatio GetAssetDepriciationRatioById(long iid)
        {
            return Database.AssetDepriciationRatios.Where(b => b.IID == iid && b.IsRemoved == 0).FirstOrDefault();
        }

        public List<AssetDepriciationRatio> GetAllAssetDepriciationRatio()
        {
            return Database.AssetDepriciationRatios.Where(b => b.IsRemoved == 0).ToList();
        }

    }
}
