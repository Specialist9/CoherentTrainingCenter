using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Listeners
{
    public class WordListenerConfig
    {
        public string FileName { get; set; }
        public int MinLogLevel { get; set; }

        public const string SectionName = "wordListener";

        public override string ToString()
        {
            return $"{FileName} - {MinLogLevel}";
        }
    }
}
