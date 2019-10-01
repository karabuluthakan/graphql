using GraphQL;
using Orders.QraphQL.Mutations;
using Orders.QraphQL.Queries;
using Orders.QraphQL.Subscriptions;

namespace Orders.QraphQL.Schemas
{
    public class OrdersSchema : GraphQL.Types.Schema
    {
        public OrdersSchema(OrdersQuery query, OrdersMutation mutation, OrderSubscription subscription,
            IDependencyResolver resolver)
        {
            Query = query;
            DependencyResolver = resolver;
            Mutation = mutation;
            Subscription = subscription;
        }
    }
}