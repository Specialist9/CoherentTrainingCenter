﻿using System;
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
    public class SiteMonitoringApp
    {
        public List<WebSite> WebSites { get; set; }
        public WebSiteConfig[] WebsiteConfigs { get; set; }
        //List of tasks TList


        public SiteMonitoringApp()
        {
            var cfg = GetAppSettings();

            WebsiteConfigs = cfg.GetSection("configArray").Get<WebSiteConfig[]>();

            WebSites = new();

            foreach (var config in WebsiteConfigs)
            {
                WebSites.Add(new WebSite(config));
            }

        }

        IConfigurationRoot GetAppSettings()
        {
            var builder = new ConfigurationBuilder()
                           .SetBasePath(Directory.GetCurrentDirectory())
                           .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            IConfigurationRoot configuration = builder.Build();
            
            configuration.Reload();

            return configuration;
        }

        
        public void ReloadWebsiteSettings()
        {
            var cfg = GetAppSettings();

            WebsiteConfigs = cfg.GetSection("configArray").Get<WebSiteConfig[]>();

            WebSites = new();

            foreach (var config in WebsiteConfigs)
            {
                WebSites.Add(new WebSite(config));
            }
        }

        public void StartTimers()
        {
            foreach(var item in WebSites)
            {
                item.StartPingTimer();
            }

        }
        
    }
}
