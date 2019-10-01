using System;

namespace Orders.Models
{
    public class Order
    {
        public Order(string id, string name, string description, DateTime created, int customerId)
        {
            Id = id;
            Name = name;
            Description = description;
            Created = created;
            CustomerId = customerId;
            Status = OrderStatusesEnum.CREATED;
        }

        public string Id { get; private set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Created { get; private set; }
        public int CustomerId { get; set; }
        public OrderStatusesEnum Status { get; set; }
    }
}