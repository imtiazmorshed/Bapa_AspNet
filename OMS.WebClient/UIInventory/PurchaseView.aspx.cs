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
using OMS.Framework;

namespace OMS.WebClient.UIInventory
{
    public partial class PurchaseView : System.Web.UI.Page
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

        public long CurrentStockMasterID
        {
            get
            {
                if (ViewState["CurrentStockMasterID"] == null)
                {
                    return -1;
                }
                else
                {
                    return Convert.ToInt64(ViewState["CurrentStockMasterID"]);
                }
            }
            set { ViewState["CurrentStockMasterID"] = value; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadSupplier();
                LoadItem();
                LoadPurchaseListView();
            }
        }

        private void LoadPurchaseListView()
        {
            List<StockMaster> stockMasterList = new List<StockMaster>();
            using (TheFacade _facade = new TheFacade())
            {
                stockMasterList = _facade.StockFacade.GetStockMasterListByTransactionPrefix("PU");
                if (stockMasterList.Count > 0)
                {
                    lvPurchaseDetail.DataSource = stockMasterList;
                    lvPurchaseDetail.DataBind();
                }
            }
        }

        private void LoadItem()
        {
            List<Item> itemList = new List<Item>();

            using (TheFacade _facade = new TheFacade())
            {
                itemList = _facade.ItemFacade.GetItemAll();
            }
            DDLHelper.Bind<Item>(ddlItem, itemList, "Name", "IID", EnumCollection.ListItemType.ItemName);
        }

        private void LoadSupplier()
        {
            List<Supplier> supplierList = new List<Supplier>();

            using (TheFacade _facade = new TheFacade())
            {
                supplierList = _facade.SupplierFacade.GetSupplierAll();
            }
            DDLHelper.Bind<Supplier>(ddlSupplier, supplierList, "Name", "IID", EnumCollection.ListItemType.SupplierName);
        }

        protected void btnAddItem_Click(object sender, EventArgs e)
        {
            List<StockDetail> stockDetailList = GetExistingStockDetailList();
            StockDetail stockDetail = new StockDetail();
            stockDetail.ItemID = Convert.ToInt64(ddlItem.SelectedValue);
            Item item = new Item();
            using (TheFacade _facade = new TheFacade())
            {
                item = _facade.ItemFacade.GetItemByID(Convert.ToInt64(ddlItem.SelectedValue));
            }
            stockDetail.Item = item;
            stockDetail.Quantity = Convert.ToDecimal(txtQuantity.Text);
            stockDetail.CostPrice = Convert.ToDecimal(txtCostPrice.Text);
            stockDetail.SellPrice = Convert.ToDecimal(txtSellPrice.Text);
            stockDetailList.Add(stockDetail);
            BindItemList(stockDetailList);
        }

        private void BindItemList(List<StockDetail> stockDetailList)
        {
            lvItem.DataSource = stockDetailList;
            lvItem.DataBind();
        }

        private List<StockDetail> GetExistingStockDetailList()
        {
            List<StockDetail> stockDetailList = new List<StockDetail>();
            foreach (ListViewDataItem item in lvItem.Items)
            {
                
                Label lblItemID = (Label)item.FindControl("lblItemID");
                Label lblItemName = (Label)item.FindControl("lblItemName");
                Label lblItemCode = (Label)item.FindControl("lblItemCode");
                Label lblCostPrice = (Label)item.FindControl("lblCostPrice");
                Label lblSellPrice = (Label)item.FindControl("lblSellPrice");
                Label lblQuantity = (Label)item.FindControl("lblQuantity");

                StockDetail stockDetail = new StockDetail();
                stockDetail.BatchNo = "1";
                stockDetail.ItemID = Convert.ToInt64(lblItemID.Text);
                

                Item itemP = new Item();
                using (TheFacade _facade = new TheFacade())
                {
                    itemP = _facade.ItemFacade.GetItemByID(stockDetail.ItemID);
                }
                stockDetail.Item = itemP;
                stockDetail.CostPrice = Convert.ToDecimal(lblCostPrice.Text);
                
                stockDetail.SellPrice = Convert.ToDecimal(lblSellPrice.Text);
                stockDetail.Quantity = Convert.ToDecimal(lblQuantity.Text);
                stockDetail.Discount = 0;
                stockDetail.VAT = 0;
                stockDetail.ExpiryDate = DateTime.Now;
                stockDetail.CreateDate = DateTime.Now;
                stockDetail.UpdateDate = DateTime.Now;
                stockDetail.CreateBy = 1;
                stockDetail.UpdateBy = 1;
                stockDetail.IsRemoved = 0;
                stockDetailList.Add(stockDetail);
            }
            return stockDetailList;
        }

