using OMS.DAL;
using OMS.Facade;
using OMS.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OMS.Incentive.InsMember
{
    public partial class MemberChaFormListing : System.Web.UI.Page
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
            if (!IsPostBack)
            {
                BindPageData();
            }
        }

        private void BindPageData()
        {
            using (TheFacade facade = new TheFacade())
            {
                List<Ins_ChaForm> chafromList = facade.InsentiveFacade.GetChaFormAllByMemeberID(MemberID);
                List<Ins_ChaForm> draftChafromList = chafromList.Where(c => c.Status == (int)EnumCollection.ChaFormStatus.Draft).ToList();
                List<Ins_ChaForm> submittedChafromList = chafromList.Where(c => c.Status == (int)EnumCollection.ChaFormStatus.Submited || c.Status == (int)EnumCollection.ChaFormStatus.ReSubmit).ToList();
                List<Ins_ChaForm> declinedChafromList = chafromList.Where(c => c.Status == (int)EnumCollection.ChaFormStatus.Decline).ToList();
                List<Ins_ChaForm> approvedChafromList = chafromList.Where(c => c.Status == (int)EnumCollection.ChaFormStatus.Approved).ToList();

                lvIDraftChaForm.DataSource = draftChafromList;
                lvIDraftChaForm.DataBind();

                lvDeclinedChaForm.DataSource = declinedChafromList;
                lvDeclinedChaForm.DataBind();

                lvSubmittedChaForm.DataSource = submittedChafromList;
                lvSubmittedChaForm.DataBind();

                lvApprovedChaForm.DataSource = approvedChafromList;
                lvApprovedChaForm.DataBind();
            }
        }
        protected void lvIDraftChaForm_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            if (e.Item.ItemType == ListViewItemType.DataItem)
            {
                ListViewDataItem dataItem = (ListViewDataItem)e.Item;
                Label lblAggrementNo = (Label)e.Item.FindControl("lblAggrementNo");
                Label lblAggrementDate = (Label)e.Item.FindControl("lblAggrementDate");
                Label lblForignCustomerName = (Label)e.Item.FindControl("lblForignCustomerName");
                Label lblForignCustomerBankName = (Label)e.Item.FindControl("lblForignCustomerBankName");
                Label lblCurrency = (Label)e.Item.FindControl("lblCurrency");
                Label lblShipmentDate = (Label)e.Item.FindControl("lblShipmentDate");

                LinkButton lnkBtnEdit = (LinkButton)e.Item.FindControl("lnkBtnEdit");
                LinkButton lnkBtnSummit = (LinkButton)e.Item.FindControl("lnkBtnSummit");


                Ins_ChaForm chaForm = dataItem.DataItem as Ins_ChaForm;

                lblAggrementNo.Text = chaForm.ExportLCNo;
                lblAggrementDate.Text = chaForm.LCDate.ToString("dd/MM/yyyy");
                lblForignCustomerName.Text = chaForm.ForignCustomerName;
                lblForignCustomerBankName.Text = chaForm.ForignCustomerBankName;
                lblCurrency.Text = chaForm.Currency.CurrencyCode;
                lblShipmentDate.Text = chaForm.ShipmentDate.ToString("dd/MM/yyyy");

                lnkBtnEdit.CommandArgument = chaForm.ID.ToString();
                lnkBtnEdit.CommandName = "editItem";
                lnkBtnEdit.Text = "Edit";
                lnkBtnSummit.CommandArgument = chaForm.ID.ToString();
                lnkBtnSummit.CommandName = "submitItem";
                lnkBtnSummit.Text = "Submit";
            }
        }
        protected void lvIDraftChaForm_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            if (e.CommandName == "editItem")
            {
                long chaFormID = Convert.ToInt32(e.CommandArgument.ToString());
                Response.Redirect(string.Format("~/InsMember/ChaForm.aspx?CurrentChaFormID={0}",chaFormID));

            }
            if (e.CommandName == "submitItem")
            {
                long chaFormID = Convert.ToInt32(e.CommandArgument.ToString());
                Response.Redirect(string.Format("~/InsMember/ChaForm.aspx?CurrentChaFormID={0}&IsForSubmit=1",chaFormID));

            }
        }

        //decline
        protected void lvDeclinedChaForm_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            if (e.Item.ItemType == ListViewItemType.DataItem)
            {
                ListViewDataItem dataItem = (ListViewDataItem)e.Item;
                Label lblAggrementNo = (Label)e.Item.FindControl("lblAggrementNo");
                Label lblAggrementDate = (Label)e.Item.FindControl("lblAggrementDate");
                Label lblForignCustomerName = (Label)e.Item.FindControl("lblForignCustomerName");
                Label lblForignCustomerBankName = (Label)e.Item.FindControl("lblForignCustomerBankName");
                Label lblCurrency = (Label)e.Item.FindControl("lblCurrency");
                Label lblShipmentDate = (Label)e.Item.FindControl("lblShipmentDate");

                LinkButton lnkBtnEdit = (LinkButton)e.Item.FindControl("lnkBtnEdit");
                LinkButton lnkBtnSummit = (LinkButton)e.Item.FindControl("lnkBtnSummit");


                Ins_ChaForm chaForm = dataItem.DataItem as Ins_ChaForm;

                lblAggrementNo.Text = chaForm.ExportLCNo;
                lblAggrementDate.Text = chaForm.LCDate.ToString("dd/MM/yyyy");
                lblForignCustomerName.Text = chaForm.ForignCustomerName;
                lblForignCustomerBankName.Text = chaForm.ForignCustomerBankName;
                lblCurrency.Text = chaForm.Currency.CurrencyCode;
                lblShipmentDate.Text = chaForm.ShipmentDate.ToString("dd/MM/yyyy");

                lnkBtnEdit.CommandArgument = chaForm.ID.ToString();
                lnkBtnEdit.CommandName = "editItem";
                lnkBtnEdit.Text = "Edit";
                lnkBtnSummit.CommandArgument = chaForm.ID.ToString();
                lnkBtnSummit.CommandName = "submitItem";
                lnkBtnSummit.Text = "View";
            }
        }
        protected void lvDeclinedChaForm_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            if (e.CommandName == "editItem")
            {
                long chaFormID = Convert.ToInt32(e.CommandArgument.ToString());
                Response.Redirect(string.Format("~/InsMember/ChaForm.aspx?CurrentChaFormID={0}", chaFormID));

            }
            if (e.CommandName == "submitItem")
            {
                long chaFormID = Convert.ToInt32(e.CommandArgument.ToString());
                Response.Redirect(string.Format("~/InsMember/ChaForm.aspx?CurrentChaFormID={0}&IsForSubmit=1", chaFormID));

            }
        }

        //submited
        protected void lvSubmittedChaForm_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            if (e.Item.ItemType == ListViewItemType.DataItem)
            {
                ListViewDataItem dataItem = (ListViewDataItem)e.Item;
                Label lblAggrementNo = (Label)e.Item.FindControl("lblAggrementNo");
                Label lblAggrementDate = (Label)e.Item.FindControl("lblAggrementDate");
                Label lblForignCustomerName = (Label)e.Item.FindControl("lblForignCustomerName");
                Label lblForignCustomerBankName = (Label)e.Item.FindControl("lblForignCustomerBankName");
                Label lblCurrency = (Label)e.Item.FindControl("lblCurrency");
                Label lblShipmentDate = (Label)e.Item.FindControl("lblShipmentDate");

                LinkButton lnkBtnView = (LinkButton)e.Item.FindControl("lnkBtnView");


                Ins_ChaForm chaForm = dataItem.DataItem as Ins_ChaForm;

                lblAggrementNo.Text = chaForm.ExportLCNo;
                lblAggrementDate.Text = chaForm.LCDate.ToString("dd/MM/yyyy");
                lblForignCustomerName.Text = chaForm.ForignCustomerName;
                lblForignCustomerBankName.Text = chaForm.ForignCustomerBankName;
                lblCurrency.Text = chaForm.Currency.CurrencyCode;
                lblShipmentDate.Text = chaForm.ShipmentDate.ToString("dd/MM/yyyy");

                lnkBtnView.CommandArgument = chaForm.ID.ToString();
                lnkBtnView.CommandName = "ViewChaForm";
                lnkBtnView.Text = "View";
            }
        }
        protected void lvSubmittedChaForm_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            if (e.CommandName == "ViewChaForm")
            {
                long chaFormID = Convert.ToInt32(e.CommandArgument.ToString());
                Response.Redirect(string.Format("~/InsMember/ChaForm.aspx?CurrentChaFormID={0}&IsForView=1",chaFormID));

            }
        }
        //approved
        protected void lvApprovedChaForm_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            if (e.Item.ItemType == ListViewItemType.DataItem)
            {
                ListViewDataItem dataItem = (ListViewDataItem)e.Item;
                Label lblAggrementNo = (Label)e.Item.FindControl("lblAggrementNo");
                Label lblAggrementDate = (Label)e.Item.FindControl("lblAggrementDate");
                Label lblForignCustomerName = (Label)e.Item.FindControl("lblForignCustomerName");
                Label lblForignCustomerBankName = (Label)e.Item.FindControl("lblForignCustomerBankName");
                Label lblCurrency = (Label)e.Item.FindControl("lblCurrency");
                Label lblShipmentDate = (Label)e.Item.FindControl("lblShipmentDate");

                LinkButton lnkBtnView = (LinkButton)e.Item.FindControl("lnkBtnView");
                


                Ins_ChaForm chaForm = dataItem.DataItem as Ins_ChaForm;

                lblAggrementNo.Text = chaForm.ExportLCNo;
                lblAggrementDate.Text = chaForm.LCDate.ToString("dd/MM/yyyy");
                lblForignCustomerName.Text = chaForm.ForignCustomerName;
                lblForignCustomerBankName.Text = chaForm.ForignCustomerBankName;
                lblCurrency.Text = chaForm.Currency.CurrencyCode;
                lblShipmentDate.Text = chaForm.ShipmentDate.ToString("dd/MM/yyyy");

                lnkBtnView.CommandArgument = chaForm.ID.ToString();
                lnkBtnView.CommandName = "ViewChaForm";
                lnkBtnView.Text = "View";
                
            }
        }
        protected void lvApprovedChaForm_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            
            if (e.CommandName == "ViewChaForm")
            {
                long chaFormID = Convert.ToInt32(e.CommandArgument.ToString());
                Response.Redirect(string.Format("~/InsMember/ChaForm.aspx?CurrentChaFormID={0}&IsForView=1", chaFormID));

            }
        }

    }
}