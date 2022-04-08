using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SensorApp
{
    public class MagneticSensorConfig : ISensorConfig
    {
        public int MeasuredValue { get; set; }
        public int MeasurementInterval { get; set; }
        public string SensorType { get; set; }
        public ISensorConfig.Mode SensorMode { get; set; }
        /*public enum Mode
        {
            Idle,
            Calibration,
            Working
        }*/
    }
}
