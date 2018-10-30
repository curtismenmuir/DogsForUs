using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DogsForUs.Models;

namespace UnitTests.Models
{
    [TestClass]
    public class DogTest
    {
        [TestMethod]
        public void DogEqualsTest()
        {
            // Arrange
            Dog dog1 = new Dog("a", "a");
            Dog dog2 = new Dog("a", "a");
            Dog dog3 = new Dog("a", "a");
            Dog dog4 = new Dog("a", "b");
            Dog dog5 = new Dog("b", "a");
            Dog dog6 = new Dog("b", "b");
            Dog dog7 = new Dog("b", "b");

            string[] subBreeds = new string[] { "a", "b" };
            dog3.SubBreeds = subBreeds;
            dog7.SubBreeds = subBreeds;

            // Assert
            Assert.IsTrue(dog1.Equals(dog2));
            Assert.IsTrue(dog1.Equals(dog3));
            Assert.IsTrue(dog1.Equals(dog4));
            Assert.IsFalse(dog1.Equals(dog5));
            Assert.IsFalse(dog1.Equals(dog6));
            Assert.IsFalse(dog1.Equals(dog7));

            Assert.IsTrue(dog2.Equals(dog1));
            Assert.IsTrue(dog2.Equals(dog3));
            Assert.IsTrue(dog2.Equals(dog4));
            Assert.IsFalse(dog2.Equals(dog5));
            Assert.IsFalse(dog2.Equals(dog6));
            Assert.IsFalse(dog2.Equals(dog7));

            Assert.IsTrue(dog3.Equals(dog1));
            Assert.IsTrue(dog3.Equals(dog2));
            Assert.IsTrue(dog3.Equals(dog4));
            Assert.IsFalse(dog3.Equals(dog5));
            Assert.IsFalse(dog3.Equals(dog6));
            Assert.IsFalse(dog3.Equals(dog7));

            Assert.IsTrue(dog4.Equals(dog1));
            Assert.IsTrue(dog4.Equals(dog2));
            Assert.IsTrue(dog4.Equals(dog4));
            Assert.IsFalse(dog4.Equals(dog5));
            Assert.IsFalse(dog4.Equals(dog6));
            Assert.IsFalse(dog4.Equals(dog7));

            Assert.IsFalse(dog5.Equals(dog1));
            Assert.IsFalse(dog5.Equals(dog2));
            Assert.IsFalse(dog5.Equals(dog3));
            Assert.IsFalse(dog5.Equals(dog4));
            Assert.IsTrue(dog5.Equals(dog6));
            Assert.IsTrue(dog5.Equals(dog7));

            Assert.IsFalse(dog6.Equals(dog1));
            Assert.IsFalse(dog6.Equals(dog2));
            Assert.IsFalse(dog6.Equals(dog3));
            Assert.IsFalse(dog6.Equals(dog4));
            Assert.IsTrue(dog6.Equals(dog5));
            Assert.IsTrue(dog6.Equals(dog7));

            Assert.IsFalse(dog7.Equals(dog1));
            Assert.IsFalse(dog7.Equals(dog2));
            Assert.IsFalse(dog7.Equals(dog3));
            Assert.IsFalse(dog7.Equals(dog4));
            Assert.IsTrue(dog7.Equals(dog5));
            Assert.IsTrue(dog7.Equals(dog6));
        }
    }
}
