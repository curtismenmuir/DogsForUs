using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DogsForUs.Models;

namespace DogsForUs.Controllers
{
    [Route("api/[controller]")]
    public class DogsController : ControllerBase
    {
        private static Dictionary<string, Dog> _dogCollection = new Dictionary<string, Dog>();

        // GET: api/dogs
        [HttpGet]
        public ActionResult GetAllDogs()
        {
            Dictionary<string, Dog> tempCollection = new Dictionary<string, Dog>();
            if (_dogCollection.Count == 0)
            {
                PopulateCollection();

            }
            lock (_dogCollection)
            {
                tempCollection = _dogCollection;
            }
            return Ok(tempCollection);
        }
        
        // POST: api/dogs
        [HttpPost]
        public ActionResult AddDog(Dog dog)
        {
            lock (_dogCollection)
            {
                if (!_dogCollection.ContainsKey(dog.Name))
                {
                    _dogCollection[dog.Name] = dog;
                    return Ok();
                }
                else
                {
                    return BadRequest();
                }
            }
        }

        // PUT api/dogs/Original Dog Name
        [HttpPut("{originalName}")]
        public ActionResult EditDog(string originalName, Dog newDog)
        {
            lock (_dogCollection)
            {
                if (_dogCollection.ContainsKey(originalName))
                {
                    if (originalName.Equals(newDog.Name))
                    {
                        _dogCollection[newDog.Name] = newDog;
                        return Ok();
                    }
                    else if (!_dogCollection.ContainsKey(newDog.Name))
                    {
                        _dogCollection.Remove(originalName);
                        _dogCollection[newDog.Name] = newDog;
                        return Ok();
                    }
                }
                return BadRequest();
            }
        }

        // DELETE api/dogs/Dog Name
        [HttpDelete("{name}")]
        public ActionResult DeleteDog(string name)
        {
            lock (_dogCollection)
            {
                if (_dogCollection.ContainsKey(name))
                {
                    _dogCollection.Remove(name);
                    return Ok();
                }
            }
            return BadRequest();
        }

        public void Clear()
        {
            if (_dogCollection != null && _dogCollection.Count != 0)
            {
                lock (_dogCollection)
                {
                    _dogCollection.Clear();
                }
            }
        }

        private void PopulateCollection()
        {
            string[] terrierList = new string[] { "American", "Australian", "Bedlington", "Border", "Dandie", "Fox", "Irish", "Kerryblue", "Lakeland", "Norfolk", "Norwich", "Patterdale", "Scottish", "Sealyham", "Silky", "Tibetan", "Toy", "Westhighland", "Wheaten", "Yorkshire" };
            Dog dog1 = new Dog("bulldog", "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur.Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.");
            Dog dog2 = new Dog("chihuahua", "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur.Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.");
            Dog dog3 = new Dog("sheepdog", "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur.Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.");
            Dog dog4 = new Dog("terrier", "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur.Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.");
            dog4.SubBreeds = terrierList;

            lock (_dogCollection)
            {
                _dogCollection[dog1.Name] = dog1;
                _dogCollection[dog2.Name] = dog2;
                _dogCollection[dog3.Name] = dog3;
                _dogCollection[dog4.Name] = dog4;
            }
        }
    }
}
