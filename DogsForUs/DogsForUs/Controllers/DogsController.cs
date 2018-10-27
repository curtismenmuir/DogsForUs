using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace DogsForUs.Controllers
{
    [Route("api/[controller]")]
    public class DogsController : ControllerBase
    {
        // GET: api/dogs
        [HttpGet]
        public string Get()
        {
            return "Hello World";
        }
        /*
        // GET api/dogs/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "Hello World";
        }

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
