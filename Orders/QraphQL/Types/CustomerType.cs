using GraphQL.Types;
using Orders.Models;

namespace Orders.QraphQL.Types
{
    public class CustomerType : ObjectGraphType<Customer>
    {
        public CustomerType()
        {
            Field(x => x.Id).Description("Id");
            Field(x=>x.Name).Description("Name");
        }
    }
}