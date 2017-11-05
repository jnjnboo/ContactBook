using System.Threading.Tasks;
using System.Collections.Generic;
using ContactBookApi.Controllers;
using ContactBookApi.Models.ViewModels;
using ContactBookApi.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Microsoft.AspNetCore.Mvc;

namespace ContactBookApi.Test
{
    [TestClass]
    public class EmailTypes
    {
        [TestMethod]
        public async Task EmailTypesReturnsValidResponse()
        {
            var mockRepo = new Mock<ILookupRepository>();
            mockRepo.Setup(repo => repo.GetEmailTypes()).Returns(Task.FromResult(GetTestEmailTypes()));
            var emailTypesController = new EmailTypesController(mockRepo.Object);

            var result = await emailTypesController.GetEmailType();

            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
            var okResult = (OkObjectResult)result;

            Assert.IsInstanceOfType(okResult.Value, typeof(List<LookupModels.EmailTypes>));
            var listResult = (List<LookupModels.EmailTypes>)okResult.Value;

            Assert.AreEqual(3, listResult.Count);
        }

        private IEnumerable<LookupModels.EmailTypes> GetTestEmailTypes()
        {
            return new List<LookupModels.EmailTypes>
            {
                new LookupModels.EmailTypes {  Id = 1, Name = "Home" },
                new LookupModels.EmailTypes {  Id = 1, Name = "Personal" },
                new LookupModels.EmailTypes {  Id = 1, Name = "Other" }
            };
        }
    }
}
