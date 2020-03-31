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

namespace OMS.WebClient.UIAsset
{
    public partial class AssetInfoCreate : System.Web.UI.Page
    {
        public long CurrentAssetInfoID
        {
            get
            {
                if (ViewState["AssetInfoID"] == null)
                {
                    return -1;
                }
                else
                {
                    return Convert.ToInt64(ViewState["AssetInfoID"]);
                }
            }
            set { ViewState["AssetInfoID"] = value; }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadAssetType();
                LoadListView();
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (CurrentAssetInfoID <= 0)
            {
                try
            {
                AssetInformation aAssetInformation = new AssetInformation();
                aAssetInformation = CreateAssetInformation(aAssetInformation);
                using (TheFacade facade = new TheFacade())
                {
                    facade.Insert<AssetInformation>(aAssetInformation);
                    Response.Redirect(Request.Url.ToString());
                }

            }
            catch
            {
                lblMsg.Text = "Data Not Saved...";
                lblMsg.Visible = true;
            }
            }
            try
            {
                using (TheFacade facade = new TheFacade())
                {
                    AssetInformation asset = facade.AssetFacade.GetAssetInformationByID(CurrentAssetInfoID);
                    asset = CreateAssetInformation(asset);
                    facade.Update<AssetInformation>(asset);
                }
                Session["IsSaved"] = true;
                Response.Redirect(Request.Url.ToString());
            }
            catch
            {
                lblMsg.Text = "Data not saved...";
                lblMsg.Visible = true;
            }
            ClearAll();

        }

        private AssetInformation CreateAssetInformation(AssetInformation aAssetInformation)
        {
            aAssetInformation.Name = txtName.Text.Trim();
            aAssetInformation.AssetTypeID = Convert.ToInt64(ddlAssetList.SelectedValue);
            
            aAssetInformation.Serial = txtSerial.Text.Trim();
            aAssetInformation.FARNo = txtFarNo.Text.Trim();
            aAssetInformation.Location = txtLocation.Text.Trim();
            aAssetInformation.Origin = txtOrigin.Text.Trim();
            aAssetInformation.PurchesYear = txtPurchaceYear.Text.Trim();
            aAssetInformation.UnitPrice = Convert.ToInt64(txtUnitPrice.Text.Trim());
            aAssetInformation.Qty = Convert.ToDecimal(txtQty.Text.Trim());
            if (aAssetInformation.IID <= 0)
            {
                aAssetInformation.CreateBy = 1;
                aAssetInformation.CreateDate = DateTime.Now;
            }
            aAssetInformation.UpdateBy = 1;
            aAssetInformation.UpdateDate = DateTime.Now;
            aAssetInformation.IsRemoved = 0;
            return aAssetInformation;
        }

        public void ClearAll()
        {
            txtName.Text = "";
            txtQty.Text = "";
            txtSerial.Text = "";
            txtFarNo.Text = "";
            txtLocation.Text = "";
            txtOrigin.Text = "";
            txtPurchaceYear.Text = "";
            txtUnitPrice.Text = "";
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            ClearAll();
        }

        private void LoadAssetType()
        {
            using (TheFacade facade = new TheFacade())
            {
                List<Asset_Type> assetList = facade.AssetFacade.GetAssetInfoAll();
                DDLHelper.Bind<Asset_Type>(ddlAssetList, assetList, "Name", "IID", EnumCollection.ListItemType.AssetType, true);
            }
        }


