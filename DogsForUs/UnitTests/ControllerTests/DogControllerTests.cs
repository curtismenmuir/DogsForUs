using DogsForUs.Controllers;
using DogsForUs.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace UnitTests
{
    [TestClass]
    public class DogControllerTests
    {
        private static Dictionary<int, Dog> _dogTestCollection;
        public void PopulateTestCollection()
        {
            Dog dog1 = new Dog("bulldog", "Some description");
            Dog dog2 = new Dog("chihuahua", "Some description");
            Dog dog3 = new Dog("sheepdog", "Some description");
            _dogTestCollection[dog1.GetHashCode()] = dog1;
            _dogTestCollection[dog2.GetHashCode()] = dog2;
            _dogTestCollection[dog3.GetHashCode()] = dog3;
        }

        [TestMethod]
        public void DogControllerAddDogTest()
        {
            // Arrange
            var dogController = new DogsController();
            dogController.Clear();
            Dog testDog = new Dog("Test Name", "Test Description");
            var result = dogController.AddDog(testDog);
            var result2 = dogController.AddDog(testDog);

            // Assert
            Assert.AreEqual(typeof(OkResult), result.GetType());
            Assert.AreEqual(typeof(BadRequestResult), result2.GetType());
        }

        [TestMethod]
        public void DogControllerGetAllDogsTest()
        {
            // Arrange
            _dogTestCollection = new Dictionary<int, Dog>();
            PopulateTestCollection();
            var dogController = new DogsController();
            dogController.Clear();
            var result = dogController.GetAllDogs();
            var okObjectResult = result as OkObjectResult;
            Dictionary<int, Dog> dogCollection = okObjectResult.Value as Dictionary<int, Dog>;

            // Assert
            Assert.AreEqual(3, dogCollection.Count);
            foreach (var dog in dogCollection)
            {
                Assert.IsTrue(_dogTestCollection[dog.Value.GetHashCode()].Equals(dog.Value));
            }
        }
    }
}
