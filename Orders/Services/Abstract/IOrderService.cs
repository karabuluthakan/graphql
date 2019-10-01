using System.Collections.Generic;
using System.Threading.Tasks;
using Orders.Models;

namespace Orders.Services.Abstract
{
    public interface IOrderService
    {
        Task<Order> GetOrderByIdAsync(string id);
        Task<IEnumerable<Order>> GetOrdersAsync();
        Task<Order> CreateAsync(Order order);
        Task<Order> StartAsync(string orderId);
        Task<Order> CloseAsync(string orderId);
        Task<Order> CompleteAsync(string orderId);
        Task<Order> CancelAsync(string orderId);
    }
}