        protected void lvItem_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            if (e.Item.ItemType == ListViewItemType.DataItem)
            {
                ListViewDataItem item = (ListViewDataItem)e.Item;
                StockDetail stockDetail = (StockDetail)((ListViewDataItem)(e.Item)).DataItem;
                Label lblItemID = (Label)item.FindControl("lblItemID");
                Label lblItemName = (Label)item.FindControl("lblItemName");
                Label lblItemCode = (Label)item.FindControl("lblItemCode");
                Label lblCostPrice = (Label)item.FindControl("lblCostPrice");
                Label lblSellPrice = (Label)item.FindControl("lblSellPrice");
                Label lblQuantity = (Label)item.FindControl("lblQuantity");
                lblItemID.Text = stockDetail.ItemID.ToString();
                lblItemName.Text = stockDetail.Item.Name;
                lblItemCode.Text = stockDetail.Item.Code;
                lblCostPrice.Text = stockDetail.CostPrice.ToString();
                lblSellPrice.Text = stockDetail.SellPrice.ToString();
                lblQuantity.Text = stockDetail.Quantity.ToString();
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            StockMaster stockMaster = new StockMaster();
            List<StockMaster> stockMasterList = new List<StockMaster>();
            List<StockDetail> stockDetailList = GetExistingStockDetailListUpdate();


            if (stockDetailList.Count == 0)
                return;
            if (CurrentStockMasterID == -1)
            {
                
                LoadStockMaster(stockMaster, stockDetailList);
                using (TheFacade _facade = new TheFacade())
                {
                    stockMasterList = _facade.StockFacade.GetStockMasterListByTransactionPrefix("PU");
                    StockMaster stockMasterForBatch = new StockMaster();
                    stockMasterForBatch = stockMasterList.LastOrDefault();
                    _facade.Insert<StockMaster>(stockMaster);

                    if (stockMaster.IID > 0)
                    {
                        List<StockDetail> stockDetailListForBatch = _facade.StockFacade.GetStockDetailAll();
                        StockDetail stockDetailForBatch = new StockDetail();
                        if (stockMasterForBatch != null)
                        {
                            stockDetailForBatch = _facade.StockFacade.GetStockDetailListByStockMatserID(stockMasterForBatch.IID).LastOrDefault();
                        }
                        string batchNo = string.Empty;
                        long startNo = 0;
                        int startNoLength = 0;
                        if (stockDetailForBatch.IID == 0)
                        {
                            //batchNo = "000000001";
                            //startNo = Convert.ToInt64(batchNo.Substring(1));
                            startNo = 0;
                            startNoLength = startNo.ToString().Length;
                            //batchNo = "A" + startNoLength.ToString().PadLeft((10 - startNoLength), '0');
                        }
                        else
                        {
                            batchNo = stockDetailForBatch.BatchNo.Substring(1);
                            startNo = Convert.ToInt64(batchNo.Substring(1));
                            startNoLength = startNo.ToString().Length;
                            //batchNo = "A" + startNo.ToString().PadLeft((10 - startNoLength), '0');
                        }                       

                        
                        
                        foreach (StockDetail stockDetail in stockDetailList)
                        {
                            batchNo = "";
                            startNo += 1;
                            batchNo = "A" + startNo.ToString().PadLeft((10 - startNoLength), '0');

                            stockDetail.StockMasterID = stockMaster.IID;
                            stockDetail.BatchNo = batchNo;
                            StockDetail stockDetailNew = new StockDetail();
                            stockDetailNew = stockDetail;
                            _facade.Insert<StockDetail>(stockDetailNew);
                        }
                    }
                }
            }
            else
            {
                //using (TheFacade _facade = new TheFacade())
                //{
                //    stockMaster = _facade.StockFacade.GetStockMasterByID(CurrentStockMasterID);
                //    LoadStockMaster(stockMaster,stockDetailList);
                //    _facade.Update<StockMaster>(stockMaster);
                //}
            }
            Response.Redirect("~/UIInventory/PurchaseView.aspx");
            
        }

