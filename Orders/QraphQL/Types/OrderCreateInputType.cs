using GraphQL.Types;

namespace Orders.QraphQL.Types
{
    public class OrderCreateInputType : InputObjectGraphType
    {
        public OrderCreateInputType()
        {
            Name = "OrderInput";
            Field<NonNullGraphType<StringGraphType>>("name","Name for the order");
            Field<NonNullGraphType<StringGraphType>>("description", "Order description");
            Field<NonNullGraphType<IntGraphType>>("customerId", "Id of the customer who owns this order");
            Field<NonNullGraphType<DateGraphType>>("created", "Date the order was created");
        }
    }
}