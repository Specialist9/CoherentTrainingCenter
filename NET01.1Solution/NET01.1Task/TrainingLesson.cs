using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NET01._1Task
{
    public class TrainingLesson : Entity
    {
        public Entity[] TrainingElements { get; private set; }

        public enum LessonType
        {
            VideoLesson,
            TextLesson
        }
        public TrainingLesson(string description) : base(description)
        {
            TrainingElements = new Entity[10];
        }

        public override string ToString()
        {
            return Description.ToString();
        }

        public void AddTrainingMaterial(Entity newElement)
        {
            for(int i = TrainingElements.Length - 1; i >= 0; i--)
            {
                if(TrainingElements[i] == null)
                {
                    TrainingElements[i] = newElement;
                }
            }
        }

        public LessonType CheckTrainingType()
        {
            for(int i = 0; i < TrainingElements.Length; i++)
            {
                if(TrainingElements[i] is VideoMaterial)
                {
                    return LessonType.VideoLesson;
                }
            }
            return LessonType.TextLesson;
        }
    }
}
  