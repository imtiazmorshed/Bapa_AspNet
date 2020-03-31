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

namespace OMS.WebClient.UIInventory
{
    public partial class ChannelWiseTotalOrderView : System.Web.UI.Page
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
            if (ddlChannelCode.SelectedValue != "")
            {
                ddlChannelName.SelectedValue = ddlChannelCode.SelectedValue;         
            }
        }

        protected void ddlChannelName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlChannelName.SelectedValue != "")
            {
                ddlChannelCode.SelectedValue = ddlChannelName.SelectedValue;            
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
                        List<Item> itemList = _facade.ItemFacade.GetItemAll();
                        List<Item> itemListForListView = new List<Item>();
                        channelList = _facade.ChannelFacade.GetChannelListByParentID(channel.IID);
                        channelList.Add(channel);
                        foreach (Channel channelChild in channelList)
                        {
                            List<Order> orderList = new List<Order>();
                            orderList = _facade.OrderFacade.GetOrderListByChannelIDAndDateRange(channelChild.IID, Convert.ToDateTime(txtDateFrom.Text), Convert.ToDateTime(txtDateTo.Text));
                            foreach (Order order in orderList)
                            {
                                List<OrderDetail> orderDetailList = new List<OrderDetail>();
                                orderDetailList = _facade.OrderFacade.GetOrderDetailListByOrderID(order.IID);
                                foreach (OrderDetail orderDetial in orderDetailList)
                                {
                                    foreach (Item item in itemList)
                                    {
                                        if (orderDetial.ItemID == item.IID)
                                        {
                                            item.ItemQuantity += orderDetial.Quantity;
                                            if (itemListForListView.Exists(i => i.IID == item.IID))
                                            {

                                            }
                                            else
                                            {
                                                itemListForListView.Add(item);
                                            }
                                        }
                                    }
                                }
                            }

                        }
                        itemListForListView = itemListForListView.OrderBy(i => i.IID).ToList();
                        lvChannelOrderItemList.DataSource = itemListForListView;
                        lvChannelOrderItemList.DataBind();
                    }
                }
            }
        }

        protected void lvChannelOrderItemList_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            if (e.Item.ItemType == ListViewItemType.DataItem)
            {
                ListViewDataItem currentItem = (ListViewDataItem)e.Item;
                Item item = (Item)((ListViewDataItem)(e.Item)).DataItem;

                Label lblItemCode = (Label)currentItem.FindControl("lblItemCode");
                Label lblItemName = (Label)currentItem.FindControl("lblItemName");
                Label lblQuantity = (Label)currentItem.FindControl("lblQuantity");

                lblItemCode.Text = item.Code;
                lblItemName.Text = item.Name;
                lblQuantity.Text = item.ItemQuantity.ToString();
            }
        }

        protected void btnPrint_Click(object sender, EventArgs e)
        {
            Session["ctrl"] = pnl1;

            ClientScript.RegisterStartupScript(this.GetType(), "onclick", "<script language=javascript>window.open('PrintChannelOrderDetailView.aspx','PrintMe','height=500px,width=600px,scrollbars=1');</script>");
        }
    }
}
