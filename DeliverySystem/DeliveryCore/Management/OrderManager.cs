using DeliverySystem.DeliveryCore.Data;
using System;
using System.Collections.Generic;

namespace DeliverySystem.DeliveryCore.Management
{
    class OrderManager
    {
        private Dictionary<int, Order> acceptedOrders;
        public IReadOnlyDictionary<int, Order> AcceptedOrders;

        private Dictionary<int, Order> inProgressOrders;
        public IReadOnlyDictionary<int, Order> InProgressOrders;

        private Dictionary<int, Order> canceledOrders;
        public IReadOnlyDictionary<int, Order> CanceledOrders;

        public OrderManager()
        {
            acceptedOrders = new Dictionary<int, Order>();
            AcceptedOrders = acceptedOrders;
            inProgressOrders = new Dictionary<int, Order>();
            InProgressOrders = inProgressOrders;
            canceledOrders = new Dictionary<int, Order>();
            CanceledOrders = canceledOrders;

        }

        public Order CreateOrder(Client client, string address1, string address2)
        {
            Order order = new Order(client, address1, address2);
            acceptedOrders.Add(order.ID, order);
            return order;
        }

        public void CancelOrder(int ID)
        {

        }
    }
}
