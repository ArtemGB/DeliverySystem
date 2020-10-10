using DeliverySystem.DeliveryCore.Data;
using System;
using System.Collections.Generic;

namespace DeliverySystem.DeliveryCore.Management
{
    class OrderManager
    {
        private Dictionary<int, Order> acceptedOrders;
        /// <summary>
        /// Принятые заказы.
        /// </summary>
        public IReadOnlyDictionary<int, Order> AcceptedOrders;

        private Dictionary<int, Order> inProgressOrders;
        /// <summary>
        /// Заказы в работе
        /// </summary>
        public IReadOnlyDictionary<int, Order> InProgressOrders;

        private Dictionary<int, Order> canceledOrders;
        /// <summary>
        /// Отменённые заказы.
        /// </summary>
        public IReadOnlyDictionary<int, Order> CanceledOrders;

        public delegate void OrderCreatedHandler(Order order);
        /// <summary>
        /// Уведомление о создании заказа.
        /// </summary>
        public event OrderCreatedHandler OrderCreatedNotify;

        public delegate void OrderCanceledHandler(Order order);
        /// <summary>
        /// Уведомление об отмене заказа.
        /// </summary>
        public event OrderCanceledHandler OrderCanceledNotify;

        public delegate void OrderStatusChanged(Order order, OrderStatus PreviosStatus, OrderStatus NewStatus);
        /// <summary>
        /// Уведомление о смене статуса заказа.
        /// </summary>
        public event OrderStatusChanged OrderStatusChangedNotify;

        public OrderManager()
        {
            acceptedOrders = new Dictionary<int, Order>();
            AcceptedOrders = acceptedOrders;
            inProgressOrders = new Dictionary<int, Order>();
            InProgressOrders = inProgressOrders;
            canceledOrders = new Dictionary<int, Order>();
            CanceledOrders = canceledOrders;

        }

        /// <summary>
        /// Возвращает новый заказ.
        /// </summary>
        /// <param name="client"></param>
        /// <param name="address1"></param>
        /// <param name="address2"></param>
        /// <returns>Новый заказ.</returns>
        public Order CreateOrder(Client client, string address1, string address2)
        {
            if (client != null)
            {
                Order order = new Order(client, address1, address2);
                acceptedOrders.Add(order.ID, order);
                //Уведомляем о создании нового заказа.
                OrderCreatedNotify?.Invoke(order);
                return order;
            }
            else throw new ArgumentNullException("Параметр client равен null.");
        }

        /// <summary>
        /// Отмена заказа.
        /// </summary>
        /// <param name="order">Заказ для отмены.</param>
        public void CancelOrder(Order order)
        {
            if (order != null)
            {
                switch (order.Status)
                {
                    case OrderStatus.Accepted:
                        acceptedOrders.Remove(order.ID);
                        UpOrderStatus(order, OrderStatus.Canceled);
                        canceledOrders.Add(order.ID, order);
                        //Уведомляем об отмене заказа.
                        OrderCanceledNotify?.Invoke(order);
                        break;
                    case OrderStatus.Complete:
                        throw new ArgumentException("Заказ уже завершён.");
                    case OrderStatus.InProgress:
                        inProgressOrders.Remove(order.ID);
                        UpOrderStatus(order, OrderStatus.Canceled);
                        canceledOrders.Add(order.ID, order);
                        //Уведомляем об отмене заказа.
                        OrderCanceledNotify?.Invoke(order);
                        break;
                    case OrderStatus.Assembly:
                        acceptedOrders.Remove(order.ID);
                        UpOrderStatus(order, OrderStatus.Canceled);
                        canceledOrders.Add(order.ID, order);
                        //Уведомляем об отмене заказа.
                        OrderCanceledNotify?.Invoke(order);
                        break;
                    default:
                        break;
                }
            }
            else throw new ArgumentNullException("Параметр order равен null.");
        }


        //ДОДЕЛАТЬ!!!!
        public void UpOrderStatus(Order order, OrderStatus newStatus)
        {
            if((int)order.Status < (int)newStatus)
            {
                OrderStatus PrevStatus = order.Status;
                order.Status = newStatus;
                OrderStatusChangedNotify(order, PrevStatus, newStatus);
            }
        }

    }
}
