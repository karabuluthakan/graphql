using GraphQL.Types;
using Orders.QraphQL.Types;
using Orders.Services.Abstract;

namespace Orders.QraphQL.Queries
{
    public class OrdersQuery : ObjectGraphType<object>
    {
        public OrdersQuery(IOrderService orderService, ICustomerService customerService,
            IOrderEventService eventService)
        {
            Name = "Query";
            Field<ListGraphType<OrderType>>("orders", resolve: context => orderService.GetOrdersAsync());

            Field<OrderType>("order",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<StringGraphType>> {Name = "id"}),
                resolve: context => orderService.GetOrderByIdAsync(context.GetArgument<string>("id")));

            Field<ListGraphType<CustomerType>>("customers", resolve: context => customerService.GetCustomersAsync());

            Field<CustomerType>("customer",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<IntGraphType>> {Name = "id"}),
                resolve: context => customerService.GetCustomerById(context.GetArgument<int>("id")));
        }
    }
}