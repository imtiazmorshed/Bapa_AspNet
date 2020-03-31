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

namespace OMS.Incentive.InsMember
{
    public partial class MemberProduct : System.Web.UI.Page
    {
        public long MemberID
        {
            get
            {
                if (ViewState["MemberID"] != null)
                {
                    return Convert.ToInt64(ViewState["MemberID"].ToString());
                }
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
                if (Session["MemberID"] != null)
                {
                    MemberID = Convert.ToInt64(Session["MemberID"].ToString());
                    ddlMember.Enabled = false;
                }
                LoadPageData();



            }
        }

        private void LoadPageData()
        {
            using (TheFacade facade = new TheFacade())
            {
                //List<Ins_Item> itemList = facade.InsentiveFacade.GetItemAll();
                //DDLHelper.Bind<Ins_Item>(ddlItem, itemList, "Name", "IID", EnumCollection.ListItemType.ItemName, true);

                List<Member> members = facade.InsentiveFacade.GetMemberAll();
                DDLHelper.Bind<Member>(ddlMember, members, "Name", "ID", EnumCollection.ListItemType.Select, true);

                List<Ins_ItemCategory> categories = facade.InsentiveFacade.GetCategoryAll();
                DDLHelper.Bind<Ins_ItemCategory>(ddlCategory, categories, "Name", "IID", EnumCollection.ListItemType.Select, true);
                if (MemberID > 0)
                    ddlMember.SelectedValue = MemberID.ToString();
                LoadMemberItem();
            }
        }

