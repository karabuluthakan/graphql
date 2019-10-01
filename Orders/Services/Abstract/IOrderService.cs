using System.Collections.Generic;
using System.Threading.Tasks;
using Orders.Models;

namespace Orders.Services.Abstract
{
    public interface IOrderService
    {
        Task<Order> GetOrderByIdAsync(string id);
        Task<IEnumerable<Order>> GetOrdersAsync();
    }
}