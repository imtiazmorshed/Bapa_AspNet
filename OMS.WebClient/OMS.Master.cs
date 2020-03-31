using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using OMS.DAL;
using OMS.Facade;
using System.Collections.Generic;
using OMS.Framework;

namespace OMS.WebClient
{
    public partial class OMS : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //Menu1.DataSource = UserSiteMapDataSource;
                //Menu1.DataBind();

                //if (Session["uid"] == null || Session["uid"].ToString() == string.Empty)
                //{
                //    Response.Redirect("login.aspx");

                //}

                CompanyInfo com = new CompanyInfo();
                using (TheFacade facade = new TheFacade())
                {
                    com = facade.CommonFacade.GetCompanyInfoAll().FirstOrDefault();
                }
                imgLogo.ImageUrl = com.LogoLocation;
                lblCompany.Text = com.Name;
                lblAddress.Text = com.Address;
                if (Session["BranchName"] != null)
                {
                    LoadMenu();
                    lblBranchName.Text = "Branch Name :" + Session["BranchName"].ToString();
                }
                else
                {
                    FormsAuthentication.SignOut();
                    Roles.DeleteCookie();
                    Session.Abandon();
                    Response.Redirect("~/login.aspx");
                }
                
            }
        }

        public void callforLogout()
        {
            FormsAuthentication.SignOut();
            Roles.DeleteCookie();
            Session.Abandon();
            Response.Redirect("~/login.aspx");
        }

        private void LoadMenu()
        {
            if(Session["UserID"]!=null)
            {
                using (TheFacade facade = new TheFacade())
                {
                    SystemUser currentUser = facade.AdminFacade.GetySystemUserID(Convert.ToInt64(Session["UserID"].ToString()));
                    List<SystemPage> pageList = new List<SystemPage>();
                    if (currentUser.IsRoleBased)
                    {
                        pageList = facade.AdminFacade.GetPageListByRole(currentUser.RoleID);
                    }
                    else
                    {
                        pageList = facade.AdminFacade.GetPageListByUser(currentUser.IID);
                    }
                    lvAdminManagement.DataSource = pageList.Where(p => p.SystemModuleID == (int)EnumCollection.SystemModule.Admin_Management && p.IsRemoved == 0).ToList();
                    lvAdminManagement.DataBind();
                    //lvTicketSale.DataSource = pageList.Where(p => p.SystemModuleID == (int)EnumCollection.SystemModule.Ticket_Sale).ToList();
                    //lvTicketSale.DataBind();
                    lvContacts.DataSource = pageList.Where(p => p.SystemModuleID == (int)EnumCollection.SystemModule.Contacts && p.IsRemoved == 0).ToList();
                    lvContacts.DataBind();
                    lvBankManagement.DataSource = pageList.Where(p => p.SystemModuleID == (int)EnumCollection.SystemModule.Bank_Management && p.IsRemoved == 0).ToList();
                    lvBankManagement.DataBind();
                    lvFinancialManagement.DataSource = pageList.Where(p => p.SystemModuleID == (int)EnumCollection.SystemModule.Financial_Management && p.IsRemoved == 0).ToList();
                    lvFinancialManagement.DataBind();
                    //lvInventroy.DataSource = pageList.Where(p => p.SystemModuleID == (int)EnumCollection.SystemModule.Inventory_Management).ToList();
                    //lvInventroy.DataBind();
                    
                }
            }
        }

        protected void lvInventroy_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            if (e.Item.ItemType == ListViewItemType.DataItem)
            {
                ListViewDataItem currentItem = (ListViewDataItem)e.Item;

                SystemPage pages = (SystemPage)((ListViewDataItem)(e.Item)).DataItem;
                HyperLink lnkPage = (HyperLink)currentItem.FindControl("lnkPage");
                lnkPage.NavigateUrl = pages.Url;
                lnkPage.Text = pages.PageName;
            }
        }

        protected void lvAdminManagement_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            if (e.Item.ItemType == ListViewItemType.DataItem)
            {
                ListViewDataItem currentItem = (ListViewDataItem)e.Item;

                SystemPage pages = (SystemPage)((ListViewDataItem)(e.Item)).DataItem;
                HyperLink lnkPage = (HyperLink)currentItem.FindControl("lnkPage");
                lnkPage.NavigateUrl = pages.Url;
                lnkPage.Text = pages.PageName;
            }
        }

        //protected void lvTicketSale_ItemDataBound(object sender, ListViewItemEventArgs e)
        //{
        //    if (e.Item.ItemType == ListViewItemType.DataItem)
        //    {
        //        ListViewDataItem currentItem = (ListViewDataItem)e.Item;

        //        SystemPage pages = (SystemPage)((ListViewDataItem)(e.Item)).DataItem;
        //        HyperLink lnkPage = (HyperLink)currentItem.FindControl("lnkPage");
        //        lnkPage.NavigateUrl = pages.Url;
        //        lnkPage.Text = pages.PageName;
        //    }
        //}

        protected void lvBankManagement_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            if (e.Item.ItemType == ListViewItemType.DataItem)
            {
                ListViewDataItem currentItem = (ListViewDataItem)e.Item;

                SystemPage pages = (SystemPage)((ListViewDataItem)(e.Item)).DataItem;
                HyperLink lnkPage = (HyperLink)currentItem.FindControl("lnkPage");
                lnkPage.NavigateUrl = pages.Url;
                lnkPage.Text = pages.PageName;
            }
        }

        protected void lvFinancialManagement_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            if (e.Item.ItemType == ListViewItemType.DataItem)
            {
                ListViewDataItem currentItem = (ListViewDataItem)e.Item;

                SystemPage pages = (SystemPage)((ListViewDataItem)(e.Item)).DataItem;
                HyperLink lnkPage = (HyperLink)currentItem.FindControl("lnkPage");
                lnkPage.NavigateUrl = pages.Url;
                lnkPage.Text = pages.PageName;
            }
        }

        protected void lvContacts_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            if (e.Item.ItemType == ListViewItemType.DataItem)
            {
                ListViewDataItem currentItem = (ListViewDataItem)e.Item;

                SystemPage pages = (SystemPage)((ListViewDataItem)(e.Item)).DataItem;
                HyperLink lnkPage = (HyperLink)currentItem.FindControl("lnkPage");
                lnkPage.NavigateUrl = pages.Url;
                lnkPage.Text = pages.PageName;
            }
        }

        protected void lnkSignOut_Click(object sender, EventArgs e)
        {
            FormsAuthentication.SignOut();
            Roles.DeleteCookie();
            Session.Abandon();
            Response.Redirect("~/Login.aspx");
        }
    }
}
