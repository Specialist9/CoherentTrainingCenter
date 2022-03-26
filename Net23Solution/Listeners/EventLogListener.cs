using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Listeners
{
    public class EventLogListener : IListener
    {
        public EventLogListener(EventLogListenerConfig eventLogConfig)
        {
            MinLogLevel = eventLogConfig.MinLogLevel;
            EventLogName = eventLogConfig.EventLogName;
        }
        public int MinLogLevel { get; set; }
        public string EventLogName { get; set; }

        public void WriteToLogFile(string message)
        {
            File.WriteAllText("events.txt", message);
            Console.WriteLine("I'm writing to events.txt");
        }
    }
}
