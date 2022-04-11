using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SensorApp
{
    internal static class SensorsFactory
    {
        public static ObservableCollection<Sensor> Sensors { get; private set; } = new ObservableCollection<Sensor>();

        public static ObservableCollection<Sensor> CreateSensors()
        {
            ConfigReader reader = new ConfigReader();
            reader.BuildXmlConfig();
            //reader.BuildJsonConfig();
            Sensors.Add(new Sensor(reader.PConfig));
            Sensors.Add(new Sensor(reader.TConfig));
            Sensors.Add(new Sensor(reader.MConfig));
            return Sensors;
        }

        public static void AddSensor(ISensorConfig config)
        {
            Sensors.Add(new Sensor(config));
        }

        public static void RemoveSensor(Sensor deleted)
        {
            Sensors.Remove(deleted);
        }

    }
}
