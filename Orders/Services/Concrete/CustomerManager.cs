using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Orders.Models;
using Orders.Services.Abstract;

namespace Orders.Services.Concrete
{
    public class CustomerManager : ICustomerService
    {
        private IList<Customer> _customers;

        public CustomerManager()
        {
            _customers = new List<Customer>();
            _customers.Add(new Customer(1, "No More Mistakes With CUSTOMER NAME"));
            _customers.Add(new Customer(2, "The Secret Of CUSTOMER NAME"));
            _customers.Add(new Customer(3, "Here Is A Method That Is Helping CUSTOMER NAME"));
            _customers.Add(new Customer(4, "Don't Fall For This CUSTOMER NAME Scam"));
        }

        public Customer GetCustomerById(int id)
        {
            return GetCustomerByIdAsync(id).Result;
        }

        public Task<Customer> GetCustomerByIdAsync(int id)
        {
            return Task.FromResult(_customers.Single(customer => Equals(customer.Id, id)));
        }

        public Task<IEnumerable<Customer>> GetCustomersAsync()
        {
            return Task.FromResult(_customers.AsEnumerable());
        }
    }
}