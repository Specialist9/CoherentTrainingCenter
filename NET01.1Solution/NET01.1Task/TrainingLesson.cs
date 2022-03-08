using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NET01._1Task
{
    public class TrainingLesson : Entity
    {
        public TrainingLesson(string description) : base(description)
        {

        }

        public override string ToString()
        {
            return Description.ToString();
        }
    }
}
  