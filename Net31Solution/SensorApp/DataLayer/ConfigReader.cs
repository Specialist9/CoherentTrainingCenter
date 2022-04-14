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
        public static SensorConfig[] SensorConfigs { get; set; }
        public static SensorConfig SConfig { get; set; }

        public static ConfigArray SensorConfigsArray { get; set; }


        public static void BuildJsonConfig()
        {
            IConfigurationBuilder builder = new ConfigurationBuilder().AddJsonFile("sensorsettings2.json");
            var cfg = builder.Build();

            SensorConfigs = cfg.GetSection("configArray").Get<SensorConfig[]>();
            
        }

        public static void BuildXmlConfig()
        {
            IConfigurationBuilder builderX = new ConfigurationBuilder().AddXmlFile("sensorsettings2.xml");
            var cfgX = builderX.Build();

            SensorConfigsArray = cfgX.GetSection("configArray").Get<ConfigArray>();
            int i = 35;
        }

    }
}
