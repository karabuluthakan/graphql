using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Orders.Models;
using Orders.Services.Abstract;

namespace Orders.Services.Concrete
{
    public class OrderManager : IOrderService
    {
        private IList<Order> _orders;

        public OrderManager()
        {
            _orders = new List<Order>();
            _orders.Add(new Order("dec79418-165b-4d22-a5dd-3fb9b9e0dbc9","Little Known Ways To Rid Yourself Of NAME","3 Ways You Can Reinvent DESCRIPTION Without Looking Like An Amateur",DateTime.Now,1));
            _orders.Add(new Order("45410e98-4374-4749-81aa-a3096c44fc0a","Succeed With NAME In 24 Hours","What Alberto Savoia Can Teach You About DESCRIPTION",DateTime.Now,2));
            _orders.Add(new Order("8e5a1acd-e32d-47b6-8cf2-8954284fba8b","What Can You Do About NAME Right Now","5 Surefire Ways DESCRIPTION Will Drive Your Business Into The Ground",DateTime.Now,3));
            _orders.Add(new Order("fafa8932-673e-46c9-b2c1-c05a152e9020","Get Rid of NAME For Good","Should Fixing DESCRIPTION Take 60 Steps?",DateTime.Now,4));
        }
        
        public Task<Order> GetOrderByIdAsync(string id)
        {
            return Task.FromResult(_orders.Single(order=>Equals(order.Id,id)));
        }

        public Task<IEnumerable<Order>> GetOrdersAsync()
        {
            return Task.FromResult(_orders.AsEnumerable());
        }
    }
}