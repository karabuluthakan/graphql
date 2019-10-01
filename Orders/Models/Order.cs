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
            Status = OrderStatuses.CREATED;
        }

        public string Id { get; private set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Created { get; private set; }
        public int CustomerId { get; set; }
        public OrderStatuses Status { get; set; }
    }

    [Flags]
    public enum OrderStatuses
    {
        CREATED = 2,
        PROCESSING = 4,
        COMPLETED = 8,
        CANCELLED = 16,
        CLOSED = 32
    }
}