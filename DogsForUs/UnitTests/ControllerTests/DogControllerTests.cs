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
        private static Dictionary<string, Dog> _dogTestCollection;
        public void PopulateTestCollection()
        {
            Dog dog1 = new Dog("bulldog", "Some description");
            Dog dog2 = new Dog("chihuahua", "Some description");
            Dog dog3 = new Dog("sheepdog", "Some description");

            _dogTestCollection[dog1.Name] = dog1;
            _dogTestCollection[dog2.Name] = dog2;
            _dogTestCollection[dog3.Name] = dog3;
        }

        [TestMethod]
        public void DogControllerAddDogTest()
        {
            // Arrange
            var dogController = new DogsController();
            dogController.Clear();

            Dog testDog = new Dog("Test Name", "Test Description");
            Dog testDog2 = new Dog("Test Name", "Test Description Edited");
            Dog testDog3 = new Dog("Test Name Edited", "Test Description Edited");

            var result = dogController.AddDog(testDog);
            var result2 = dogController.AddDog(testDog);
            var result3 = dogController.AddDog(testDog2);
            var result4 = dogController.AddDog(testDog3);

            // Assert
            Assert.AreEqual(typeof(OkResult), result.GetType());
            Assert.AreEqual(typeof(BadRequestResult), result2.GetType());
            Assert.AreEqual(typeof(BadRequestResult), result3.GetType());
            Assert.AreEqual(typeof(OkResult), result4.GetType());
        }

        [TestMethod]
        public void DogControllerGetAllDogsTest()
        {
            // Arrange
            _dogTestCollection = new Dictionary<string, Dog>();
            PopulateTestCollection();

            var dogController = new DogsController();
            dogController.Clear();

            var result = dogController.GetAllDogs();
            var okObjectResult = result as OkObjectResult;

            Dictionary<string, Dog> dogCollection = okObjectResult.Value as Dictionary<string, Dog>;

            // Assert
            Assert.AreEqual(typeof(OkObjectResult), result.GetType());
            Assert.AreEqual(3, dogCollection.Count);
            foreach (var dog in dogCollection)
            {
                Assert.IsTrue(_dogTestCollection[dog.Key].Equals(dog.Value));
            }
        }

        [TestMethod]
        public void DogControllerEditDogTest()
        {
            // Arrange
            var dogController = new DogsController();
            dogController.Clear();

            Dog addDog1 = new Dog("bulldog", "Some Description");
            Dog addDog2 = new Dog("sheepdog", "Some Description");
            Dog editDogName = new Dog("bulldog_edited", "Some Description");
            Dog editDogDescription = new Dog("bulldog_edited", "Some Description Edited");
            Dog editDogNameAndDescription = new Dog("bulldog_edited_2", "Some Description Edited Twice");
            Dog editInvalidDogName = new Dog("sheepdog", "Some Description");

            var addDog1Result = dogController.AddDog(addDog1);
            var addDog2Result = dogController.AddDog(addDog2);
            var editDogNameResult = dogController.EditDog("bulldog", editDogName);
            var editDogDescriptionResult = dogController.EditDog("bulldog_edited", editDogDescription);
            var editDogNameAndDescriptionResult = dogController.EditDog("bulldog_edited", editDogNameAndDescription);
            var editInvalidDogNameResult = dogController.EditDog("bulldog_edited_2", editInvalidDogName);

            // Assert
            Assert.AreEqual(typeof(OkResult), addDog1Result.GetType());
            Assert.AreEqual(typeof(OkResult), addDog2Result.GetType());
            Assert.AreEqual(typeof(OkResult), editDogNameResult.GetType());
            Assert.AreEqual(typeof(OkResult), editDogDescriptionResult.GetType());
            Assert.AreEqual(typeof(OkResult), editDogNameAndDescriptionResult.GetType());
            Assert.AreEqual(typeof(BadRequestResult), editInvalidDogNameResult.GetType());
        }

        [TestMethod]
        public void DogControllerDeleteDogTest()
        {
            // Arrange
            var dogController = new DogsController();
            dogController.Clear();
            PopulateTestCollection();

            var addDog1Result = dogController.AddDog(_dogTestCollection["bulldog"]);
            var addDog2Result = dogController.AddDog(_dogTestCollection["chihuahua"]);
            var deleteDog1Result = dogController.DeleteDog("bulldog");
            var deleteDog2Result = dogController.DeleteDog("chihuahua");
            var deleteDog3Result = dogController.DeleteDog("sheepdog");

            // Assert
            Assert.AreEqual(typeof(OkResult), addDog1Result.GetType());
            Assert.AreEqual(typeof(OkResult), addDog2Result.GetType());
            Assert.AreEqual(typeof(OkResult), deleteDog1Result.GetType());
            Assert.AreEqual(typeof(OkResult), deleteDog2Result.GetType());
            Assert.AreEqual(typeof(BadRequestResult), deleteDog3Result.GetType());
        }
    }
}
