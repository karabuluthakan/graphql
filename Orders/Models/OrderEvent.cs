using System;

namespace Orders.Models
{
    public class OrderEvent
    {
        public OrderEvent(string id, string orderName, string orderId, OrderStatusesEnum status, DateTime timestamp)
        {
            Id = id;
            OrderName = orderName;
            OrderId = orderId;
            Status = status;
            Timestamp = timestamp;
        }

        public string Id { get; private set; }
        public string OrderName { get; set; }
        public string OrderId { get; set; }
        public OrderStatusesEnum Status { get; set; }
        public DateTime Timestamp { get; set; }
    }
}