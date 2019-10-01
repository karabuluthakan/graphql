using GraphQL.Types;
using Orders.Models;
using Orders.QraphQL.Enums;

namespace Orders.QraphQL.Types
{
    public class OrderEventType : ObjectGraphType<OrderEvent>
    {
        public OrderEventType()
        {
            Field(x => x.Id).Description("Event Id");
            Field(x => x.OrderName).Description("Event Order Name");
            Field(x => x.OrderId).Description("Event Order Id");
            Field<OrderStatusesGraphEnum>("status","Status for the order");
            Field(x => x.Timestamp).Description("When the event occured");
        }
    }
}