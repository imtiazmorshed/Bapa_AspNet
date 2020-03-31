using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Xml.Linq;
using OMS.DAL;
using System.Collections.Generic;
using OMS.Facade;
using OMS.Web.Helpers;

namespace OMS.WebClient.UIInventory
{
    public partial class ItemView : System.Web.UI.Page
    {
        public int IsNew
        {
            get
            {
                if (ViewState["IsNew"] == null)
                {
                    return 1;
                }
                else
                {
                    return Convert.ToInt32(ViewState["IsNew"]);
                }
            }
            set { ViewState["IsNew"] = value; }
        }

        public long CurrentItemID
        {
            get
            {
                if (ViewState["CurrentItemID"] == null)
                {
                    return -1;
                }
                else
                {
                    return Convert.ToInt64(ViewState["CurrentItemID"]);
                }
            }
            set { ViewState["CurrentItemID"] = value; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                IsNew = 1;

                LoadItemListView();
                LoadMeasurementUnit();
            }
        }

        private void LoadMeasurementUnit()
        {
            List<MeasurementUnit> measurementUnitList = new List<MeasurementUnit>();
            using (TheFacade _facade = new TheFacade())
            {
                measurementUnitList = _facade.InventoryGeneralFacade.GetMeasurementUnitAll();
            }
            DDLHelper.Bind<MeasurementUnit>(ddlMeasurementUnit, measurementUnitList, "Name", "IID");
        }

        private void LoadItemListView()
        {
            List<Item> itemList = new List<Item>();
            using (TheFacade _facade = new TheFacade())
            {
                itemList = _facade.ItemFacade.GetItemAll();
            }
            lvItem.DataSource = itemList;
            lvItem.DataBind();
        }

        protected void lvItem_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            if (e.Item.ItemType == ListViewItemType.DataItem)
            {
                ListViewDataItem currentItem = (ListViewDataItem)e.Item;
                Item item = (Item)((ListViewDataItem)(e.Item)).DataItem;
                LinkButton lnkName = (LinkButton)currentItem.FindControl("lnkName");
                Label lblCode = (Label)currentItem.FindControl("lblCode");
                Label lblMeasurementUnit = (Label)currentItem.FindControl("lblMeasurementUnit");
                LinkButton lnkEdit = (LinkButton)currentItem.FindControl("lnkEdit");
                LinkButton lnkDelete = (LinkButton)currentItem.FindControl("lnkDelete");

                lnkName.Text = item.Name;
                lnkName.CommandArgument = item.IID.ToString();
                lnkName.CommandName = "LoadItem";

                lblCode.Text = item.Code;
                lblMeasurementUnit.Text = item.MeasurementUnit.Name;
                lnkEdit.CommandName = "DoEdit";
                lnkEdit.CommandArgument = item.IID.ToString();

                lnkDelete.CommandName = "DoDelete";
                lnkDelete.CommandArgument = item.IID.ToString();
            }
        }

        protected void lvItem_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            if (e.CommandName == "DoDelete")
            {

                using (TheFacade _facade = new TheFacade())
                {
                    Item item = new Item();

                    item = _facade.ItemFacade.GetItemByID(Convert.ToInt64(e.CommandArgument.ToString()));
                    CurrentItemID = item.IID;
                    txtName.Text = item.Name;
                    txtCode.Text = item.Code;
                    ddlMeasurementUnit.SelectedValue = item.MeasurementUnitID.ToString();
                    IsNew = -1;
                }
            }

            else
            {

                using (TheFacade _facade = new TheFacade())
                {
                    Item item = new Item();

                    item = _facade.ItemFacade.GetItemByID(Convert.ToInt64(e.CommandArgument.ToString()));
                    CurrentItemID = item.IID;
                    txtName.Text = item.Name;
                    txtCode.Text = item.Code;
                    ddlMeasurementUnit.SelectedValue = item.MeasurementUnitID.ToString();
                    IsNew = 0;
                }
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            Item item = new Item();
            if (Convert.ToBoolean(ViewState["IsNew"]))
            {

                LoadItem(item);
                using (TheFacade _facade = new TheFacade())
                {
                    _facade.Insert<Item>(item);
                }
            }
            else
            {
                using (TheFacade _facade = new TheFacade())
                {
                    item= _facade.ItemFacade.GetItemByID(CurrentItemID);
                    LoadItem(item);
                    _facade.Update<Item>(item);
                }
            }
            Response.Redirect("~/UIInventory/ItemView.aspx");
            
        }

        private void LoadItem(Item item)
        {
            item.Name = txtName.Text;
            item.Code = txtCode.Text;
            item.MeasurementUnitID = Convert.ToInt32(ddlMeasurementUnit.SelectedValue);
            item.CategoryID = 1;
            if (Convert.ToBoolean(ViewState["IsNew"]))
            {
                item.CreateBy = 1;
            }

            item.UpdateBy = 1;
            if (Convert.ToBoolean(ViewState["IsNew"]))
            {
                item.CreateDate = DateTime.Now;
            }
            item.UpdateDate = DateTime.Now;
            item.IsRemoved = 0;
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            txtName.Text = string.Empty;
            txtCode.Text = string.Empty;
            ddlMeasurementUnit.SelectedIndex = -1;
            IsNew = 1;
        }

        protected void dpItem_PreRender(object sender, EventArgs e)
        {
            LoadItemListView();
        }
    }
}
