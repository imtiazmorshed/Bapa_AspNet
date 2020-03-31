using OMS.DAL;
using OMS.Facade;
using OMS.Framework;
using OMS.Web.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OMS.Incentive.MemberRegisterd
{
    public partial class ExistingMemberRegistrationForm : System.Web.UI.Page
    {
        public int showHide = 0;
        protected void Page_Load(object sender, EventArgs e)
        {            
            if (!IsPostBack)
            {
                LoadBusniessType();
                LoadCompanyType();
                LoadCompanyCategory();
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            // create membership user
            //Please check first anyuser already has same email 
            MembershipUser user = null;

            //txtPassword.Text = Convert.ToInt32(123456).ToString();
            string Password= txtPassword.Text.Trim();
            string UserName = txtEmail.Text.Trim();

            try
            {
                user = Membership.CreateUser(UserName, Password);
            }
            catch (Exception ex)
            {
                
            }
            //create system User
            if (user != null)
            {
                SystemUser systemuser = new SystemUser();
                systemuser = CreateSystemUser(user.ProviderUserKey.ToString());
                using (TheFacade facade = new TheFacade())
                {
                    facade.Insert<SystemUser>(systemuser);
                }
            }
            // create Member
            Member member = new Member();
            member = CreateMamber(user.ProviderUserKey.ToString());
            using (TheFacade facade = new TheFacade())
            {
                facade.Insert<Member>(member);
            }
            // add varification data with pending status

            Ins_MemberVerification memberVerification = new Ins_MemberVerification();
            memberVerification.MemberID = member.ID;
            memberVerification.Status = (int)EnumCollection.VerificationStatus.Pending;
            //memberVerification.LastUpdateDate = D
            using (TheFacade facade = new TheFacade())
            {
                facade.Insert<Ins_MemberVerification>(memberVerification);

                List<Ins_VerificationType> typeList = facade.MemberFacade.GetAllVerificationType();
                foreach (Ins_VerificationType type in typeList)
                {
                    Ins_MemberVerificationDetail detail = new Ins_MemberVerificationDetail();
                    detail.MemberID = member.ID;
                    detail.Status = (int)EnumCollection.VerificationStatus.Pending;
                    detail.VerificationTypeId = type.IID;
                    facade.Insert<Ins_MemberVerificationDetail>(detail);
                }
            }


        }
        public Member CreateMamber(string ProviderUserKey)
        {
            Member aMember = new Member();
            aMember.Name = txtCompanyName.Text.Trim();
            aMember.NameBangla = txtCompanyNameBangla.Text.Trim();
            aMember.Address = txtCompanyAddress.Text.Trim();
            aMember.AddressBangla = txtCompanyAddressBangla.Text.Trim();
            aMember.Phone = txtPhone.Text.Trim();
            aMember.Mobile = txtMobile.Text.Trim();
            aMember.Email = txtEmail.Text.Trim();
            aMember.Fax = txtFax.Text.Trim();
            aMember.CompanyEstablishmentYear = Convert.ToInt32(txtCompanyEstablishmentDate.Text.Trim());
            aMember.IndustryLocation = txtIndustryLocation.Text;
            aMember.IndustryFoundationYear = Convert.ToInt32(txtIndustryFoundationDate.Text);
            aMember.TypeOfBusiness = ddlBusniessTypes.SelectedItem.ToString();
            aMember.CompanyTypeID = Convert.ToInt32(ddlCompanyType.SelectedValue);
            aMember.CompanyCategoryID = Convert.ToInt32(ddlCompanyCategory.SelectedValue);
            aMember.ManufacturedProducts = txtManufacturedProducts.Text;
            aMember.ImportedProducts = txtImportedProducts.Text;
            aMember.ExportedProducts = txtExportedProducts.Text;
            aMember.NameOfTheAssociations = txtNameOfTheAssociations.Text;
            aMember.MembershipStatus = Convert.ToInt32(EnumCollection.MembershipStatus.Pending);
            aMember.TypeOfSubmission = Convert.ToInt32(EnumCollection.TypeOfSubmission.Existing);
            aMember.MembershipCode = txtMembershipCode.Text;
            aMember.ProviderKey = ProviderUserKey;
            if (aMember.ID <= 0)
            {
                aMember.CreateBy = 1;
                aMember.CreateDate = DateTime.Now;
            }
            aMember.UpdateBy = 1;
            aMember.UpdateDate = DateTime.Now;
            aMember.IsRemoved = 0;

            return aMember;
        }

        public Member CreateExistingMamberRegistration(string ProviderUserKey)
        {
            Member aMember = new Member();
            aMember.Name = txtCompanyName.Text.Trim();
            aMember.NameBangla = txtCompanyNameBangla.Text.Trim();
            aMember.Address = txtCompanyAddress.Text.Trim();
            aMember.AddressBangla = txtCompanyAddressBangla.Text.Trim();
            aMember.Phone = txtPhone.Text.Trim();
            aMember.Mobile = txtMobile.Text.Trim();
            aMember.Email = txtEmail.Text.Trim();


            aMember.Fax = txtFax.Text.Trim();
            aMember.CompanyEstablishmentYear = Convert.ToInt32(txtCompanyEstablishmentDate.Text.Trim());
            aMember.IndustryLocation = txtIndustryLocation.Text;
            aMember.IndustryFoundationYear = Convert.ToInt32(txtIndustryFoundationDate.Text);
            aMember.TypeOfBusiness = ddlBusniessTypes.SelectedItem.ToString();
            aMember.CompanyTypeID = Convert.ToInt32(ddlCompanyType.SelectedValue);
            aMember.CompanyCategoryID = Convert.ToInt32(ddlCompanyCategory.SelectedValue);
            aMember.ManufacturedProducts = txtManufacturedProducts.Text;
            aMember.ImportedProducts = txtImportedProducts.Text;
            aMember.ExportedProducts = txtExportedProducts.Text;
            aMember.NameOfTheAssociations = txtNameOfTheAssociations.Text;
            aMember.MembershipStatus = Convert.ToInt32(EnumCollection.MembershipStatus.Pending);
            aMember.TypeOfSubmission = Convert.ToInt32(EnumCollection.TypeOfSubmission.Existing);
            aMember.MembershipCode = txtMembershipCode.Text;
            aMember.ProviderKey = ProviderUserKey;
            if (aMember.ID <= 0)
            {
                aMember.CreateBy = 1;
                aMember.CreateDate = DateTime.Now;
            }
            aMember.UpdateBy = 1;
            aMember.UpdateDate = DateTime.Now;
            aMember.IsRemoved = 0;

            return aMember;
        }

        public SystemUser CreateSystemUser(string ProviderUserKey)
        {
            SystemUser aSystemUser = new SystemUser();
            aSystemUser.FirstName = txtCompanyName.Text;
            aSystemUser.Email = txtEmail.Text.Trim();
            aSystemUser.UserName = txtEmail.Text.Trim();
            aSystemUser.Password = txtPassword.Text.Trim();


            aSystemUser.RoleID = 4;
            
            aSystemUser.ProviderKey = ProviderUserKey;
            aSystemUser.Status = Convert.ToBoolean(1);
            aSystemUser.IsRoleBased = false;
            aSystemUser.Roles = "Member";
            aSystemUser.LastName = " ";




            if (aSystemUser.IID <= 0)
            {
                aSystemUser.CreatedBy = 1;
                aSystemUser.CreatedDate = DateTime.Now;
            }
            aSystemUser.UpdatedBy = 1;
            aSystemUser.UpdatedDate = DateTime.Now;
            aSystemUser.IsRemoved = 0;
            return aSystemUser;
        }
        
        
        private void LoadCompanyType()
        {
            using (TheFacade facade = new TheFacade())
            {
                List<CompanyType> companyTypeList = facade.MemberFacade.GetCompanyTypeInfoAll();
                
                DDLHelper.Bind<CompanyType>(ddlCompanyType, companyTypeList, "Name", "ID", EnumCollection.ListItemType.CompanyType, true);
            }
        }
        private void LoadCompanyCategory()
        {
            using (TheFacade facade = new TheFacade())
            {
                List<CompanyCategory> companyCategoryList = facade.MemberFacade.GetCompanyCategoryInfoAll();

                DDLHelper.Bind<CompanyCategory>(ddlCompanyCategory, companyCategoryList, "Name", "ID", EnumCollection.ListItemType.CompanyCategory, true);
            }
        }

        private void LoadBusniessType()
        {
            using (TheFacade facade = new TheFacade())
            {
                List<BusinessType> businessTypeList = facade.MemberFacade.GetBusinessTypeInfoAll();

                DDLHelper.Bind<BusinessType>(ddlBusniessTypes, businessTypeList, "Name", "ID", EnumCollection.ListItemType.BusinessTypeList, true);
            }
        }


    }
}