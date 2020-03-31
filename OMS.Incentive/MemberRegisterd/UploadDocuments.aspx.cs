using OMS.DAL;
using OMS.Facade;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OMS.Incentive.MemberRegisterd
{
    public partial class UploadDocuments : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //UploadedDocument();
                LoadListView();
            }
        }

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




        #region Table Upload Show
        //public void UploadedDocument()
        //{
        //    MemberDocument member = new MemberDocument();
        //    List<MemberDocument> memberDocuments = new List<MemberDocument>();
        //    using (TheFacade facade = new TheFacade())
        //    {
        //        memberDocuments = facade.MemberFacade.GetMemberByMemberId(MemberID);
        //    }

        //    foreach (var item in memberDocuments)
        //    {

        //         if(item.DocumentTypeID == 1)
        //        {
        //            lblPayorderSlip.Text = item.DocumentName;
        //            ImgPaorder.ImageUrl = item.Path;
        //            hyperlinkPayorderSlip.NavigateUrl = item.Path;
        //        }
        //        else if(item.DocumentTypeID == 2)
        //        {
        //            lblTradeLicense.Text = item.DocumentName;
        //            ImgTradeLicence.ImageUrl = item.Path;
        //            hyperlinkTradeLicence.NavigateUrl = item.Path;
        //        }
        //        else if(item.DocumentTypeID == 3)
        //        {
        //            lblTinCertificate.Text = item.DocumentName;
        //            ImgTINcertificate.ImageUrl = item.Path;
        //            hyperlinkTINcertificate.NavigateUrl = item.Path;
        //        }
        //        else if (item.DocumentTypeID == 4)
        //        {
        //            lblPartnerShip.Text = item.DocumentName;
        //            ImgPartnerShip.ImageUrl = item.Path;
        //            hyperlinkPartnerShip.NavigateUrl = item.Path;
        //        }
        //         else if(item.DocumentTypeID == 5)
        //        {
        //            lblBankStatment.Text = item.DocumentName;
        //            ImgBankStatment.ImageUrl = item.Path;
        //            hyperlinkBankStatment.NavigateUrl = item.Path;


        //        }
        //         else if(item.DocumentTypeID == 6)
        //        {
        //            lblVatCertificate.Text = item.DocumentName;
        //            ImgVatCertificate.ImageUrl = item.Path;
        //            hyperlinkVatCertificate.NavigateUrl = item.Path;
        //        }
        //    }
        //}
        #endregion

        public void VerifiedUploadedDocument()
        {
            Ins_MemberVerification memberDocuments = new Ins_MemberVerification();

            using (TheFacade facade = new TheFacade())
            {
                memberDocuments = facade.MemberFacade.GetVerifiedMemberByMemberId(memberDocuments.MemberID);
            }
        }

        private void LoadListView()
        {
            MemberDocument memberList = new MemberDocument();
            List<MemberDocument> memberDocuments = new List<MemberDocument>();
            using (TheFacade facade = new TheFacade())
            {
                memberDocuments = facade.MemberFacade.GetMemberByMemberId(MemberID);
            }

            lvNewMember.DataSource = memberDocuments;
            lvNewMember.DataBind();
        }

        protected void lvNewMember_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            using (TheFacade facade = new TheFacade())
            {

                if (e.Item.ItemType == ListViewItemType.DataItem)
                {
                    ListViewDataItem dataItem = (ListViewDataItem)e.Item;
                    Label lblDocumentName = (Label)e.Item.FindControl("lblDocumentName");
                    HyperLink hlinkDocumentNamePath = (HyperLink)e.Item.FindControl("hlinkDocumentNamePath");
                    Label lblVerificationStatus = (Label)e.Item.FindControl("lblVerificationStatus");
                    Label lblLastUpdateDate = (Label)e.Item.FindControl("lblLastUpdateDate");

                    MemberDocument member = dataItem.DataItem as MemberDocument;

                    lblDocumentName.Text = member.DocumentName;
                    hlinkDocumentNamePath.NavigateUrl = string.Format("~/{0}",member.Path);
                    hlinkDocumentNamePath.Text = member.Path;

                    lblVerificationStatus.Text = member.DocumentTypeID.ToString();//member.Status.ToString();
                    lblLastUpdateDate.Text = member.MemberID.ToString();
                }
            }
        }
    }
}