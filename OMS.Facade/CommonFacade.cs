using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OMS.DAL;

namespace OMS.Facade
{
    public interface ICommonFacade
    {
        //City
        List<City> GetCityAll();
        City GetCityByID(int id);        

        //Country
        List<Country> GetCountryAll();

        //BranchInfo
        List<BranchInfo> GetBranchInfoAll();
        BranchInfo GetBranchInfoByID(int id);        

        //CompanyInfo
        List<CompanyInfo> GetCompanyInfoAll();
        CompanyInfo GetCompanyInfoByID(int id);

        CompanyType GetCompanyTypeById(int id);
        CompanyCategory GetCompanyCategotyById(int id);
        void Dispose();

        CompanyInfo GetCurrentCompanyInfo();
        List<CompanyInfo> GetCompanyLocation();

        Member GetMemberNameById(int id);

        List<Currency> GetCurrencyAll();

    }
    class CommonFacade:BaseFacade,ICommonFacade
    {
        public CommonFacade(OMSDataContext database)
            : base(database)
        {
        }

        #region BranchInfo
        public List<BranchInfo> GetBranchInfoAll()
        {
            List<BranchInfo> list = new List<BranchInfo>();
            list = Database.BranchInfos.Where(b => b.IsRemoved == 0).ToList();
           
            return list;
        }

        public BranchInfo GetBranchInfoByID(int id)
        {
            BranchInfo branchInfo = new BranchInfo();
            branchInfo = Database.BranchInfos.Where(b => b.IID == id && b.IsRemoved == 0).FirstOrDefault();
            return branchInfo;
        }

        #endregion
        
        #region CompanyInfo

        public List<CompanyInfo> GetCompanyInfoAll()
        {
            List<CompanyInfo> list = new List<CompanyInfo>();
            list = Database.CompanyInfos.Where(b => b.IsRemoved == 0).ToList();

            return list;
        }

        public CompanyInfo GetCompanyInfoByID(int id)
        {
            CompanyInfo item = new CompanyInfo();
            item = Database.CompanyInfos.Where(c => c.IID == id && c.IsRemoved == 0).FirstOrDefault();
            return item;
        }

        public CompanyInfo GetCurrentCompanyInfo()
        {
            return Database.CompanyInfos.Where(c => c.IsRemoved == 0).FirstOrDefault();
        }

        //public CompanyInfo GetCompanyLocation(string latitude, string longitude)
        //{
        //    CompanyInfo latLong = new CompanyInfo();
        //    latLong =  Database.CompanyInfos.Where(c => c.Latitude == latitude && c.Longitude == longitude).FirstOrDefault();            
        //    return latLong;
        //}

        public List<CompanyInfo> GetCompanyLocation()
        {
            List<CompanyInfo> latLong = new List<CompanyInfo>();
            latLong = Database.CompanyInfos.Where(c => c.IsRemoved==0).ToList();
            return latLong;
        }

        #endregion
        #region ICommonFacade Members

        public List<Country> GetCountryAll()
        {
            List<Country> countryList = new List<Country>();
            countryList = Database.Countries.ToList();
            return countryList;
        }

        public List<City> GetCityAll()
        {
            List<City> cityList = new List<City>();
            cityList = Database.Cities.Where(c => c.IsRemoved == 0).ToList();
            return cityList;
        }

        public City GetCityByID(int id)
        {
            City city = new City();
            city = Database.Cities.Single(c => c.IID == id && c.IsRemoved == 0);
            return city;
        }
        #endregion


        #region Company Type and Category

        public CompanyType GetCompanyTypeById(int id)
        {
            return Database.CompanyTypes.Where(c => c.ID == id).FirstOrDefault();
        }

        public CompanyCategory GetCompanyCategotyById(int id)
        {
            return Database.CompanyCategories.Where(c => c.ID == id).FirstOrDefault();
        }

        public Member GetMemberNameById(int id)
        {
            return Database.Members.Where(c => c.ID == id).FirstOrDefault();
        }

        public List<Currency> GetCurrencyAll()
        {
            List<Currency> currencies = new List<Currency>();
            currencies = Database.Currencies.Where(c => c.IsRemove == false).ToList();
            return currencies;
        }

        #endregion



        #region


        #endregion
    }
}
