using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Orders.Models;
using Orders.Services.Abstract;

namespace Orders.Services.Concrete
{
    public class OrderManager : IOrderService
    {
        private IList<Order> _orders;
        private IOrderEventService _eventService;

        public OrderManager(IOrderEventService eventService)
        {
            _eventService = eventService;
            _orders = new List<Order>();
            _orders.Add(new Order("Little Known Ways To Rid Yourself Of NAME",
                "3 Ways You Can Reinvent DESCRIPTION Without Looking Like An Amateur", DateTime.Now, 1, "dec79418-165b-4d22-a5dd-3fb9b9e0dbc9"));
            _orders.Add(new Order("Succeed With NAME In 24 Hours",
                "What Alberto Savoia Can Teach You About DESCRIPTION", DateTime.Now, 2, "45410e98-4374-4749-81aa-a3096c44fc0a"));
            _orders.Add(new Order("What Can You Do About NAME Right Now",
                "5 Surefire Ways DESCRIPTION Will Drive Your Business Into The Ground", DateTime.Now, 3, "8e5a1acd-e32d-47b6-8cf2-8954284fba8b"));
            _orders.Add(new Order("Get Rid of NAME For Good",
                "Should Fixing DESCRIPTION Take 60 Steps?", DateTime.Now, 4, "fafa8932-673e-46c9-b2c1-c05a152e9020"));
        }

        public Task<Order> GetOrderByIdAsync(string id)
        {
            return Task.FromResult(_orders.Single(order => Equals(order.Id, id)));
        }

        private Order GetById(string id)
        {
            var order = _orders.SingleOrDefault(x => Equals(x.Id, id));
            if (order is null)
                throw new ArgumentException(string.Format("Oder ID {0} is invalid", id));
            return order;
        }

        public Task<IEnumerable<Order>> GetOrdersAsync()
        {
            return Task.FromResult(_orders.AsEnumerable());
        }

        public Task<Order> CreateAsync(Order order)
        {
            _orders.Add(order);
            var orderEvent = new OrderEvent(order.Id, order.Name, OrderStatusesEnum.CREATED, order.Created);
            _eventService.AddEvent(orderEvent);
            return Task.FromResult(order);
        }

        public Task<Order> StartAsync(string orderId)
        {
            var order = GetById(orderId);
            order.Start();
            var orderEvent = new OrderEvent(order.Id, order.Name, OrderStatusesEnum.PROCESSING, DateTime.Now);
            _eventService.AddEvent(orderEvent);
            return Task.FromResult(order);
        }

        public Task<Order> CloseAsync(string orderId)
        {
            var order = GetById(orderId);
            order.Close();
            var orderEvent = new OrderEvent(order.Id, order.Name, OrderStatusesEnum.CLOSED, DateTime.Now);
            _eventService.AddEvent(orderEvent);
            return Task.FromResult(order);
        }

        public Task<Order> CompleteAsync(string orderId)
        {
            var order = GetById(orderId);
            order.Complete();
            var orderEvent = new OrderEvent(order.Id, order.Name, OrderStatusesEnum.COMPLETED, DateTime.Now);
            _eventService.AddEvent(orderEvent);
            return Task.FromResult(order);
        }

        public Task<Order> CancelAsync(string orderId)
        {
            var order = GetById(orderId);
            order.Cancel();
            var orderEvent = new OrderEvent(order.Id, order.Name, OrderStatusesEnum.CANCELLED, DateTime.Now);
            _eventService.AddEvent(orderEvent);
            return Task.FromResult(order);
        }
    }
}