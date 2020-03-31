using OMS.DAL;
using OMS.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static OMS.Framework.EnumCollection;

namespace OMS.Facade
{
    public interface IMemberFacade
    {
        void Dispose();
        bool IsAssetNameAlreadyExist(string name);
        Member GetMemberByName(string name);
        List<CompanyType> GetCompanyTypeInfoAll();
        List<CompanyCategory> GetCompanyCategoryInfoAll();
        List<BusinessType> GetBusinessTypeInfoAll();
        List<Ins_DocumentType> GetDocumentTypeInfoAll();
        Member GetMemberByEmail(string email);
        Ins_ChaForm GetMemberByChaFormMemberId(long Id);

        Member GetMemberById(long Id);
        //Member GetMemberByName(string name);
        Ins_MemberVerification GetVerifiedMemberByMemberId(long ID);
        List<Member> GetApprovedMember();
        List<MemberDocument> GetMemberByMemberId(long ID);

        List<Member> GetNewMemberVerificationList();
        List<Member> GetExistingMemberVerificationList();

        List<Member> GetMemberForCommitteeMeeting();

        List<Ins_VerificationType> GetAllVerificationType();
        Ins_VerificationType GetAllVerificationTypeById(long id);
        List<Ins_MemberVerificationDetail> GetMemberVerificationDetailsById(long id);

        Member GetMemberByAspnetUserID(string userID);

        Ins_MemberVerification GetMemberVerificationByMemberID(long memberID);
        List<Ins_MemberVerificationDetail> GetMemberVerificationDetail(long memberID);

        Ins_MemberVerificationDetail GetMemberVerificationDetailByType(long MemberID, int typeID);
        List<Currency> GetAllCurrency();
        List<Inv_Master> GetAllInvoice();
        List<Inv_Master> GetInvoiceByMemberID(long memberID);
        List<Inv_Master> GetInvoiceByMemberIDForChaForm(long memberID);
        List<Inv_Master> GetAllInvoiceByIDList(List<long> invoiceID );
    }
    class MemberFacade: BaseFacade, IMemberFacade
    {
        public MemberFacade(OMSDataContext database)
            : base(database)
        {
        }

        public Ins_MemberVerificationDetail GetMemberVerificationDetailByType(long MemberID, int typeID)
        {
            return Database.Ins_MemberVerificationDetails.FirstOrDefault(m => m.MemberID == MemberID && m.VerificationTypeId == typeID);
        }

        public Ins_MemberVerification GetMemberVerificationByMemberID(long memberID)
        {
            return Database.Ins_MemberVerifications.Where(v => v.MemberID == memberID).FirstOrDefault();
        }
        public List<Ins_MemberVerificationDetail> GetMemberVerificationDetail(long memberID)
        {
            return Database.Ins_MemberVerificationDetails.Where(m => m.MemberID == memberID).ToList();
        }
        public Member GetMemberByAspnetUserID(string userID)
        {
            return Database.Members.FirstOrDefault(m => m.ProviderKey == userID);
        }

        public List<Ins_VerificationType> GetAllVerificationType()
        {
            return Database.Ins_VerificationTypes.OrderBy(v => v.IID).ToList();
        }

        public List<Member> GetApprovedMember()
        {
            return Database.Members.Where(m => m.MembershipStatus == (int)EnumCollection.MembershipStatus.Approved && m.IsRemoved == 0).ToList();
        }



        public Ins_VerificationType GetAllVerificationTypeById(long id)
        {
            return Database.Ins_VerificationTypes.Where(v => v.IID == id).FirstOrDefault();
        }
        public List<Ins_MemberVerificationDetail> GetMemberVerificationDetailsById(long id)
        {
            return Database.Ins_MemberVerificationDetails.Where(v => v.MemberID == id).ToList();
        }



        public List<Member> GetMemberVerificationListForCommitteMeeting()
        {
            List<Member> memberlist = new List<Member>();

            memberlist = Database.Members.Where(m => m.TypeOfSubmission == 1 && m.MembershipStatus == 0 && m.MemberVerificationStatus== (int)VerificationStatus.Approved_for_Committee_Meeting).ToList();
            foreach (Member member in memberlist)
            {
                Ins_MemberVerification mverification = Database.Ins_MemberVerifications.FirstOrDefault(m => m.MemberID == member.ID);
                if (mverification != null)
                {
                    //member.MemberVerificationStatus = EnumHelper.EnumToString<VerificationStatus>(mverification.Status);
                    member.VerificationLastUpdateDate = mverification.SubmitedDate.HasValue ? mverification.SubmitedDate.Value.ToString("dd/MM/yyyy") : string.Empty;
                }
                else
                {
                   // member.MemberVerificationStatus = EnumHelper.EnumToString<VerificationStatus>(0);
                    member.VerificationLastUpdateDate = string.Empty;
                }
            }
            return memberlist;
        }