        private List<StockDetail> GetExistingStockDetailListUpdate()
        {
            List<StockDetail> stockDetailList = new List<StockDetail>();
            foreach (ListViewDataItem item in lvItem.Items)
            {

                Label lblItemID = (Label)item.FindControl("lblItemID");
                Label lblItemName = (Label)item.FindControl("lblItemName");
                Label lblItemCode = (Label)item.FindControl("lblItemCode");
                Label lblCostPrice = (Label)item.FindControl("lblCostPrice");
                Label lblSellPrice = (Label)item.FindControl("lblSellPrice");
                Label lblQuantity = (Label)item.FindControl("lblQuantity");

                StockDetail stockDetail = new StockDetail();
                stockDetail.BatchNo = "1";
                stockDetail.ItemID = Convert.ToInt64(lblItemID.Text);
                stockDetail.Quantity = Convert.ToDecimal(lblQuantity.Text);
                stockDetail.CostPrice = Convert.ToDecimal(lblCostPrice.Text);
                stockDetail.SellPrice = Convert.ToDecimal(lblSellPrice.Text);
                stockDetail.Discount = 0;
                stockDetail.VAT = 0;
                stockDetail.ExpiryDate = DateTime.Now;
                stockDetail.CreateDate = DateTime.Now;
                stockDetail.UpdateDate = DateTime.Now;
                stockDetail.CreateBy = 1;
                stockDetail.UpdateBy = 1;
                stockDetail.IsRemoved = 0;
                stockDetailList.Add(stockDetail);
            }
            return stockDetailList;
        }

        private void LoadStockMaster(StockMaster stockMaster,List<StockDetail> stockDetailList)
        {
            stockMaster.StockTransactionTypeID = Convert.ToInt32(EnumCollection.StockTransactionType.Purchase);
            stockMaster.ReferenceTypeID = Convert.ToInt32(EnumCollection.ReferenceType.Supplier);
            stockMaster.ReferenceID = Convert.ToInt64(ddlSupplier.SelectedValue);
            stockMaster.PurchaseOrSaleBy = 1; //EmployeeID
            stockMaster.Date = DateTime.Now;
            stockMaster.TransactionNo = getLastOrderNumber();
            stockMaster.BillNo = txtBillNo.Text;
            stockMaster.TotalDiscount = 0;
            stockMaster.SpecialDiscount = 0;
            stockMaster.TotalVAT = 0;

            Decimal totalAmount = 0;
            foreach (StockDetail stockDetail in stockDetailList)
            {
                totalAmount += stockDetail.Quantity * stockDetail.CostPrice;
            }

            stockMaster.TotalAmount = totalAmount;
            stockMaster.TotalPaidAmount = 0;
            stockMaster.TotalDueAmount = 0;
            stockMaster.Hold = false;
            stockMaster.StoreID = 1;
            stockMaster.FinancialYearID = 1;


            if (Convert.ToBoolean(ViewState["IsNew"]))
            {
                stockMaster.CreateDate = DateTime.Now;
            }
            else
            {
                stockMaster.CreateDate = DateTime.Now;
            }

            stockMaster.UpdateDate = DateTime.Now;

            if (Convert.ToBoolean(ViewState["IsNew"]))
            {
                stockMaster.CreateBy = 1;
            }
            else
            {
                stockMaster.CreateBy = 1;
            }
            
            stockMaster.UpdateBy = 1;
            stockMaster.IsRemoved = 0;
            
        }

