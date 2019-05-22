using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CF247.CustomersWebApi.Tests.Integration.Controllers
{
    /// <summary>
    /// Used sample code from this location
    /// https://fullstackmark.com/post/20/painless-integration-testing-with-aspnet-core-web-api
    /// </summary>
    public class PlayersControllerIntegrationTests : IClassFixture<CustomWebApplicationFactory<Startup>>
    {
        private readonly HttpClient _client;

        public PlayersControllerIntegrationTests(CustomWebApplicationFactory<Startup> factory)
        {
            _client = factory.CreateClient();
        }

        [Fact]
        public async Task CanGetPlayers()
        {
            // The endpoint or route of the controller action.
            var httpResponse = await _client.GetAsync("/api/customers");

            // Must be successful.
            httpResponse.EnsureSuccessStatusCode();

            // Deserialize and examine results.
            var stringResponse = await httpResponse.Content.ReadAsStringAsync();
            var players = JsonConvert.DeserializeObject<IEnumerable<Models.CustomerDto>>(stringResponse);
            Assert.Contains(players, p => p.FirstName == "David");
            Assert.Contains(players, p => p.FirstName == "Jamie");
        }


        [Fact]
        public async Task CanGetPlayerById()
        {
            // The endpoint or route of the controller action.
            var httpResponse = await _client.GetAsync("/api/customers/A56F5F93-3D50-49DD-BBF7-AF7BE44FA66C");

            // Must be successful.
            httpResponse.EnsureSuccessStatusCode();

            // Deserialize and examine results.
            var stringResponse = await httpResponse.Content.ReadAsStringAsync();
            var customer = JsonConvert.DeserializeObject<Models.CustomerDto>(stringResponse);
            Assert.Equal(Guid.Parse("A56F5F93-3D50-49DD-BBF7-AF7BE44FA66C"), customer.CustomerId);
            Assert.Equal("Jamie", customer.FirstName);
        }

        [Fact]
        public async Task CanCreateCustomer()
        {
            var customer = new Models.CustomerForCreationDto
            {
                EmailAddress = "Bill@microsoft.com",
                FirstName = "Bill",
                LastName = "Gates",
                Password = "68*Tb1ERv#Yg#d4D"
            };

            var customerToString = JsonConvert.SerializeObject(customer);

            // The endpoint or route of the controller action.
            var httpResponse = await _client.PostAsync(
                "/api/customers",
                new StringContent(
                    customerToString, 
                    Encoding.UTF8, 
                    "application/json")
                );

            // Must be successful.
            httpResponse.EnsureSuccessStatusCode();

            var stringResponse = await httpResponse.Content.ReadAsStringAsync();
            var createdCustomer = JsonConvert.DeserializeObject<Models.CustomerDto>(stringResponse);

            Assert.True(httpResponse.Headers.Contains("Location"));
            Assert.Equal(customer.EmailAddress, createdCustomer.EmailAddress);
        }

        [Fact]
        public async Task CanUpdateCustomer()
        {
            var customer = new Models.CustomerForCreationDto
            {
                EmailAddress = "jamie@admin.com",
                FirstName = "Jamie",
                LastName = "Oliver",
                Password = "NewPassword1"
            };

            var customerToString = JsonConvert.SerializeObject(customer);

            var httpResponse = await _client.PutAsync(
                "/api/customers/A56F5F93-3D50-49DD-BBF7-AF7BE44FA66C",
                new StringContent(
                    customerToString,
                    Encoding.UTF8,
                    "application/json"));

            // Must be successful.
            httpResponse.EnsureSuccessStatusCode();
        }
    }
}
