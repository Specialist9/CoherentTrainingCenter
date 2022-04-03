using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using NLog;

namespace Net24Task
{
    public class MonitoringAppC
    {
        public List<WebSiteData>? SiteData { get; set; }

        public string WebSiteSettingsFile { get; set; }
        public string WebSiteSettingsDirectory { get; set; }
        public FileSystemWatcher WebSiteWatcher { get; set; }
        //public bool IsStopped { get; set; }


        public MonitoringAppC()
        {
            
            var cfg = GetAppssetingsConfig();

            SiteData = new();

            var yahooCheck = cfg.GetSection(nameof(YahooConfig)).Get<YahooConfig>();
            var googleCheck = cfg.GetSection(nameof(GoogleConfig)).Get<GoogleConfig>();
            var microsoftCheck = cfg.GetSection(nameof(MicrosoftConfig)).Get<MicrosoftConfig>();

            SiteData.Add(yahooCheck);
            SiteData.Add(googleCheck);
            SiteData.Add(microsoftCheck);
            

            /*
            WebSiteSettingsFile = "appsettings2.json";
            string jsonString = File.ReadAllText(WebSiteSettingsFile);
            SiteData = JsonConvert.DeserializeObject<List<WebSiteData>>(jsonString);

            WebSiteSettingsDirectory = Directory.GetCurrentDirectory();

            WebSiteWatcher = new FileSystemWatcher(WebSiteSettingsDirectory);
            WebSiteWatcher.EnableRaisingEvents = true;

            WebSiteWatcher.Filter = WebSiteSettingsFile;
            WebSiteWatcher.NotifyFilter = NotifyFilters.LastWrite | NotifyFilters.LastAccess;

            WebSiteWatcher.Changed += OnChanged;
            */

        }



    IConfigurationRoot GetAppssetingsConfig()
        {
            
            var builder = new ConfigurationBuilder()
                           .SetBasePath(Directory.GetCurrentDirectory())
                           .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            //.AddEnvironmentVariables();

            IConfigurationRoot configuration = builder.Build();
            
            configuration.Reload();

            return configuration;
        }

        public void ReloadWebsiteSettings()
        {
            GetAppssetingsConfig();
        }

        private void OnChanged(object source, FileSystemEventArgs e)
        {
            Console.WriteLine("File: " + e.FullPath + " " + e.ChangeType);

            ReloadWebsiteSettings();

        }

        public void StartTimers()
        {
            foreach(WebSiteData webSiteData in SiteData)
            {
                webSiteData.StartPingTimer();
            }
        }

    }
}