        private void LoadMemberItem()
        {
            using (TheFacade facade = new TheFacade())
            {
                if (MemberID > 0)
                {
                    List<Ins_MemberItem> memberInsItems = facade.InsentiveFacade.GetMemberItemByMemberID(MemberID);
                    lvMemberItem.DataSource = memberInsItems;
                    lvMemberItem.DataBind();
                }
                else
                {
                    List<Ins_MemberItem> memberInsItems = facade.InsentiveFacade.GetMemberItemAll();
                    lvMemberItem.DataSource = memberInsItems;
                    lvMemberItem.DataBind();
                }
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (SelectedItemId <= 0)
            {

                Ins_MemberItem item = new Ins_MemberItem();
                item.Name = txtName.Text;
                item.ItemID = Convert.ToInt32(ddlItem.SelectedValue);
                item.MemberID = Convert.ToInt32(ddlMember.SelectedValue);
                item.Code = txtProductCode.Text;
                item.ItemWeight = Convert.ToDecimal(txtProductWeight.Text);
                item.CreateBy = 1;//sustemuserid
                item.CreateDate = DateTime.Now;
                item.IsRemoved = 0;
                item.UpdateBy = 1;//sustemuserid
                item.UpdateDate = DateTime.Now;

                using (TheFacade facade = new TheFacade())
                {
                    facade.Insert<Ins_MemberItem>(item);
                    Response.Redirect(Request.Url.ToString());
                }
            }
            else
            {

                using (TheFacade facade = new TheFacade())
                {
                    Ins_MemberItem item = facade.InsentiveFacade.GetMemberItemByIdForUpdate(SelectedItemId);
                    item.Name = txtName.Text;
                    item.MemberID = Convert.ToInt32(ddlMember.SelectedValue);
                    item.ItemID = Convert.ToInt32(ddlItem.SelectedValue);
                    item.Code = txtProductCode.Text;
                    item.ItemWeight = Convert.ToDecimal(txtProductWeight.Text);
                    item.UpdateBy = 1;//sustemuserid
                    item.UpdateDate = DateTime.Now;

                    facade.Update<Ins_MemberItem>(item);
                    Response.Redirect(Request.Url.ToString());
                }

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
        protected void lvMemberItem_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            if (e.CommandName == "editMemberItem")
            {
                SelectedItemId = Convert.ToInt32(e.CommandArgument.ToString());
                LoadMemberItemDetails();

            }
        }

        private void LoadMemberItemDetails()
        {
            using (TheFacade facade = new TheFacade())
            {
                Ins_MemberItem memberItem = facade.InsentiveFacade.GetMemberItemById(SelectedItemId);

                if (memberItem != null)
                {
                    ddlMember.SelectedValue = memberItem.MemberID.ToString();
                    MemberID = memberItem.MemberID;
                    ddlMember.Enabled = false;
                    txtName.Text = memberItem.Name;
                    ddlCategory.SelectedValue = memberItem.Ins_Item.CategoryID.ToString();
                    ddlCategory_SelectedIndexChanged(null, null);
                    // BindItemDropdownList(memberItem.Ins_Item.CategoryID);
                    //BindItemDropdownListForUpdate(memberItem.Ins_Item.CategoryID, memberItem.Ins_Item.IID);
                    ddlItem.SelectedValue = memberItem.Ins_Item.IID.ToString();

                    txtProductCode.Text = memberItem.Code;
                    txtMeasurementUnit.Text = memberItem.Ins_Item.MeasurementUnit.Unit;
                    txtProductWeight.Text = memberItem.ItemWeight.HasValue ? memberItem.ItemWeight.Value.ToString("0.000") : "0";

                }
            }
        }

        protected void lvMemberItem_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            if (e.Item.ItemType == ListViewItemType.DataItem)
            {
                ListViewDataItem dataItem = (ListViewDataItem)e.Item;

                Label lblMemberItemName = (Label)e.Item.FindControl("lblMemberItemName");
                Label lblMember = (Label)e.Item.FindControl("lblMember");
                Label lblItemName = (Label)e.Item.FindControl("lblItemName");
                Label lblCode = (Label)e.Item.FindControl("lblCode");
                Label lblMesurementUnit = (Label)e.Item.FindControl("lblMesurementUnit");
                Label lblCategory = (Label)e.Item.FindControl("lblCategory");
                Label lblWeight = (Label)e.Item.FindControl("lblWeight");
                LinkButton lnkBtnEdit = (LinkButton)e.Item.FindControl("lnkBtnEdit");


                Ins_MemberItem item = dataItem.DataItem as Ins_MemberItem;


                lblMember.Text = item.Member.Name;
                lblMemberItemName.Text = item.Name;
                lblItemName.Text = item.Ins_Item.Name;
                lblCode.Text = item.Code;
                lblMesurementUnit.Text = item.Ins_Item.MeasurementUnit.Name;
                lblCategory.Text = item.Ins_Item.Ins_ItemCategory.Name;
                lnkBtnEdit.CommandArgument = item.IID.ToString();
                lblWeight.Text = item.ItemWeight.HasValue ? item.ItemWeight.Value.ToString("0.000") : "0";
                lnkBtnEdit.CommandName = "editMemberItem";
                lnkBtnEdit.Text = "Edit";
            }
        }

        protected void ddlItem_SelectedIndexChanged(object sender, EventArgs e)
        {

            long itemID = Convert.ToInt32(((DropDownList)sender).SelectedValue);

            using (TheFacade facade = new TheFacade())
            {
                Ins_Item item = facade.InsentiveFacade.GetItemByID(itemID);
                if (item != null)
                {

                    txtMeasurementUnit.Text = item.MeasurementUnit.Unit;
                    // txtCode.Text = item.Code;

                }
            }
        }

        protected void ddlMember_SelectedIndexChanged(object sender, EventArgs e)
        {
            long memberID = Convert.ToInt32(ddlMember.SelectedValue);
            MemberID = memberID;
            LoadMemberItem();
            ddlCategory_SelectedIndexChanged(null, null);
        }


        protected void ddlCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            long categoryId = Convert.ToInt32(ddlCategory.SelectedValue);

            BindItemDropdownList(categoryId);
        }

        private void BindItemDropdownList(long categoryId)
        {
            using (TheFacade facade = new TheFacade())
            {
                List<Ins_Item> itemList = facade.InsentiveFacade.GetItemListByCategoryID(categoryId);// GetItemListForMemberItemInsertByCategoryID(categoryId,MemberID);
                DDLHelper.Bind<Ins_Item>(ddlItem, itemList, "Name", "IID", EnumCollection.ListItemType.ItemName, true);
            }
        }

        private void BindItemDropdownListForUpdate(long categoryId, long itemID)
        {
            using (TheFacade facade = new TheFacade())
            {
                List<Ins_Item> itemList = facade.InsentiveFacade.GetItemListForMemberItemUpdateByCategoryID(categoryId, MemberID, itemID);
                DDLHelper.Bind<Ins_Item>(ddlItem, itemList, "Name", "IID", EnumCollection.ListItemType.ItemName, true);
            }
        }
    }
}