        private string getLastOrderNumber()
        {
            string newCode = "PU";

            //Last Order
            List<StockMaster> stockMasterList = new List<StockMaster>();
            using (TheFacade _facade = new TheFacade())
            {
                stockMasterList = _facade.StockFacade.GetStockMasterAll();
            }
            DateTime startDate = Convert.ToDateTime(DateTime.Now.ToShortDateString() + " 12:00:00 AM");
            DateTime endDate = Convert.ToDateTime(DateTime.Now.ToShortDateString() + " 11:59:59 PM");
            stockMasterList = stockMasterList.Where(s => (s.Date >= startDate && s.Date <= endDate) && (s.TransactionNo.StartsWith("PU"))).ToList();

            int count = stockMasterList.Count;
            int lastnumber = 0;



            //SqlDataAdapter dbAdapterOrder = new SqlDataAdapter("SELECT * FROM [Order] Where Date >='" + DateTime.Now.ToShortDateString() + " 12:00:00 AM' and Date<= '" + DateTime.Now.ToShortDateString() + " 11:59:59 PM'", conn);
            //DataSet dbDatasetOrder = new DataSet();
            //dbAdapterOrder.Fill(dbDatasetOrder, "Order");
            //DataTable dbTableOrder = dbDatasetOrder.Tables[0];

            //DataRow[] drOrder = dbTableOrder.Select(null, "OrderNo");


            //DataRow drrr = drOrder.LastOrDefault<DataRow>();

            //


            //dsTransaction.TransactionMaster.Clear();
            //string _where = " where TransactionDate >= '" + dtpTransactionDate.DateTime.Date.ToShortDateString() + " 12:00:00 AM' and TransactionDate<= '" + dtpTransactionDate.DateTime.ToShortDateString() + " 11:59:59 PM' AND JournalCode Like '" + newCode + "%'";
            //dsTransaction.TransactionMaster.Merge(DataHelper.GetTableData(dsTransaction.TransactionMaster, _where).Tables[0]);
            //DataRow[] drTransaction = dsTransaction.TransactionMaster.Select(null, "JournalCode");
            //int count = drTransaction.Length;
            //int count = drOrder.Length;
            //int lastnumber = 0;
            if (count != 0)
            {
                string TrLastCode = stockMasterList.LastOrDefault().TransactionNo;
                lastnumber = int.Parse(TrLastCode.Substring(8));
            }
            newCode += DateTime.Now.Year.ToString().Substring(2);
            if (DateTime.Now.Month < 10)
            {
                newCode += "0" + DateTime.Now.Month.ToString();
            }
            else
                newCode += DateTime.Now.Month.ToString();
            if (DateTime.Now.Day < 10)
            {
                newCode += "0" + DateTime.Now.Day.ToString();
            }
            else
                newCode += DateTime.Now.Day.ToString();

            if (lastnumber == 9999 || count == 0)
                newCode += "9001";
            else
                newCode += (lastnumber + 1).ToString();
            //JCode = newCode;
            return newCode;
        }

        protected void btnClose_Click(object sender, EventArgs e)
        {
            ddlSupplier.SelectedIndex = -1;
            txtBillNo.Text = string.Empty;
            txtDate.Text = string.Empty;
            CurrentStockMasterID = -1;
        }

        protected void lvPurchaseDetail_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            if (e.Item.ItemType == ListViewItemType.DataItem)
            {
                ListViewDataItem item = (ListViewDataItem)e.Item;

                Label lblDate = (Label)item.FindControl("lblDate");
                LinkButton lnkbtnTransactionNo = (LinkButton)item.FindControl("lnkbtnTransactionNo");
                Label lblSupplierName = (Label)item.FindControl("lblSupplierName");
                Label lblTotalPrice = (Label)item.FindControl("lblTotalPrice");

                StockMaster stockMaster = (StockMaster)((ListViewDataItem)(e.Item)).DataItem;

                lblDate.Text = stockMaster.Date.ToShortDateString();

                lnkbtnTransactionNo.Text = stockMaster.TransactionNo;
                lnkbtnTransactionNo.CommandArgument = stockMaster.IID.ToString();
                lnkbtnTransactionNo.CommandName = "DoEdit";
                
                lblSupplierName.Text = stockMaster.Supplier.Name;
                lblTotalPrice.Text = stockMaster.TotalAmount.ToString();
            }
        }

        protected void lvPurchaseDetail_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            if (e.CommandName == "DoDelete")
            {

                using (TheFacade _facade = new TheFacade())
                {
                    //Item item = new Item();

                    //item = _facade.ItemFacade.GetItemByID(Convert.ToInt64(e.CommandArgument.ToString()));
                    //CurrentItemID = item.IID;
                    //txtName.Text = item.Name;
                    //txtCode.Text = item.Code;
                    //ddlMeasurementUnit.SelectedValue = item.MeasurementUnitID.ToString();
                    IsNew = -1;
                }
            }

            else
            {

                using (TheFacade _facade = new TheFacade())
                {
                    StockMaster stockMaster = new StockMaster();

                    stockMaster = _facade.StockFacade.GetStockMasterByID(Convert.ToInt64(e.CommandArgument.ToString()));
                    CurrentStockMasterID = stockMaster.IID;
                    
                    ddlSupplier.SelectedValue =  stockMaster.Supplier.IID.ToString();
                    txtBillNo.Text = stockMaster.BillNo;
                    txtDate.Text = stockMaster.Date.ToShortDateString();
                    //Load Item 
                    List<StockDetail> stockDetailList = _facade.StockFacade.GetStockDetailListByStockMatserID(stockMaster.IID);
                    lvItem.DataSource = stockDetailList;
                    lvItem.DataBind();

                    IsNew = 0;
                }
            }
        }

        protected void dpPurchaseDetail_PreRender(object sender, EventArgs e)
        {
            LoadPurchaseListView();
        }
    }
}
