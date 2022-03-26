using System;
using System.Collections.Generic;
using System.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.IO;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
using System.Configuration;
using System.Reflection;
using Listeners;

namespace LoggerApp
{
    public class Logger
    {
        public List<IListener> Listeners { get; set; }
        public LogLevel LogLevelValue { get; set; }

        public enum LogLevel
        {
            Error = 0,
            Information = 1,
            Warning = 2
        }

        public Logger()
        {
            IConfigurationBuilder builder = new ConfigurationBuilder().AddJsonFile("appsettings2.json");
            var cfg = builder.Build();

            Listeners = new List<IListener>();

            var textListen = cfg.GetSection(TextListenerConfig.SectionName).Get<TextListenerConfig>();
            var wordListen = cfg.GetSection(WordListenerConfig.SectionName).Get<WordListenerConfig>();
            var eventLogListen = cfg.GetSection(EventLogListenerConfig.SectionName).Get<EventLogListenerConfig>();
            
            if (textListen != null)
            {
                TextListener textListener1 = new(textListen);
                Listeners.Add(textListener1);
            }
            if (wordListen != null)
            {
                WordListener wordListener1 = new(wordListen);
                Listeners.Add(wordListener1);
            }
            if (eventLogListen != null)
            {
                EventLogListener eventLogListener1 = new(eventLogListen);
                Listeners.Add(eventLogListener1);
            }

        }

        public void Track(object testObject, LogLevel logginglevel)
        {
            var objType = testObject.GetType(); //get passed object type

            Dictionary<string, string> propsAndValues = new(); // initialize dictionary for (property name : property value) pairs


            if (testObject.GetType().GetCustomAttributes<TrackingEntityAttribute>() != null) // if there is a custom attribute TrackingEntity
            {
                MemberInfo[] members = objType.GetProperties().Cast<MemberInfo>().Concat(objType.GetFields()).ToArray(); //get an array of all properties & fields of passed object type

                foreach (var prop in members) // go through all properties & fields of passed object type
                {
                    object[] customAttributes = prop.GetCustomAttributes(false); // get an array of all custom attributes (subclasses not checked)

                    foreach (var attr in customAttributes) // go through all the custom attributes
                    {
                        TrackingPropertyAttribute trackA = attr as TrackingPropertyAttribute; // initialize trackA variable as TrackingProperty
                        string attrName;
                        string propValue;

                        if (trackA != null) // if TrackingPropertyAttribute exists
                        {
                            if (trackA.Name != null) // if TrackingPropertyAttribute has a name
                            {
                                attrName = trackA.Name; // assign TrackingPropertyAttribute name to attrName
                            }
                            else
                            {
                                attrName = prop.Name; // else assign Property name to attrName
                            }


                            propValue = prop.MemberType == MemberTypes.Property ? ((PropertyInfo)prop).GetValue(testObject).ToString() : ((FieldInfo)prop).GetValue(testObject).ToString();
                            //if member is Property get value of Property else get value of Field and put it to string

                            propsAndValues.Add(attrName, propValue); // add name and value to dictionary
                        }
                    }
                }
                
                string json = JsonSerializer.Serialize(propsAndValues);
                LogLevelValue = logginglevel;

                foreach (var listener in Listeners)
                {
                    if (listener != null && listener.MinLogLevel >= (int)LogLevelValue)
                    {
                        listener.WriteToLogFile(json);
                    }
                }

            }
        }
    }
}
