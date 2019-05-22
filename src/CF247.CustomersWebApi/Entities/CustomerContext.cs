using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Microsoft.EntityFrameworkCore;

namespace CF247.CustomersWebApi.Entities
{
    public class CustomerContext : DbContext
    {
        public CustomerContext()
        {

        }

        public CustomerContext(DbContextOptions<CustomerContext> options)
           : base(options)
        {

        }

        public DbSet<Customer> Customers { get; set; }
    }
}
