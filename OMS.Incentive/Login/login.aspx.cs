using OMS.DAL;
using OMS.Facade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OMS.Incentive.Login
{
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //MultiView1.ActiveViewIndex = 0;
            }
        }


        #region Member Registration
        //protected void btnSubmit_Click(object sender, EventArgs e)
        //{
        //    Member member = new Member();
        //    member = CreateMamber(member);
        //    using (TheFacade facade = new TheFacade())
        //    {
        //        facade.Insert<Member>(member);
        //    }
        //}
        //public Member CreateMamber(Member aMember)
        //{
        //    aMember.Name = txtCompanyName.Text.Trim();
        //    aMember.NameBangla = txtCompanyNameBangla.Text.Trim();
        //    aMember.Address = txtCompanyAddress.Text.Trim();
        //    aMember.AddressBangla = txtCompanyAddressBangla.Text.Trim();
        //    aMember.Phone = txtPhone.Text.Trim();
        //    aMember.Mobile = txtMobile.Text.Trim();
        //    aMember.Email = txtEmail.Text.Trim();
        //    aMember.Fax = txtFax.Text.Trim();
        //    //aMember.CompanyEstablishmentDate = Convert.ToDateTime(txtCompanyEstablishmentDate.Text.Trim());com
        //    aMember.CompanyEstablishmentYear = Convert.ToInt32(txtCompanyEstablishmentDate.Text.Trim());
        //    aMember.IndustryLocation = txtIndustryLocation.Text;
        //    aMember.IndustryFoundationYear = Convert.ToInt32(txtIndustryFoundationDate.Text);
        //    aMember.TypeOfBusiness = txtTypeOfBusiness.Text;
        //    aMember.CompanyTypeID = Convert.ToInt32(txtCompanyTypeID.Text);
        //    aMember.CompanyCategoryID = Convert.ToInt32(txtCompanyCategoryID.Text);
        //    aMember.ManufacturedProducts = txtManufacturedProducts.Text;
        //    aMember.ImportedProducts = txtImportedProducts.Text;
        //    aMember.ExportedProducts = txtExportedProducts.Text;
        //    aMember.NameOfTheAssociations = txtNameOfTheAssociations.Text;
        //    aMember.MembershipStatus = Convert.ToInt32(txtMembershipStatus.Text);
        //    aMember.MembershipCode = txtMembershipCode.Text;
        //    aMember.TypeOfSubmission = Convert.ToInt32(txtTypeOfSubmission.Text);

        //    if (aMember.ID <= 0)
        //    {
        //        aMember.CreateBy = 1;
        //        aMember.CreateDate = DateTime.Now;
        //    }
        //    aMember.UpdateBy = 1;
        //    aMember.UpdateDate = DateTime.Now;
        //    aMember.IsRemoved = 0;

        //    return aMember;
        //}

        ////protected void btnGoToStep2_Click(object sender, EventArgs e)
        ////{
        ////    //MultiView1.ActiveViewIndex = 1;
        ////}

        ////protected void btnBackStep1_Click(object sender, EventArgs e)
        ////{
        ////   // MultiView1.ActiveViewIndex = 0;
        ////}

        ////protected void btnGoToStep3_Click(object sender, EventArgs e)
        ////{
        ////   // MultiView1.ActiveViewIndex = 2;
        ////}

        ////protected void btnGoToStepTwo2_Click(object sender, EventArgs e)
        ////{
        ////    //MultiView1.ActiveViewIndex = 4;
        ////}

        ////protected void btnStep2_Click(object sender, EventArgs e)
        ////{
        ////    //MultiView1.ActiveViewIndex = 1;
        ////}

        ////protected void btnStep4_Click(object sender, EventArgs e)
        ////{
        ////    MultiView1.ActiveViewIndex = 3;
        ////}

        ////protected void btnStep3_Click(object sender, EventArgs e)
        ////{
        ////    MultiView1.ActiveViewIndex = 2;
        ////}

        ////protected void btnStep5_Click(object sender, EventArgs e)
        ////{
        ////    MultiView1.ActiveViewIndex = 4;
        ////}

        ////protected void btnStepAgain4_Click(object sender, EventArgs e)
        ////{
        ////    MultiView1.ActiveViewIndex = 3;
        ////}

        ////protected void btnStep6_Click(object sender, EventArgs e)
        ////{
        ////    MultiView1.ActiveViewIndex = 5;
        ////    ShowAll();
        ////}
        //private void ShowAll()
        //{
        //    lblCompanyBangla.Text = " " + txtCompanyNameBangla.Text;
        //    lblCompanyName.Text = " " + txtCompanyName.Text;
        //    lblCompanyAddress.Text = " " + txtCompanyAddress.Text;
        //    lblCompanyAddressBangla.Text = " " + txtCompanyAddressBangla.Text;
        //    lblPhone.Text = " " + txtPhone.Text;
        //    lblMobile.Text = " " + txtMobile.Text;
        //    lblEmail.Text = " " + txtEmail.Text;
        //    lblFax.Text = " " + txtFax.Text;
        //    lblCompanyEstablishmentDate.Text = " " + txtCompanyEstablishmentDate.Text;
        //    lblIndustryLocation.Text = " " + txtIndustryLocation.Text;
        //    lblIndustryFoundationDate.Text = " " + txtIndustryFoundationDate.Text;
        //    lblTypeOfBusiness.Text = " " + txtTypeOfBusiness.Text;
        //    lblCompanyType.Text = " " + txtCompanyTypeID.Text;
        //    lblCompanyCategory.Text = " " + txtCompanyCategoryID.Text;
        //    lblManufacturedProducts.Text = " " + txtManufacturedProducts.Text;
        //    lblImportedProducts.Text = " " + txtImportedProducts.Text;
        //    lblExportedProducts.Text = " " + txtExportedProducts.Text;
        //    lblNameOfTheAssociations.Text = " " + txtNameOfTheAssociations.Text;
        //    lblMembershipStatus.Text = " " + txtMembershipStatus.Text;
        //    lblMembershipCode.Text = " " + txtMembershipCode.Text;
        //    lblTypeOfSubmission.Text = " " + txtTypeOfSubmission.Text;

        //}
        #endregion

        [System.Web.Services.WebMethod]
        public static string GetMemberByName( string name)
        {
            TheFacade facade = new TheFacade();
            Member checkMember = facade.MemberFacade.GetMemberByName(name);
            string returnMSG = "";
            if(checkMember!=null)
            {
                returnMSG = checkMember.Name;
            }

            return returnMSG;
        }

        [System.Web.Services.WebMethod]
        public static string GetUserNameOrPass(string userName, string password)
        {
            TheFacade facade = new TheFacade();
            SystemUser syst = facade.AdminFacade.IsValidUserorPass(userName, password);
            string returndmg = ""; 
            if(returndmg!= "")
            {
                returndmg = syst.UserName;
                returndmg = syst.Password;
            }          
            return returndmg;
            
        }

        protected void btnloginSubmit_Click(object sender, EventArgs e)
        {
            SystemUser syst = new SystemUser();
            string userName = txtUserName.Text.Trim();
            string passWord = txtPassword.Text.Trim();
            bool isValidUser = false;
            using (TheFacade facade = new TheFacade())
            {
                if (facade.AdminFacade.IsValidUser(userName, passWord))
                {
                    isValidUser = true;
                }
            }
            if (isValidUser/*Membership.ValidateUser(userName, passWord)*/)
            {
                MembershipUser user = Membership.GetUser(userName);
                if (user == null)
                    return;
                string userID = user.ProviderUserKey.ToString();
                Session["UserID"] = user.ProviderUserKey.ToString();
                Member member = new Member();
                using (TheFacade facade = new TheFacade())
                {
                    member = facade.MemberFacade.GetMemberByAspnetUserID(userID);
                }
                if (member != null)
                {

                    Session["MemberID"] = member.ID.ToString();
                    Response.Redirect("/MemberRegisterd/AccountInformation.aspx");
                }
                else
                {

                    Response.Redirect("/AdminDashboard.aspx");
                }


            }
            else
            {
                lblLoginStatus.Text = "Invalid User Name or Password";
                // show invalid user
            }
            
           
        }
    }
}