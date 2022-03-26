using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
using System.Configuration;
using System.ComponentModel;
using LoggerApp;

namespace LoggerApp
{
    public class Program
    {
        static void Main(string[] args)
        {

            Student student1 = new(18, "John Doe", 27, "+37012345678", "johndoe@gmail.com");
            Logger logger1 = new();
            logger1.Track(student1, Logger.LogLevel.Debug);

            /*
            EventLog eventLog = new EventLog();
            eventLog.Source = "MyEventLogTarget";
            eventLog.WriteEntry("This is a test message.", EventLogEntryType.Information);
            */

            static void WriteEventLogEntry(string message)
            {
                // Create an instance of EventLog
                EventLog eventLog = new EventLog();

                // Check if the event source exists. If not create it.
                if (!EventLog.SourceExists("TestApplication"))
                {
                    EventLog.CreateEventSource("TestApplication", "Application");
                }

                // Set the source name for writing log entries.
                eventLog.Source = "TestApplication";

                // Create an event ID to add to the event log
                int eventID = 8;

                // Write an entry to the event log.
                eventLog.WriteEntry(message, EventLogEntryType.Error, eventID);

                // Close the Event Log
                eventLog.Close();
            }
            WriteEventLogEntry("Just Testing the Event Log");

        }
    }
}



