using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ContactBookApi.Controllers;
using ContactBookApi.Models;
using ContactBookApi.Persistence;
using ContactBookApi.Test.Config;
using ContactBookApi.Test.Mocks;

namespace ContactBookApi.Test
{
    [TestClass]
    public class ContactTests
    {
        [TestMethod]
        public async Task GetContactReturnsValidResponse()
        {
            using (var context = SqlLiteInMemory.GetTestContext())
            {
                var userId = context.SeedDbContacts();
                var contactRepository = new ContactRepository(context);
                var contactController = new ContactsController(contactRepository);


                var result = await contactController.GetContacts(userId);

                Assert.IsInstanceOfType(result, typeof(OkObjectResult));
                var ok = (OkObjectResult)result;

                Assert.IsInstanceOfType(ok.Value, typeof(List<Contact>));
                var listResult = (List<Contact>)ok.Value;

                Assert.AreEqual(2, listResult.Count);
            }
        }
    }
}
