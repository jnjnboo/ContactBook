using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ContactBookApi.Controllers;
using ContactBookApi.Models;
using ContactBookApi.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace ContactBookApi.Test
{
    [TestClass]
   public class ContactTests
    {
        [TestMethod]
        public async Task GetContactReturnsValidResponse()
        {
            var mockRepo = new Mock<IContactRepository>();
            mockRepo.Setup(repo => repo.GetContacts()).Returns(Task.FromResult(this.GetContacts()));
            var contactController = new ContactsController(mockRepo.Object);

            var result = await contactController.GetContacts();

            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
            var ok = (OkObjectResult)result;

            Assert.IsInstanceOfType(ok.Value, typeof(List<Models.Contact>));
            var listResult = (List<Models.Contact>)ok.Value;

            Assert.AreEqual(1, listResult.Count);
        }

        private IEnumerable<Models.Contact> GetContacts()
        {
            return new List<Models.Contact>
            {
                new Models.Contact { ContactId = 1, Name = "Satya Nadella", Company="Microsoft", JobTitle ="CEO",
                    Email = new Models.Email[] { new Email
                        { EmailId=1, EmailAddress = "snadella@microsoft.com", EmailTypeId=2 } },
                    Website = new Website[] { new Website { WebsiteId=1, Url="www.microsoft.com", WebsiteTypeId =2} },
                    Phone = new Phone[] { new Phone { PhoneId=1, Number="206-555-1234", PhoneTypeId=1} }
                }
            };
        }
    }
}
