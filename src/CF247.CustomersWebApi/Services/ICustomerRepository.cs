using CF247.CustomersWebApi.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CF247.CustomersWebApi.Services
{
    public interface ICustomerRepository
    {
        IEnumerable<Customer> GetCustomers();
        Customer GetCustomerById(Guid customerId);
        void AddCustomer(Customer customer);
        bool Save();
        void UpdateCustomer(Customer customer);
    }
}
