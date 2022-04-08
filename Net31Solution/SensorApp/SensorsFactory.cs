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
        /*
        public static ObservableCollection<Sensor> CreateSensors(int count)
        {
            Sensor[] _sensors = new Sensor[count];
            for (int i = 0; i < count; i++)
            {
                _sensors[i] = new Sensor(Guid.NewGuid().ToString(), i);
            }

            return new ObservableCollection<Sensor>(_sensors);
        }
        */
        public static ObservableCollection<Sensor> CreateSensors()
        {
            List<Sensor> sensorList = new List<Sensor>();
            ConfigReader reader = new ConfigReader();
            //reader.BuildXmlConfig();
            reader.BuildJsonConfig();
            sensorList.Add(new Sensor(reader.PConfig));
            sensorList.Add(new Sensor(reader.TConfig));
            sensorList.Add(new Sensor(reader.MConfig));
            return new ObservableCollection<Sensor>(sensorList);
        }
    }
}
