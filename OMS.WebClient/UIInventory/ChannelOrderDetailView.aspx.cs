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
using OMS.DAL;
using OMS.Facade;
using OMS.Web.Helpers;
using OMS.Framework;
using OMS.WebClient.Controls;

namespace OMS.WebClient.UIInventory
{
    public partial class ChannelOrderDetailView : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadChannelCode();
                LoadChannelName();
                LoadOrderNo();
                wucChannelOrderDetail1.Visible = false;
            }
            
        }

        private void LoadChannelCode()
        {
            List<Channel> channelList = new List<Channel>();
            using (TheFacade _facade = new TheFacade())
            {
                channelList = _facade.ChannelFacade.GetChannelAll();
            }
            DDLHelper.Bind<Channel>(ddlChannelCode, channelList, "Code", "IID", EnumCollection.ListItemType.ChannelCode);
        }

        private void LoadChannelName()
        {
            List<Channel> channelList = new List<Channel>();
            using (TheFacade _facade = new TheFacade())
            {
                channelList = _facade.ChannelFacade.GetChannelAll();
            }
            DDLHelper.Bind<Channel>(ddlChannelName, channelList, "Name", "IID", EnumCollection.ListItemType.ChannelName);
        }

        private void LoadOrderNo()
        {
            List<Order> orderList = new List<Order>();
            using (TheFacade _facade = new TheFacade())
            {
                orderList = _facade.OrderFacade.GetOrderAll();
            }
            DDLHelper.Bind<Order>(ddlOrderNo, orderList, "OrderNo", "IID", EnumCollection.ListItemType.OrderNo);
        }

        protected void ddlChannelCode_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<Order> orderList = new List<Order>();
            if (ddlChannelCode.SelectedValue != "")
            {
                ddlChannelName.SelectedValue = ddlChannelCode.SelectedValue;
                using (TheFacade _facade = new TheFacade())
                {
                    orderList = _facade.OrderFacade.GetOrderListByChannelID(Convert.ToInt64(ddlChannelCode.SelectedValue));
                }
                if (orderList.Count > 0)
                {
                    ddlOrderNo.Enabled = true;
                    DDLHelper.Bind<Order>(ddlOrderNo, orderList, "OrderNo", "IID", EnumCollection.ListItemType.OrderNo);
                }
                else
                {
                    ddlOrderNo.Enabled = false;
                    ddlOrderNo.SelectedIndex = -1;
                }
            }
        }

        protected void ddlChannelName_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<Order> orderList = new List<Order>();
            if (ddlChannelName.SelectedValue != "")
            {
                ddlChannelCode.SelectedValue = ddlChannelName.SelectedValue;
                using (TheFacade _facade = new TheFacade())
                {
                    orderList = _facade.OrderFacade.GetOrderListByChannelID(Convert.ToInt64(ddlChannelName.SelectedValue));
                }
                if (orderList.Count > 0)
                {
                    ddlOrderNo.Enabled = true;
                    DDLHelper.Bind<Order>(ddlOrderNo, orderList, "OrderNo", "IID", EnumCollection.ListItemType.OrderNo);
                }
                else
                {
                    ddlOrderNo.Enabled = false;
                    ddlOrderNo.SelectedIndex = -1;
                }
            }
        }

        protected void ddlOrderNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Convert.ToInt64(ddlOrderNo.SelectedValue) > 0)
            {
                Order order = new Order();
                using (TheFacade _facade = new TheFacade())
                {
                    order = _facade.OrderFacade.GetOrderByID(Convert.ToInt64(ddlOrderNo.SelectedValue));
                }
                if (order.IID > 0)
                {
                    txtDate.Text = order.Date.ToShortDateString();
                    wucChannelOrderDetail1.Visible = true;
                    
                    wucChannelOrderDetail1.CurrentOrderID = order.IID;
                    wucChannelOrderDetail1.LoadOrderDetail();
                    
                }
            }
        }

        protected void btnPrint_Click(object sender, EventArgs e)
        {
            Session["ctrl"] = pnl1;

            ClientScript.RegisterStartupScript(this.GetType(), "onclick", "<script language=javascript>window.open('PrintChannelOrderDetailView.aspx','PrintMe','height=500px,width=600px,scrollbars=1');</script>");
        }

        
    }
}
