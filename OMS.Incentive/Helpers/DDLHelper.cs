using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Collections.Generic;
using OMS.Framework;
using System.Linq.Dynamic;

namespace OMS.Web.Helpers
{
    public static class DDLHelper
    {
        public static void Bind<T>(DropDownList ddl, List<T> items, string nameProperty, string valueProperty)
        {
            //DropDownList ddl = new DropDownList();
            //Edited by Imtiaz
            //items = items.AsQueryable().OrderBy(nameProperty + " " + "asc").ToList<T>();
            //end
            ddl.DataSource = items;
            ddl.DataTextField = nameProperty;
            ddl.DataValueField = valueProperty;
            ddl.DataBind();
            //return ddl;
        }

        public static void Bind<T>(DropDownList ddl, List<T> items, string nameProperty, string valueProperty, bool sorted)
        {
            //DropDownList ddl = new DropDownList();
            //Edited by Imtiaz
            if (sorted)
                items = items.AsQueryable().OrderBy(nameProperty + " " + "asc").ToList<T>();
            //end
            ddl.DataSource = items;
            ddl.DataTextField = nameProperty;
            ddl.DataValueField = valueProperty;
            ddl.DataBind();
            //return ddl;
        }
        public static void Bind<T>(DropDownList ddl, List<T> items, string nameProperty, string valueProperty, ListItemCollection extraItems, int hasSelectedValue)
        {
            if (hasSelectedValue == 1)
            {
                foreach (ListItem item in extraItems)
                {
                    ddl.Items.Insert(0, item);
                }
                Bind<T>(ddl, items, nameProperty, valueProperty);
            }
            else
            {
                Bind<T>(ddl, items, nameProperty, valueProperty);
                foreach (ListItem item in extraItems)
                {
                    ddl.Items.Insert(0, item);
                }
            }
        }
        public static void Bind<T>(DropDownList ddl, List<T> items, string nameProperty, string valueProperty, ListItemCollection extraItems)
        {

            Bind<T>(ddl, items, nameProperty, valueProperty);
            foreach (ListItem item in extraItems)
            {
                ddl.Items.Insert(0, item);
            }
        }
        public static void Bind<T>(DropDownList ddl, List<T> items, string nameProperty, string valueProperty, ListItemCollection extraItems, bool sorted)
        {
            Bind<T>(ddl, items, nameProperty, valueProperty, sorted);
            foreach (ListItem item in extraItems)
            {
                ddl.Items.Insert(0, item);
            }
        }
        public static void Bind(DropDownList ddl, ListItemCollection list)
        {
            foreach (ListItem item in list)
            {
                ddl.Items.Add(item);
            }
        }
        public static void Bind(DropDownList ddl, ListItemCollection list, EnumCollection.ListItemType ddlType)
        {
            Bind(ddl, list);
            foreach (ListItem item in GetExtraItems(ddlType))
            {
                ddl.Items.Insert(0, item);
            }
        }

