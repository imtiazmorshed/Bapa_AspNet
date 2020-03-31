using OMS.DAL;
using OMS.Facade;
using OMS.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static OMS.Framework.EnumCollection;

namespace OMS.Incentive.MemberRegisterd
{
    public partial class RegistrationMemberVerification : System.Web.UI.Page
    {
        public long MemberID
        {
            get
            {
                if (ViewState["MemberID"] != null)
                    return Convert.ToInt64(ViewState["MemberID"].ToString());
                else

                    return 0;

            }
            set
            {
                ViewState["MemberID"] = value;
            }
        }
        



        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //if (Request.QueryString["MemberID"] != null)
                //{
                //    MemberID = Convert.ToInt64(Request.QueryString["MemberID"].ToString());
                //}
                if (Request.QueryString["MemberID"] != null)
                {
                    MemberID = Convert.ToInt64(Request.QueryString["MemberID"].ToString());
                }
                LoadMemberVerificationStatus();
                LoadApprovedButton();
            }
        }

        private void LoadApprovedButton()
        {
            List<Ins_MemberVerificationDetail> verificationDetails = new List<Ins_MemberVerificationDetail>();
            using (TheFacade facade = new TheFacade())
            {
                verificationDetails = facade.MemberFacade.GetMemberVerificationDetail(MemberID);
            }
            bool IsApprover = false;
            foreach (Ins_MemberVerificationDetail item in verificationDetails)
            {
                if (item.Status == 1)
                {
                    IsApprover = true;
                }
                else
                {
                    IsApprover = false;
                    break;
                }
            }
            btnAllSubmit.Enabled = IsApprover;
        }

        private void LoadMemberVerificationStatus()
        {
            List<Ins_MemberVerificationDetail> verificationDetails = new List<Ins_MemberVerificationDetail>();
            using (TheFacade facade = new TheFacade())
            {
                verificationDetails = facade.MemberFacade.GetMemberVerificationDetail(MemberID);
            }
            foreach (Ins_MemberVerificationDetail item in verificationDetails)
            {
                switch (item.VerificationTypeId)
                {
                    case 1:
                        if (item.Status == 1)
                        {
                            radioVType11.Checked = true;
                        }
                        else
                        {
                            radioVType12.Checked = true;
                        }
                        txtComment1.Text = item.Comment;
                        break;
                    case 2:
                        if (item.Status == 1)
                        {
                            radioVType13.Checked = true;
                        }
                        else
                        {
                            radioVType14.Checked = true;
                        }
                        txtComment2.Text = item.Comment;
                        break;
                    case 3:
                        if (item.Status == 1)
                        {
                            radioVType15.Checked = true;
                        }
                        else
                        {
                            radioVType16.Checked = true;
                        }
                        txtComment3.Text = item.Comment;
                        break;
                    case 4:
                        if (item.Status == 1)
                        {
                            radioVType17.Checked = true;
                        }
                        else
                        {
                            radioVType18.Checked = true;
                        }
                        txtComment4.Text = item.Comment;
                        break;
                    case 5:
                        if (item.Status == 1)
                        {
                            radioVType19.Checked = true;
                        }
                        else
                        {
                            radioVType20.Checked = true;
                        }
                        txtComment5.Text = item.Comment;
                        break;
                    case 6:
                        if (item.Status == 1)
                        {
                            radioVType21.Checked = true;
                        }
                        else
                        {
                            radioVType22.Checked = true;
                        }
                        txtComment6.Text = item.Comment;
                        break;
                    case 7:
                        if (item.Status == 1)
                        {
                            radioVType23.Checked = true;
                        }
                        else
                        {
                            radioVType24.Checked = true;
                        }
                        txtComment7.Text = item.Comment;
                        break;
                    case 8:
                        if (item.Status == 1)
                        {
                            radioVType25.Checked = true;
                        }
                        else
                        {
                            radioVType26.Checked = true;
                        }
                        txtComment8.Text = item.Comment;
                        break;
                    case 9:
                        if (item.Status == 1)
                        {
                            radioVType27.Checked = true;
                        }
                        else
                        {
                            radioVType28.Checked = true;
                        }
                        txtComment9.Text = item.Comment;
                        break;
                    case 10:
                        if (item.Status == 1)
                        {
                            radioVType29.Checked = true;
                        }
                        else
                        {
                            radioVType30.Checked = true;
                        }
                        txtComment10.Text = item.Comment;
                        break;
                    case 11:
                        if (item.Status == 1)
                        {
                            radioVType31.Checked = true;
                        }
                        else
                        {
                            radioVType32.Checked = true;
                        }
                        txtComment11.Text = item.Comment;
                        break;
                    case 12:
                        if (item.Status == 1)
                        {
                            radioVType33.Checked = true;
                        }
                        else
                        {
                            radioVType34.Checked = true;
                        }
                        txtComment12.Text = item.Comment;
                        break;
                    case 13:
                        if (item.Status == 1)
                        {
                            radioVType35.Checked = true;
                        }
                        else
                        {
                            radioVType36.Checked = true;
                        }
                        txtComment13.Text = item.Comment;
                        break;
                    case 14:
                        if (item.Status == 1)
                        {
                            radioVType37.Checked = true;
                        }
                        else
                        {
                            radioVType38.Checked = true;
                        }
                        txtComment14.Text = item.Comment;
                        break;
                    case 15:
                        if (item.Status == 1)
                        {
                            radioVType39.Checked = true;
                        }
                        else
                        {
                            radioVType40.Checked = true;
                        }
                        txtComment15.Text = item.Comment;
                        break;
                    case 16:
                        if (item.Status == 1)
                        {
                            radioVType41.Checked = true;
                        }
                        else
                        {
                            radioVType42.Checked = true;
                        }
                        txtComment16.Text = item.Comment;
                        break;
                    case 17:
                        if (item.Status == 1)
                        {
                            radioVType43.Checked = true;
                        }
                        else
                        {
                            radioVType44.Checked = true;
                        }
                        txtComment17.Text = item.Comment;
                        break;
                    case 18:
                        if (item.Status == 1)
                        {
                            radioVType45.Checked = true;
                        }
                        else
                        {
                            radioVType46.Checked = true;
                        }
                        txtComment18.Text = item.Comment;
                        break;
                    case 19:
                        if (item.Status == 1)
                        {
                            radioVType47.Checked = true;
                        }
                        else
                        {
                            radioVType48.Checked = true;
                        }
                        txtComment19.Text = item.Comment;
                        break;

                }
            }
        }
        #region Submit Button

        protected void btnVType1_Click(object sender, EventArgs e)
        {
            SaveMemberVerificationStatusDetail(1);
        }
        protected void btnVType2_Click(object sender, EventArgs e)
        {
            SaveMemberVerificationStatusDetail(2);
        }
        protected void btnVType3_Click(object sender, EventArgs e)
        {
            SaveMemberVerificationStatusDetail(3);
        }
        protected void btnVType4_Click(object sender, EventArgs e)
        {
            SaveMemberVerificationStatusDetail(4);
        }
        protected void btnVType5_Click(object sender, EventArgs e)
        {
            SaveMemberVerificationStatusDetail(5);
        }
        protected void btnVType6_Click(object sender, EventArgs e)
        {
            SaveMemberVerificationStatusDetail(6);
        }
        protected void btnVType7_Click(object sender, EventArgs e)
        {
            SaveMemberVerificationStatusDetail(7);
        }
        protected void btnVType8_Click(object sender, EventArgs e)
        {
            SaveMemberVerificationStatusDetail(8);
        }
        protected void btnVType9_Click(object sender, EventArgs e)
        {
            SaveMemberVerificationStatusDetail(9);
        }
        protected void btnVType10_Click(object sender, EventArgs e)
        {
            SaveMemberVerificationStatusDetail(10);
        }
        protected void btnVType11_Click(object sender, EventArgs e)
        {
            SaveMemberVerificationStatusDetail(11);
        }
        protected void btnVType12_Click(object sender, EventArgs e)
        {
            SaveMemberVerificationStatusDetail(12);
        }
        protected void btnVType13_Click(object sender, EventArgs e)
        {
            SaveMemberVerificationStatusDetail(13);
        }
        protected void btnVType14_Click(object sender, EventArgs e)
        {
            SaveMemberVerificationStatusDetail(14);
        }
        protected void btnVType15_Click(object sender, EventArgs e)
        {
            SaveMemberVerificationStatusDetail(15);
        }
        protected void btnVType16_Click(object sender, EventArgs e)
        {
            SaveMemberVerificationStatusDetail(16);
        }
        protected void btnVType17_Click(object sender, EventArgs e)
        {
            SaveMemberVerificationStatusDetail(17);
        }
        protected void btnVType18_Click(object sender, EventArgs e)
        {
            SaveMemberVerificationStatusDetail(18);
        }
        protected void btnVType19_Click(object sender, EventArgs e)
        {
            SaveMemberVerificationStatusDetail(19);
        }

        #endregion       

        private void SaveMemberVerificationStatusDetail(int typeID)
        {
            Ins_MemberVerificationDetail verificationDetail = new Ins_MemberVerificationDetail();
            bool isNew = false;
            using (TheFacade facade = new TheFacade())
            {
                Ins_MemberVerification memberVerification = facade.MemberFacade.GetMemberVerificationByMemberID(MemberID);
                Member member = facade.MemberFacade.GetMemberById(MemberID);
                member.MemberVerificationStatus = (int)VerificationStatus.Processing;
                facade.Update<Member>(member);
                if (memberVerification != null)
                {
                    memberVerification.Status = (int)VerificationStatus.Processing;
                    facade.Update<Ins_MemberVerification>(memberVerification);
                }
                verificationDetail = facade.MemberFacade.GetMemberVerificationDetailByType(MemberID, typeID);
                if (verificationDetail == null)
                {
                    verificationDetail = new Ins_MemberVerificationDetail();
                    isNew = true;
                }
                switch (typeID)
                {
                    case 1:
                        if (radioVType11.Checked)
                        {
                            verificationDetail.Status = 1;
                        }
                        else
                        {
                            verificationDetail.Status = 0;
                        }
                        verificationDetail.Comment = txtComment1.Text;
                        verificationDetail.LastUpdated = DateTime.Now;

                        if (isNew)
                        {
                            try
                            {
                                verificationDetail.VerificationTypeId = typeID;
                                facade.Insert<Ins_MemberVerificationDetail>(verificationDetail);
                            }
                            catch (Exception ex) { }
                        }
                        else
                        {
                            facade.Update<Ins_MemberVerificationDetail>(verificationDetail);
                        }
                        break;
                    case 2:
                        if (radioVType13.Checked)
                        {
                            verificationDetail.Status = 1;
                        }
                        else
                        {
                            verificationDetail.Status = 0;
                        }
                        verificationDetail.Comment = txtComment2.Text;
                        verificationDetail.LastUpdated = DateTime.Now;

                        if (isNew)
                        {
                            try
                            {
                                verificationDetail.VerificationTypeId = typeID;
                                facade.Insert<Ins_MemberVerificationDetail>(verificationDetail);
                            }
                            catch (Exception ex) { }
                        }
                        else
                        {
                            facade.Update<Ins_MemberVerificationDetail>(verificationDetail);
                        }
                        break;
                    case 3:
                        if (radioVType15.Checked)
                        {
                            verificationDetail.Status = 1;
                        }
                        else
                        {
                            verificationDetail.Status = 0;
                        }
                        verificationDetail.Comment = txtComment3.Text;
                        verificationDetail.LastUpdated = DateTime.Now;

                        if (isNew)
                        {
                            try
                            {
                                verificationDetail.VerificationTypeId = typeID;
                                facade.Insert<Ins_MemberVerificationDetail>(verificationDetail);
                            }
                            catch (Exception ex) { }
                        }
                        else
                        {
                            facade.Update<Ins_MemberVerificationDetail>(verificationDetail);
                        }
                        break;
                    case 4:
                        if (radioVType17.Checked)
                        {
                            verificationDetail.Status = 1;
                        }
                        else
                        {
                            verificationDetail.Status = 0;
                        }
                        verificationDetail.Comment = txtComment4.Text;
                        verificationDetail.LastUpdated = DateTime.Now;

                        if (isNew)
                        {
                            try
                            {
                                verificationDetail.VerificationTypeId = typeID;
                                facade.Insert<Ins_MemberVerificationDetail>(verificationDetail);
                            }
                            catch (Exception ex) { }
                        }
                        else
                        {
                            facade.Update<Ins_MemberVerificationDetail>(verificationDetail);
                        }
                        break;
                    case 5:
                        if (radioVType19.Checked)
                        {
                            verificationDetail.Status = 1;
                        }
                        else
                        {
                            verificationDetail.Status = 0;
                        }
                        verificationDetail.Comment = txtComment5.Text;
                        verificationDetail.LastUpdated = DateTime.Now;

                        if (isNew)
                        {
                            try
                            {
                                verificationDetail.VerificationTypeId = typeID;
                                facade.Insert<Ins_MemberVerificationDetail>(verificationDetail);
                            }
                            catch (Exception ex) { }
                        }
                        else
                        {
                            facade.Update<Ins_MemberVerificationDetail>(verificationDetail);
                        }
                        break;
                    case 6:
                        if (radioVType21.Checked)
                        {
                            verificationDetail.Status = 1;
                        }
                        else
                        {
                            verificationDetail.Status = 0;
                        }
                        verificationDetail.Comment = txtComment6.Text;
                        verificationDetail.LastUpdated = DateTime.Now;

                        if (isNew)
                        {
                            try
                            {
                                verificationDetail.VerificationTypeId = typeID;
                                facade.Insert<Ins_MemberVerificationDetail>(verificationDetail);
                            }
                            catch (Exception ex) { }
                        }
                        else
                        {
                            facade.Update<Ins_MemberVerificationDetail>(verificationDetail);
                        }
                        break;
                    case 7:
                        if (radioVType23.Checked)
                        {
                            verificationDetail.Status = 1;
                        }
                        else
                        {
                            verificationDetail.Status = 0;
                        }
                        verificationDetail.Comment = txtComment7.Text;
                        verificationDetail.LastUpdated = DateTime.Now;

                        if (isNew)
                        {
                            try
                            {
                                verificationDetail.VerificationTypeId = typeID;
                                facade.Insert<Ins_MemberVerificationDetail>(verificationDetail);
                            }
                            catch (Exception ex) { }
                        }
                        else
                        {
                            facade.Update<Ins_MemberVerificationDetail>(verificationDetail);
                        }
                        break;
                    case 8:
                        if (radioVType25.Checked)
                        {
                            verificationDetail.Status = 1;
                        }
                        else
                        {
                            verificationDetail.Status = 0;
                        }
                        verificationDetail.Comment = txtComment8.Text;
                        verificationDetail.LastUpdated = DateTime.Now;

                        if (isNew)
                        {
                            try
                            {
                                verificationDetail.VerificationTypeId = typeID;
                                facade.Insert<Ins_MemberVerificationDetail>(verificationDetail);
                            }
                            catch (Exception ex) { }
                        }
                        else
                        {
                            facade.Update<Ins_MemberVerificationDetail>(verificationDetail);
                        }
                        break;
                    case 9:
                        if (radioVType27.Checked)
                        {
                            verificationDetail.Status = 1;
                        }
                        else
                        {
                            verificationDetail.Status = 0;
                        }
                        verificationDetail.Comment = txtComment9.Text;
                        verificationDetail.LastUpdated = DateTime.Now;

                        if (isNew)
                        {
                            try
                            {
                                verificationDetail.VerificationTypeId = typeID;
                                facade.Insert<Ins_MemberVerificationDetail>(verificationDetail);
                            }
                            catch (Exception ex) { }
                        }
                        else
                        {
                            facade.Update<Ins_MemberVerificationDetail>(verificationDetail);
                        }
                        break;
                    case 10:
                        if (radioVType29.Checked)
                        {
                            verificationDetail.Status = 1;
                        }
                        else
                        {
                            verificationDetail.Status = 0;
                        }
                        verificationDetail.Comment = txtComment10.Text;
                        verificationDetail.LastUpdated = DateTime.Now;

                        if (isNew)
                        {
                            try
                            {
                                verificationDetail.VerificationTypeId = typeID;
                                facade.Insert<Ins_MemberVerificationDetail>(verificationDetail);
                            }
                            catch (Exception ex) { }
                        }
                        else
                        {
                            facade.Update<Ins_MemberVerificationDetail>(verificationDetail);
                        }
                        break;
                    case 11:
                        if (radioVType31.Checked)
                        {
                            verificationDetail.Status = 1;
                        }
                        else
                        {
                            verificationDetail.Status = 0;
                        }
                        verificationDetail.Comment = txtComment11.Text;
                        verificationDetail.LastUpdated = DateTime.Now;

                        if (isNew)
                        {
                            try
                            {
                                verificationDetail.VerificationTypeId = typeID;
                                facade.Insert<Ins_MemberVerificationDetail>(verificationDetail);
                            }
                            catch (Exception ex) { }
                        }
                        else
                        {
                            facade.Update<Ins_MemberVerificationDetail>(verificationDetail);
                        }
                        break;
                    case 12:
                        if (radioVType33.Checked)
                        {
                            verificationDetail.Status = 1;
                        }
                        else
                        {
                            verificationDetail.Status = 0;
                        }
                        verificationDetail.Comment = txtComment12.Text;
                        verificationDetail.LastUpdated = DateTime.Now;

                        if (isNew)
                        {
                            try
                            {
                                verificationDetail.VerificationTypeId = typeID;
                                facade.Insert<Ins_MemberVerificationDetail>(verificationDetail);
                            }
                            catch (Exception ex) { }
                        }
                        else
                        {
                            facade.Update<Ins_MemberVerificationDetail>(verificationDetail);
                        }
                        break;
                    case 13:
                        if (radioVType35.Checked)
                        {
                            verificationDetail.Status = 1;
                        }
                        else
                        {
                            verificationDetail.Status = 0;
                        }
                        verificationDetail.Comment = txtComment13.Text;
                        verificationDetail.LastUpdated = DateTime.Now;

                        if (isNew)
                        {
                            try
                            {
                                verificationDetail.VerificationTypeId = typeID;
                                facade.Insert<Ins_MemberVerificationDetail>(verificationDetail);
                            }
                            catch (Exception ex) { }
                        }
                        else
                        {
                            facade.Update<Ins_MemberVerificationDetail>(verificationDetail);
                        }
                        break;
                    case 14:
                        if (radioVType37.Checked)
                        {
                            verificationDetail.Status = 1;
                        }
                        else
                        {
                            verificationDetail.Status = 0;
                        }
                        verificationDetail.Comment = txtComment14.Text;
                        verificationDetail.LastUpdated = DateTime.Now;

                        if (isNew)
                        {
                            try
                            {
                                verificationDetail.VerificationTypeId = typeID;
                                facade.Insert<Ins_MemberVerificationDetail>(verificationDetail);
                            }
                            catch (Exception ex) { }
                        }
                        else
                        {
                            facade.Update<Ins_MemberVerificationDetail>(verificationDetail);
                        }
                        break;
                    case 15:
                        if (radioVType39.Checked)
                        {
                            verificationDetail.Status = 1;
                        }
                        else
                        {
                            verificationDetail.Status = 0;
                        }
                        verificationDetail.Comment = txtComment15.Text;
                        verificationDetail.LastUpdated = DateTime.Now;

                        if (isNew)
                        {
                            try
                            {
                                verificationDetail.VerificationTypeId = typeID;
                                facade.Insert<Ins_MemberVerificationDetail>(verificationDetail);
                            }
                            catch (Exception ex) { }
                        }
                        else
                        {
                            facade.Update<Ins_MemberVerificationDetail>(verificationDetail);
                        }
                        break;
                    case 16:
                        if (radioVType41.Checked)
                        {
                            verificationDetail.Status = 1;
                        }
                        else
                        {
                            verificationDetail.Status = 0;
                        }
                        verificationDetail.Comment = txtComment16.Text;
                        verificationDetail.LastUpdated = DateTime.Now;

                        if (isNew)
                        {
                            try
                            {
                                verificationDetail.VerificationTypeId = typeID;
                                facade.Insert<Ins_MemberVerificationDetail>(verificationDetail);
                            }
                            catch (Exception ex) { }
                        }
                        else
                        {
                            facade.Update<Ins_MemberVerificationDetail>(verificationDetail);
                        }
                        break;
                    case 17:
                        if (radioVType43.Checked)
                        {
                            verificationDetail.Status = 1;
                        }
                        else
                        {
                            verificationDetail.Status = 0;
                        }
                        verificationDetail.Comment = txtComment17.Text;
                        verificationDetail.LastUpdated = DateTime.Now;

                        if (isNew)
                        {
                            try
                            {
                                verificationDetail.VerificationTypeId = typeID;
                                facade.Insert<Ins_MemberVerificationDetail>(verificationDetail);
                            }
                            catch (Exception ex) { }
                        }
                        else
                        {
                            facade.Update<Ins_MemberVerificationDetail>(verificationDetail);
                        }
                        break;
                    case 18:
                        if (radioVType45.Checked)
                        {
                            verificationDetail.Status = 1;
                        }
                        else
                        {
                            verificationDetail.Status = 0;
                        }
                        verificationDetail.Comment = txtComment18.Text;
                        verificationDetail.LastUpdated = DateTime.Now;

                        if (isNew)
                        {
                            try
                            {
                                verificationDetail.VerificationTypeId = typeID;
                                facade.Insert<Ins_MemberVerificationDetail>(verificationDetail);
                            }
                            catch (Exception ex) { }
                        }
                        else
                        {
                            facade.Update<Ins_MemberVerificationDetail>(verificationDetail);
                        }
                        break;
                    case 19:
                        if (radioVType47.Checked)
                        {
                            verificationDetail.Status = 1;
                        }
                        else
                        {
                            verificationDetail.Status = 0;
                        }
                        verificationDetail.Comment = txtComment19.Text;
                        verificationDetail.LastUpdated = DateTime.Now;

                        if (isNew)
                        {
                            try
                            {
                                verificationDetail.VerificationTypeId = typeID;
                                facade.Insert<Ins_MemberVerificationDetail>(verificationDetail);
                            }
                            catch (Exception ex) { }
                        }
                        else
                        {
                            facade.Update<Ins_MemberVerificationDetail>(verificationDetail);
                        }
                        break;
                    default:
                        verificationDetail.LastUpdated = DateTime.Now;

                        if (isNew)
                        {
                            try
                            {
                                verificationDetail.VerificationTypeId = typeID;
                                facade.Insert<Ins_MemberVerificationDetail>(verificationDetail);
                            }
                            catch (Exception ex) { }
                        }
                        else
                        {
                            facade.Update<Ins_MemberVerificationDetail>(verificationDetail);
                        }
                        break;

                }
                LoadApprovedButton();
            }

        }

        protected void btnAllSubmit_Click(object sender, EventArgs e)
        {
            using (TheFacade facade = new TheFacade())
            {
                Member member = facade.MemberFacade.GetMemberById(MemberID);
                Ins_MemberVerification memberVerification = facade.MemberFacade.GetMemberVerificationByMemberID(MemberID);
                if (memberVerification != null)
                {
                    memberVerification.Status = (int)VerificationStatus.Approved_for_Committee_Meeting;
                    facade.Update<Ins_MemberVerification>(memberVerification);
                }
                member.MemberVerificationStatus =  (int)VerificationStatus.Approved_for_Committee_Meeting;
                facade.Update<Member>(member);
            }
        }
    }
}