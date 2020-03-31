using OMS.DAL;
using OMS.Facade;
using OMS.Framework;
using OMS.Web.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OMS.Incentive.Admin
{
    public partial class MemberChaForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadData();
            }
        }

        private void LoadData()
        {
            using (TheFacade facade = new TheFacade())
            {
                List<Member> memberItems = facade.MemberFacade.GetApprovedMember();
                DDLHelper.Bind<Member>(ddlMember, memberItems, "Name", "ID", EnumCollection.ListItemType.Select, true);

               

            }
            LoadListViews();
        }

        private void LoadListViews()
        {
            using (TheFacade facade = new TheFacade())
            {
                long memberID = Convert.ToInt64(ddlMember.SelectedValue.ToString());
                List<Ins_ChaForm> chaFromList = new List<Ins_ChaForm>();
                if (memberID > 0)
                {
                    chaFromList = facade.InsentiveFacade.GetChaFormAllByMemeberID(memberID);
                }
                else
                {
                    chaFromList = facade.InsentiveFacade.GetChaFormAll();
                }
                List<Ins_ChaForm> submitedCgaForm = chaFromList.Where(c => c.Status == (int)EnumCollection.ChaFormStatus.Submited || c.Status == (int)EnumCollection.ChaFormStatus.ReSubmit).ToList();
                List<Ins_ChaForm> approvedCgaForm = chaFromList.Where(c => c.Status == (int)EnumCollection.ChaFormStatus.Approved).ToList();
                lvApproved.DataSource = approvedCgaForm;
                lvApproved.DataBind();
                lvSubmittedChaForm.DataSource = submitedCgaForm;
                lvSubmittedChaForm.DataBind();
            }
        }

        protected void lvSubmittedChaForm_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            if (e.Item.ItemType == ListViewItemType.DataItem)
            {
                ListViewDataItem dataItem = (ListViewDataItem)e.Item;
                Label lblMemberNo = (Label)e.Item.FindControl("lblMemberNo");
                Label lblMemberName = (Label)e.Item.FindControl("lblMemberName");
                Label lblAggrementNo = (Label)e.Item.FindControl("lblAggrementNo");
                Label lblAggrementDate = (Label)e.Item.FindControl("lblAggrementDate");
                Label lblForignCustomerName = (Label)e.Item.FindControl("lblForignCustomerName");
                Label lblForignCustomerBankName = (Label)e.Item.FindControl("lblForignCustomerBankName");
                Label lblCurrency = (Label)e.Item.FindControl("lblCurrency");
                Label lblShipmentDate = (Label)e.Item.FindControl("lblShipmentDate");

                LinkButton lnkBtnView = (LinkButton)e.Item.FindControl("lnkBtnView");
                LinkButton lnkBtnApprove = (LinkButton)e.Item.FindControl("lnkBtnApprove");


                Ins_ChaForm chaForm = dataItem.DataItem as Ins_ChaForm;

                lblMemberNo.Text = chaForm.Member.MembershipCode;
                lblMemberName.Text = chaForm.Member.Name;
                lblAggrementNo.Text = chaForm.ExportLCNo;
                lblAggrementDate.Text = chaForm.LCDate.ToString("dd/MM/yyyy");
                lblForignCustomerName.Text = chaForm.ForignCustomerName;
                lblForignCustomerBankName.Text = chaForm.ForignCustomerBankName;
                lblCurrency.Text = chaForm.Currency.CurrencyCode;
                lblShipmentDate.Text = chaForm.ShipmentDate.ToString("dd/MM/yyyy");

                lnkBtnView.CommandArgument = chaForm.ID.ToString();
                lnkBtnView.CommandName = "viewItem";
                lnkBtnView.Text = "View";
                lnkBtnApprove.CommandArgument = chaForm.ID.ToString();
                lnkBtnApprove.CommandName = "approveItem";
                lnkBtnApprove.Text = "Approve";
            }
        }
        protected void lvSubmittedChaForm_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            if (e.CommandName == "viewItem")
            {
                long chaFormID = Convert.ToInt32(e.CommandArgument.ToString());

                Response.Redirect(string.Format("~/Admin/ChaForm.aspx?CurrentChaFormID={0}&IsForSubmit=1", chaFormID));
            }
            if (e.CommandName == "approveItem")
            {
                long chaFormID = Convert.ToInt32(e.CommandArgument.ToString());
                
                Response.Redirect(string.Format("~/Admin/ChaFormApproval.aspx?CurrentChaFormID={0}", chaFormID));

            }
        }

        //Approved
        protected void lvApproved_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            if (e.Item.ItemType == ListViewItemType.DataItem)
            {
                ListViewDataItem dataItem = (ListViewDataItem)e.Item;
                Label lblChgaFormNo = (Label)e.Item.FindControl("lblChaFormNo");
                Label lblMemberNo = (Label)e.Item.FindControl("lblMemberNo");
                Label lblMemberName = (Label)e.Item.FindControl("lblMemberName");
                Label lblAggrementNo = (Label)e.Item.FindControl("lblAggrementNo");
                Label lblAggrementDate = (Label)e.Item.FindControl("lblAggrementDate");
                Label lblForignCustomerName = (Label)e.Item.FindControl("lblForignCustomerName");
                Label lblForignCustomerBankName = (Label)e.Item.FindControl("lblForignCustomerBankName");
                Label lblCurrency = (Label)e.Item.FindControl("lblCurrency");
                Label lblShipmentDate = (Label)e.Item.FindControl("lblShipmentDate");

                //LinkButton lnkBtnEdit = (LinkButton)e.Item.FindControl("lnkBtnEdit");
                LinkButton lnkBtnView = (LinkButton)e.Item.FindControl("lnkBtnView");


                Ins_ChaForm chaForm = dataItem.DataItem as Ins_ChaForm;
                lblChgaFormNo.Text = chaForm.ChaFormNo;
                lblMemberNo.Text = chaForm.Member.MembershipCode;
                lblMemberName.Text = chaForm.Member.Name;
                lblAggrementNo.Text = chaForm.ExportLCNo;
                lblAggrementDate.Text = chaForm.LCDate.ToString("dd/MM/yyyy");
                lblForignCustomerName.Text = chaForm.ForignCustomerName;
                lblForignCustomerBankName.Text = chaForm.ForignCustomerBankName;
                lblCurrency.Text = chaForm.Currency.CurrencyCode;
                lblShipmentDate.Text = chaForm.ShipmentDate.ToString("dd/MM/yyyy");

                //lnkBtnEdit.CommandArgument = chaForm.ID.ToString();
                //lnkBtnEdit.CommandName = "editItem";
                //lnkBtnEdit.Text = "Edit";
                lnkBtnView.CommandArgument = chaForm.ID.ToString();
                lnkBtnView.CommandName = "viewItem";
                lnkBtnView.Text = "View";
            }
        }
        protected void lvApproved_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            //if (e.CommandName == "editItem")
            //{
            //    long chaFormID = Convert.ToInt32(e.CommandArgument.ToString());
            //    Response.Redirect("~/InsMember/ChaForm.aspx?CurrentChaFormID=chaFormID");

            //}
            if (e.CommandName == "viewItem")
            {
                long chaFormID = Convert.ToInt32(e.CommandArgument.ToString());
                Response.Redirect(string.Format("~/Admin/ChaForm.aspx?CurrentChaFormID={0}&IsForSubmit=1",chaFormID));

            }
        }
    }
}