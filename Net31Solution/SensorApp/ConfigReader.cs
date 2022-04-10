using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
using Microsoft.Extensions.Configuration.Xml;
using System.Threading.Tasks;

namespace SensorApp
{
    public class ConfigReader
    {
        public PressureSensorConfig PConfig { get; set; }
        public TemperatureSensorConfig TConfig { get; set; }
        public MagneticSensorConfig MConfig { get; set; }

        public void BuildJsonConfig()
        {
            IConfigurationBuilder builder = new ConfigurationBuilder().AddJsonFile("sensorsettings.json");
            var cfg = builder.Build();
            PConfig = cfg.GetSection("pressure").Get<PressureSensorConfig>();
            MConfig = cfg.GetSection("magnetic").Get<MagneticSensorConfig>();
            TConfig = cfg.GetSection("temperature").Get<TemperatureSensorConfig>();
        }

        public void BuildXmlConfig()
        {
            IConfigurationBuilder builderX = new ConfigurationBuilder().AddXmlFile("sensorsettings.xml");
            var cfgX = builderX.Build();
            PConfig = cfgX.GetSection("pressure").Get<PressureSensorConfig>();
            MConfig = cfgX.GetSection("magnetic").Get<MagneticSensorConfig>();
            TConfig = cfgX.GetSection("temperature").Get<TemperatureSensorConfig>();
        }

    }
}
