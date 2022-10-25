using Account.API.Models;
using Account.API.Specifications;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using NUnit.Framework;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using System.Linq;
using System.Net.Http.Json;
using System;

namespace Account.Test.IntegrationTests
{
    public class CustomerAccountControllerIntegrationTests
    {
        HttpClient _clientUnderTest;

        [SetUp]
        public void Setup()
        {
            var application = new WebApplicationFactory<Program>();
            _clientUnderTest = application.CreateClient();
        }

        #region GetCustomerAccounts

        [TestCase("GRI")]
        public void GetCustomerAccounts_WithExistingCustomerId_ShouldReturnSuccessCode(string customerId)
        {
            var responseUnderTest = GetCustomerAccounts(customerId);
            Assert.That(responseUnderTest, Is.Not.Null);
            Assert.That(responseUnderTest.IsSuccessStatusCode, Is.True);
        }

        [TestCase("GRI")]
        public void GetCustomerAccounts_WithExistingCustomerId_ShouldReturnCustomerAccounts(string customerId)
        {
            var resultUnderTest = DeserializedGetCustomerAccounts(customerId);

            Assert.That(resultUnderTest, Is.Not.Null);
            CollectionAssert.AllItemsAreInstancesOfType(resultUnderTest, typeof(CustomerAccount));
        }

        [TestCase("GRI")]
        public void GetCustomerAccounts_WithExistingCustomerId_ShouldReturnUniqueCollection(string customerId)
        {
            var resultUnderTest = DeserializedGetCustomerAccounts(customerId);

            CollectionAssert.AllItemsAreUnique(resultUnderTest);
        }

        [TestCase("GRI")]
        public void GetCustomerAccounts_WithExistingCustomerId_ShouldReturnCustomerAccount(string customerId)
        {
            var resultUnderTest = DeserializedGetCustomerAccounts(customerId);

            Assert.That(resultUnderTest?.All(x => x.CustomerId == customerId), Is.True);
        }

        #endregion

        #region PutCustomerAccount

        [TestCase("GRI", 0)]
        public void PutCustomerAccount_WithExistingCustomerIdAndValidBalance_ShouldReturnSuccessCode(string customerId, decimal initialBalance)
        {
            var responseUnderTest = PutCustomerAccount(customerId, initialBalance);
            Assert.That(responseUnderTest, Is.Not.Null);
            Assert.That(responseUnderTest.IsSuccessStatusCode, Is.True);
        }

        [TestCase("GRI", 0)]
        [TestCase("GRI", 50)]
        [TestCase("GRI", 150)]
        [TestCase("GRI", 200)]
        public void PutCustomerAccount_WithExistingCustomerIdAndValidBalance_ShouldReturnExpectedAccount(string customerId, decimal initialBalance)
        {
            var resultUnderTest = DeserializedPutCustomerAccount(customerId, initialBalance);
            Assert.That(resultUnderTest, Is.Not.Null);
            Assert.IsTrue(resultUnderTest?.AccountType == AccountTypeEnum.Undefined);
            Assert.IsTrue(resultUnderTest?.CustomerId == customerId);
            Assert.IsTrue(resultUnderTest?.Balance == initialBalance);
        }

        [TestCase("GRI", 300)]
        [TestCase("GRI", 100000)]
        public void PutCustomerAccount_WithExistingCustomerIdButInvalidBalance_ShouldThrowException(string customerId, decimal initialBalance)
        {
            Assert.Catch<Exception>(() => DeserializedPutCustomerAccount(customerId, initialBalance));
        }

        #endregion


        #region ControllerMethods
        private HttpResponseMessage GetCustomerAccounts(string customerId) => 
            _clientUnderTest.GetAsync($"/customers/{customerId}/customerAccounts").Result;

        private IEnumerable<CustomerAccount>? DeserializedGetCustomerAccounts(string customerId) => 
            JsonSerializer.Deserialize<IEnumerable<CustomerAccount>>(GetCustomerAccounts(customerId).Content.ReadAsStream(), new JsonSerializerOptions(JsonSerializerDefaults.Web));


        private HttpResponseMessage PutCustomerAccount(string customerId, decimal initialBalance) =>
            _clientUnderTest.PutAsync($"/customers/{customerId}/customerAccounts", JsonContent.Create(JsonSerializer.Serialize(initialBalance))).Result;

        private CustomerAccount? DeserializedPutCustomerAccount(string customerId, decimal initialBalance) => 
            JsonSerializer.Deserialize<CustomerAccount>(PutCustomerAccount(customerId, initialBalance).Content.ReadAsStream(), new JsonSerializerOptions(JsonSerializerDefaults.Web));

        #endregion
    }
}