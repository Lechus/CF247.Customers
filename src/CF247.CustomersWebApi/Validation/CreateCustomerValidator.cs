using CF247.CustomersWebApi.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CF247.CustomersWebApi.Validation
{
    public class CreateCustomerValidator : AbstractValidator<Customer>
    {
        public CreateCustomerValidator()
        {
            RuleFor(c => c.EmailAddress)
                .NotNull()
                .NotEmpty()
                .Length(1, 100)
                .EmailAddress();

            RuleFor(c => c.FirstName)
                .NotNull()
                .NotEmpty()
                .Length(1, 50)
                .Must(c => IsAlpha(c));

            RuleFor(c => c.LastName)
                .NotNull()
                .NotEmpty()
                .Length(1, 50)
                .Must(c => IsAlpha(c));

            RuleFor(c => c.Password)
                .Password();
        }

        private bool IsAlpha(string nameAttribute)
        {
            if (!string.IsNullOrWhiteSpace(nameAttribute))
                return Regex.IsMatch(nameAttribute, "^[A-Za-z]+$");
            else
                return false;
        }
    }
}
