using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OMS.DAL;
using OMS.Framework;

namespace OMS.Facade
{
    public interface IStockFacade
    {
        //StockMaster
        List<StockMaster> GetStockMasterAll();
        List<StockMaster> GetStockMasterAllByStockTransactionTypeID(Int32 stockTransactionTypeID);
        StockMaster GetStockMasterByID(long id);
        List<StockMaster> GetStockMasterListByTransactionPrefix(string transactionNoPrefix);

        //StockDetail
        List<StockDetail> GetStockDetailAll();
        StockDetail GetStockDetailByID(long id);
        List<StockDetail> GetStockDetailListByStockMatserID(long stockMasterID);
        StockDetail GetStockDetailByBatchNo(string batchNo);

        //ItemSearchInStock
        Item GetItemStockDetailByItemID(long itemID);
        Item GetItemStockDetailByItem(Item item);
        void Dispose();
    }

    class StockFacade : BaseFacade, IStockFacade
    {
        public StockFacade(OMSDataContext database)
            : base(database)
        {
        }

        #region IStockFacade Members
        #region ItemStock
        public StockDetail GetStockDetailByBatchNo(string batchNo)
        {
            StockDetail stockDetail = new StockDetail();
            stockDetail = Database.StockDetails.Single(sd => sd.BatchNo == batchNo && sd.StockMaster.StockTransactionTypeID == Convert.ToInt32(EnumCollection.StockTransactionType.Purchase));
            return stockDetail;
        }

