using CF247.CustomersWebApi.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CF247.CustomersWebApi.Tests.Integration
{
    public static class SeedData
    {
        public static void PopulateTestData(CustomerContext dbContext)
        {
            dbContext.Customers.Add(
                new Customer
                {
                    FirstName = "David",
                    LastName = "Gray",
                    EmailAddress = "david.gray@msn.com",
                    Password = "HiceR@sHwJ^1M4eV",
                    CustomerId = Guid.Parse("D28903F3-AD18-4BD4-B479-1A395F7B212F")
                });
            dbContext.Customers.Add(
                new Customer
                {
                    FirstName = "Jamie",
                    LastName = "Oliver",
                    EmailAddress = "jamie.oliver@admin.com",
                    Password = "Kd@d#xUN19#O*OO9",
                    CustomerId = Guid.Parse("A56F5F93-3D50-49DD-BBF7-AF7BE44FA66C")
                });
            dbContext.SaveChanges();
        }
    }
}
