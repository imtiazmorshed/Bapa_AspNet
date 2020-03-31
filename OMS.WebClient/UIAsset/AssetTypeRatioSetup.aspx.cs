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
    public partial class AssetTypeRatioSetup : System.Web.UI.Page
    {
        public long CreateAssetDepriciationRatioID
        {
            get
            {
                if (ViewState["AssetDepriciationRatioID"] == null)
                {
                    return -1;
                }
                else
                {
                    return Convert.ToInt64(ViewState["AssetDepriciationRatioID"]);
                }
            }
            set { ViewState["AssetDepriciationRatioID"] = value; }
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
            if (CreateAssetDepriciationRatioID <= 0)
            {
                try
                {
                    AssetDepriciationRatio aAssetDepriciationRatio = new AssetDepriciationRatio();
                    aAssetDepriciationRatio = CreateAssetDepriciationRatio(aAssetDepriciationRatio);
                    using (TheFacade facade = new TheFacade())
                    {
                        facade.Insert<AssetDepriciationRatio>(aAssetDepriciationRatio);
                    }
                    lblMsg.Text = "Data Saved Successfully...";
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
                    AssetDepriciationRatio aAssetDepriciationRatio = new AssetDepriciationRatio();
                    aAssetDepriciationRatio = CreateAssetDepriciationRatio(aAssetDepriciationRatio);
                    facade.Update<AssetDepriciationRatio>(aAssetDepriciationRatio);
                }
                Session["IsSaved"] = true;
                Response.Redirect(Request.Url.ToString());
            }
            catch
            {
                lblMsg.Text = "Data not saved...";
                lblMsg.Visible = true;
            }
            txtRatio.Text = "";
        }
        private AssetDepriciationRatio CreateAssetDepriciationRatio(AssetDepriciationRatio aAssetDepriciationRatio)
        {
            aAssetDepriciationRatio.AssettypeID = Convert.ToInt64(ddlAssetList.SelectedValue);
            aAssetDepriciationRatio.AssetYear = ddlYear.SelectedValue;
            aAssetDepriciationRatio.Ratio = Convert.ToDecimal(txtRatio.Text.Trim().ToString());
            if (aAssetDepriciationRatio.IID <= 0)
            {
                aAssetDepriciationRatio.CreateBy = 1;
                aAssetDepriciationRatio.CreateDate = DateTime.Now;
            }
            aAssetDepriciationRatio.UpdateBy = 1;
            aAssetDepriciationRatio.UpdateDate = DateTime.Now;
            aAssetDepriciationRatio.IsRemoved = 0;
            return aAssetDepriciationRatio;
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

        protected void ListViewAssetTypeRatio_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            if (e.CommandName == "DoDelete")
            {

                using (TheFacade _facade = new TheFacade())
                {
                    AssetDepriciationRatio asset = new AssetDepriciationRatio();
                    CreateAssetDepriciationRatioID = Convert.ToInt64(e.CommandArgument.ToString());
                    asset = _facade.AssetFacade.GetAssetDepriciationRatioById(Convert.ToInt64(e.CommandArgument.ToString()));
                    asset.IsRemoved = 1;
                    _facade.Update<AssetDepriciationRatio>(asset);
                    Response.Redirect(Request.Url.ToString());
                }
            }

            else if (e.CommandName == "DoEdit")
            {
                using (TheFacade _facade = new TheFacade())
                {

                    AssetDepriciationRatio asset = new AssetDepriciationRatio();
                    CreateAssetDepriciationRatioID = Convert.ToInt64(e.CommandArgument.ToString());
                    asset = _facade.AssetFacade.GetAssetDepriciationRatioById(Convert.ToInt64(e.CommandArgument.ToString()));
                    LoadAssetType(asset);
                }
            }
        }

        protected void ListViewAssetTypeRatio_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            if (e.Item.ItemType == ListViewItemType.DataItem)
            {
                ListViewDataItem currentItem = (ListViewDataItem)e.Item;
                AssetDepriciationRatio asset = (AssetDepriciationRatio)((ListViewDataItem)(e.Item)).DataItem;
                LinkButton lblAssetTypeID = (LinkButton)currentItem.FindControl("lblAssetTypeID");
                Label lblRatio = (Label)currentItem.FindControl("lblRatio");
                Label lblyear = (Label)currentItem.FindControl("lblyear");
                LinkButton lnkEdit = (LinkButton)currentItem.FindControl("lnkEdit");
                LinkButton lnkDelete = (LinkButton)currentItem.FindControl("lnkDelete");

                //Serial Number
                lvRowCount += 1;
                Label lblSerial = (Label)currentItem.FindControl("lblSerial");
                lblSerial.Text = lvRowCount.ToString();

                //lblShortName.Text = asset.Name;
                //lblShortName.CommandArgument = asset.IID.ToString();
                //lblShortName.CommandName = "DoEdit";

                using (TheFacade facade = new TheFacade())
                {
                    if (asset.AssettypeID.HasValue)
                    {

                        lblAssetTypeID.Text = facade.AssetFacade.GetAssetTypeByID(asset.AssettypeID.Value).Name;
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

        private void LoadListView()
        {
            using (TheFacade facade = new TheFacade())
            {
                ListViewAssetTypeRatio.DataSource = facade.AssetFacade.GetAllAssetDepriciationRatio();
                ListViewAssetTypeRatio.DataBind();
            }
        }

        private void LoadAssetType(AssetDepriciationRatio asset)
        {

            ddlAssetList.SelectedValue = Convert.ToInt64(asset.AssettypeID).ToString();
            txtRatio.Text = asset.Ratio.ToString();
            ddlYear.SelectedValue = asset.AssetYear;


        }

        int CurrentPage = 0;
        protected void dpList_PreRender(object sender, EventArgs e)
        {
            lvRowCount = CurrentPage * 20;
            if (IsPostBack)
                LoadListView();
        }

        protected void ListViewAssetTypeRatio_PagePropertiesChanging(object sender, PagePropertiesChangingEventArgs e)
        {
            CurrentPage = (e.StartRowIndex / e.MaximumRows) + 0;
        }
    }
}