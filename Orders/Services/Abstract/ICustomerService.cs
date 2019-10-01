using System.Collections.Generic;
using System.Threading.Tasks;
using Orders.Models;

namespace Orders.Services.Abstract
{
    public interface ICustomerService
    {
        Customer GetCustomerById(int id);
        Task<Customer> GetCustomerByIdAsync(int id);
        Task<IEnumerable<Customer>> GetCustomersAsync();
    }
}