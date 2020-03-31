
using System;
using OMS.Facade;
using OMS.DAL;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Collections.Generic;
using OMS.Framework;

namespace OMS.WebClient.UIAsset
{
    public partial class AssetType : System.Web.UI.Page
    {
        public long CurrentAssetTypeID
        {
            get
            {
                if (ViewState["AssetTypeID"] == null)
                {
                    return -1;
                }
                else
                {
                    return Convert.ToInt64(ViewState["AssetTypeID"]);
                }
            }
            set { ViewState["AssetTypeID"] = value; }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //Asset_Type aAssetType = new Asset_Type();
                //using(TheFacade facade = new TheFacade())
                //{
                //    //facade.CommonFacade.GetAllAssetType
                //}
                LoadListView();
            }
        }
        private void LoadListView()
        {
            using (TheFacade facade = new TheFacade())
            {
                ListViewAssetType.DataSource = facade.AssetFacade.GetAllAssetType();
                ListViewAssetType.DataBind();
            }
        }              
        protected void btnAssetSave_Click(object sender, EventArgs e)
        {
            if (CurrentAssetTypeID <= 0)
            {
                bool hasExist = false;
                using (TheFacade facade = new TheFacade())
                {
                    hasExist = facade.AssetFacade.IsAssetNameAlreadyExist(txyAssetName.Text.Trim());

                }
                if (hasExist)
                {
                    //lebale red color
                    return;
                }
            
                
                try
                {

                    Asset_Type aAssetType = new Asset_Type();
                    aAssetType = CreateAsset(aAssetType);
                    using (TheFacade facade = new TheFacade())
                    {
                        facade.Insert<Asset_Type>(aAssetType);
                        //SaveAutoID();
                        if (ConfigurationManager.AppSettings["IsLinkedWithAccount"] != null)
                        {
                            if (Convert.ToInt32(ConfigurationManager.AppSettings["IsLinkedWithAccount"].ToString()) == 1)
                            {
                                Acc_ChartOfAccount chartofAcc = facade.AccountsFacade.GetAcc_ChartOfAccountByName("Fixed Asset");

                                #region acc
                                Acc_ChartOfAccount newAccount = new Acc_ChartOfAccount();
                                newAccount.AccountNo = GenerateAccountNo(chartofAcc.Gparent.ToString());
                                newAccount.Name = aAssetType.Name;//supplier.Name;
                                newAccount.IsActive = 1;

                                newAccount.AccountTypeID = Convert.ToInt32(EnumCollection.AccountType.Transactable);
                                newAccount.ParentID = chartofAcc.IID;
                                newAccount.Gparent = chartofAcc.Gparent;
                                newAccount.CreateBy = Convert.ToInt64(Session["uid"]);
                                newAccount.UpdateBy = Convert.ToInt64(Session["uid"]);
                                newAccount.CreateDate = DateTime.Now;
                                newAccount.UpdateDate = DateTime.Now;
                                newAccount.IsRemoved = 0;
                                facade.Insert<Acc_ChartOfAccount>(newAccount);

                                #endregion


                                //Acc_ChartOfAccountSupplier supplierAccount = new Acc_ChartOfAccountSupplier();
                                //supplierAccount.ChartOfAccountID = newAccount.IID;
                                //supplierAccount.SupplierID = aAssetType.IID;
                                ////supplierAccount.SupplierID = supplier.IID;
                                //supplierAccount.UpdateDate = DateTime.Now;
                                //supplierAccount.UpdateBy = Convert.ToInt64(Session["UserID"]);


                                //supplierAccount.CreateDate = DateTime.Now;
                                //supplierAccount.CreateBy = Convert.ToInt64(Session["UserID"]);

                                //supplierAccount.IsRemoved = 0;
                                //facade.Insert<Acc_ChartOfAccountSupplier>(supplierAccount);
                            }
                        }
                        

                    }
                }
                catch
                {
                    lblMessage.Text = "Data Not Saved....";
                    lblMessage.Visible = true;
                    return;
                }
                Response.Redirect(Request.Url.ToString());
            }
            try
            {
                using (TheFacade facade = new TheFacade())
                {
                    Asset_Type asset = facade.AssetFacade.GetAssetTypeByID(CurrentAssetTypeID);
                    asset = CreateAsset(asset);
                    facade.Update<Asset_Type>(asset);
                }
                Session["IsSaved"] = true;
                Response.Redirect(Request.Url.ToString());
            }
            catch
            {
                lblMessage.Text = "Data not saved...";
                lblMessage.Visible = true;
            }
        }

