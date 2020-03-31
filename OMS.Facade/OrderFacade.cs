using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OMS.DAL;

namespace OMS.Facade
{
    public interface IOrderFacade
    {
        //Order
        List<Order> GetOrderAll();
        Order GetOrderByID(long id);
        List<Order> GetOrderListByChannelID(long channelID);
        List<Order> GetOrderListByChannelIDAndDateRange(long channelID, DateTime startDate, DateTime endDate);

        //OrderDetail
        List<OrderDetail> GetOrderDetailAll();
        List<OrderDetail> GetOrderDetailListByOrderID(long orderID);
        OrderDetail GetOrderDetailByID(int id);

        void Dispose();
    }

    class OrderFacade : BaseFacade,IOrderFacade
    {
        public OrderFacade(OMSDataContext database)
            : base(database)
        {
        }


        #region IOrderFacade Members

        public List<Order> GetOrderAll()
        {
            List<Order> orderList = new List<Order>();
            List<Order> orderListNew = new List<Order>();
            orderList = Database.Orders.Where(o => o.IsRemoved == 0).ToList();
            foreach (Order order in orderList)
            {
                order.Channel = order.Channel;
                orderListNew.Add(order);
            }
            return orderListNew;        
        }

        public Order GetOrderByID(long id)
        {
            Order order = new Order();
            order = Database.Orders.Single(o => o.IID == id && o.IsRemoved == 0);
            order.Channel = order.Channel;
            return order;
        }

        public List<Order> GetOrderListByChannelID(long channelID)
        {
            List<Order> orderList = new List<Order>();
            List<Order> orderListNew = new List<Order>();
            orderList = Database.Orders.Where(o => o.ChannelID == channelID && o.IsRemoved == 0).ToList();
            foreach(Order order in orderList)
            {
                order.Channel = order.Channel;
                orderListNew.Add(order);
            }
            return orderListNew;
        }

        public List<Order> GetOrderListByChannelIDAndDateRange(long channelID, DateTime startDate, DateTime endDate)
        {
            List<Order> orderList = new List<Order>();
            List<Order> orderListNew = new List<Order>();
            orderList = Database.Orders.Where(o => o.ChannelID == channelID && o.Date >= startDate && o.Date < endDate.AddDays(1) && o.IsRemoved == 0).ToList();
            foreach (Order order in orderList)
            {
                order.Channel = order.Channel;
                orderListNew.Add(order);
            }
            return orderListNew;
            
        }

        public List<OrderDetail> GetOrderDetailAll()
        {
            List<OrderDetail> orderDetailList = new List<OrderDetail>();
            List<OrderDetail> orderDetailListNew = new List<OrderDetail>();
            orderDetailList = Database.OrderDetails.Where(o => o.IsRemoved == 0).ToList();
            foreach (OrderDetail orderDetail in orderDetailList)
            {
                orderDetail.Item = orderDetail.Item;
                orderDetailListNew.Add(orderDetail);
            }
            return orderDetailListNew;
        }

        public List<OrderDetail> GetOrderDetailListByOrderID(long orderID)
        {
            List<OrderDetail> orderDetailList = new List<OrderDetail>();
            List<OrderDetail> orderDetailListNew = new List<OrderDetail>();
            orderDetailList = Database.OrderDetails.Where(o => o.OrderID == orderID &&  o.IsRemoved == 0).ToList();
            foreach (OrderDetail orderDetail in orderDetailList)
            {
                orderDetail.Item = orderDetail.Item;
                orderDetailListNew.Add(orderDetail);
            }
            return orderDetailListNew;
        }

        public OrderDetail GetOrderDetailByID(int id)
        {
            OrderDetail orderDetail = new OrderDetail();
            orderDetail = Database.OrderDetails.Single(o => o.IID == id && o.IsRemoved == 0);
            orderDetail.Item = orderDetail.Item;
            return orderDetail;
        }

        #endregion
    }
}
