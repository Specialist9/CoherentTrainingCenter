using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NET01._1Task
{
    public abstract class Entity
    {
        public string? Description { get; set; }
        public Guid ID { get; set; }

        const int DescriptionLength = 256;

        public Entity(string description)
        {
            Description = description.Length <= DescriptionLength? description : throw new ArgumentOutOfRangeException(nameof(description), "Description max length is 256 char");
        }
    }
}