        int lvRowCount = 0;
        protected void ListViewAssetInfo_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            if (e.Item.ItemType == ListViewItemType.DataItem)
            {
                ListViewDataItem currentItem = (ListViewDataItem)e.Item;
                AssetInformation asset = (AssetInformation)((ListViewDataItem)(e.Item)).DataItem;
                LinkButton lblAssetTypeID = (LinkButton)currentItem.FindControl("lblAssetTypeID");
                Label lblName = (Label)currentItem.FindControl("lblName");
                Label lblSerialNo = (Label)currentItem.FindControl("lblSerial");
                Label lblQty = (Label)currentItem.FindControl("lblQty");
                Label lblFarNo = (Label)currentItem.FindControl("lblFarNo");
                Label lblLocation = (Label)currentItem.FindControl("lblLocation");
                Label lblOrigin = (Label)currentItem.FindControl("lblOrigin");
                Label lblPurchaceYear = (Label)currentItem.FindControl("lblPurchaceYear");
                Label lblUnitPrice = (Label)currentItem.FindControl("lblUnitPrice");
                LinkButton lnkEdit = (LinkButton)currentItem.FindControl("lnkEdit");
                LinkButton lnkDelete = (LinkButton)currentItem.FindControl("lnkDelete");

                //Serial Number
                lvRowCount += 1;
                Label lblSerial = (Label)currentItem.FindControl("lblSerial");
                lblSerial.Text = lvRowCount.ToString();

                //lblShortName.Text = asset.Name;
                //lblShortName.CommandArgument = asset.IID.ToString();
                //lblShortName.CommandName = "DoEdit";

                using (TheFacade facade=new TheFacade())
                {
                    if (asset.AssetTypeID.HasValue)
                    {

                        lblAssetTypeID.Text = facade.AssetFacade.GetAssetTypeByID(asset.AssetTypeID.Value).Name;
                        //lblAssetTypeID.Text = Convert.ToString(asset.AssetTypeID.Value).;
                    }
                    else
                    {
                        lblAssetTypeID.Text = "";
                    }

                }

             
                lblAssetTypeID.CommandArgument = asset.IID.ToString();
                lblAssetTypeID.CommandName = "DoEdit";


                lnkEdit.CommandName = "DoEdit";
                lnkEdit.CommandArgument = asset.IID.ToString();

                lnkDelete.CommandName = "DoDelete";
                lnkDelete.CommandArgument = asset.IID.ToString();
            }
        }

        protected void ListViewAssetInfo_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            if (e.CommandName == "DoDelete")
            {

                using (TheFacade _facade = new TheFacade())
                {
                    AssetInformation asset = new AssetInformation();
                    CurrentAssetInfoID = Convert.ToInt64(e.CommandArgument.ToString());
                    asset = _facade.AssetFacade.GetAssetInformationByID(Convert.ToInt64(e.CommandArgument.ToString()));
                    asset.IsRemoved = 1;
                    _facade.Update<AssetInformation>(asset);
                    Response.Redirect(Request.Url.ToString());
                }
            }

            else if (e.CommandName == "DoEdit")
            {
                using (TheFacade _facade = new TheFacade())
                {

                    AssetInformation asset = new AssetInformation();
                    CurrentAssetInfoID = Convert.ToInt64(e.CommandArgument.ToString());
                    asset = _facade.AssetFacade.GetAssetInformationByID(Convert.ToInt64(e.CommandArgument.ToString()));
                    LoadAssetType(asset);
                }
            }
        }

        private void LoadListView()
        {
            using (TheFacade facade = new TheFacade())
            {
                ListViewAssetInfo.DataSource = facade.AssetFacade.GetAllAssetInformation();
                ListViewAssetInfo.DataBind();
            }
        }

        private void LoadAssetType(AssetInformation asset)
        {
            
            ddlAssetList.SelectedValue =Convert.ToInt64( asset.AssetTypeID).ToString();
            txtFarNo.Text = asset.FARNo;
            txtLocation.Text = asset.Location;
            txtOrigin.Text = asset.Origin;
            txtPurchaceYear.Text = asset.PurchesYear;
            txtQty.Text = asset.Qty.ToString();
            txtSerial.Text = asset.Serial;
            txtUnitPrice.Text = asset.UnitPrice.ToString();
            txtName.Text = asset.Name;
        }

        int CurrentPage = 0;
        protected void dpList_PreRender(object sender, EventArgs e)
        {
            lvRowCount = CurrentPage * 20;
            if (IsPostBack)
                LoadListView();
        }

        protected void ListViewAssetInfo_PagePropertiesChanging(object sender, PagePropertiesChangingEventArgs e)
        {
            CurrentPage = (e.StartRowIndex / e.MaximumRows) + 0;
        }
    }
}