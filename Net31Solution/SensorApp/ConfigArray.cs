using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Microsoft.Extensions.Configuration.Xml;

namespace SensorApp
{
    [XmlRoot("configArray")]
    public class ConfigArray
    {
        [XmlElement("sensorConfig")]
        public SensorConfig[] SensorConfigs { get; set; }
    }
}
