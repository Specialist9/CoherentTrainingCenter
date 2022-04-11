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
    public static class ConfigReader
    {
        public static PressureSensorConfig PConfig { get; set; }
        public static TemperatureSensorConfig TConfig { get; set; }
        public static MagneticSensorConfig MConfig { get; set; }

        public static void BuildJsonConfig()
        {
            IConfigurationBuilder builder = new ConfigurationBuilder().AddJsonFile("sensorsettings.json");
            var cfg = builder.Build();
            PConfig = cfg.GetSection("pressure").Get<PressureSensorConfig>();
            MConfig = cfg.GetSection("magnetic").Get<MagneticSensorConfig>();
            TConfig = cfg.GetSection("temperature").Get<TemperatureSensorConfig>();
        }

        public static void BuildXmlConfig()
        {
            IConfigurationBuilder builderX = new ConfigurationBuilder().AddXmlFile("sensorsettings.xml");
            var cfgX = builderX.Build();
            PConfig = cfgX.GetSection("pressure").Get<PressureSensorConfig>();
            MConfig = cfgX.GetSection("magnetic").Get<MagneticSensorConfig>();
            TConfig = cfgX.GetSection("temperature").Get<TemperatureSensorConfig>();
        }

    }
}
