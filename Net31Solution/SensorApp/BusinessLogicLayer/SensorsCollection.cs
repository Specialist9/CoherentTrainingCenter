using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SensorApp
{
    internal static class SensorsCollection
    {
        public static ObservableCollection<Sensor> Sensors { get; private set; } = new ObservableCollection<Sensor>();

        public static ObservableCollection<Sensor> CreateSensors()
        {
            /*
            ConfigReader.BuildJsonConfig();
            foreach(var config in ConfigReader.SensorConfigs)
            {
                Sensors.Add(new Sensor(config));
            }
            */
            /*
            ConfigReader.BuildXmlConfig();
            foreach (var config in ConfigReader.SensorConfigsArray.SensorConfig)
            {
                Sensors.Add(new Sensor(config));
            }
            */
            return Sensors;
        }

        public static void AddSensor(SensorConfig config)
        {
            Sensors.Add(new Sensor(config));
        }

        public static void RemoveSensor(Sensor deleted)
        {
            Sensors.Remove(deleted);
        }

    }
}
