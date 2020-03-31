using OMS.DAL;
using OMS.Facade;
using OMS.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OMS.Incentive.MemberVerification
{
    public partial class ExistingMemberInCommiteeMeeting : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadListView();
            }
        }
        

        private void LoadListView()
        {
            List<Member> memberList = new List<Member>();
            using (TheFacade facade = new TheFacade())
            {
                memberList = facade.MemberFacade.GetMemberForCommitteeMeeting();
            }
            lvNewMember.DataSource = memberList.Where(m => m.TypeOfSubmission == (int)EnumCollection.TypeOfSubmission.Existing).ToList();
            lvNewMember.DataBind();
        }      

      

        protected void lvNewMember_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            if (e.Item.ItemType == ListViewItemType.DataItem)
            {
                ListViewDataItem dataItem = (ListViewDataItem)e.Item;
                Label lblName = (Label)e.Item.FindControl("lblName");
                Label lblMemberNo = (Label)e.Item.FindControl("lblMemberNo");
                Label lblStatus = (Label)e.Item.FindControl("lblStatus");
                Label lblVerificationTypeId = (Label)e.Item.FindControl("lblVerificationTypeId");
                LinkButton lnkBtnApproval = (LinkButton)e.Item.FindControl("lnkBtnApproval");


                Member member = dataItem.DataItem as Member;

                lblName.Text = member.Name;
                lblMemberNo.Text = member.MembershipCode;
                lblStatus.Text = EnumHelper.EnumToString<EnumCollection.VerificationStatus>(member.MemberVerificationStatus);
                lblVerificationTypeId.Text = EnumHelper.EnumToString<EnumCollection.TypeOfSubmission>(member.TypeOfSubmission);

                lnkBtnApproval.CommandArgument = member.ID.ToString();
                lnkBtnApproval.CommandName = "memberapproval";
                lnkBtnApproval.Text = "Approve";
            }
        }
        public int SelectedItemId
        {
            get
            {
                if (ViewState["SelectedItemId"] != null)
                    return Convert.ToInt32(ViewState["SelectedItemId"].ToString());
                else
                    return 0;
            }
            set
            {
                ViewState["SelectedItemId"] = value;
            }
        }
        protected void lvNewMember_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            if (e.CommandName == "memberapproval")
            {
                SelectedItemId = Convert.ToInt32(e.CommandArgument.ToString());
                Response.Redirect(String.Format("~/Admin/MemberAccountsView.aspx?MemberID={0}", SelectedItemId));
            }
        }

    }
}