        public Item GetItemStockDetailByItem(Item item)
        {
            //Item item = new Item();
            //item = Database.Items.Where(i => i.IID == itemID).FirstOrDefault();
            List<StockDetail> stockDetailList = new List<StockDetail>();
            


            stockDetailList = Database.StockDetails.Where(sd => sd.ItemID == item.IID && sd.IsRemoved == 0).ToList();


            List<string> batchList = stockDetailList.Select(sd => sd.BatchNo).Distinct().ToList();


            foreach (StockDetail stockDetail in stockDetailList)
            {
                stockDetail.StockMaster = stockDetail.StockMaster;

            }
            List<StockDetail> stockDetailListForPurchase = new List<StockDetail>();
            List<StockDetail> stockDetailListForPurchaseReturn = new List<StockDetail>();
            List<StockDetail> stockDetailListForSale = new List<StockDetail>();
            List<StockDetail> stockDetailListForSaleReturn = new List<StockDetail>();
            List<ItemBatch> itemBatchList = new List<ItemBatch>();
            decimal itemQty = 0;
            decimal purTQty = 0;
            decimal purRtnTQty = 0;
            decimal saleTQty = 0;
            decimal saleRtnTQty = 0;
            long ItemBatchID = 1;

            decimal totalStockCostPrice = 0;
            decimal totalStockSalePrice = 0;
            decimal totalPurchasePrice = 0;
            decimal totalSalePrice = 0;
            decimal totalPurchaseReturnPrice = 0;
            decimal totalSaleReturnPrice = 0;

            foreach (String st in batchList)
            {

                decimal purchaseQty = 0;
                decimal purchaseReturnQty = 0;
                decimal saleQty = 0;
                decimal saleReturnQty = 0;

                decimal purchasePrice = 0;
                decimal purchaseReturnPrice = 0;
                decimal salePrice = 0;
                decimal saleReturnPrice = 0;

                ItemBatch itemBatch = new ItemBatch();
                StockDetail stockDetail = new StockDetail();
                //Purchase
                stockDetail = stockDetailList.Where(sd => sd.BatchNo == st && sd.StockMaster.StockTransactionTypeID == Convert.ToInt32(EnumCollection.StockTransactionType.Purchase)).FirstOrDefault();
                purchaseQty = stockDetail.Quantity;
                purchasePrice = stockDetail.Quantity * stockDetail.CostPrice;
                //stockDetailListForPurchase.Add(stockDetail);
                //PurchaseReturn
                stockDetailListForPurchaseReturn = stockDetailList.Where(sd => sd.BatchNo == st && sd.StockMaster.StockTransactionTypeID == Convert.ToInt32(EnumCollection.StockTransactionType.PurchaseReturn)).ToList();
                if (stockDetailListForPurchaseReturn.Count > 0)
                {
                    foreach (StockDetail stockDetailPurchaseReturn in stockDetailListForPurchaseReturn)
                    {
                        purchaseReturnQty += stockDetailPurchaseReturn.Quantity;
                        purchaseReturnPrice += stockDetailPurchaseReturn.Quantity * stockDetailPurchaseReturn.CostPrice;
                    }
                }
                //Sale
                stockDetailListForSale = stockDetailList.Where(sd => sd.BatchNo == st && sd.StockMaster.StockTransactionTypeID == Convert.ToInt32(EnumCollection.StockTransactionType.Sale)).ToList();
                if (stockDetailListForSale.Count > 0)
                {
                    foreach (StockDetail stockDetailSale in stockDetailListForSale)
                    {
                        saleQty += stockDetailSale.Quantity;
                        salePrice += stockDetailSale.Quantity * stockDetailSale.SellPrice;
                    }
                }
                //SaleReturn
                stockDetailListForSaleReturn = stockDetailList.Where(sd => sd.BatchNo == st && sd.StockMaster.StockTransactionTypeID == Convert.ToInt32(EnumCollection.StockTransactionType.SaleReturn)).ToList();
                if (stockDetailListForSaleReturn.Count > 0)
                {
                    foreach (StockDetail stockDetailSaleReturn in stockDetailListForSaleReturn)
                    {
                        saleReturnQty += stockDetailSaleReturn.Quantity;
                        saleReturnPrice += stockDetailSaleReturn.Quantity*stockDetailSaleReturn.SellPrice;
                    }
                }

                itemBatch.IID = ItemBatchID;
                itemBatch.BatchNo = st;
                itemBatch.CostPrice = stockDetail.CostPrice;
                itemBatch.SellPrice = stockDetail.SellPrice;
                itemBatch.Quantity = purchaseQty - purchaseReturnQty - saleQty + saleReturnQty;

                itemQty += itemBatch.Quantity;
                purTQty += purchaseQty;
                purRtnTQty += purchaseReturnQty;
                saleTQty += saleQty;
                saleRtnTQty += saleReturnQty;

                totalStockCostPrice += purchasePrice - purchaseReturnPrice - salePrice + saleReturnPrice;
                totalPurchasePrice += purchasePrice;
                totalSalePrice += salePrice;
                totalPurchaseReturnPrice += purchaseReturnPrice;
                totalSaleReturnPrice += saleReturnPrice;
                //if (itemQty > 0)
                //    itemBatchList.Add(itemBatch);
            }
            item.PurchaseQuantity = purTQty;
            item.PurchaseReturnQuantity = purRtnTQty;
            item.SaleQuantity = saleTQty;
            item.SaleReturnQuantity = saleRtnTQty;
            item.ItemQuantity = itemQty;
            item.ItemBatchList = itemBatchList;
            ItemBatchID += 1;
            return item;

        }

