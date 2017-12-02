using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ContactBookApi.Controllers;
using ContactBookApi.Models;
using ContactBookApi.Persistence;
using ContactBookApi.Test.Config;
using ContactBookApi.Test.Mocks;
using NUnit.Framework;

namespace ContactBookApi.Test
{
    [TestFixture]
    public class ContactTests
    {
        [Test]
        public async Task GetContactReturnsValidResponse()
        {
            using (var context = SqlLiteInMemory.GetTestContext())
            {
                var userId = context.SeedDbContacts();
                var contactRepository = new ContactRepository(context);
                var contactController = new ContactsController(contactRepository);


                var result = await contactController.GetContacts(userId);

                Assert.That(result, Is.InstanceOf(typeof(OkObjectResult)));
                var ok = (OkObjectResult)result;

                Assert.That(ok.Value, Is.InstanceOf(typeof(List<Contact>)));
                var listResult = (List<Contact>)ok.Value;

                Assert.AreEqual(2, listResult.Count);
            }
        }
    }
}
