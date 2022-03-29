using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NLog;

namespace Net24Task
{
    public class MonitoringApp
    {
        //public List<WebSiteConfig> SiteConfig { get; set; }
        public List<WebSiteData> SiteData { get; set; }
        public Logger MLogger { get; set; }

        public MonitoringApp()
        {
            //SiteConfig = new List<WebSiteConfig>();
            SiteData = new List<WebSiteData>();
            MLogger = LogManager.GetCurrentClassLogger();
        }

        public void DisplayPingStatus()
        {
            foreach(WebSiteData siteData in SiteData)
            {
                siteData.DisplayPingReply();
                MLogger.Info(siteData.LogPingReply());
            }
        }

    }
}
