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
using System.Collections.Generic;
using OMS.Facade;
using OMS.DAL;

namespace OMS.WebClient.UIInventory
{
    public partial class MeasurementUnitView : System.Web.UI.Page
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

        public int CurrentMeasurementUnitID
        {
            get
            {
                if (ViewState["CurrentMeasurementUnitID"] == null)
                {
                    return -1;
                }
                else
                {
                    return Convert.ToInt32(ViewState["CurrentMeasurementUnitID"]);
                }
            }
            set { ViewState["CurrentMeasurementUnitID"] = value; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                IsNew = 1;

                LoadMeasurementUnitListView();
            }
        }

        private void LoadMeasurementUnitListView()
        {
            List<MeasurementUnit> measurementUnitList = new List<MeasurementUnit>();
            using (TheFacade _facade = new TheFacade())
            {
                measurementUnitList = _facade.InventoryGeneralFacade.GetMeasurementUnitAll();
            }
            lvMeasurementUnit.DataSource = measurementUnitList;
            lvMeasurementUnit.DataBind();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            MeasurementUnit measurementUnit = new MeasurementUnit();
            if (Convert.ToBoolean(ViewState["IsNew"]))
            {
                
                LoadMeasurementUnit(measurementUnit);
                using (TheFacade _facade = new TheFacade())
                {
                    _facade.Insert<MeasurementUnit>(measurementUnit);
                }
            }
            else
            {
                using (TheFacade _facade = new TheFacade())
                {
                    measurementUnit = _facade.InventoryGeneralFacade.GetMeasurementUnitByID(CurrentMeasurementUnitID);
                    LoadMeasurementUnit(measurementUnit);
                    _facade.Update<MeasurementUnit>(measurementUnit);
                }
            }
            Response.Redirect("~/UIInventory/MeasurementUnitView.aspx");
        }

        private void LoadMeasurementUnit(MeasurementUnit measurementUnit)
        {
            measurementUnit.Name = txtName.Text;
            measurementUnit.Unit = txtUnit.Text;
            
            if (Convert.ToBoolean(ViewState["IsNew"]))
            {
                measurementUnit.CreateBy = 1;
            }            

            measurementUnit.UpdateBy = 1;
            if (Convert.ToBoolean(ViewState["IsNew"]))
            {
                measurementUnit.CreateDate = DateTime.Now;
            }
            measurementUnit.UpdateDate = DateTime.Now;
            measurementUnit.IsRemoved = 0;
        }        

        protected void lvMeasurementUnit_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            if (e.Item.ItemType == ListViewItemType.DataItem)
            {
                ListViewDataItem currentItem = (ListViewDataItem)e.Item;
                MeasurementUnit measurementUnit = (MeasurementUnit)((ListViewDataItem)(e.Item)).DataItem;
                LinkButton lnkMeasurementUnit = (LinkButton)currentItem.FindControl("lnkMeasurementUnit");
                Label lblUnit = (Label)currentItem.FindControl("lblUnit");
                LinkButton lnkEdit = (LinkButton)currentItem.FindControl("lnkEdit");
                LinkButton lnkDelete = (LinkButton)currentItem.FindControl("lnkDelete");

                lnkMeasurementUnit.Text = measurementUnit.Name;
                lnkMeasurementUnit.CommandArgument = measurementUnit.IID.ToString();
                lnkMeasurementUnit.CommandName = "LoadMeasurementUnit";

                //lblUnit.Text = measurementUnit.Unit;
                lnkEdit.CommandName = "DoEdit";
                lnkEdit.CommandArgument = measurementUnit.IID.ToString();

                lnkDelete.CommandName = "DoDelete";
                lnkDelete.CommandArgument = measurementUnit.IID.ToString();
            }
        }

        protected void lvMeasurementUnit_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            if (e.CommandName == "DoDelete")
            {

                using (TheFacade _facade = new TheFacade())
                {
                    MeasurementUnit measurementUnit = new MeasurementUnit();

                    measurementUnit = _facade.InventoryGeneralFacade.GetMeasurementUnitByID(Convert.ToInt32(e.CommandArgument.ToString()));
                    CurrentMeasurementUnitID = measurementUnit.IID;
                    txtName.Text = measurementUnit.Name;
                    txtUnit.Text = measurementUnit.Unit;
                    IsNew = -1;
                }
            }

            else
            {

                using (TheFacade _facade = new TheFacade())
                {
                    MeasurementUnit measurementUnit = new MeasurementUnit();

                    measurementUnit = _facade.InventoryGeneralFacade.GetMeasurementUnitByID(Convert.ToInt32(e.CommandArgument.ToString()));
                    CurrentMeasurementUnitID = measurementUnit.IID;
                    txtName.Text = measurementUnit.Name;
                    txtUnit.Text = measurementUnit.Unit;
                    IsNew = 0;
                }
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            txtName.Text = string.Empty;
            txtUnit.Text = string.Empty;
            IsNew = 1;
        }

        protected void dpMeasurementUnit_PreRender(object sender, EventArgs e)
        {
            LoadMeasurementUnitListView();
        }
    }
}
