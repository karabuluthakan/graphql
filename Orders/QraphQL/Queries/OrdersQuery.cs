using GraphQL.Types;
using Orders.QraphQL.Types;
using Orders.Services.Abstract;

namespace Orders.QraphQL.Queries
{
    public class OrdersQuery : ObjectGraphType<object>
    {
        public OrdersQuery(IOrderService orderService)
        {
            Name = "Query";
            Field<ListGraphType<OrderType>>("orders",resolve:context=>orderService.GetOrdersAsync());
        }
    }
}