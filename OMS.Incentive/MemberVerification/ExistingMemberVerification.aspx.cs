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
    public partial class ExistingMemberVerification : System.Web.UI.Page
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
                memberList = facade.MemberFacade.GetExistingMemberVerificationList();
            }
            lvNewMember.DataSource = memberList;
            lvNewMember.DataBind();
        }

        protected void lvNewMember_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            if (e.Item.ItemType == ListViewItemType.DataItem)
            {
                ListViewDataItem dataItem = (ListViewDataItem)e.Item;
                Label lblName = (Label)e.Item.FindControl("lblName");
                Label lblAddress = (Label)e.Item.FindControl("lblAddress");
                Label lblStatus = (Label)e.Item.FindControl("lblStatus");
                Label lblLastUpdateDate = (Label)e.Item.FindControl("lblLastUpdateDate");
                LinkButton lnkBtnVerification = (LinkButton)e.Item.FindControl("lnkBtnVerification");


                Member member = dataItem.DataItem as Member;

                lblName.Text = member.Name;
                lblAddress.Text = member.Address;
                lblStatus.Text = EnumHelper.EnumToString<EnumCollection.VerificationStatus>(member.MemberVerificationStatus);
                lblLastUpdateDate.Text = member.VerificationLastUpdateDate;
                lnkBtnVerification.CommandArgument = member.ID.ToString();
                lnkBtnVerification.CommandName = "memberverification";
                lnkBtnVerification.Text = "Proced verification";
            }
        }

        protected void lvNewMember_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            if (e.CommandName == "memberverification")
            {
                int memberID = Convert.ToInt32(e.CommandArgument);
                string pageUrl = string.Format("/MemberVerification/RegistrationMemberVerification.aspx?MemberID={0}", memberID.ToString());
                Response.Redirect(pageUrl);
            }
        }
    }
}