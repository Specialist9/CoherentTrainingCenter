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

        public override string ToString()
        {
            return Description.ToString();
        }

        public override bool Equals(object obj)
        {
            var temp = obj as Entity;

            if(this.ID == temp.ID)
            {
                return true;
            }
            else { return false; }
        }

    }
}
