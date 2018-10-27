using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DogsForUs.Controllers;

namespace UnitTests
{
    [TestClass]
    public class DogControllerTests
    {
        [TestMethod]
        public void TestGet()
        {
            var temp = new DogsController();
            string result = temp.Get();
            Assert.IsTrue(result.Equals("Hello World"));
        }
    }
}
