using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Dynamic;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using NLog;

namespace Net24Task
{
    public class MonitoringApp
    {
        public List<WebSiteData>? SiteData { get; set; }
        public string WebSiteSettingsFile { get; set; }
        public string WebSiteSettingsDirectory { get; set; }
        public FileSystemWatcher WebSiteWatcher { get; set; }
        

        public MonitoringApp()
        {

            WebSiteSettingsFile = "appsettings2.json";
            string jsonString = File.ReadAllText(WebSiteSettingsFile);

            SiteData = JsonConvert.DeserializeObject<List<WebSiteData>>(jsonString);
            /*
            WebSiteWatcher = new FileSystemWatcher(Directory.GetCurrentDirectory());
            WebSiteWatcher.Filter = WebSiteSettingsFile;
            WebSiteWatcher.EnableRaisingEvents = true;
            WebSiteWatcher.NotifyFilter = NotifyFilters.LastWrite | NotifyFilters.LastAccess;

            WebSiteWatcher.Changed += OnChanged;
            */
        }

       
        public void ReloadWebsiteSettings()
        {
            string jsonStringNew = File.ReadAllText(WebSiteSettingsFile);
            SiteData = JsonConvert.DeserializeObject<List<WebSiteData>>(jsonStringNew);
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
