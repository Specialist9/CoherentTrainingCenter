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
            var pressure = cfg.GetSection("pressure").Get<PressureSensorConfig>();
            var magnet = cfg.GetSection("magnetic").Get<MagneticSensorConfig>();
            var temperature = cfg.GetSection("temperature").Get<TemperatureSensorConfig>();

            PConfig = pressure;
            TConfig = temperature;
            MConfig = magnet;

        }

        public void BuildXmlConfig()
        {
            IConfigurationBuilder builderX = new ConfigurationBuilder().AddXmlFile("sensorsettings.xml");
            var cfgX = builderX.Build();
            var pressureX = cfgX.GetSection("pressure").Get<PressureSensorConfig>();
            var magnetX = cfgX.GetSection("magnetic").Get<MagneticSensorConfig>();
            var temperatureX = cfgX.GetSection("temperature").Get<TemperatureSensorConfig>();

            PConfig = pressureX;
            TConfig = temperatureX;
            MConfig = magnetX;
        }

    }
}