        private Asset_Type CreateAsset(Asset_Type aAssetType)
        {
            aAssetType.Name = txyAssetName.Text.Trim();
            if (aAssetType.IID <= 0)
            {
                aAssetType.Code = Helpers.CommonHelper.GenerateAssetCode();
                aAssetType.CreateBy = 1;
                aAssetType.CreateDate = DateTime.Now;
            }
            aAssetType.UpdateBy = 1;
            aAssetType.UpdateDate = DateTime.Now;
            aAssetType.IsRemoved = 0;
            return aAssetType;
        }
        private void ClearAll()
        {
            txyAssetName.Text = "";
        }
        int lvRowCount = 0;
        protected void btnAsserCancel_Click(object sender, EventArgs e)
        {
            ClearAll();
        }        
        protected void ListViewAssetType_ItemDataBound(object sender, System.Web.UI.WebControls.ListViewItemEventArgs e)
        {
            if (e.Item.ItemType == ListViewItemType.DataItem)
            {
                ListViewDataItem currentItem = (ListViewDataItem)e.Item;
                Asset_Type asset = (Asset_Type)((ListViewDataItem)(e.Item)).DataItem;
                LinkButton lblShortName = (LinkButton)currentItem.FindControl("lblShortName");
                Label lblCode = (Label)currentItem.FindControl("lblCode");
                LinkButton lnkEdit = (LinkButton)currentItem.FindControl("lnkEdit");
                LinkButton lnkDelete = (LinkButton)currentItem.FindControl("lnkDelete");

                //Serial Number
                lvRowCount += 1;
                Label lblSerial = (Label)currentItem.FindControl("lblSerial");
                lblSerial.Text = lvRowCount.ToString();

                lblShortName.Text = asset.Name;
                lblShortName.CommandArgument = asset.IID.ToString();
                lblShortName.CommandName = "DoEdit";
                

                lnkEdit.CommandName = "DoEdit";
                lnkEdit.CommandArgument = asset.IID.ToString();

                lnkDelete.CommandName = "DoDelete";
                lnkDelete.CommandArgument = asset.IID.ToString();
            }
        }
        private void LoadAssetType(Asset_Type asset)
        {
            txyAssetName.Text = asset.Name;
            txtCode.Text = asset.Code;
        }
        protected void ListViewAssetType_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            if (e.CommandName == "DoDelete")
            {

                using (TheFacade _facade = new TheFacade())
                {
                    Asset_Type asset = new Asset_Type();
                    CurrentAssetTypeID = Convert.ToInt64(e.CommandArgument.ToString());
                    asset = _facade.AssetFacade.GetAssetTypeByID(Convert.ToInt64(e.CommandArgument.ToString()));
                    asset.IsRemoved = 1;
                    _facade.Update<Asset_Type>(asset);
                    Response.Redirect(Request.Url.ToString());
                }
            }

