using ContactBookApi.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace ContactBookApi.Test
{
    [TestClass]
    public class Values
    {
        [TestMethod]
        public void ValuesGetValidResponse()
        {
            var valuesController = new ValuesController();

            var result = valuesController.Get();

            var expected = new string[] { "value1", "value2" };
            Assert.AreEqual(string.Join(" ", expected), string.Join(" ", result));
        }
    }
}