        private static ListItemCollection GetExtraItems(EnumCollection.ListItemType ddltype)
        {
            ListItemCollection extraItems = new ListItemCollection();
            switch (ddltype)
            {
                case EnumCollection.ListItemType.ChannelType: //for ChannelType
                    extraItems.Add(new ListItem("Select Channel Type", "-1"));
                    break;
                case EnumCollection.ListItemType.ChannelParent: //for ChannelParent
                    extraItems.Add(new ListItem("Select Parent", "-1"));
                    //Bind<T>(ddl, items, nameProperty, valueProperty, extraItems);
                    break;                
                case EnumCollection.ListItemType.City: //for City                    
                    extraItems.Add(new ListItem("Select City", "-1")); 
                    break;

                case EnumCollection.ListItemType.ChannelCode: //for ChannelCode
                    extraItems.Add(new ListItem("Select Channel Code", "-1"));
                    break;

                case EnumCollection.ListItemType.ChannelName: //for ChannelName
                    extraItems.Add(new ListItem("Select Channel Name", "-1"));
                    break;

                case EnumCollection.ListItemType.OrderNo: //for OrderNo
                    extraItems.Add(new ListItem("Select OrderNo", "-1"));
                    break;

                case EnumCollection.ListItemType.SupplierName: //for SupplierName
                    extraItems.Add(new ListItem("Select Supplier", "-1"));
                    break;

                case EnumCollection.ListItemType.ItemName: //for ItemName
                    extraItems.Add(new ListItem("Select Item Name", "-1"));
                    break;

                case EnumCollection.ListItemType.ItemCode: //for Item Code
                    extraItems.Add(new ListItem("Select Item Code", "-1"));
                    break;

                case EnumCollection.ListItemType.CustomerName: //for CustomerName
                    extraItems.Add(new ListItem("Select Customer", "-1"));
                    break;

                case EnumCollection.ListItemType.EmployeeName: //for EmployeeName
                    extraItems.Add(new ListItem("Select Employee", "-1"));
                    break;

                case EnumCollection.ListItemType.DepartmentName: //for DepartmentName
                    extraItems.Add(new ListItem("Select Department", "-1"));
                    break;

                case EnumCollection.ListItemType.CategoryName: //for CategoryName
                    extraItems.Add(new ListItem("Select Category", "-1"));
                    break;

                case EnumCollection.ListItemType.ClassName: //for ClassName
                    extraItems.Add(new ListItem("Select Class Name", "-1"));
                    break;

                case EnumCollection.ListItemType.AccountName: //for ChartOfAccount
                    extraItems.Add(new ListItem("Select Account Name", "-1"));
                    break;

                case EnumCollection.ListItemType.AccountCode: //for ChartOfAccount
                    extraItems.Add(new ListItem("Select Account No.", "-1"));
                    break;

                case EnumCollection.ListItemType.Supplier: //for ChartOfAccount
                    extraItems.Add(new ListItem("Select Supplier", "-1"));
                    break;

                case EnumCollection.ListItemType.Customer: //for ChartOfAccount
                    extraItems.Add(new ListItem("Select Customer", "-1"));
                    break;

                case EnumCollection.ListItemType.AccountType: //for ChartOfAccount
                    extraItems.Add(new ListItem("Select Account", "-1"));
                    break;
                case EnumCollection.ListItemType.Bank: //for ChartOfAccount
                    extraItems.Add(new ListItem("Select Bank", "-1"));
                    break;
                case EnumCollection.ListItemType.Select: //for ChartOfAccount
                    extraItems.Add(new ListItem("Please Select", "-1"));
                    break;
                case EnumCollection.ListItemType.ChequeLeafStatus: //for ProductType                    
                    extraItems.Add(new ListItem("Select ChequeLeaf Status", "-1"));
                    break;
                case EnumCollection.ListItemType.TransactionType: //for ProductType
                    extraItems.Add(new ListItem("Select Transaction Type", "-1"));
                    break;
                case EnumCollection.ListItemType.Country: //for Country
                    extraItems.Add(new ListItem("Select Country", "-1"));
                    break;
                case EnumCollection.ListItemType.Invoice: //for Invoice
                    extraItems.Add(new ListItem("Select Invoice", "-1"));
                    break;

                    //case EnumHelper.ListItemType.PriceDetailTypeRow: //for ProductType
                    //    extraItems.Add(new ListItem("Select Type", "-1"));
                    //    break;
                    //case EnumHelper.ListItemType.PriceDetailTypeCol: //for ProductType
                    //    extraItems.Add(new ListItem("Select Room Type", "-1"));
                    //    extraItems.Add(new ListItem("No Type", "12"));
                    //    break;
                    //case EnumHelper.ListItemType.PackageStatus: //for PackageStatus
                    //    extraItems.Add(new ListItem("Select Package Status", "-1"));
                    //    break;
                    ////case EnumHelper.ListItemType.Insurance: //for Insurance
                    ////    extraItems.Add(new ListItem("Select Insurance", "-1"));
                    ////    break;
                    //case EnumHelper.ListItemType.CompsType: //for Insurance
                    //    extraItems.Add(new ListItem("Select CompsType", "-1"));
                    //    break;
                    //case EnumHelper.ListItemType.ApplyCostAndPrice: //for Insurance
                    //    extraItems.Add(new ListItem("Don't Apply", "-1"));
                    //    break;
                    //case EnumHelper.ListItemType.ExtraField: //for Insurance
                    //    extraItems.Add(new ListItem("Select Item", "-1"));
                    //    break;
                    //case EnumHelper.ListItemType.ExtraFees: //for Insurance
                    //    extraItems.Add(new ListItem("Select Feed", "-1"));
                    //    break;
                    //case EnumHelper.ListItemType.Agent: //for Insurance
                    //    extraItems.Add(new ListItem("Select Agent", "-1"));
                    //    break;
                    //case EnumHelper.ListItemType.PackagePriceApprovalStatus: //for Insurance
                    //    extraItems.Add(new ListItem("Select Approval Status", "-1"));
                    //    break;
                    //case EnumHelper.ListItemType.DocumentType: //for Insurance
                    //    extraItems.Add(new ListItem("Select Type", "-1"));
                    //    break;
                    //case EnumHelper.ListItemType.PaymentStatusType:
                    //    extraItems.Add(new ListItem("Select Payment Type", "-1"));
                    //    break;
                    //case EnumHelper.ListItemType.TourType:
                    //    extraItems.Add(new ListItem("Select Tour Type", "-1"));
                    //    break;
                    //case EnumHelper.ListItemType.Client: //for Cleint
                    //    extraItems.Add(new ListItem("Select Client", "-1"));
                    //    break;
                    //case EnumHelper.ListItemType.ClientType: //for ClientType
                    //    extraItems.Add(new ListItem("Select ClientType", "-1"));
                    //    break;
                    //case EnumHelper.ListItemType.Category: //for ClientType
                    //    extraItems.Add(new ListItem("N/A", "-1"));
                    //    break;
                    //case EnumHelper.ListItemType.Location: //for ClientType
                    //    extraItems.Add(new ListItem("Select Location", "-1"));
                    //    break;
                    //case EnumHelper.ListItemType.Group: //for Group
                    //    extraItems.Add(new ListItem("Select Group", "-1"));
                    //    break;
                    //case EnumHelper.ListItemType.User: //for Group
                    //    extraItems.Add(new ListItem("Select User", "-1"));
                    //    break;
                    //case EnumHelper.ListItemType.ShortName: //for Group
                    //    extraItems.Add(new ListItem("Select Short Name", "-1"));
                    //    break;
                    //case EnumHelper.ListItemType.VendorRating: //for Group
                    //    extraItems.Add(new ListItem("N/A", "-1"));
                    //    break;
                    //case EnumHelper.ListItemType.Hour: //for Group
                    //    extraItems.Add(new ListItem("Hour", "-1"));
                    //    break;
                    //case EnumHelper.ListItemType.Munite: //for Group
                    //    extraItems.Add(new ListItem("Min", "-1"));
                    //    break;
            }
            return extraItems;
        }