            else if (e.CommandName == "DoEdit")
            {
                using (TheFacade _facade = new TheFacade())
                {

                    Asset_Type asset = new Asset_Type();
                    CurrentAssetTypeID = Convert.ToInt64(e.CommandArgument.ToString());
                    asset = _facade.AssetFacade.GetAssetTypeByID(Convert.ToInt64(e.CommandArgument.ToString()));
                    LoadAssetType(asset);
                }
            }
        }
        int CurrentPage = 0;
        protected void dpList_PreRender(object sender, EventArgs e)
        {
            lvRowCount = CurrentPage * 20;
            if (IsPostBack)
                LoadListView();
        }
        protected void ListViewAssetType_PagePropertiesChanging(object sender, PagePropertiesChangingEventArgs e)
        {
            CurrentPage = (e.StartRowIndex / e.MaximumRows) + 0;
        }

        #region new logic
        private string GenerateAccountNo(string gParent)
        {
            string code = "";

            code = gParent;
            int count = 0;
            using (TheFacade facade = new TheFacade())
            {
                List<Acc_ChartOfAccount> acclistAnother = facade.AccountsFacade.GetAcc_ChartOfAccountListByGParetntID(Convert.ToInt32(gParent)); //.OrderBy(a => a.IID).ToList();
                count = acclistAnother.Count + 1;
                code = code + count.ToString().PadLeft(5, '0');
            }
            return code;
        }
        #endregion

        private void SaveAutoID()
        {
            TheFacade facade = new TheFacade();
            Asset_Type aAssetType = new Asset_Type();
            if (ConfigurationManager.AppSettings["IsLinkedWithAccount"] != null)
            {
                if (Convert.ToInt32(ConfigurationManager.AppSettings["IsLinkedWithAccount"].ToString()) == 1)
                {
                    Acc_ChartOfAccount chartofAcc = facade.AccountsFacade.GetAcc_ChartOfAccountByName("Fixed Asset");

                    #region acc
                    Acc_ChartOfAccount newAccount = new Acc_ChartOfAccount();
                    newAccount.AccountNo = GenerateAccountNo(chartofAcc.Gparent.ToString());
                    newAccount.Name = aAssetType.Name;//supplier.Name;
                    newAccount.IsActive = 1;

                    newAccount.AccountTypeID = Convert.ToInt32(EnumCollection.AccountType.Transactable);
                    newAccount.ParentID = chartofAcc.IID;
                    newAccount.Gparent = chartofAcc.Gparent;

                    newAccount.CreateBy = Convert.ToInt64(Session["uid"]);

                    newAccount.UpdateBy = Convert.ToInt64(Session["uid"]);


                    newAccount.CreateDate = DateTime.Now;

                    newAccount.UpdateDate = DateTime.Now;
                    newAccount.IsRemoved = 0;
                    facade.Insert<Acc_ChartOfAccount>(newAccount);

                    #endregion


                    Acc_ChartOfAccountSupplier supplierAccount = new Acc_ChartOfAccountSupplier();
                    supplierAccount.ChartOfAccountID = newAccount.IID;
                    supplierAccount.SupplierID = aAssetType.IID;
                    //supplierAccount.SupplierID = supplier.IID;
                    supplierAccount.UpdateDate = DateTime.Now;
                    supplierAccount.UpdateBy = Convert.ToInt64(Session["UserID"]);


                    supplierAccount.CreateDate = DateTime.Now;
                    supplierAccount.CreateBy = Convert.ToInt64(Session["UserID"]);

                    supplierAccount.IsRemoved = 0;
                    facade.Insert<Acc_ChartOfAccountSupplier>(supplierAccount);
                }
            }
        }

        protected void txyAssetName_TextChanged(object sender, EventArgs e)
        {

            bool hasExist = false;

           
            using (TheFacade facade = new TheFacade())
            {
                hasExist = facade.AssetFacade.IsAssetNameAlreadyExist(txyAssetName.Text.Trim());
                
            }
            if (hasExist)
            {
                lblMessage.Text = "This name is Already inserted !!!";
                btnAssetSave.Enabled = false;
            }
            else
            {
                lblMessage.Text = string.Empty;
                btnAssetSave.Enabled = true;
            }            
        }
    }
}
