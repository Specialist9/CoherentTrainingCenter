using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NET011.Task
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
            var lessonType = TrainingElements.Any(x => x is VideoMaterial)? LessonType.VideoLesson : LessonType.TextLesson;
            return lessonType;
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
  