        public static void Bind<T>(DropDownList ddl, List<T> items, string nameProperty, string valueProperty, EnumCollection.ListItemType ddltype)
        {
            //ListItemCollection extraItems = new ListItemCollection();
            //switch (ddltype)
            //{
            //    case 1: //for City
            //        extraItems.Add(new ListItem("N/A", "-2"));
            //        extraItems.Add(new ListItem("Select City", "-1"));
            //        //Bind<T>(ddl, items, nameProperty, valueProperty, extraItems);
            //        break;
            //    case 2: //for State
            //        extraItems.Add(new ListItem("N/A", "-2"));
            //        extraItems.Add(new ListItem("Select State", "-1"));
            //        //Bind<T>(ddl, items, nameProperty, valueProperty, extraItems);
            //        break;
            //    case 3: //for Country                    
            //        extraItems.Add(new ListItem("Select Country", "-1"));                    
            //        break;
            //    case 4: //for ProductType
            //        extraItems.Add(new ListItem("Select Type", "-1"));
            //        break;
            //}

            Bind<T>(ddl, items, nameProperty, valueProperty, GetExtraItems(ddltype));

        }

        public static void Bind<T>(DropDownList ddl, List<T> items, string nameProperty, string valueProperty, EnumCollection.ListItemType ddltype, bool sorted)
        {
            ListItemCollection extraItems = new ListItemCollection();
            //switch (ddltype)
            //{
            //    case 1: //for City
            //        extraItems.Add(new ListItem("N/A", "-2"));
            //        extraItems.Add(new ListItem("Select City", "-1"));
            //        //Bind<T>(ddl, items, nameProperty, valueProperty, extraItems);
            //        break;
            //    case 2: //for State
            //        extraItems.Add(new ListItem("N/A", "-2"));
            //        extraItems.Add(new ListItem("Select State", "-1"));
            //        //Bind<T>(ddl, items, nameProperty, valueProperty, extraItems);
            //        break;
            //    case 3: //for Country                    
            //        extraItems.Add(new ListItem("Select Country", "-1"));                    
            //        break;
            //    case 4: //for ProductType
            
                    //extraItems.Add(new ListItem("Select", "-1"));
            //        break;
            //}

            Bind<T>(ddl, items, nameProperty, valueProperty, GetExtraItems(ddltype), sorted);

        }

        //ddlState.Items.Insert(0, new ListItem("N/A", "-2"));
        //ddlState.Items.Insert(0, new ListItem("Select State", "-1"));
        //public static DropDownList Bind<T>(List<T> items, string nameProperty, string valueProperty, ListItemCollection extraItems)
        //{
        //    DropDownList ddl = Bind<T>(items, nameProperty, valueProperty);
        //    foreach (ListItem item in extraItems)
        //    {
        //        ddl.Items.Insert(0,item);
        //    }
        //    return ddl;

        //}
        //public static DropDownList Bind<T>(List<T> items, string nameProperty, string valueProperty, int ddltype)
        //{
        //    DropDownList ddl = new DropDownList();
        //    if (ddltype == 1) // for city
        //    {
        //         ListItemCollection extraItems = new ListItemCollection();
        //    extraItems.Add(new ListItem("N/A", "-2"));
        //      extraItems.Add(new ListItem("Select City", "-1"));
        //       ddl = Bind<T>(items, nameProperty, valueProperty, extraItems);
        //    }
        //    return ddl;
        //}
        ////public static DropDownList Bind<T>(DropDownList ddl, List<T> items, string nameProperty, string valueProperty)
        //{
        //    //DropDownList ddl = new DropDownList();
        //    ddl.DataSource = items;
        //    ddl.DataTextField = nameProperty;
        //    ddl.DataValueField = valueProperty;
        //    ddl.DataBind();
        //    //return ddl;
        //}
        //public static void Bind(DropDownList ddl, ListItemCollection list)
        //{
        //    foreach (ListItem item in list)
        //    {
        //        ddl.Items.Add(item);
        //    }
        //}
    }
}
