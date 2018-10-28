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
            Dog dog1 = new Dog("bulldog", "Some description");
            Dog dog2 = new Dog("chihuahua", "Some description");
            Dog dog3 = new Dog("sheepdog", "Some description");
            lock (_dogCollection)
            {
                _dogCollection[dog1.Name] = dog1;
                _dogCollection[dog2.Name] = dog2;
                _dogCollection[dog3.Name] = dog3;
            }
        }
        /*
       // POST api/dogs
       [HttpPost]
       public void Post([FromBody]string value)
       {
       }

       // PUT api/dogs/5
       [HttpPut("{id}")]
       public void Put(int id, [FromBody]string value)
       {
       }

       // DELETE api/dogs/5
       [HttpDelete("{id}")]
       public void Delete(int id)
       {
       }
       */
    }
}
