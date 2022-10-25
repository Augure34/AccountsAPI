using Account.API.Models;
using Account.API.Specifications;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using NUnit.Framework;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace Account.Test.IntegrationTests
{
    public class CustomerControllerIntegrationTests
    {
        HttpClient _clientUnderTest;

        [SetUp]
        public void Setup()
        {
            var application = new WebApplicationFactory<Program>();
            _clientUnderTest = application.CreateClient();
        }

        [TestCase("GRI")]
        public async Task GetCustomer_WithExistingId_ShouldReturnSuccessCode(string customerId)
        {
            var test = await _clientUnderTest.GetAsync($"/customers/{customerId}");
            Assert.That(test, Is.Not.Null);
            Assert.That(test.IsSuccessStatusCode, Is.True);
        }

        [TestCase("GRI")]
        public async Task GetCustomer_WithExistingId_ShouldReturnCustomer(string customerId)
        {
            var responseUnderTest = await _clientUnderTest.GetAsync($"/customers/{customerId}");

            var resultUnderTest = JsonSerializer.Deserialize<Customer>(responseUnderTest.Content.ReadAsStream(), new JsonSerializerOptions(JsonSerializerDefaults.Web));

            Assert.That(resultUnderTest, Is.Not.Null);
        }

        [TestCase("GRI")]
        public async Task GetCustomer_WithExistingId_ShouldReturnCustomerWithSameId(string customerId)
        {
            var responseUnderTest = await _clientUnderTest.GetAsync($"/customers/{customerId}");

            var resultUnderTest = JsonSerializer.Deserialize<Customer>(responseUnderTest.Content.ReadAsStream(), new JsonSerializerOptions(JsonSerializerDefaults.Web));

            Assert.That(resultUnderTest?.CustomerId, Is.EqualTo(customerId));
        }
    }
}