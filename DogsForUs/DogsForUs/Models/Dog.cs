using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DogsForUs.Models
{
    public class Dog
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string[] SubBreeds { get; set; }

        /// <summary>
        /// Constructor for empty dog object
        /// </summary>
        public Dog () { }

        /// <summary>
        /// Constructor to create dog object with name and description
        /// </summary>
        /// <param name="name"></param>
        /// <param name="description"></param>
        public Dog (string name, string description)
        {
            this.Name = name;
            this.Description = description;
        }

        /// <summary>
        /// Compares this Dog object to another to establish if they are the same
        /// </summary>
        /// <param name="dog"></param>
        /// <returns>True / False</returns>
        public bool Equals(Dog dog)
        {
            return this.Name.Equals(dog.Name);
        }
    }
}
