using CF247.CustomersWebApi.Entities;
using CF247.CustomersWebApi.Validation;
using FluentAssertions;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace CF247.CustomersWebApi.Tests.Unit.Validation
{
    public class PasswordValidationTests
    {
        public class Validate
        {
            [Theory()]
            [InlineData(null, null, null, null, false)]
            [InlineData("hfhdkjs6", "hfdskjhsdkj4", "fjdsh@hjdkhsk.com", "jjfd833D", false)]
            [InlineData("David", "Smith", "david.smith@test.com", "ASDFtyu789", true)]
            [InlineData("David Edward", "Smith", "david.smith@test.com", "ASDFtyu789", false)]
            [InlineData("David", "Smith Wood", "david.smith@test.com", "ASDFtyu789", false)]
            public void Customer_IsValidated_IsValid(
                string fistName, 
                string lastName, 
                string emailAddress,
                string password, 
                bool validCustomer)
            {
                var customer = new Customer
                {
                    FirstName = fistName,
                    LastName = lastName,
                    EmailAddress = emailAddress,
                    Password = password
                };

                var validator = new CreateCustomerValidator();
                var results = validator.Validate(customer);

                results.IsValid.Should().Be(validCustomer);
            }
        }
    }
}
