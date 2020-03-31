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
    public partial class ExistingMember : System.Web.UI.Page
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
            //using (TheFacade facade = new TheFacade())
            //{
            //    Member checkMember = facade.MemberFacade.GetMemberByName(txtCompanyName.Text.Trim());
            //    if(checkMember.Name != null)
            //    {
            //        lblmessage.Text = "Company Name is Already Exist !";
            //        Response.Redirect("ExistingMember.aspx");
            //    }
            //}

            // create membership user
            //Please check first anyuser already has same email 
            MembershipUser user = null;

            //txtPassword.Text = Convert.ToInt32(123456).ToString();
            string Password = txtPassword.Text.Trim();
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

            // Account Create
            GetMemberForAccount(member.ID);
            lablmessage.Text = " Registration & Account  Create Succesfully";
            //member.ID = 


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

            aMember.TypeOfBusiness = ddlBusniessTypes.SelectedItem.ToString();
            aMember.CompanyTypeID = Convert.ToInt32(ddlCompanyType.SelectedValue);
            aMember.CompanyCategoryID = Convert.ToInt32(ddlCompanyCategory.SelectedValue);

            
            aMember.MembershipStatus = Convert.ToInt32(EnumCollection.MembershipStatus.Pending);
            aMember.TypeOfSubmission = Convert.ToInt32(EnumCollection.TypeOfSubmission.Existing);
            aMember.MembershipCode = txtMembershipCode.Text;
            aMember.ProviderKey = ProviderUserKey;

            //aMember.Fax = txtFax.Text.Trim();
            //aMember.CompanyEstablishmentYear = Convert.ToInt32(txtCompanyEstablishmentDate.Text.Trim());
            //aMember.IndustryLocation = txtIndustryLocation.Text;
            //aMember.IndustryFoundationYear = Convert.ToInt32(txtIndustryFoundationDate.Text);
            //aMember.ManufacturedProducts = txtManufacturedProducts.Text;
            //aMember.ImportedProducts = txtImportedProducts.Text;
            //aMember.ExportedProducts = txtExportedProducts.Text;
            //aMember.NameOfTheAssociations = txtNameOfTheAssociations.Text;

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



        //Account Number Generate
        public long GetMemberForAccount(long CurrentMemberID)
        {
            try
            {
                if (CurrentMemberID > 0)
                {

                    using (TheFacade facade = new TheFacade())
                    {
                        Member member = facade.MemberFacade.GetMemberById(CurrentMemberID);
                        if (member != null )
                        {
                            member.MemberVerificationStatus = (int)EnumCollection.VerificationStatus.Completed;
                            member.MembershipStatus = (int)EnumCollection.MembershipStatus.Approved;
                            DateTime expireDate = new DateTime(DateTime.Now.Year, 6, 30);
                            if (DateTime.Now.Date > expireDate)
                                expireDate = expireDate.AddYears(1);
                            try
                            {
                                expireDate = Convert.ToDateTime(txtExpireDate.Text);
                            }
                            catch (Exception ex)
                            {
                            }
                            member.MembershipCode = txtMembershipCode.Text;

                            facade.Update<Member>(member);
                            Ins_MembershipExpireInfo info = new Ins_MembershipExpireInfo();
                            info.MemberID = member.ID;
                            info.ExpireDate = expireDate.Date;
                            info.CreateBy = 1;
                            info.CreateDate = DateTime.Now;
                            info.UpdateBy = 1;
                            info.UpdateDate = DateTime.Now;
                            info.IsRemoved = 0;
                            facade.Insert<Ins_MembershipExpireInfo>(info);
                            Ins_MemberVerification memberVerification = facade.MemberFacade.GetMemberVerificationByMemberID(member.ID);
                            if (memberVerification != null)
                            {
                                memberVerification.Status = (int)EnumCollection.VerificationStatus.Completed;
                                facade.Update<Ins_MemberVerification>(memberVerification);
                            }

                            Acc_ChartOfAccount chartofAcc = facade.AccountsFacade.GetAcc_ChartOfAccountByName("Account Receivable");
                            Acc_ChartOfAccountMember customerAccount = new Acc_ChartOfAccountMember();

                            #region acc
                            Acc_ChartOfAccount newAccount = new Acc_ChartOfAccount();
                            newAccount.AccountNo = GenerateAccountNo(chartofAcc.Gparent.ToString());
                            newAccount.Name = member.Name;
                            newAccount.IsActive = 1;

                            newAccount.AccountTypeID = Convert.ToInt32(EnumCollection.AccountType.Transactable);
                            newAccount.ParentID = chartofAcc.IID;
                            newAccount.Gparent = chartofAcc.Gparent;
                            newAccount.OpeningBalance = Convert.ToDecimal(txtOpeningBalance.Text);
                            newAccount.CreateBy = 1;

                            newAccount.UpdateBy = 1;


                            newAccount.CreateDate = DateTime.Now;

                            newAccount.UpdateDate = DateTime.Now;
                            newAccount.IsRemoved = 0;
                            facade.Insert<Acc_ChartOfAccount>(newAccount);

                            #endregion

                            customerAccount.ChartofAccountID = newAccount.IID;
                            customerAccount.MemberID = member.ID;
                            customerAccount.UpdateDate = DateTime.Now;
                            customerAccount.UpdateBy = 1;


                            customerAccount.CreateDate = DateTime.Now;
                            customerAccount.CreateBy = 1;

                            customerAccount.IsRemoved = 0;
                            facade.Insert<Acc_ChartOfAccountMember>(customerAccount);
                        }

                        else
                        {
                            Session["duplicate"] = true;
                        }
                    }
                }
                else
                {
                    using (TheFacade facade = new TheFacade())
                    {

                    }
                }
                Session["IsSaved"] = true;
            }
            catch
            {
                Session["IsSaved"] = false;
            }
            finally
            {
                Response.Redirect(Request.Url.ToString());
            }

           lablmessage.Text = " Registration & Account  Create Succesfully";

            return CurrentMemberID;
        }

        private string GenerateAccountNo(string gParent)
        {
            string code = "";

            code = gParent;
            int count = 0;
            using (TheFacade facade = new TheFacade())
            {
                List<Acc_ChartOfAccount> acclistAnother = facade.AccountsFacade.GetAcc_ChartOfAccountListByGParetntID(Convert.ToInt32(gParent)).OrderBy(a => a.IID).ToList();
                count = acclistAnother.Count + 1;
                code = code + count.ToString().PadLeft(5, '0');
            }
            return code;
        }
    }
}