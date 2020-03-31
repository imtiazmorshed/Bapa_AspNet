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

namespace OMS.WebClient.Controls
{
    public partial class wucChannelOrderDetail : System.Web.UI.UserControl
    {
        

        public long CurrentOrderID
        {
            get
            {
                if (ViewState["OrderID"] == null)
                    return -1;
                else
                    return Convert.ToInt64(ViewState["OrderID"].ToString());
            }
            set
            {
                ViewState["OrderID"] = value;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserID"] == null)
            {
                Session.Abandon();
                Response.Redirect("../Login.aspx?" + "&msgSessionOut=1");
            }
            else
            {
                if (!IsPostBack)
                {
                    if (CurrentOrderID > 0)
                    {
                        LoadControl();

                    }
                }
            }
        }
        public void LoadOrderDetail()
        {
            if (CurrentOrderID > 0)
            {
                LoadControl();
                
            }
        }

        

        private void LoadControl()
        {
            Order order = new Order();
            List<OrderDetail> orderDetailList = new List<OrderDetail>();
            using(TheFacade _facade = new TheFacade())
            {
                order = _facade.OrderFacade.GetOrderByID(CurrentOrderID);
                orderDetailList = _facade.OrderFacade.GetOrderDetailListByOrderID(CurrentOrderID);
            }
            if (orderDetailList.Count > 0)
            {
                lvOrderDetails.DataSource = orderDetailList;
                lvOrderDetails.DataBind();
            }
            
            lblChannelName.Text = order.Channel.Name;
            lblChannelCode.Text = order.Channel.Code;
            lblOrderNo.Text = order.OrderNo;
            lblDate.Text = order.Date.ToShortDateString();
        }

        protected void lvOrderDetails_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            if (e.Item.ItemType == ListViewItemType.DataItem)
            {
                ListViewDataItem currentItem = (ListViewDataItem)e.Item;
                OrderDetail orderDetail = (OrderDetail)((ListViewDataItem)(e.Item)).DataItem;

                Label lblItemCode = (Label)currentItem.FindControl("lblItemCode");
                Label lblItemName = (Label)currentItem.FindControl("lblItemName");
                Label lblQuantity = (Label)currentItem.FindControl("lblQuantity");

                lblItemCode.Text = orderDetail.Item.Code;
                lblItemName.Text = orderDetail.Item.Name;
                lblQuantity.Text = orderDetail.Quantity.ToString();                
            }
        }

        protected void lvOrderDetails_ItemCommand(object sender, ListViewCommandEventArgs e)
        {

        }
    }
}