using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NET01._1Task
{
    public class TrainingLesson : Entity, IVersionable, ICloneable
    {
        public byte[] Version;

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

        public string ReadVersion()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var item in Version)
            {
                sb.Append($"{item.ToString()}.");
            };
            return sb.ToString();
        }

        public void WriteVersion(ulong version)
        {
            Version = BitConverter.GetBytes(version);
        }

        public object Clone()
        {
            Entity[] copyOfTrainingElements = new Entity[TrainingElements.Length];

            for (int i = 0; i < TrainingElements.Length; i++)
            {
                var tempItem = (Entity)TrainingElements[i].Clone();
                copyOfTrainingElements[i] = tempItem;
            }

            return new TrainingLesson(Description)
            {
                TrainingElements = copyOfTrainingElements
            };
        }
    }
}
  