        public List<Member> GetNewMemberVerificationList()
        {
            List<Member> memberlist = new List<Member>();

            memberlist = Database.Members.Where(m => m.TypeOfSubmission == 1 && m.MembershipStatus == 0 && (m.MemberVerificationStatus == (int)EnumCollection.VerificationStatus.Processing || m.MemberVerificationStatus == (int)EnumCollection.VerificationStatus.Pending)).ToList();
            foreach (Member member in memberlist)
            {
                Ins_MemberVerification mverification = Database.Ins_MemberVerifications.FirstOrDefault(m => m.MemberID == member.ID);
                if (mverification != null)
                {
                    //member.MemberVerificationStatus = EnumHelper.EnumToString<VerificationStatus>(mverification.Status);
                    member.VerificationLastUpdateDate = mverification.SubmitedDate.HasValue ? mverification.SubmitedDate.Value.ToString("dd/MM/yyyy") : string.Empty;
                }
                else
                {
                    //member.MemberVerificationStatus = EnumHelper.EnumToString<VerificationStatus>(0);
                    member.VerificationLastUpdateDate = string.Empty;
                }
            }
            return memberlist;
        }
        public List<Member> GetExistingMemberVerificationList()
        {
            List<Member> memberlist = new List<Member>();

            memberlist = Database.Members.Where(m => m.TypeOfSubmission == 2 && m.MembershipStatus == 0 && (m.MemberVerificationStatus == (int)EnumCollection.VerificationStatus.Processing || m.MemberVerificationStatus == (int)EnumCollection.VerificationStatus.Pending)).ToList();
            foreach (Member member in memberlist)
            {
                Ins_MemberVerification mverification = Database.Ins_MemberVerifications.FirstOrDefault(m => m.MemberID == member.ID);
                if (mverification != null)
                {
                    //member.MemberVerificationStatus = EnumHelper.EnumToString<VerificationStatus>(mverification.Status);
                    member.VerificationLastUpdateDate = mverification.SubmitedDate.HasValue ? mverification.SubmitedDate.Value.ToString("dd/MM/yyyy") : string.Empty;
                }
                else
                {
                    //member.MemberVerificationStatus = EnumHelper.EnumToString<VerificationStatus>(0);
                    member.VerificationLastUpdateDate = string.Empty;
                }
            }
            return memberlist;
        }
        public List<Member> GetMemberForCommitteeMeeting()
        {
            List<Member> memberlist = new List<Member>();

            memberlist = Database.Members.Where(m =>  m.MembershipStatus == 0 && m.MemberVerificationStatus == (int)EnumCollection.VerificationStatus.Approved_for_Committee_Meeting).ToList();
            foreach (Member member in memberlist)
            {
                Ins_MemberVerification mverification = Database.Ins_MemberVerifications.FirstOrDefault(m => m.MemberID == member.ID);
                if (mverification != null)
                {
                    //member.MemberVerificationStatus = EnumHelper.EnumToString<VerificationStatus>(mverification.Status);
                    member.VerificationLastUpdateDate = mverification.SubmitedDate.HasValue ? mverification.SubmitedDate.Value.ToString("dd/MM/yyyy") : string.Empty;
                }
                else
                {
                    //member.MemberVerificationStatus = EnumHelper.EnumToString<VerificationStatus>(0);
                    member.VerificationLastUpdateDate = string.Empty;
                }
            }
            return memberlist;
        }
        public bool IsAssetNameAlreadyExist(string name)
        {
            bool retVal = false;
            Member type = GetMemberByName(name);

            if (type != null && type.ID > 0)
            {
                retVal = true;
            }
            return retVal;

        }

        public Ins_ChaForm GetMemberByChaFormMemberId(long Id)
        {
            return Database.Ins_ChaForms.Where(b => b.MemberID == Id && b.IsRemoved == 0).FirstOrDefault();
        }

