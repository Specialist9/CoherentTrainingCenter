using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using System.Diagnostics;

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
            string source = "LoggerApp";
            string log = "Application";
            int eventID = 45;


            if (!EventLog.SourceExists(source))
            {
                EventLog.CreateEventSource(source, log);
            }
            EventLog.WriteEntry(source, message, EventLogEntryType.Information, eventID);

            Console.WriteLine("I'm writing to Windows Event Log");
        }
    }
}
