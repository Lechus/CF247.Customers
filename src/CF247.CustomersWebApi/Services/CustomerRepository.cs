using CF247.CustomersWebApi.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CF247.CustomersWebApi.Services
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly CustomerContext _context;

        public CustomerRepository(CustomerContext context)
        {
            _context = context;
        }

        public Customer GetCustomerById(Guid customerId)
        {
            return _context.Customers.FirstOrDefault(a => a.CustomerId == customerId);
        }

        public IEnumerable<Customer> GetCustomers()
        {
            return _context.Customers.OrderBy(a => a.FirstName).ThenBy(a => a.LastName);
        }

        public Customer CustomerExists(string emailAddress)
        {
            return _context.Customers.FirstOrDefault(a => a.EmailAddress == emailAddress);
        }

        public void AddCustomer(Customer customer)
        {
            customer.CustomerId = Guid.NewGuid();

            _context.Customers.Add(customer);
        }

        public void UpdateCustomer(Customer customer)
        {
            //no code in this implementation
        }

        public bool Save()
        {
            return (_context.SaveChanges() > 0);
        }
    }
}
