using OMS.DAL;
using OMS.Facade;
using OMS.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OMS.Incentive.MemberRegisterd
{
    public partial class MemberVarificationStatus : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["MemberID"] == null)
                {
                    Session.Abandon();
                    Response.Redirect("~/Login/login.aspx");
                }
                else
                {
                    LoadListView();

                }

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
        private void LoadListView()
        {
            List<Ins_MemberVerificationDetail> memberList = new List<Ins_MemberVerificationDetail>();
            using (TheFacade facade = new TheFacade())
            {
                memberList = facade.MemberFacade.GetMemberVerificationDetailsById(MemberID);
            }
            lvNewMember.DataSource = memberList;
            lvNewMember.DataBind();
        }

        protected void lvNewMember_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            
        }
          
        protected void lvNewMember_ItemDataBound1(object sender, ListViewItemEventArgs e)
        {
            using (TheFacade facade = new TheFacade())
            {

                if (e.Item.ItemType == ListViewItemType.DataItem)
                {
                    ListViewDataItem dataItem = (ListViewDataItem)e.Item;
                    Label lblName = (Label)e.Item.FindControl("lblName");
                    Label lblVerificationTypeId = (Label)e.Item.FindControl("lblVerificationTypeId");
                    Label lblStatus = (Label)e.Item.FindControl("lblStatus");
                    Label lblLastUpdateDate = (Label)e.Item.FindControl("lblLastUpdateDate");

                    Ins_MemberVerificationDetail member = dataItem.DataItem as Ins_MemberVerificationDetail;

                    lblName.Text = facade.MemberFacade.GetMemberById(member.MemberID).Name;
                    lblVerificationTypeId.Text = facade.MemberFacade.GetAllVerificationTypeById(member.VerificationTypeId).Name;//member.VerificationTypeId.ToString();
                    lblStatus.Text = EnumHelper.EnumToString <EnumCollection.VerificationStatus>( member.Status);//member.Status.ToString();
                    lblLastUpdateDate.Text = member.LastUpdated.ToString();
                }
            }

        }
    }
}