        public Item GetItemStockDetailByItemID(long itemID)
        {
            Item item = new Item();
            item = Database.Items.Where(i => i.IID == itemID).FirstOrDefault();
            List<StockDetail> stockDetailList = new List<StockDetail>();
            ////Purchase
            //List<StockMaster> stockMasterListPurchase = new List<StockMaster>();
            //stockMasterListPurchase = GetStockMasterAllByStockTransactionTypeID(Convert.ToInt32(EnumCollection.StockTransactionType.Purchase));
            ////Sale
            //List<StockMaster> stockMasterListSale = new List<StockMaster>();
            //stockMasterListSale = GetStockMasterAllByStockTransactionTypeID(Convert.ToInt32(EnumCollection.StockTransactionType.Sale));
            ////PurchaseReturn
            //List<StockMaster> stockMasterListPurchaseReturn = new List<StockMaster>();
            //stockMasterListPurchaseReturn = GetStockMasterAllByStockTransactionTypeID(Convert.ToInt32(EnumCollection.StockTransactionType.PurchaseReturn));
            ////SaleReturn
            //List<StockMaster> stockMasterListSaleReturn = new List<StockMaster>();
            //stockMasterListSaleReturn = GetStockMasterAllByStockTransactionTypeID(Convert.ToInt32(EnumCollection.StockTransactionType.SaleReturn));


            stockDetailList = Database.StockDetails.Where(sd => sd.ItemID == itemID && sd.IsRemoved == 0).ToList();
            

            List<string> batchList = stockDetailList.Select(sd => sd.BatchNo).Distinct().ToList();


            foreach (StockDetail stockDetail in stockDetailList)
            {
                stockDetail.StockMaster = stockDetail.StockMaster;

            }
            List<StockDetail> stockDetailListForPurchase = new List<StockDetail>();
            List<StockDetail> stockDetailListForPurchaseReturn = new List<StockDetail>();
            List<StockDetail> stockDetailListForSale = new List<StockDetail>();
            List<StockDetail> stockDetailListForSaleReturn = new List<StockDetail>();
            List<ItemBatch> itemBatchList = new List<ItemBatch>();
            decimal itemQty = 0;
            decimal purTQty = 0;
            decimal purRtnTQty = 0;
            decimal saleTQty = 0;
            decimal saleRtnTQty = 0;
            long ItemBatchID = 1;
            foreach (String st in batchList)
            {

                decimal purchaseQty = 0;
                decimal purchaseReturnQty = 0;
                decimal saleQty = 0;
                decimal saleReturnQty = 0;

                ItemBatch itemBatch = new ItemBatch();
                StockDetail stockDetail = new StockDetail();
                //Purchase
                stockDetail = stockDetailList.Where(sd => sd.BatchNo == st && sd.StockMaster.StockTransactionTypeID == Convert.ToInt32(EnumCollection.StockTransactionType.Purchase)).FirstOrDefault();
                purchaseQty = stockDetail.Quantity;
                //stockDetailListForPurchase.Add(stockDetail);
                //PurchaseReturn
                stockDetailListForPurchaseReturn = stockDetailList.Where(sd => sd.BatchNo == st && sd.StockMaster.StockTransactionTypeID == Convert.ToInt32(EnumCollection.StockTransactionType.PurchaseReturn)).ToList();
                if (stockDetailListForPurchaseReturn.Count > 0)
                {
                    foreach (StockDetail stockDetailSale in stockDetailListForPurchaseReturn)
                    {
                        purchaseReturnQty += stockDetailSale.Quantity;
                    }
                }
                //Sale
                stockDetailListForSale = stockDetailList.Where(sd => sd.BatchNo == st && sd.StockMaster.StockTransactionTypeID == Convert.ToInt32(EnumCollection.StockTransactionType.Sale)).ToList();
                if(stockDetailListForSale.Count>0)
                {
                    foreach(StockDetail stockDetailSale in stockDetailListForSale)
                    {
                        saleQty+= stockDetailSale.Quantity;
                    }
                }
                //SaleReturn
                stockDetailListForSaleReturn = stockDetailList.Where(sd => sd.BatchNo == st && sd.StockMaster.StockTransactionTypeID == Convert.ToInt32(EnumCollection.StockTransactionType.SaleReturn)).ToList();
                if (stockDetailListForSaleReturn.Count > 0)
                {
                    foreach (StockDetail stockDetailSale in stockDetailListForSaleReturn)
                    {
                        saleReturnQty += stockDetailSale.Quantity;
                    }
                }

                itemBatch.IID = ItemBatchID;
                itemBatch.BatchNo = st;
                itemBatch.CostPrice = stockDetail.CostPrice;
                itemBatch.SellPrice = stockDetail.SellPrice;
                itemBatch.Quantity = purchaseQty -purchaseReturnQty - saleQty + saleReturnQty;
                
                itemQty += itemBatch.Quantity;
                purTQty += purchaseQty;
                purRtnTQty += purchaseReturnQty;
                saleTQty += saleQty;
                saleRtnTQty += saleReturnQty;
                if(itemQty>0)
                    itemBatchList.Add(itemBatch);
            }
            item.PurchaseQuantity = purTQty;
            item.PurchaseReturnQuantity = purRtnTQty;
            item.SaleQuantity = saleTQty;
            item.SaleReturnQuantity = saleRtnTQty;
            item.ItemQuantity = itemQty;
            item.ItemBatchList = itemBatchList;
            ItemBatchID += 1;
            return item;

        }

#endregion

        #region StockMaster


