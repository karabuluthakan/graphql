using System;
using GraphQL.Types;
using Orders.Models;
using Orders.QraphQL.Types;
using Orders.Services.Abstract;

namespace Orders.QraphQL.Mutations
{
    public class OrdersMutation : ObjectGraphType<object>
    {
        public OrdersMutation(IOrderService orderService, ICustomerService customerService)
        {
            Name = "Mutation";

            Field<OrderType>("createOrder",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<OrderCreateInputType>> {Name = "order"}),
                resolve: context =>
                {
                    var orderInput = context.GetArgument<OrderCreateInput>("order");
                    var order = new Order(orderInput.Name, orderInput.Description, orderInput.Created,
                        orderInput.CustomerId);
                    return orderService.CreateAsync(order);
                },
                description: "Create a new order");

            FieldAsync<OrderType>("startOrder",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<StringGraphType>> {Name = "orderId"}),
                resolve: async context =>
                {
                    var orderId = context.GetArgument<String>("orderId");
                    return await context.TryAsyncResolve(async x => await orderService.StartAsync(orderId));
                },
                description: "Start an order");

            FieldAsync<OrderType>("completeOrder",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<StringGraphType>> {Name = "orderId"}),
                resolve: async context =>
                {
                    var orderId = context.GetArgument<String>("orderId");
                    return await context.TryAsyncResolve(async x => await orderService.CompleteAsync(orderId));
                },
                description: "Complete an order"
            );

            FieldAsync<OrderType>("cancelOrder",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<StringGraphType>> {Name = "orderId"}),
                resolve: async context =>
                {
                    var orderId = context.GetArgument<String>("orderId");
                    return await context.TryAsyncResolve(async x => await orderService.CancelAsync(orderId));
                },
                description: "Cancel an order"
            );
        }
    }
}