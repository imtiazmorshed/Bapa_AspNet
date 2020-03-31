using OMS.DAL;
using OMS.Facade;
using OMS.Framework;
using OMS.Web.Helpers;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OMS.Incentive.MemberRegisterd
{
    public partial class MemberRegistrationForm : System.Web.UI.Page
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
            //Image Upload

            //string filename = FileUpload1.FileName;
            //FileUpload1.PostedFile.SaveAs(Server.MapPath("~\\UploadMemberCertificates\\" + filename.Trim()));
            //string path = "~\\UploadMemberCertificates\\" + filename.Trim();            

            #region ex
            //if (Request.Files["UploadedFile"] != null)
            //{
            //    HttpPostedFile MyFile = Request.Files["UploadedFile"];
            //    //Setting location to upload files
            //    string TargetLocation = Server.MapPath("~/UploadMemberCertificates/");
            //    try
            //    {
            //        if (MyFile.ContentLength > 0)
            //        {
            //            //Determining file name. You can format it as you wish.
            //            string FileName = MyFile.FileName;
            //            //Determining file size.
            //            int FileSize = MyFile.ContentLength;
            //            //Creating a byte array corresponding to file size.
            //            byte[] FileByteArray = new byte[FileSize];
            //            //Posted file is being pushed into byte array.
            //            MyFile.InputStream.Read(FileByteArray, 0, FileSize);
            //            //Uploading properly formatted file to server.
            //            MyFile.SaveAs(TargetLocation + FileName);
            //        }
            //    }
            //    catch (Exception BlueScreen)
            //    {
            //        //Handle errors
            //    }
            //}
            #endregion

            MembershipUser user = null;            
            string Password = txtPassword.Text.Trim();
            string UserName = txtEmail.Text.Trim();

            try
            {
                user = Membership.CreateUser(UserName, Password);
            }
            catch (Exception ex)
            {
                lblmessage.Text = "User Name is Already Created";
            }
            //create system User
            if (user == null)
            {
                lblmessage.Text = "User failed to create. Please contract with system administrator."; 
                return;
            }
            if (user != null)
            {
                SystemUser systemuser = new SystemUser();
                systemuser = CreateSystemUser(user.ProviderUserKey.ToString());
                using (TheFacade facade = new TheFacade())
                {
                    facade.Insert<SystemUser>(systemuser);
                }
            }
            else
            {
                lblmessage.Text = "User Name is Already Created";
            }

            //create Member
            Member member = new Member();
            member = CreateMamber(user.ProviderUserKey.ToString());
            using (TheFacade facade = new TheFacade())
            {
                facade.Insert<Member>(member);
            }

            // Add role
            //Roles.AddUserToRole(user.UserName, "User");

            

            //create Member Document
            List<MemberDocument> memberDocuments = new List<MemberDocument>();
            memberDocuments = CreateMemberDocument(member.ID);
            foreach (var item in memberDocuments)
            {
                using (TheFacade facade = new TheFacade())
                {
                    facade.Insert<MemberDocument>(item);
                }
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
                    Response.Redirect("");
                }
            }
        }

        public List<MemberDocument> CreateMemberDocument( long ID)
        {
            List<MemberDocument> memberDocuments = new List<MemberDocument>();
            
                try
                {
                    //if (FileUploadTradeLicense.PostedFile.ContentType == "Image/jpeg/png/PNG/jpg/JPG/JPEG" && TINCertificateFileUpload.PostedFile.ContentType == "Image/jpeg/png/PNG/jpg/JPG/JPEG" && VATCertificateFileUpload.PostedFile.ContentType == "Image/jpeg/png/PNG/jpg/JPG/JPEG" && BankStatmentFileUpload.PostedFile.ContentType == "Image/jpeg/png/PNG/jpg/JPG/JPEG" && PartnershipAgrementFileUpload.PostedFile.ContentType == "Image/jpeg/png/PNG/jpg/JPG/JPEG" && PayorderFileUpload.PostedFile.ContentType == "Image/jpeg/png/PNG/jpg/JPG/JPEG")
                    //{
                    //if (fuTradeLicense.PostedFile.ContentLength < 102400 && TINCertificateFileUpload.PostedFile.ContentLength < 102400 && VATCertificateFileUpload.PostedFile.ContentLength < 102400 && BankStatmentFileUpload.PostedFile.ContentLength < 102400 && PartnershipAgrementFileUpload.PostedFile.ContentLength < 102400 && PayorderFileUpload.PostedFile.ContentLength < 102400)
                    //{

                    if (fuTINCertificate.HasFile)
                    {
                        string TINCertificatefilename = fuTINCertificate.FileName;
                        string path = Server.MapPath(@"\MemberData\" + ID.ToString() + @"\Document\\");
                        if (!Directory.Exists(path))
                        {
                            Directory.CreateDirectory(path);
                        }
                        fuTINCertificate.SaveAs(Path.Combine(path, TINCertificatefilename));

                        MemberDocument memberDocument = new MemberDocument();
                        memberDocument.MemberID = ID;
                    try {
                        memberDocument.DocumentName = EnumHelper.EnumToString<EnumCollection.DocumentType>(Convert.ToInt32(EnumCollection.DocumentType.TIN_Certificate));
                    }
                    catch(Exception ex)
                    {

                    }
                        memberDocument.DocumentTypeID = Convert.ToInt32(EnumCollection.DocumentType.TIN_Certificate);
                        memberDocument.Path = path + TINCertificatefilename.Trim();
                        memberDocuments.Add(memberDocument);
 
                    }
                    if (fuTradeLicense.HasFile)
                    {
                        string filename = fuTINCertificate.FileName;
                        string path = Server.MapPath(@"\MemberData\" + ID.ToString() + @"\Document\\");
                        if (!Directory.Exists(path))
                        {
                            Directory.CreateDirectory(path);
                        }
                        fuTINCertificate.SaveAs(Path.Combine(path, filename));

                        MemberDocument memberDocument = new MemberDocument();
                        memberDocument.MemberID = ID;
                        memberDocument.DocumentName = EnumHelper.EnumToString<EnumCollection.DocumentType>(Convert.ToInt32(EnumCollection.DocumentType.Trade_license));
                        memberDocument.DocumentTypeID = Convert.ToInt32(EnumCollection.DocumentType.Trade_license);
                        memberDocument.Path = path + filename.Trim();
                        memberDocuments.Add(memberDocument);

                    }
                    if (fuPartnershipAgrement.HasFile)
                    {
                        string filename = fuPartnershipAgrement.FileName;
                        string path = Server.MapPath(@"\MemberData\" + ID.ToString() + @"\Document\\");
                        if (!Directory.Exists(path))
                        {
                            Directory.CreateDirectory(path);
                        }
                        fuTINCertificate.SaveAs(Path.Combine(path, filename));

                        MemberDocument memberDocument = new MemberDocument();
                        memberDocument.MemberID = ID;
                        memberDocument.DocumentName = EnumHelper.EnumToString<EnumCollection.DocumentType>(Convert.ToInt32(EnumCollection.DocumentType.Partnership_Aggrement));
                        memberDocument.DocumentTypeID = Convert.ToInt32(EnumCollection.DocumentType.Partnership_Aggrement);
                        memberDocument.Path = path + filename.Trim();
                        memberDocuments.Add(memberDocument);

                    }
                    if (fuBankStatment.HasFile)
                    {
                        string filename = fuTINCertificate.FileName;
                        string path = Server.MapPath(@"\MemberData\" + ID.ToString() + @"\Document\\");
                        if (!Directory.Exists(path))
                        {
                            Directory.CreateDirectory(path);
                        }
                        fuTINCertificate.SaveAs(Path.Combine(path, filename));

                        MemberDocument memberDocument = new MemberDocument();
                        memberDocument.MemberID = ID;
                        memberDocument.DocumentName = EnumHelper.EnumToString<EnumCollection.DocumentType>(Convert.ToInt32(EnumCollection.DocumentType.Bank_Statment));
                        memberDocument.DocumentTypeID = Convert.ToInt32(EnumCollection.DocumentType.Bank_Statment);
                        memberDocument.Path = path + filename.Trim();
                        memberDocuments.Add(memberDocument);

                    }
                    if (fuVATCertificate.HasFile)
                    {
                        string filename = fuTINCertificate.FileName;
                        string path = Server.MapPath(@"\MemberData\" + ID.ToString() + @"\Document\\");
                        if (!Directory.Exists(path))
                        {
                            Directory.CreateDirectory(path);
                        }
                        fuTINCertificate.SaveAs(Path.Combine(path, filename));

                        MemberDocument memberDocument = new MemberDocument();
                        memberDocument.MemberID = ID;
                        memberDocument.DocumentName = EnumHelper.EnumToString<EnumCollection.DocumentType>(Convert.ToInt32(EnumCollection.DocumentType.VAT_Certificate));
                        memberDocument.DocumentTypeID = Convert.ToInt32(EnumCollection.DocumentType.VAT_Certificate);
                        memberDocument.Path = path + filename.Trim();
                        memberDocuments.Add(memberDocument);

                    }


                       
                }
                catch (Exception ex)
                {
                    lblmessage.Text = "Upload status: The file could not be uploaded. The following error occured: " + ex.Message;
                }

         


            return memberDocuments;
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
            aMember.IndustryLocation = txtIndustryLocation.Text.Trim();
            aMember.IndustryFoundationYear = Convert.ToInt32(txtIndustryFoundationDate.Text.Trim());
            //aMember.TypeOfBusiness = txtTypeOfBusiness.Text.Trim();
            aMember.CompanyTypeID = Convert.ToInt32(ddlCompanyType.SelectedValue);
            aMember.CompanyCategoryID = Convert.ToInt32(ddlCompanyCategory.SelectedValue);
            aMember.TypeOfBusiness = ddlBusniessTypes.SelectedItem.ToString();
            aMember.ManufacturedProducts = txtManufacturedProducts.Text.Trim();
            aMember.ImportedProducts = txtImportedProducts.Text.Trim();
            aMember.ExportedProducts = txtExportedProducts.Text.Trim();
            aMember.NameOfTheAssociations = txtNameOfTheAssociations.Text.Trim();
            aMember.MembershipStatus = Convert.ToInt32(EnumCollection.MembershipStatus.Pending);
            aMember.TypeOfSubmission = Convert.ToInt32(EnumCollection.TypeOfSubmission.New);
            //aMember.RegistrationFee = Convert.ToInt32(txtRegistrationAmount.Text.Trim());
            //aMember.PayorderNumber = txtPayOrderNumber.Text.Trim();
            //aMember.PayorderDate = Convert.ToDateTime(txtPayOrderDate.Text.Trim());
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

        #region MultiView Steps
        //protected void btnGoToStep2_Click(object sender, EventArgs e)
        //{
        //    MultiView1.ActiveViewIndex = 1;
        //}
        //protected void btnBackStep1_Click(object sender, EventArgs e)
        //{
        //    MultiView1.ActiveViewIndex = 0;
        //    showHide = 1;

        //}
        //protected void btnGoToStep3_Click(object sender, EventArgs e)
        //{
        //    MultiView1.ActiveViewIndex = 2;
        //}
        //protected void btnGoToStepTwo2_Click(object sender, EventArgs e)
        //{
        //    MultiView1.ActiveViewIndex = 4;
        //}
        //protected void btnStep2_Click(object sender, EventArgs e)
        //{
        //    MultiView1.ActiveViewIndex = 1;
        //}
        //protected void btnStep4_Click(object sender, EventArgs e)
        //{
        //    MultiView1.ActiveViewIndex = 3;
        //}
        //protected void btnStep3_Click(object sender, EventArgs e)
        //{
        //    MultiView1.ActiveViewIndex = 2;
        //}
        //protected void btnStep5_Click(object sender, EventArgs e)
        //{
        //    MultiView1.ActiveViewIndex = 4;
        //}
        //protected void btnStepAgain4_Click(object sender, EventArgs e)
        //{
        //    MultiView1.ActiveViewIndex = 3;
        //}
        //protected void btnStep6_Click(object sender, EventArgs e)
        //{
        //    MultiView1.ActiveViewIndex = 5;
        //    ShowAll();
        //}

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
        //    lblCompanyType.Text = " " + ddlCompanyType.SelectedItem;//txtCompanyTypeID.Text;
        //    lblCompanyCategory.Text = " " + ddlCompanyCategory.SelectedItem;//txtCompanyCategoryID.Text;
        //    lblManufacturedProducts.Text = " " + txtManufacturedProducts.Text;
        //    lblImportedProducts.Text = " " + txtImportedProducts.Text;
        //    lblExportedProducts.Text = " " + txtExportedProducts.Text;
        //    lblNameOfTheAssociations.Text = " " + txtNameOfTheAssociations.Text;
        //    lblMembershipStatus.Text = " " + txtMembershipStatus.Text;
        //    lblMembershipCode.Text = " " + txtMembershipCode.Text;
        //    lblTypeOfSubmission.Text = " " + txtTypeOfSubmission.Text;
        //}
        //private void btnStepTwoDisable()
        //{
        //    if (!string.IsNullOrEmpty(txtCompanyAddress.Text))
        //    //if(txtCompanyName.Text =)
        //    //if(txtCompanyName.Text == null)
        //    {
        //        btnGoToStep2.Visible = false;
        //    }
        //    else
        //    {
        //        btnGoToStep2.Visible = true;
        //        //btnGoToStep2.ForeColor = System.Drawing.Color.Red;

        //    }
        //}
        #endregion
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