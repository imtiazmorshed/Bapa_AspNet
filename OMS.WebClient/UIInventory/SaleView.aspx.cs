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
    public partial class SaleView : System.Web.UI.Page
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

        public Item CurrentItem
        {
            get
            {
                if (ViewState["Item"] == null)
                {
                    return null;
                }
                else
                {
                    return (Item)ViewState["Item"];
                }
            }
            set { ViewState["Item"] = value; }
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
                LoadCustomer();
                LoadItemBatchNo();
                LoadSaleListView();
                LoadItemCode();
                LoadItemName();
                LoadSalesPerson();
            }
        }

        private void LoadSalesPerson()
        {
            List<HRM_Employee> employeeList = new List<HRM_Employee>();

            using (TheFacade _facade = new TheFacade())
            {
                employeeList = _facade.EmployeeFacade.GetEmployeeAll();
            }
            DDLHelper.Bind<HRM_Employee>(ddlSalesPerson, employeeList, "DisplayName", "IID", EnumCollection.ListItemType.EmployeeName); 
        }

        private void LoadItemName()
        {
            List<Item> itemList = new List<Item>();

            using (TheFacade _facade = new TheFacade())
            {
                itemList = _facade.ItemFacade.GetItemAll();
            }
            DDLHelper.Bind<Item>(ddlItemName, itemList, "Name", "IID", EnumCollection.ListItemType.ItemName); 
        }

        private void LoadItemCode()
        {
            List<Item> itemList = new List<Item>();

            using (TheFacade _facade = new TheFacade())
            {
                itemList = _facade.ItemFacade.GetItemAll();
            }
            DDLHelper.Bind<Item>(ddlItem, itemList, "Code", "IID", EnumCollection.ListItemType.ItemCode); 
        }

        private void LoadCustomer()
        {
            List<Customer> customerList = new List<Customer>();

            using (TheFacade _facade = new TheFacade())
            {
                customerList = _facade.CustomerFacade.GetCustomerAll();
            }
            DDLHelper.Bind<Customer>(ddlCustomer, customerList, "Name", "IID", EnumCollection.ListItemType.CustomerName); 
        }

        private void LoadItemBatchNo()
        {
            
        }

        private void LoadSaleListView()
        {
            List<StockMaster> stockMasterList = new List<StockMaster>();
            using (TheFacade _facade = new TheFacade())
            {
                stockMasterList = _facade.StockFacade.GetStockMasterListByTransactionPrefix("SI");
                if (stockMasterList.Count > 0)
                {
                    lvSaleDetail.DataSource = stockMasterList;
                    lvSaleDetail.DataBind();
                }
            }
        }
        int index = 1;
        protected void lvItem_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            if (e.Item.ItemType == ListViewItemType.DataItem)
            {
                ListViewDataItem item = (ListViewDataItem)e.Item;
                StockDetail stockDetail = (StockDetail)((ListViewDataItem)(e.Item)).DataItem;
                Label lblItemID = (Label)item.FindControl("lblItemID");
                Label lblItemName = (Label)item.FindControl("lblItemName");
                Label lblItemCode = (Label)item.FindControl("lblItemCode");
                Label lblItemBatchNo = (Label)item.FindControl("lblItemBatchNo");
                Label lblCostPrice = (Label)item.FindControl("lblCostPrice");
                Label lblSellPrice = (Label)item.FindControl("lblSellPrice");
                Label lblQuantity = (Label)item.FindControl("lblQuantity");
                LinkButton lnkbtnDelete = (LinkButton)item.FindControl("lnkbtnDelete");
                
                lblItemID.Text = stockDetail.ItemID.ToString();
                lblItemName.Text = stockDetail.Item.Name;
                lblItemCode.Text = stockDetail.Item.Code;
                //using (TheFacade _facade = new TheFacade())
                //{
                //    StockDetail stockDetailnew = _facade.StockFacade.GetStockDetailByBatchNo(stockDetail.BatchNo);
                //}
                lblItemBatchNo.Text = stockDetail.BatchNo;
                lblCostPrice.Text = stockDetail.CostPrice.ToString();
                lblSellPrice.Text = stockDetail.SellPrice.ToString();
                lblQuantity.Text = stockDetail.Quantity.ToString();

                lnkbtnDelete.Text = "Delete";
                lnkbtnDelete.CommandArgument = stockDetail.BatchNo;
                lnkbtnDelete.CommandName = "DoDelete";
                index++;
            }
        }

        protected void lvItem_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            if (e.CommandName == "DoDelete")
            {
                List<StockDetail> stockDetailList = GetExistingStockDetailList();
                StockDetail stockDetail = stockDetailList.Single(sd => sd.BatchNo == e.CommandArgument.ToString());
                stockDetailList.Remove(stockDetail);
                //BindItemList(stockDetailList);

                if (stockDetailList.Count > 0)
                {
                   
                    decimal totalAmount = 0;
                    foreach (StockDetail sd in stockDetailList)
                    {
                        totalAmount += sd.Quantity * sd.SellPrice;
                    }
                    txtTotalAmount.Text = totalAmount.ToString();
                    txtSpecialDiscount.Text = "0";
                    txtTotalPayableAmount.Text = totalAmount.ToString();

                }
                else
                {
                    txtTotalAmount.Text = "0";
                    txtSpecialDiscount.Text = "0";
                    txtTotalPayableAmount.Text = "0";
                }
                BindItemList(stockDetailList);
            }
        }

        protected void ddlItem_SelectedIndexChanged(object sender, EventArgs e)
        {
            Item item = new Item();
            using (TheFacade _facade = new TheFacade())
            {
                item = _facade.StockFacade.GetItemStockDetailByItemID(Convert.ToInt64(ddlItem.SelectedValue));
            }
            if (item.IID > 0)
            {
                ddlItemName.SelectedValue = item.IID.ToString();

                lvItemBatch.DataSource = item.ItemBatchList;
                lvItemBatch.DataBind();
                //CurrentItem = item;
            }
            
        }

        protected void ddlItemName_SelectedIndexChanged(object sender, EventArgs e)
        {
            Item item = new Item();
            using (TheFacade _facade = new TheFacade())
            {
                item = _facade.StockFacade.GetItemStockDetailByItemID(Convert.ToInt64(ddlItemName.SelectedValue));
            }
            if (item.IID > 0)
            {
                ddlItem.SelectedValue = item.IID.ToString();

                lvItemBatch.DataSource = item.ItemBatchList;
                lvItemBatch.DataBind();
                //CurrentItem = item;
            }
        }

        protected void lvItemBatch_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            if (e.Item.ItemType == ListViewItemType.DataItem)
            {
                ListViewDataItem currentItem = (ListViewDataItem)e.Item;
                ItemBatch itemBatch = (ItemBatch)((ListViewDataItem)(e.Item)).DataItem;
                Label lblItemBatchNo = (Label)currentItem.FindControl("lblItemBatchNo");
                Label lblCostPrice = (Label)currentItem.FindControl("lblCostPrice");
                Label lblSellPrice = (Label)currentItem.FindControl("lblSellPrice");
                Label lblQuantity = (Label)currentItem.FindControl("lblQuantity");

                lblItemBatchNo.Text = itemBatch.BatchNo;
                lblCostPrice.Text = itemBatch.CostPrice.ToString();
                lblSellPrice.Text = itemBatch.SellPrice.ToString();
                lblQuantity.Text = itemBatch.Quantity.ToString();
                

                
            }
        }

        protected void btnAddItem_Click(object sender, EventArgs e)
        {
            List<StockDetail> stockDetailList = GetExistingStockDetailList();
            StockDetail stockDetail = new StockDetail();
            stockDetail.ItemID = Convert.ToInt64(ddlItem.SelectedValue);
            Item item = new Item();
            using (TheFacade _facade = new TheFacade())
            {
                item = _facade.StockFacade.GetItemStockDetailByItemID(Convert.ToInt64(ddlItem.SelectedValue));

                stockDetail.Item = item;
                //stockDetail = stockDetailList.Single(sd => sd.ItemID == stockDetail.ItemID);
                if (stockDetailList.Exists(sd => sd.ItemID == stockDetail.ItemID))
                    return;

                int batchCount = stockDetail.Item.ItemBatchList.Count;
                decimal totalQuantity = 0;
                if (!string.IsNullOrEmpty(txtQuantity.Text) && (Convert.ToDecimal(txtQuantity.Text) <= stockDetail.Item.ItemQuantity))
                    totalQuantity = Convert.ToDecimal(txtQuantity.Text);
                else
                    return;

                if (batchCount >= 1)
                {
                    for (int i = 0; i <= batchCount - 1; i++)
                    {
                        StockDetail stockDetailNew = new StockDetail();
                        //stockDetailNew = _facade.StockFacade.GetStockDetailByID(stockDetail.IID);
                        stockDetailNew.Item = item; 
                        if (totalQuantity > stockDetail.Item.ItemBatchList[batchCount - (batchCount - i)].Quantity)
                        {
                            totalQuantity = totalQuantity - stockDetail.Item.ItemBatchList[batchCount - (batchCount - i)].Quantity;

                            stockDetailNew.Quantity = stockDetail.Item.ItemBatchList[batchCount - (batchCount - i)].Quantity;
                            stockDetailNew.CostPrice = stockDetail.Item.ItemBatchList[i].CostPrice;
                            stockDetailNew.SellPrice = stockDetail.Item.ItemBatchList[i].SellPrice;
                            stockDetailNew.BatchNo = stockDetail.Item.ItemBatchList[i].BatchNo;
                            stockDetailList.Add(stockDetailNew);

                        }
                        //if (totalQuantity <= stockDetail.Item.ItemBatchList[batchCount - (batchCount - i)].Quantity)
                        else
                        {

                            stockDetail.Quantity = totalQuantity;
                            stockDetail.CostPrice = stockDetail.Item.ItemBatchList[i].CostPrice;
                            stockDetail.SellPrice = stockDetail.Item.ItemBatchList[i].SellPrice;
                            stockDetail.BatchNo = stockDetail.Item.ItemBatchList[i].BatchNo;
                            stockDetailList.Add(stockDetail);
                            break;
                        }
                    }
                }
            }
            

            //if (Convert.ToDecimal(txtQuantity.Text) > stockDetail.Item.ItemBatchList[0].Quantity)
            //{

            //}


            //stockDetail.Item = CurrentItem;
            //if (!string.IsNullOrEmpty(txtQuantity.Text))
            //{
            //    stockDetail.Quantity = Convert.ToDecimal(txtQuantity.Text);
            //}
            //else
            //    return;
            //if (!string.IsNullOrEmpty(txtCostPrice.Text))
            //{
            //    stockDetail.CostPrice = Convert.ToDecimal(txtCostPrice.Text);
            //}
            //else
            //    return;
            //if (!string.IsNullOrEmpty(txtSellPrice.Text))
            //{
            //    stockDetail.SellPrice = Convert.ToDecimal(txtSellPrice.Text);
            //}
            //else
            //    return;
            //if (Convert.ToDecimal(txtQuantity.Text) > stockDetail.Item.ItemBatchList[0].Quantity)
            //{

            //}
            //else
            //{
            //    stockDetail.BatchNo = item.ItemBatchList[0].BatchNo;
            //}
            //stockDetailList.Add(stockDetail);
            if (stockDetailList.Count > 0)
            {
                BindItemList(stockDetailList);
                decimal totalAmount = 0;
                foreach (StockDetail sd in stockDetailList)
                {
                    totalAmount += sd.Quantity * sd.SellPrice;
                }
                txtTotalAmount.Text = totalAmount.ToString();
                txtSpecialDiscount.Text = "0";
                txtTotalPayableAmount.Text = totalAmount.ToString();
                
            }

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
                Label lblItemBatchNo = (Label)item.FindControl("lblItemBatchNo");
                Label lblSellPrice = (Label)item.FindControl("lblSellPrice");
                Label lblQuantity = (Label)item.FindControl("lblQuantity");
                
                LinkButton lnkbtnDelete = (LinkButton)item.FindControl("lnkbtnDelete");
                
                StockDetail stockDetail = new StockDetail();
                stockDetail.BatchNo = "1";
                stockDetail.ItemID = Convert.ToInt64(lblItemID.Text);


                Item itemP = new Item();
                using (TheFacade _facade = new TheFacade())
                {
                    itemP = _facade.StockFacade.GetItemStockDetailByItemID(stockDetail.ItemID);
                }
                stockDetail.Item = itemP;
                stockDetail.CostPrice = Convert.ToDecimal(lblCostPrice.Text);
                stockDetail.SellPrice = Convert.ToDecimal(lblSellPrice.Text);
                stockDetail.BatchNo = lblItemBatchNo.Text;
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
                    stockMasterList = _facade.StockFacade.GetStockMasterListByTransactionPrefix("SI");
                    StockMaster stockMasterForBatch = new StockMaster();
                    stockMasterForBatch = stockMasterList.LastOrDefault();
                    _facade.Insert<StockMaster>(stockMaster);

                    if (stockMaster.IID > 0)
                    {
                        foreach (StockDetail stockDetail in stockDetailList)
                        {
                            stockDetail.StockMasterID = stockMaster.IID;
                            
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
            Response.Redirect("~/UIInventory/SaleView.aspx");
        }

        private void LoadStockMaster(StockMaster stockMaster, List<StockDetail> stockDetailList)
        {
            stockMaster.StockTransactionTypeID = Convert.ToInt32(EnumCollection.StockTransactionType.Sale);
            stockMaster.ReferenceTypeID = Convert.ToInt32(EnumCollection.ReferenceType.Customer);
            stockMaster.ReferenceID = Convert.ToInt64(ddlCustomer.SelectedValue);
            stockMaster.PurchaseOrSaleBy = Convert.ToInt64(ddlSalesPerson.SelectedValue); //EmployeeID
            stockMaster.Date = DateTime.Now;
            stockMaster.TransactionNo = getLastOrderNumber();
            stockMaster.BillNo = txtBillNo.Text;
            stockMaster.TotalDiscount = 0;
            if(!string.IsNullOrEmpty(txtSpecialDiscount.Text))
                stockMaster.SpecialDiscount = Convert.ToDecimal(txtSpecialDiscount.Text);
            else
                stockMaster.SpecialDiscount = 0;
            stockMaster.TotalVAT = 0;

            Decimal totalAmount = 0;
            foreach (StockDetail stockDetail in stockDetailList)
            {
                totalAmount += stockDetail.Quantity * stockDetail.SellPrice;
            }

            stockMaster.TotalAmount = totalAmount;
            stockMaster.TotalPaidAmount = Convert.ToDecimal(txtPaidAmount.Text);
            stockMaster.TotalDueAmount = Convert.ToDecimal(txtDueAmount.Text);
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

        private List<StockDetail> GetExistingStockDetailListUpdate()
        {
            List<StockDetail> stockDetailList = new List<StockDetail>();
            foreach (ListViewDataItem item in lvItem.Items)
            {

                Label lblItemID = (Label)item.FindControl("lblItemID");
                Label lblItemName = (Label)item.FindControl("lblItemName");
                Label lblItemCode = (Label)item.FindControl("lblItemCode");
                Label lblItemBatchNo = (Label)item.FindControl("lblItemBatchNo");
                
                Label lblCostPrice = (Label)item.FindControl("lblCostPrice");
                Label lblSellPrice = (Label)item.FindControl("lblSellPrice");
                Label lblQuantity = (Label)item.FindControl("lblQuantity");

                StockDetail stockDetail = new StockDetail();
                
                stockDetail.ItemID = Convert.ToInt64(lblItemID.Text);
                stockDetail.BatchNo = lblItemBatchNo.Text;
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


        private string getLastOrderNumber()
        {
            string newCode = "SI";

            //Last Order
            List<StockMaster> stockMasterList = new List<StockMaster>();
            using (TheFacade _facade = new TheFacade())
            {
                stockMasterList = _facade.StockFacade.GetStockMasterAll();
            }
            DateTime startDate = Convert.ToDateTime(DateTime.Now.ToShortDateString() + " 12:00:00 AM");
            DateTime endDate = Convert.ToDateTime(DateTime.Now.ToShortDateString() + " 11:59:59 PM");
            stockMasterList = stockMasterList.Where(s => (s.Date >= startDate && s.Date <= endDate) && (s.TransactionNo.StartsWith("SI"))).ToList();

            int count = stockMasterList.Count;
            int lastnumber = 0;
                                   
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

        }

        protected void lvSaleDetail_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            if (e.Item.ItemType == ListViewItemType.DataItem)
            {
                ListViewDataItem item = (ListViewDataItem)e.Item;

                Label lblDate = (Label)item.FindControl("lblDate");
                LinkButton lnkbtnTransactionNo = (LinkButton)item.FindControl("lnkbtnTransactionNo");
                Label lblCustomerName = (Label)item.FindControl("lblCustomerName");
                Label lblTotalPrice = (Label)item.FindControl("lblTotalPrice");

                StockMaster stockMaster = (StockMaster)((ListViewDataItem)(e.Item)).DataItem;

                lblDate.Text = stockMaster.Date.ToShortDateString();

                lnkbtnTransactionNo.Text = stockMaster.TransactionNo;
                lnkbtnTransactionNo.CommandArgument = stockMaster.IID.ToString();
                lnkbtnTransactionNo.CommandName = "DoEdit";

                lblCustomerName.Text = stockMaster.Customer.Name;
                lblTotalPrice.Text = stockMaster.TotalAmount.ToString();
            }
        }

        protected void txtSpecialDiscount_TextChanged(object sender, EventArgs e)
        {
            txtTotalPayableAmount.Text = (Convert.ToDecimal(txtTotalAmount.Text) - Convert.ToDecimal(txtSpecialDiscount.Text)).ToString();
        }

        protected void txtPaidAmount_TextChanged(object sender, EventArgs e)
        {
            txtDueAmount.Text = (Convert.ToDecimal(txtTotalPayableAmount.Text) - Convert.ToDecimal(txtPaidAmount.Text)).ToString();
        }

        protected void dpSaleDetail_PreRender(object sender, EventArgs e)
        {
            LoadSaleListView();
        }

        

        

    }
}
