using System.Collections.Generic;
using System.Threading.Tasks;
using ContactBookApi.Controllers;
using ContactBookApi.Models.ViewModels;
using ContactBookApi.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace ContactBookApi.Test
{
    [TestClass]
    public class LookupTypeTests
    {
        [TestMethod]
        public async Task GetAddressTypesReturnsValidResponse()
        {
            var mockRepo = new Mock<ILookupRepository>();
            mockRepo.Setup(repo => repo.GetAddressTypes()).Returns(Task.FromResult(this.GetTestAddressTypes()));
            var lookupController = new LookupController(mockRepo.Object);

            var result = await lookupController.GetAddressTypes();

            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
            var ok = (OkObjectResult)result;

            Assert.IsInstanceOfType(ok.Value, typeof(List<LookupModels.AddressTypes>));
            var finalResult = (List<LookupModels.AddressTypes>)ok.Value;

            Assert.AreEqual(1, finalResult.Count);
        }

        [TestMethod]
        public async Task GetEmailTypesReturnsValidResponse()
        {
            var mockRepo = new Mock<ILookupRepository>();
            mockRepo.Setup(repo => repo.GetEmailTypes()).Returns(Task.FromResult(this.GetTestEmailTypes()));
            var lookupController = new LookupController(mockRepo.Object);

            var result = await lookupController.GetEmailTypes();

            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
            var ok = (OkObjectResult)result;

            Assert.IsInstanceOfType(ok.Value, typeof(List<LookupModels.EmailTypes>));
            var listResult = (List<LookupModels.EmailTypes>)ok.Value;

            Assert.AreEqual(2, listResult.Count);
        }

        [TestMethod]
        public async Task GetEventTypesReturnsValidResponse()
        {
            var mockRepo = new Mock<ILookupRepository>();
            mockRepo.Setup(repo => repo.GetEventTypes()).Returns(Task.FromResult(this.GetTestEventTypes()));
            var lookupController = new LookupController(mockRepo.Object);

            var result = await lookupController.GetEventTypes();

            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
            var ok = (OkObjectResult)result;

            Assert.IsInstanceOfType(ok.Value, typeof(List<LookupModels.EventTypes>));
            var listResult = (List<LookupModels.EventTypes>)ok.Value;

            Assert.AreEqual(3, listResult.Count);
        }

        [TestMethod]
        public async Task GetPhoneTypesReturnsValidResponse()
        {
            var mockRepo = new Mock<ILookupRepository>();
            mockRepo.Setup(repo => repo.GetPhoneTypes()).Returns(Task.FromResult(this.GetTestPhoneTypes()));
            var lookupController = new LookupController(mockRepo.Object);

            var result = await lookupController.GetPhoneTypes();

            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
            var ok = (OkObjectResult)result;

            Assert.IsInstanceOfType(ok.Value, typeof(List<LookupModels.PhoneTypes>));
            var listResult = (List<LookupModels.PhoneTypes>)ok.Value;

            Assert.AreEqual(5, listResult.Count);
        }

        [TestMethod]
        public async Task GetWebsiteTypesReturnsValidResponse()
        {
            var mockRepo = new Mock<ILookupRepository>();
            mockRepo.Setup(repo => repo.GetWebsiteTypes()).Returns(Task.FromResult(this.GetTestWebsiteTypes()));
            var lookupController = new LookupController(mockRepo.Object);

            var result = await lookupController.GetWebsiteTypes();

            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
            var ok = (OkObjectResult)result;

            Assert.IsInstanceOfType(ok.Value, typeof(List<LookupModels.WebsiteTypes>));
            var listResult = (List<LookupModels.WebsiteTypes>)ok.Value;

            Assert.AreEqual(4, listResult.Count);
        }

        private IEnumerable<LookupModels.AddressTypes> GetTestAddressTypes()
        {
            return new List<LookupModels.AddressTypes> { new LookupModels.AddressTypes { Id = 1, Name = "Home" } };
        }

        private IEnumerable<LookupModels.EmailTypes> GetTestEmailTypes()
        {
            return new List<LookupModels.EmailTypes>
            {
                new LookupModels.EmailTypes { Id = 1, Name = "Business" },
                new LookupModels.EmailTypes { Id = 2, Name = "Personal" }
            };
        }

        private IEnumerable<LookupModels.EventTypes> GetTestEventTypes()
        {
            return new List<LookupModels.EventTypes>
            {
                new LookupModels.EventTypes { Id = 1, Name = "Anniversary" },
                new LookupModels.EventTypes { Id = 2, Name = "Birthday" },
                new LookupModels.EventTypes { Id = 3, Name = "Other" }
            };
        }

        private IEnumerable<LookupModels.PhoneTypes> GetTestPhoneTypes()
        {
            return new List<LookupModels.PhoneTypes>
            {
                new LookupModels.PhoneTypes { Id = 1, Name = "Home" },
                new LookupModels.PhoneTypes { Id = 2, Name = "Business" },
                new LookupModels.PhoneTypes { Id = 3, Name = "Home Fax" },
                new LookupModels.PhoneTypes { Id = 4, Name = "Business Fax" },
                new LookupModels.PhoneTypes { Id = 5, Name = "Pager" }
            };
        }

        private IEnumerable<LookupModels.WebsiteTypes> GetTestWebsiteTypes()
        {
            return new List<LookupModels.WebsiteTypes>
            {
                new LookupModels.WebsiteTypes { Id = 1, Name = "Personal" },
                new LookupModels.WebsiteTypes { Id = 2, Name = "Business" },
                new LookupModels.WebsiteTypes { Id = 3, Name = "Blog" },
                new LookupModels.WebsiteTypes { Id = 4, Name = "Profile" }
            };
        }
    }
}