        public List<StockMaster> GetStockMasterAll()
        {
            List<StockMaster> StockMasterList = new List<StockMaster>();
            List<StockMaster> StockMasterListNew = new List<StockMaster>();
            StockMasterList = Database.StockMasters.Where(s => s.IsRemoved == 0).ToList();
            foreach (StockMaster stockMaster in StockMasterList)
            {
                if (stockMaster.ReferenceTypeID == Convert.ToInt32(EnumCollection.ReferenceType.Supplier))
                {
                    using(TheFacade _facade = new TheFacade())
                    {
                        Supplier supplier = _facade.SupplierFacade.GetSupplierByID(stockMaster.ReferenceID);
                        stockMaster.Supplier = supplier;                        
                    }
                }
                if (stockMaster.ReferenceTypeID == Convert.ToInt32(EnumCollection.ReferenceType.Customer))
                {
                    using (TheFacade _facade = new TheFacade())
                    {
                        Customer customer = _facade.CustomerFacade.GetCustomerByID(stockMaster.ReferenceID);
                        stockMaster.Customer = customer;
                    }
                }
                
                StockMasterListNew.Add(stockMaster);
            }
            return StockMasterListNew;
        }

        public List<StockMaster> GetStockMasterAllByStockTransactionTypeID(Int32 stockTransactionTypeID)
        {
            List<StockMaster> StockMasterList = new List<StockMaster>();
            List<StockMaster> StockMasterListNew = new List<StockMaster>();
            StockMasterList = Database.StockMasters.Where(s => s.StockTransactionTypeID == stockTransactionTypeID && s.IsRemoved == 0).ToList();
            foreach (StockMaster stockMaster in StockMasterList)
            {
                if (stockMaster.ReferenceTypeID == Convert.ToInt32(EnumCollection.ReferenceType.Supplier))
                {
                    using (TheFacade _facade = new TheFacade())
                    {
                        Supplier supplier = _facade.SupplierFacade.GetSupplierByID(stockMaster.ReferenceID);
                        stockMaster.Supplier = supplier;
                    }
                }

                StockMasterListNew.Add(stockMaster);
            }
            return StockMasterListNew;
        }

        public List<StockMaster> GetStockMasterListByTransactionPrefix(string transactionNoPrefix)
        {
            List<StockMaster> StockMasterList = new List<StockMaster>();
            StockMasterList = GetStockMasterAll().Where(sm => sm.TransactionNo.StartsWith(transactionNoPrefix)).OrderByDescending(sm => sm.Date).ToList();
            return StockMasterList;
        }

        public StockMaster GetStockMasterByID(long id)
        {
            StockMaster stockMaster = new StockMaster();
            stockMaster = Database.StockMasters.Single(s => s.IID == id && s.IsRemoved == 0);
            if (stockMaster.ReferenceTypeID == Convert.ToInt32(EnumCollection.ReferenceType.Supplier))
            {
                using (TheFacade _facade = new TheFacade())
                {
                    Supplier supplier = _facade.SupplierFacade.GetSupplierByID(stockMaster.ReferenceID);
                    stockMaster.Supplier = supplier;
                }
            }
            return stockMaster;
        }

        #endregion


        #region StockDetail

        public List<StockDetail> GetStockDetailAll()
        {
            List<StockDetail> stockDetailList = new List<StockDetail>();
            List<StockDetail> stockDetailListNew = new List<StockDetail>();
            stockDetailList = Database.StockDetails.Where(s => s.IsRemoved == 0).ToList();
            foreach (StockDetail stockDetail in stockDetailList)
            {
                stockDetail.Item = stockDetail.Item;
                stockDetailListNew.Add(stockDetail);
            }
            return stockDetailListNew;
        }

        public StockDetail GetStockDetailByID(long id)
        {
            StockDetail stockDetail = new StockDetail();
            stockDetail = Database.StockDetails.Single(s => s.IID == id && s.IsRemoved == 0);
            stockDetail.Item = stockDetail.Item;
            return stockDetail;
        }

        public List<StockDetail> GetStockDetailListByStockMatserID(long stockMasterID)
        {
            List<StockDetail> stockDetailList = new List<StockDetail>();

            stockDetailList = GetStockDetailAll().Where(sd => sd.StockMasterID == stockMasterID).ToList();

            return stockDetailList;
        }

        #endregion


        #endregion
    }
}
