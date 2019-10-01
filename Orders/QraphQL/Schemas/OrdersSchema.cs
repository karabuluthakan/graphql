using GraphQL;
using Orders.QraphQL.Queries;

namespace Orders.QraphQL.Schemas
{
    public class OrdersSchema : GraphQL.Types.Schema
    {
        public OrdersSchema(OrdersQuery query,IDependencyResolver resolver)
        {
            Query = query;
            DependencyResolver = resolver;
        }
        
        
    }
}