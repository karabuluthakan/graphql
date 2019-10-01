using GraphQL.Types;
using Orders.Models;
using Orders.Services.Abstract;

namespace Orders.QraphQL.Types
{
    public class OrderType : ObjectGraphType<Order>
    {
        public OrderType(ICustomerService customerService)
        {
            Field(x => x.Id);
            Field(x => x.Name);
            Field(x => x.Description);
            Field<CustomerType>("customer",
                resolve: context => customerService.GetCustomerByIdAsync(context.Source.CustomerId));
            Field(x => x.Created).Description("Created time");
            
        }
    }
}