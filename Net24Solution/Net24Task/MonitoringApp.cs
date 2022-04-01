using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using NLog;

namespace Net24Task
{
    public class MonitoringApp
    {
        public List<WebSiteData>? SiteData { get; set; }
        public Logger MLogger { get; set; }
        public string WebSiteSettingsFile { get; set; }
        public string WebSiteSettingsDirectory { get; set; }
        public FileSystemWatcher WebSiteWatcher { get; set; }
        

        public MonitoringApp()
        {

            WebSiteSettingsFile = "appsettings2.json";
            string jsonString = File.ReadAllText(WebSiteSettingsFile);
            SiteData = JsonConvert.DeserializeObject<List<WebSiteData>>(jsonString);
            MLogger = LogManager.GetCurrentClassLogger();

            WebSiteSettingsDirectory = Directory.GetCurrentDirectory();
            //var fileWatcher = new FileSystemWatcher(WebSiteSettingsDirectory);
            WebSiteWatcher = new FileSystemWatcher(WebSiteSettingsDirectory);
            WebSiteWatcher.EnableRaisingEvents = true;

            WebSiteWatcher.Filter = WebSiteSettingsFile;
            WebSiteWatcher.NotifyFilter = NotifyFilters.LastWrite | NotifyFilters.LastAccess;

            WebSiteWatcher.Changed += OnChanged;


        }



        public void DisplayAllWebsiteStatus()
        {
            foreach(WebSiteData siteData in SiteData)
            {
                siteData.DisplayPingReply();
            }
        }

        public void ReportAllWebsiteStatus()
        {
            foreach (WebSiteData siteData in SiteData)
            {
                MLogger.Info(siteData.SendEmailAsync());
                //MLogger.Info(siteData.ReportWebSiteStatus());
                //siteData.SendEmailAsync();
            }
            
        }
        
        public void ReloadWebsiteSettings()
        {
            string jsonString = File.ReadAllText(WebSiteSettingsFile);
            SiteData = JsonConvert.DeserializeObject<List<WebSiteData>>(jsonString);

        }

        private void OnChanged(object source, FileSystemEventArgs e)
        {
            Console.WriteLine("File: " + e.FullPath + " " + e.ChangeType);

            ReloadWebsiteSettings();

        }

        public void SendMail()
        {
            foreach(WebSiteData webSiteData in SiteData)
            {
                webSiteData.SendEmailAsync();
            }
        }

        public void StartTimers()
        {
            foreach(WebSiteData webSiteData in SiteData)
            {
                webSiteData.StartPingTimer();
            }
        }

        public async void StartLogger()
        {
            foreach (WebSiteData webSiteData in SiteData)
            {
                string logdata = await webSiteData.LogWebSiteStatus();
                MLogger.Info(logdata);
            }
        }

    }
}
