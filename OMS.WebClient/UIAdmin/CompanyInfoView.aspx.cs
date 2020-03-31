using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using OMS.DAL;
using OMS.Facade;
using OMS.Web.Helpers;
using OMS.Framework;
using System.Data;

namespace OMS.WebClient.UIAdmin
{
    public partial class CompanyInfoView : System.Web.UI.Page
    {
        public int CurrentCompanyID
        {
            get
            {
                if (ViewState["CompanyID"] == null)
                {
                    return -1;
                }
                else
                {
                    return Convert.ToInt32(ViewState["CompanyID"]);
                }
            }
            set { ViewState["CompanyID"] = value; }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            //heck has existing Company Info
            // If found load the Data and ready for update
            //If not.. ready for Save


            if (!IsPostBack)
            {
                CompanyInfo companyInfo = new CompanyInfo();
                DataTable table = new DataTable();
                using (TheFacade facade = new TheFacade())
                {
                    companyInfo = facade.CommonFacade.GetCurrentCompanyInfo();
                    if (companyInfo != null && companyInfo.IID > 0)
                    {
                        LoadCompanyData(companyInfo);

                        table = new DataTable();
                        table.Columns.Add("Latitude", typeof(string));
                        table.Columns.Add("Longitude", typeof(string));
                        table.Columns.Add("Name", typeof(string));
                        table.Columns.Add("Description", typeof(string));
                        table.Columns.Add("Website", typeof(string));


                        table.Rows.Add(companyInfo.Latitude, companyInfo.Longitude, companyInfo.Description, companyInfo.Name, companyInfo.Website);

                    }
                }

                LoadCity();
                LoadCountry();
                //CompanyLocation();                
                rptMarkers.DataSource = table;
                rptMarkers.DataBind();


            }
        }

        private void LoadCompanyData(CompanyInfo companyInfo)
        {
            txtCompanyName.Text = companyInfo.Name;
            txtCompanyAddress.Text = companyInfo.Address;
            txtCompanyEmail.Text = companyInfo.Email;
            ddlCity.Text = companyInfo.CityID.ToString();
            txtCompanyFax.Text = companyInfo.Fax;
            txtCompanyPhone.Text = companyInfo.Phone;
            ddlCountry.Text = companyInfo.CountryID.ToString();
            txtDescription.Text = companyInfo.Description;
            txtLicencedNumber.Text = companyInfo.LicencedNumber;
            txtSlogan.Text = companyInfo.Slogan;
            txtTINNumber.Text = companyInfo.TINNumber;
            txtVATRegistrationNumber.Text = companyInfo.VATRegistrationNumber;
            txtWebsite.Text = companyInfo.Website;
            txtZip.Text = companyInfo.Zip;
            txtLongitude.Text = companyInfo.Longitude;
            txtLatitude.Text = companyInfo.Latitude;

            CurrentCompanyID = companyInfo.IID;
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {

            if (CurrentCompanyID <= 0)
            {
                try
                {
                    CompanyInfo company = new CompanyInfo();
                    company = CreateCompany(company);
                    using (TheFacade facade = new TheFacade())
                    {
                        facade.Insert<CompanyInfo>(company);
                        CurrentCompanyID = company.IID;
                    }
                    Session["IsSaved"] = true;
                    //Response.Redirect(Request.Url.ToString());
                }
                catch (Exception ex)
                {
                    lblMsg.Text = "Data not saved...";
                    lblMsg.Visible = true;
                }
            }
            else
            {
                try
                {
                    // CompanyInfo company = new CompanyInfo();
                    using (TheFacade facade = new TheFacade())
                    {
                        CompanyInfo company = facade.CommonFacade.GetCompanyInfoByID(CurrentCompanyID);
                        company = CreateCompany(company);
                        facade.Update<CompanyInfo>(company);
                    }
                    Session["IsSaved"] = true;
                    //Response.Redirect(Request.Url.ToString());
                }
                catch
                {
                    lblMsg.Text = "Data not saved...";
                    lblMsg.Visible = true;
                }
            }
        }


        private CompanyInfo CreateCompany(CompanyInfo companyInfo)
        {

            companyInfo.Name = txtCompanyName.Text.Trim();
            companyInfo.Address = txtCompanyAddress.Text.Trim();
            companyInfo.Email = txtCompanyEmail.Text.Trim();
            companyInfo.CityID = Convert.ToInt64(ddlCity.SelectedValue);
            companyInfo.Fax = txtCompanyFax.Text.Trim();
            companyInfo.Phone = txtCompanyPhone.Text.Trim();
            companyInfo.CountryID = Convert.ToInt64(ddlCountry.SelectedValue);
            companyInfo.Description = txtDescription.Text.Trim();
            companyInfo.LicencedNumber = txtLicencedNumber.Text.Trim();
            companyInfo.LogoLocation = "Nothing";
            companyInfo.Slogan = txtSlogan.Text.Trim();
            companyInfo.TINNumber = txtTINNumber.Text.Trim();
            companyInfo.VATRegistrationNumber = txtVATRegistrationNumber.Text.Trim();
            companyInfo.Website = txtWebsite.Text.Trim();
            companyInfo.Zip = txtZip.Text.Trim();
            companyInfo.Latitude = txtLatitude.Text.Trim();
            companyInfo.Longitude = txtLongitude.Text.Trim();

            if (companyInfo.IID <= 0)
            {
                companyInfo.CreateBy = 1;
                companyInfo.CreateDate = DateTime.Now;
            }
            companyInfo.UpdateBy = 1;
            companyInfo.UpdateDate = DateTime.Now;
            companyInfo.IsRemoved = 0;
            return companyInfo;
        }

        private void LoadCity()
        {
            using (TheFacade facade = new TheFacade())
            {
                List<City> cityList = facade.CommonFacade.GetCityAll();
                DDLHelper.Bind<City>(ddlCity, cityList, "Name", "IID", EnumCollection.ListItemType.City, true);
            }
        }
        private void LoadCountry()
        {
            using (TheFacade facade = new TheFacade())
            {
                List<Country> countryList = facade.CommonFacade.GetCountryAll();
                DDLHelper.Bind<Country>(ddlCountry, countryList, "Name", "IID", EnumCollection.ListItemType.Country, true);
            }
        }

        private List<CompanyInfo> CompanyLocation()
        {
            //CompanyInfo companyinfo = new CompanyInfo();
            List<CompanyInfo> companyinfo = new List<CompanyInfo>();
            using (TheFacade facade = new TheFacade())
            {
                //companyinfo = facade.CommonFacade.GetCompanyLocation(companyinfo.Latitude, companyinfo.Longitude);
                companyinfo = facade.CommonFacade.GetCompanyLocation();
            }

            return companyinfo;

        }


    }
}