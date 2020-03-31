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
    public partial class ItemList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadPageData();
            }
        }

        private void LoadPageData()
        {
            using (TheFacade facade = new TheFacade())
            {
                List<Ins_ItemCategory> categoryList = facade.InsentiveFacade.GetCategoryAll();

                DDLHelper.Bind<Ins_ItemCategory>(ddlItemCetagory, categoryList, "Name", "IID", EnumCollection.ListItemType.CategoryName, true);
                List<MeasurementUnit> mesurementUnitlist = new List<MeasurementUnit>();
                mesurementUnitlist = facade.InventoryGeneralFacade.GetMeasurementUnitAll();
                DDLHelper.Bind<MeasurementUnit>(ddlMesumentUnit, mesurementUnitlist, "Name", "IID", EnumCollection.ListItemType.MesurementUnit, true);

                List<Ins_Item> itemList = facade.InsentiveFacade.GetItemAll();
                lvItem.DataSource = itemList;
                lvItem.DataBind();
            }
        }
        public long SelectedItemId
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

        protected void lvItem_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            if (e.CommandName == "editItem")
            {
                SelectedItemId = Convert.ToInt32(e.CommandArgument.ToString());
                LoadItemDetails();

            }
        }

        private void LoadItemDetails()
        {
            using (TheFacade facade = new TheFacade())
            {
                Ins_Item item = facade.InsentiveFacade.GetItemByID(SelectedItemId);
                if (item != null)
                {
                    txtName.Text = item.Name;
                    txtCode.Text = item.Code;
                    ddlItemCetagory.SelectedValue = item.CategoryID.ToString();
                    ddlMesumentUnit.SelectedValue = item.MeasurementUnitID.ToString();
                }
            }
        }

        protected void lvItem_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            if (e.Item.ItemType == ListViewItemType.DataItem)
            {
                ListViewDataItem dataItem = (ListViewDataItem)e.Item;
                Label lblName = (Label)e.Item.FindControl("lblName");
                Label lblCode = (Label)e.Item.FindControl("lblCode");
                Label lblMesurementUnit = (Label)e.Item.FindControl("lblMesurementUnit");
                Label lblCategory = (Label)e.Item.FindControl("lblCategory");
                LinkButton lnkBtnEdit = (LinkButton)e.Item.FindControl("lnkBtnEdit");


                Ins_Item item = dataItem.DataItem as Ins_Item;

                lblName.Text = item.Name;
                lblCode.Text = item.Code;
                lblMesurementUnit.Text = item.MeasurementUnit.Name;
                lblCategory.Text = item.Ins_ItemCategory.Name;
                lnkBtnEdit.CommandArgument = item.IID.ToString();
                lnkBtnEdit.CommandName = "editItem";
                lnkBtnEdit.Text = "Edit";
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (SelectedItemId <= 0)
            {

                Ins_Item item = new Ins_Item();
                item.Name = txtName.Text;
                item.Code = txtCode.Text;
                item.MeasurementUnitID = Convert.ToInt32(ddlMesumentUnit.SelectedValue);
                item.CategoryID = Convert.ToInt32(ddlItemCetagory.SelectedValue);
                item.CreateBy = 1;//sustemuserid
                item.CreateDate = DateTime.Now;
                item.IsRemoved = 0;
                item.UpdateBy = 1;//sustemuserid
                item.UpdateDate = DateTime.Now;

                using (TheFacade facade = new TheFacade())
                {
                    facade.Insert<Ins_Item>(item);
                    Response.Redirect(Request.Url.ToString());
                }
            }
            else
            {

                using (TheFacade facade = new TheFacade())
                {
                    Ins_Item item = facade.InsentiveFacade.GetItemByID(SelectedItemId);
                    item.Name = txtName.Text;
                    item.Code = txtCode.Text;
                    item.MeasurementUnitID = Convert.ToInt32(ddlMesumentUnit.SelectedValue);
                    item.CategoryID = Convert.ToInt32(ddlItemCetagory.SelectedValue);
                    item.UpdateBy = 1;//sustemuserid
                    item.UpdateDate = DateTime.Now;

                    facade.Update<Ins_Item>(item);
                    Response.Redirect(Request.Url.ToString());
                }

            }
            
        }
    }
}