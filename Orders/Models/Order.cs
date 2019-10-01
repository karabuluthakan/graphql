using System;

namespace Orders.Models
{
    public class Order
    {
        public Order(string name, string description, DateTime created, int customerId, string id = null)
        {
            if (id == null)
                id = Guid.NewGuid().ToString();

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

        public void Start()
        {
            Status = OrderStatusesEnum.PROCESSING;
        }

        public void Complete()
        {
            Status = OrderStatusesEnum.COMPLETED;
        }

        public void Cancel()
        {
            Status = OrderStatusesEnum.CANCELLED;
        }

        public void Close()
        {
            Status = OrderStatusesEnum.CLOSED;
        }
    }
}