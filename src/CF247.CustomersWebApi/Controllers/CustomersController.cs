using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CF247.CustomersWebApi.Entities;
using CF247.CustomersWebApi.Models;
using CF247.CustomersWebApi.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CF247.CustomersWebApi.Controllers
{
    [Route("api/customers")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly ILogger<CustomersController> _logger;
        public CustomersController(ICustomerRepository customerRepository, ILogger<CustomersController> logger)
        {
            _customerRepository = customerRepository;
            _logger = logger;
        }

        // GET api/customers
        [HttpGet]
        public ActionResult<IEnumerable<CustomerDto>> GetCustomers()
        {
            _logger.LogInformation(100, "Getting all customers started");

            var customersFromRepo = _customerRepository.GetCustomers();

            var customers = AutoMapper.Mapper.Map<IEnumerable<CustomerDto>>(customersFromRepo);

            _logger.LogInformation(100, $"Getting all customers finished. There were {customers?.Count()} found");

            return Ok(customers);
        }

        [HttpGet("{customerid}", Name = "GetCustomer")]
        public ActionResult<CustomerDto> GetCustomer(Guid customerId)
        {
            _logger.LogInformation($"Starting to get customer {customerId}");

            var customerFromRepo = _customerRepository.GetCustomerById(customerId);

            if (customerFromRepo != null)
            {
                var customer = AutoMapper.Mapper.Map<CustomerDto>(customerFromRepo);
                _logger.LogInformation($"Customer {customerId} was found and returned");
                return Ok(customer);
            }
            else
            {
                _logger.LogInformation($"Customer {customerId} was not found");
                return NotFound();
            }
        }

        [HttpPost]
        public ActionResult CreateCustomer([FromBody] CustomerForCreationDto customerForCreation)
        {
            if (customerForCreation == null)
            {
                _logger.LogWarning("An invalid customer object was received for create");
                return BadRequest();
            }
            else
            {
                _logger.LogInformation("Starting to process the new customer");
            }

            var customerRepo = AutoMapper.Mapper.Map<Customer>(customerForCreation);

            if (!ModelState.IsValid)
            {
                _logger.LogInformation("Creating new customer failed validation");
                return BadRequest(ModelState);
            }

            _customerRepository.AddCustomer(customerRepo);

            if (!_customerRepository.Save())
            {
                //Global error handler will return expected status code
                throw new Exception("Creating customer failed on save");
            }

            var customerToReturn = AutoMapper.Mapper.Map<CustomerDto>(customerRepo);

            _logger.LogInformation($"New customer with Id {customerToReturn.CustomerId} was created");
            return CreatedAtRoute("GetCustomer", 
                new { customerid = customerToReturn.CustomerId }, 
                customerToReturn);
        }

        [HttpPut("{customerid}")]
        public ActionResult UpdateCustomer(Guid customerid, [FromBody] CustomerForCreationDto customer)
        {
            if (customer == null)
            {
                _logger.LogWarning("An invalid customer object was received for update");
                return BadRequest();
            }
            else
            {
                _logger.LogInformation($"Starting to update customer {customerid}");
            }

            var customerFromRepo = _customerRepository.GetCustomerById(customerid);

            if (customerFromRepo == null)
            {
                _logger.LogInformation($"Customer {customerid} was not found to update");
                return NotFound();
            }

            AutoMapper.Mapper.Map(customer, customerFromRepo);

            if (!ModelState.IsValid)
            {
                _logger.LogInformation("Updating new customer failed validation");
                return BadRequest(ModelState);
            }

            _customerRepository.UpdateCustomer(customerFromRepo);

            if (!_customerRepository.Save())
            {
                throw new Exception("An unexpected error occured when updating the customer");
            }

            _logger.LogInformation($"Customer {customerid} successfully updated");
            return NoContent();
        }
    }
}
