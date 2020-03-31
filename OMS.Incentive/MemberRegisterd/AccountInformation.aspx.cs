using OMS.DAL;
using OMS.Facade;
using System;
using OMS.Incentive;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using OMS.WebClient;
using System.Web.Security;

namespace OMS.Incentive.MemberRegisterd
{
    public partial class AccountInformation : System.Web.UI.Page
    {
        public long MemberID
        {
            get
            {
                if (Session["MemberID"] == null)
                    return 0;
                else
                    return Convert.ToInt64(Session["MemberID"]);
            }
        }
        
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (!User.Identity.IsAuthenticated)
            //{
            //    FormsAuthentication.RedirectToLoginPage();
            //}


            if (!IsPostBack)
            {
                if (Session["MemberID"] == null)
                {
                    Session.Abandon();
                    //Response.Redirect("~/Login/login.aspx?returnurl="+Request.Url );
                    Response.Redirect("~/Login/login.aspx");
                }
                else
                {
                    MemberAccountInformation();
                    
                }
                
            }


        }
        public void MemberAccountInformation()
        {
            Member member = new Member();
            using (TheFacade facade = new TheFacade())
            {
                member = facade.MemberFacade.GetMemberById(MemberID);
            }

            if (member.ID > 0)
            {
                txtCompanyName.Text = member.Name;
                txtCompanyNameBangla.Text = member.NameBangla;
                txtCompanyAddress.Text = member.Address;
                txtCompanyAddressBangla.Text = member.AddressBangla;
                txtEmail.Text = member.Email;
                txtPhone.Text = member.Phone;
                txtFax.Text = member.Fax;
                txtMobile.Text = member.Mobile;
                txtIndustryLocation.Text = member.IndustryLocation;
                txtCompanyEstablishmentDate.Text = member.CompanyEstablishmentYear.ToString();
                txtIndustryFoundationDate.Text = member.IndustryFoundationYear.ToString();
                txtTypeOfBusiness.Text = member.TypeOfBusiness.ToString();                
                using (TheFacade facade = new TheFacade())
                {
                    CompanyType companyType = facade.CommonFacade.GetCompanyTypeById(member.CompanyTypeID);
                    if (companyType != null)
                    {
                        txtCompanyTypeID.Text = companyType.Name;
                    }

                    CompanyCategory companyCategory = facade.CommonFacade.GetCompanyCategotyById(member.CompanyCategoryID);
                    if (companyType != null)
                    {
                        txtCompanyCategoryID.Text = companyCategory.Name;
                    }
                }


                
                //txtCompanyCategoryID.Text = member.CompanyCategoryID.ToString();
                //txtCompanyCategoryID.Text =  member.CompanyCategory.Name.ToString();
                txtManufacturedProducts.Text = member.ManufacturedProducts;
                txtImportedProducts.Text = member.ImportedProducts;
                txtExportedProducts.Text = member.ExportedProducts;
                txtNameOfTheAssociations.Text = member.NameOfTheAssociations;

            }
            else
            {
                Response.Redirect("/Login/Logout.aspx");
            }
        }
        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            using (TheFacade facade = new TheFacade())
            {
                Member member = new Member();
                member = facade.MemberFacade.GetMemberById(MemberID);
                member = UpdateMamber(member);
                facade.Update<Member>(member);
            }
            lblMessage.Text = "Your Information Update Sucessfully";

        }
        public Member UpdateMamber(Member aMember)
        {
            aMember.Name = txtCompanyName.Text.Trim();
            aMember.NameBangla = txtCompanyNameBangla.Text.Trim();
            aMember.Address = txtCompanyAddress.Text.Trim();
            aMember.AddressBangla = txtCompanyAddressBangla.Text.Trim();
            aMember.Phone = txtPhone.Text.Trim();
            aMember.Mobile = txtMobile.Text.Trim();
            aMember.Email = txtEmail.Text.Trim();
            aMember.Fax = txtFax.Text.Trim();
            aMember.CompanyEstablishmentYear = Convert.ToInt32(txtCompanyEstablishmentDate.Text.Trim());
            aMember.IndustryLocation = txtIndustryLocation.Text.Trim();
            aMember.IndustryFoundationYear = Convert.ToInt32(txtIndustryFoundationDate.Text.Trim());
            aMember.TypeOfBusiness = txtTypeOfBusiness.Text.Trim();
            aMember.CompanyTypeID = Convert.ToInt32(txtCompanyTypeID.Text.Trim());
            aMember.CompanyCategoryID = Convert.ToInt32(txtCompanyCategoryID.Text);
            aMember.ManufacturedProducts = txtManufacturedProducts.Text.Trim();
            aMember.ImportedProducts = txtImportedProducts.Text.Trim();
            aMember.ExportedProducts = txtExportedProducts.Text.Trim();
            aMember.NameOfTheAssociations = txtNameOfTheAssociations.Text.Trim();

            if (aMember.ID <= 0)
            {
                aMember.CreateBy = 1;
                aMember.CreateDate = DateTime.Now;
            }
            aMember.UpdateBy = 2;
            aMember.UpdateDate = DateTime.Now;
            aMember.IsRemoved = 0;

            return aMember;
        }
    }
}