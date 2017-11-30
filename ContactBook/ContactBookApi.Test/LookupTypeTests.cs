using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using ContactBookApi.Controllers;
using ContactBookApi.Models;
using ContactBookApi.Test.Config;
using ContactBookApi.Test.Mocks;
using System.Threading.Tasks;

namespace ContactBookApi.Test
{
    [TestClass]
    public class LookupTypeTests
    {
        [TestMethod]
        public async Task GetAddressTypesReturnsValidResponse()
        {
            using (var context = SqlLiteInMemory.GetTestContext())
            {
                context.SeedDbAddressTypes();
                var lookupController = new LookupController(context);

                var result = await lookupController.GetAddressTypes();

                Assert.IsInstanceOfType(result, typeof(OkObjectResult));
                var ok = (OkObjectResult)result;
                Assert.IsInstanceOfType(ok.Value, typeof(List<AddressType>));
                var listResult = (List<AddressType>)ok.Value;
                Assert.AreEqual(2, listResult.Count);
            }
        }

        [TestMethod]
        public async Task GetEmailTypesReturnsValidResponse()
        {
            using (var context = SqlLiteInMemory.GetTestContext())
            {
                context.SeedDbEmailTypes();
                var lookupController = new LookupController(context);

                var result = await lookupController.GetEmailTypes();

                Assert.IsInstanceOfType(result, typeof(OkObjectResult));
                var ok = (OkObjectResult)result;
                Assert.IsInstanceOfType(ok.Value, typeof(List<EmailType>));
                var listResult = (List<EmailType>)ok.Value;
                Assert.AreEqual(2, listResult.Count);
            }
        }

        [TestMethod]
        public async Task GetEventTypesReturnsValidResponse()
        {
            using (var context = SqlLiteInMemory.GetTestContext())
            {
                context.SeedDbEventTypes();
                var lookupController = new LookupController(context);

                var result = await lookupController.GetEventTypes();

                Assert.IsInstanceOfType(result, typeof(OkObjectResult));
                var ok = (OkObjectResult)result;
                Assert.IsInstanceOfType(ok.Value, typeof(List<EventType>));
                var listResult = (List<EventType>)ok.Value;
                Assert.AreEqual(3, listResult.Count);
            }
        }

        [TestMethod]
        public async Task GetPhoneTypesReturnsValidResponse()
        {
            using (var context = SqlLiteInMemory.GetTestContext())
            {
                context.SeedDbPhoneTypes();
                var lookupController = new LookupController(context);

                var result = await lookupController.GetPhoneTypes();

                Assert.IsInstanceOfType(result, typeof(OkObjectResult));
                var ok = (OkObjectResult)result;

                Assert.IsInstanceOfType(ok.Value, typeof(List<PhoneType>));
                var listResult = (List<PhoneType>)ok.Value;

                Assert.AreEqual(5, listResult.Count);
            }
        }

        [TestMethod]
        public async Task GetWebsiteTypesReturnsValidResponse()
        {
            using (var context = SqlLiteInMemory.GetTestContext())
            {
                context.SeedDbWebsiteTypes();
                var lookupController = new LookupController(context);

                var result = await lookupController.GetWebsiteTypes();

                Assert.IsInstanceOfType(result, typeof(OkObjectResult));
                var ok = (OkObjectResult)result;
                Assert.IsInstanceOfType(ok.Value, typeof(List<WebsiteType>));
                var listResult = (List<WebsiteType>)ok.Value;
                Assert.AreEqual(4, listResult.Count);
            }
        }
    }
}