        public Member GetMemberById(long Id)
        {
            return Database.Members.Where(b => b.ID == Id && b.IsRemoved == 0).FirstOrDefault();
        }
        public Member GetMemberByName(string name)
        {
            return Database.Members.Where(b => b.Name.ToUpper() == name.Trim().ToUpper() && b.IsRemoved == 0).FirstOrDefault();
        }


        public Member GetMemberByEmail(string email)
        {
            return Database.Members.Where(b => b.Email.ToUpper() == email.Trim().ToUpper() && b.IsRemoved == 0).FirstOrDefault();
        }

        public List<MemberDocument> GetMemberByMemberId(long ID)
        {
            return Database.MemberDocuments.Where(b => b.MemberID == ID ).ToList();
        }

        public Ins_MemberVerification GetVerifiedMemberByMemberId(long ID)
        {
            return Database.Ins_MemberVerifications.Where(b => b.MemberID == ID && b.Status ==1).FirstOrDefault();
        }
        public List<CompanyType> GetCompanyTypeInfoAll()
        {
            List<CompanyType> CompanyTypeList = new List<CompanyType>();
            CompanyTypeList = Database.CompanyTypes.Where(a => a.IsRemoved == 0).ToList();
            return CompanyTypeList;
        }

        public List<CompanyCategory> GetCompanyCategoryInfoAll()
        {
            List<CompanyCategory> CompanyCategoryList = new List<CompanyCategory>();
            CompanyCategoryList = Database.CompanyCategories.Where(a => a.IsRemoved == 0).ToList();
            return CompanyCategoryList;
        }
        public List<BusinessType> GetBusinessTypeInfoAll()
        {
            List<BusinessType> BusinessTypeList = new List<BusinessType>();
            BusinessTypeList = Database.BusinessTypes.Where(a => a.IsRemoved == 0).ToList();
            return BusinessTypeList;
        }

        public List<Ins_DocumentType> GetDocumentTypeInfoAll()
        {
            List<Ins_DocumentType> DocumentTypeList = new List<Ins_DocumentType>();
            DocumentTypeList = Database.Ins_DocumentTypes.ToList();
            return DocumentTypeList;
        }

        public List<Currency> GetAllCurrency()
        {
            List<Currency> CurrencyList = new List<Currency>();
            CurrencyList = Database.Currencies.ToList();
            return CurrencyList;
        }

        public List<Inv_Master> GetAllInvoice()
        {
            List<Inv_Master> InvoiceList = new List<Inv_Master>();
            InvoiceList = Database.Inv_Masters.Where(x=> x.IsRemoved==0).ToList();
            return InvoiceList;
        }

        public List<Inv_Master> GetInvoiceByMemberID(long memberID)
        {
            List<Inv_Master> InvoiceList = new List<Inv_Master>();
            InvoiceList = Database.Inv_Masters.Where(x => x.IsRemoved == 0 && x.MemberId == memberID).ToList();
            foreach (Inv_Master item in InvoiceList)
            {
                item.Inv_Details = item.Inv_Details;
            }
            return InvoiceList;
        }

        public List<Inv_Master> GetInvoiceByMemberIDForChaForm(long memberID)
        {
            List<long> invoiceIds = Database.Ins_ChaFormInvoices.Where(c => c.Ins_ChaForm.MemberID == memberID).Select(c => c.InvoiceMasterId).ToList();
            List<Inv_Master> InvoiceList = new List<Inv_Master>();
            InvoiceList = Database.Inv_Masters.Where(x => x.IsRemoved == 0 && x.MemberId == memberID && !invoiceIds.Contains(x.IID)).ToList();
            foreach (Inv_Master item in InvoiceList)
            {
                item.Inv_Details = item.Inv_Details;
            }
            return InvoiceList;
        }

        public List<Inv_Master> GetAllInvoiceByIDList(List<long> invoiceID)
        {
            List<Inv_Master> InvoiceList = new List<Inv_Master>();
            InvoiceList = Database.Inv_Masters.Where(x => x.IsRemoved == 0 && invoiceID.Contains(x.IID)).ToList();

            foreach (var invMaster in InvoiceList)
            {
                invMaster.InvoiceDetailList = invMaster.Inv_Details.Where(id => id.IsRemoved != 1).ToList();
               
            }

            return InvoiceList;
        }
    }
}
