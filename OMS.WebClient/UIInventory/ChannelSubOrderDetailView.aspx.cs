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
    public partial class ChannelSubOrderDetailView : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadChannelCode();
                LoadChannelName();
            }
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

        private void LoadChannelCode()
        {
            List<Channel> channelList = new List<Channel>();
            using (TheFacade _facade = new TheFacade())
            {
                channelList = _facade.ChannelFacade.GetChannelAll();
            }
            DDLHelper.Bind<Channel>(ddlChannelCode, channelList, "Code", "IID", EnumCollection.ListItemType.ChannelCode);
        }

        protected void ddlChannelCode_SelectedIndexChanged(object sender, EventArgs e)
        {
            //List<Order> orderList = new List<Order>();
            if (ddlChannelCode.SelectedValue != "")
            {
                ddlChannelName.SelectedValue = ddlChannelCode.SelectedValue;
                //using (TheFacade _facade = new TheFacade())
                //{
                //    orderList = _facade.OrderFacade.GetOrderListByChannelID(Convert.ToInt64(ddlChannelCode.SelectedValue));
                //}
                //if (orderList.Count > 0)
                //{
                //    ddlOrderNo.Enabled = true;
                //    DDLHelper.Bind<Order>(ddlOrderNo, orderList, "OrderNo", "IID", EnumCollection.ListItemType.OrderNo);
                //}
                //else
                //{
                //    ddlOrderNo.Enabled = false;
                //    ddlOrderNo.SelectedIndex = -1;
                //}
            }
        }

        protected void ddlChannelName_SelectedIndexChanged(object sender, EventArgs e)
        {
            //List<Order> orderList = new List<Order>();
            if (ddlChannelName.SelectedValue != "")
            {
                ddlChannelCode.SelectedValue = ddlChannelName.SelectedValue;
                //using (TheFacade _facade = new TheFacade())
                //{
                //    orderList = _facade.OrderFacade.GetOrderListByChannelID(Convert.ToInt64(ddlChannelName.SelectedValue));
                //}
                //if (orderList.Count > 0)
                //{
                //    ddlOrderNo.Enabled = true;
                //    DDLHelper.Bind<Order>(ddlOrderNo, orderList, "OrderNo", "IID", EnumCollection.ListItemType.OrderNo);
                //}
                //else
                //{
                //    ddlOrderNo.Enabled = false;
                //    ddlOrderNo.SelectedIndex = -1;
                //}
            }
        }

        protected void btnShowOrderDetails_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt64(ddlChannelCode.SelectedValue) > 0 && Convert.ToInt64(ddlChannelCode.SelectedValue) > 0)
            {
                Channel channel = new Channel();
                using (TheFacade _facade = new TheFacade())
                {                    
                    channel = _facade.ChannelFacade.GetChannelByID(Convert.ToInt64(ddlChannelCode.SelectedValue));
                    if (channel.IID > 0)
                    {
                        List<Channel> channelList = new List<Channel>();
                        List<Order> orderListForListView = new List<Order>();
                        channelList = _facade.ChannelFacade.GetChannelListByParentID(channel.IID);
                        foreach (Channel channelChild in channelList)
                        {
                            List<Order> orderList = new List<Order>();
                            orderList = _facade.OrderFacade.GetOrderListByChannelIDAndDateRange(channelChild.IID, Convert.ToDateTime(txtDateFrom.Text), Convert.ToDateTime(txtDateTo.Text));
                            foreach (Order order in orderList)
                            {
                                orderListForListView.Add(order);
                            }
                            
                        }
                        orderListForListView = orderListForListView.OrderBy(o => o.Date).ToList();
                        lvChannelOrderList.DataSource = orderListForListView;
                        lvChannelOrderList.DataBind();
                    }
                }
            }
        }
        private int itemSerial = 0;
        protected void lvChannelOrderList_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            if (e.Item.ItemType == ListViewItemType.DataItem)
            {
                itemSerial++;
                ListViewDataItem currentItem = (ListViewDataItem)e.Item;
                Order order = (Order)((ListViewDataItem)(e.Item)).DataItem;
                Label lblSerialNo = (Label)currentItem.FindControl("lblSerialNo");
                wucChannelOrderDetail wucChannelOrderDetail1 = (wucChannelOrderDetail)currentItem.FindControl("wucChannelOrderDetail1");

                lblSerialNo.Text = itemSerial.ToString();
                wucChannelOrderDetail1.CurrentOrderID= order.IID;
                wucChannelOrderDetail1.LoadOrderDetail();
                
            }
        }

        protected void lvChannelOrderList_ItemCommand(object sender, ListViewCommandEventArgs e)
        {

        }

        protected void btnPrint_Click(object sender, EventArgs e)
        {
            btnShowOrderDetails.Visible = false;
            Session["ctrl"] = pnl1;

            ClientScript.RegisterStartupScript(this.GetType(), "onclick", "<script language=javascript>window.open('PrintChannelOrderDetailView.aspx','PrintMe','height=600px,width=800px,scrollbars=1');</script>");
        }
    }
}
