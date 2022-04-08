using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
using System.Threading.Tasks;

namespace SensorApp
{
    public interface ISensorConfig
    {
        public int MeasuredValue { get; set; }
        public int MeasurementInterval { get; set; }
        public string SensorType { get; set; }
        public Mode SensorMode { get; set; }
        public enum Mode
        {
            Idle,
            Calibration,
            Working
        }
    }
}
