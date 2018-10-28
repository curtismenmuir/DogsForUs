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
        
        public Dog (string name, string description)
        {
            this.Name = name;
            this.Description = description;
        }
        
        /// <summary>
        /// Compares this Dog object to another to establish whether the 2 are equal
        /// </summary>
        /// <param name="dog"></param>
        /// <returns>True / False</returns>
        public bool Equals(Dog dog)
        {
            return this.Name.Equals(dog.Name);
        }

        /// <summary>
        /// Override for GetHashCode() 
        /// This generates a hash based on the same fields as the Equals method - if 2 objects are equal they should generate the same hash
        /// </summary>
        /// <returns>hash as int</returns>
        public override int GetHashCode()
        {
            return this.Name.GetHashCode();
        }
    }
}
