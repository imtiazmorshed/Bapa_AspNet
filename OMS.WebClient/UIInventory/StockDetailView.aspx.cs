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
using OMS.Facade;
using System.Collections.Generic;
using OMS.Web.Helpers;
using OMS.Framework;
using OMS.WebClient.Report;
//using CrystalDecisions.CrystalReports.Engine;
//using CrystalDecisions.Enterprise;
//using CrystalDecisions.ReportSource;
//using CrystalDecisions.Web;


namespace OMS.WebClient.UIInventory
{
    public partial class StockDetailView : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //LoadStockDetailList();
                LoadDDL();
            }
        }

        private void LoadDDL()
        {
            List<Inv_Department> departmentList = new List<Inv_Department>();
            List<Inv_Category> categoryList = new List<Inv_Category>();
            List<Item> itemList = new List<Item>();
            List<HRM_Employee> employeeList = new List<HRM_Employee>();
            using (TheFacade _facade = new TheFacade())
            {
                departmentList = _facade.ItemFacade.GetDepartmentAll();
                categoryList = _facade.ItemFacade.GetCategoryAll();
                itemList = _facade.ItemFacade.GetItemAll();
                employeeList = _facade.EmployeeFacade.GetEmployeeAll();
            }
            
            DDLHelper.Bind<Inv_Department>(ddlDepartment, departmentList, "Name", "IID", EnumCollection.ListItemType.DepartmentName);
            DDLHelper.Bind<Inv_Category>(ddlCategory, categoryList, "Name", "IID", EnumCollection.ListItemType.CategoryName);
            DDLHelper.Bind<Item>(ddlItem, itemList, "Name", "IID", EnumCollection.ListItemType.ItemName);
            DDLHelper.Bind<HRM_Employee>(ddlSalesPerson, employeeList, "DisplayName", "IID", EnumCollection.ListItemType.EmployeeName);

            ddlDepartment.SelectedIndex = -1;

            ddlCategory.Enabled = false;
            ddlCategory.SelectedIndex = -1;

            ddlItem.Enabled = false;
            ddlItem.SelectedIndex = -1;
        }

        protected void ddlDepartment_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlDepartment.SelectedValue != null && ddlDepartment.SelectedIndex != -1)
            {
                List<Inv_Category> categoryList = new List<Inv_Category>();
                using (TheFacade _facade = new TheFacade())
                {
                    categoryList = _facade.ItemFacade.GetCategoryListByDepartmentID(Convert.ToInt64(ddlDepartment.SelectedValue));
                    if (categoryList.Count > 0)
                    {
                        ddlCategory.Enabled = true;
                        DDLHelper.Bind<Inv_Category>(ddlCategory, categoryList, "Name", "IID", EnumCollection.ListItemType.CategoryName);
                        ddlCategory.SelectedIndex = -1;
                    }
                    else
                    {
                        ddlCategory.SelectedIndex = -1;
                        ddlCategory.Enabled = false;
                        ddlItem.SelectedIndex = -1;
                        ddlItem.Enabled = false;
                    }
                }
            }
            else
            {
                ddlCategory.SelectedIndex = -1;
                ddlCategory.Enabled = false;
                ddlItem.SelectedIndex = -1;
                ddlItem.Enabled = false;
            }
        }

        protected void ddlCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlCategory.SelectedValue != null && ddlCategory.SelectedIndex != -1)
            {
                List<Item> itemList = new List<Item>();
                using (TheFacade _facade = new TheFacade())
                {
                    itemList = _facade.ItemFacade.GetItemListByCategoryID(Convert.ToInt64(ddlCategory.SelectedValue));
                    if (itemList.Count > 0)
                    {
                        ddlItem.Enabled = true;
                        DDLHelper.Bind<Item>(ddlItem, itemList, "Name", "IID", EnumCollection.ListItemType.ItemName);
                        ddlItem.SelectedIndex = -1;
                    }
                    else
                    {
                        ddlItem.SelectedIndex = -1;
                        ddlItem.Enabled = false;
                    }
                }
            }
            else
            {
                ddlItem.SelectedIndex = -1;
                ddlItem.Enabled = false;
            }
        }

        private void LoadStockDetailList()
        {
            List<Item> itemList = new List<Item>();
            List<Item> itemStockList = new List<Item>();

            using (TheFacade _facade = new TheFacade())
            {
                itemList = _facade.ItemFacade.GetItemAll();
                if (Convert.ToInt64(ddlDepartment.SelectedValue) > 0)
                {
                    itemList = itemList.Where(i => i.Inv_Category.Inv_Department.IID == Convert.ToInt64(ddlDepartment.SelectedValue)).ToList();
                    if (Convert.ToInt64(ddlCategory.SelectedValue) > 0)
                    {
                        itemList = itemList.Where(i => i.Inv_Category.IID == Convert.ToInt64(ddlCategory.SelectedValue)).ToList();
                        if (Convert.ToInt64(ddlItem.SelectedValue) > 0)
                        {
                            itemList = itemList.Where(i => i.IID == Convert.ToInt64(ddlItem.SelectedValue)).ToList();
                        }
                    }
                }


                if (itemList.Count > 0)
                {
                    foreach (Item item in itemList)
                    {
                        Item itemStock = new Item();
                        itemStock = _facade.StockFacade.GetItemStockDetailByItem(item);
                        itemStockList.Add(itemStock);
                    }
                }
            }
            

            lvItem.DataSource = itemStockList;
            lvItem.DataBind();
        }

        int index = 1;
        protected void lvItem_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            if (e.Item.ItemType == ListViewItemType.DataItem)
            {
                ListViewDataItem item = (ListViewDataItem)e.Item;
                Item itemStock = (Item)((ListViewDataItem)(e.Item)).DataItem;
                Label lblItemID = (Label)item.FindControl("lblItemID");
                Label lblSerialNo = (Label)item.FindControl("lblSerialNo");
                
                Label lblItemName = (Label)item.FindControl("lblItemName");
                Label lblItemCode = (Label)item.FindControl("lblItemCode");
                Label lblPurchaseQuantity = (Label)item.FindControl("lblPurchaseQuantity");
                Label lblPurchaseReturnQuantity = (Label)item.FindControl("lblPurchaseReturnQuantity");
                Label lblSaleQuantity = (Label)item.FindControl("lblSaleQuantity");
                Label lblSaleReturnQuantity = (Label)item.FindControl("lblSaleReturnQuantity");
                Label lblTotalStock = (Label)item.FindControl("lblTotalStock");

                lblItemID.Text = itemStock.IID.ToString();
                lblSerialNo.Text = index.ToString();
                lblItemName.Text = itemStock.Name;
                lblItemCode.Text = itemStock.Code;
                lblPurchaseQuantity.Text = itemStock.PurchaseQuantity.ToString(); ;
                lblPurchaseReturnQuantity.Text = itemStock.PurchaseReturnQuantity.ToString();
                lblSaleQuantity.Text = itemStock.SaleQuantity.ToString();
                lblSaleReturnQuantity.Text = itemStock.SaleReturnQuantity.ToString();
                lblTotalStock.Text = itemStock.ItemQuantity.ToString();

                
                index++;
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            LoadStockDetailList();
        }

        protected void btnReport_Click(object sender, EventArgs e)
        {
            //TestReport rpt = new TestReport();
            //TestReportDataSet _dataset = new TestReportDataSet();

            //List<StockDetail> _stockDetailList = new List<StockDetail>();
            //StockDetail _stockDetail = new StockDetail();
            //using (TheFacade _facade = new TheFacade())
            //{
            //    _stockDetailList = _facade.StockFacade.GetStockDetailAll();
            //}


            //rpt.SetDataSource(_stockDetailList);
            
            //CrystalReportViewer view = new CrystalReportViewer();
            //view.ReportSource = rpt;
            //Response.Redirect("~/Report/frmReport.aspx");
        }

        
    }
}
