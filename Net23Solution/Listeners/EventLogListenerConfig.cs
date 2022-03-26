using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Listeners
{
    public class EventLogListenerConfig
    {
        public string EventLogName { get; set; }
        public int MinLogLevel { get; set; }

        public const string SectionName = "eventLogListener";

        public override string ToString()
        {
            return $"{EventLogName} - {MinLogLevel}";
        }
    }
}
