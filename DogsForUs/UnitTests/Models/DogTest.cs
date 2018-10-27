﻿using System.Collections.Generic;
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
            Dog dog3 = new Dog("a", "b");
            Dog dog4 = new Dog("b", "a");
            Dog dog5 = new Dog("b", "b");

            // Assert
            Assert.IsTrue(dog1.Equals(dog2));
            Assert.IsFalse(dog1.Equals(dog3));
            Assert.IsFalse(dog1.Equals(dog4));
            Assert.IsFalse(dog1.Equals(dog5));

            Assert.IsTrue(dog2.Equals(dog1));
            Assert.IsFalse(dog2.Equals(dog3));
            Assert.IsFalse(dog2.Equals(dog4));
            Assert.IsFalse(dog2.Equals(dog5));

            Assert.IsFalse(dog3.Equals(dog1));
            Assert.IsFalse(dog3.Equals(dog2));
            Assert.IsFalse(dog3.Equals(dog4));
            Assert.IsFalse(dog3.Equals(dog5));

            Assert.IsFalse(dog4.Equals(dog1));
            Assert.IsFalse(dog4.Equals(dog2));
            Assert.IsFalse(dog4.Equals(dog3));
            Assert.IsFalse(dog4.Equals(dog5));
        }

        [TestMethod]
        public void DogGetHashCodeTest()
        {
            // Arrange
            Dog dog1 = new Dog("a", "a");
            Dog dog2 = new Dog("a", "a");
            Dog dog3 = new Dog("a", "b");
            Dog dog4 = new Dog("b", "a");
            Dog dog5 = new Dog("b", "b");

            Dictionary<int, Dog> dogCollection = new Dictionary<int, Dog>();
            dogCollection[dog1.GetHashCode()] = dog1;
            dogCollection[dog2.GetHashCode()] = dog2;
            dogCollection[dog3.GetHashCode()] = dog3;
            dogCollection[dog4.GetHashCode()] = dog4;
            dogCollection[dog5.GetHashCode()] = dog5;

            // Assert
            Assert.AreEqual(dog1.GetHashCode(), dog2.GetHashCode());
            Assert.AreNotEqual(dog1.GetHashCode(), dog3.GetHashCode());
            Assert.AreNotEqual(dog1.GetHashCode(), dog4.GetHashCode());
            Assert.AreNotEqual(dog1.GetHashCode(), dog5.GetHashCode());

            Assert.AreEqual(dog2.GetHashCode(), dog1.GetHashCode());
            Assert.AreNotEqual(dog2.GetHashCode(), dog3.GetHashCode());
            Assert.AreNotEqual(dog2.GetHashCode(), dog4.GetHashCode());
            Assert.AreNotEqual(dog2.GetHashCode(), dog5.GetHashCode());

            Assert.AreNotEqual(dog3.GetHashCode(), dog1.GetHashCode());
            Assert.AreNotEqual(dog3.GetHashCode(), dog2.GetHashCode());
            Assert.AreNotEqual(dog3.GetHashCode(), dog4.GetHashCode());
            Assert.AreNotEqual(dog3.GetHashCode(), dog5.GetHashCode());

            Assert.AreNotEqual(dog4.GetHashCode(), dog1.GetHashCode());
            Assert.AreNotEqual(dog4.GetHashCode(), dog2.GetHashCode());
            Assert.AreNotEqual(dog4.GetHashCode(), dog3.GetHashCode());
            Assert.AreNotEqual(dog4.GetHashCode(), dog5.GetHashCode());

            Assert.AreNotEqual(dog5.GetHashCode(), dog1.GetHashCode());
            Assert.AreNotEqual(dog5.GetHashCode(), dog2.GetHashCode());
            Assert.AreNotEqual(dog5.GetHashCode(), dog3.GetHashCode());
            Assert.AreNotEqual(dog5.GetHashCode(), dog4.GetHashCode());

            Assert.AreEqual(4, dogCollection.Count);
            Assert.AreEqual(dog2, dogCollection[dog1.GetHashCode()]);
        }
    }
}
