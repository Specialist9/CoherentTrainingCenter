using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.NetworkInformation;
using System.Net.Mail;
using System.Net;

namespace Net24Task
{
    public class WebSiteData
    {
        public int CheckInterval { get; set; }
        public int ServerResponseTime { get; set; }
        public string PageUrl { get; set; }
        public string AdminEmail { get; set; }

        public Ping PingSite { get; set; }
        public PingReply SiteReply { get; set; }
        /*
        public WebSiteData(WebSiteConfig siteConfig)
        {
            CheckInterval = siteConfig.CheckInterval;
            ServerResponseTime = siteConfig.ServerResponseTime;
            PageUrl = siteConfig.PageUrl;
            AdminEmail = siteConfig.AdminEmail;
        }
        */

        public void DisplayPingReply()
        {
            PingSite = new();
            SiteReply = PingSite.Send(PageUrl);
            if(SiteReply.Status == IPStatus.Success && SiteReply.RoundtripTime < ServerResponseTime)
            {
                Console.WriteLine($"Host: {PageUrl} - Status: {SiteReply.Status} - Response time: {SiteReply.RoundtripTime}");

            }
            else if(SiteReply.RoundtripTime > ServerResponseTime)
            {
                Console.WriteLine($"Host: {PageUrl} - Status: Unavailable");
            }
        }

        public string ReportWebSiteStatus()
        {
            StringBuilder temp = new();
            PingSite = new();
            SiteReply = PingSite.Send(PageUrl);
            if (SiteReply.Status == IPStatus.Success && SiteReply.RoundtripTime < ServerResponseTime)
            {
                temp.Append($"Host: {PageUrl} - Status: {SiteReply.Status} - Response time: {SiteReply.RoundtripTime}");

            }
            else if(SiteReply.RoundtripTime > ServerResponseTime)
            {
                temp.Append($"Host: {PageUrl} - Status: Unavailable");
                //SendStatusEmail();
            }

            return temp.ToString();
        }
        

        public void SendStatusEmail()
        {
            var smtpClient = new SmtpClient("mail.gmx.net")
            {
                Port = 587,
                Credentials = new NetworkCredential(AdminEmail, "Defiant9?") ,
                EnableSsl = true,
                UseDefaultCredentials = false,
                DeliveryMethod = SmtpDeliveryMethod.Network,
            };


            PingSite = new();
            SiteReply = PingSite.Send(PageUrl);

            if (SiteReply.Status != IPStatus.Success)
            {
                smtpClient.Send("sugarush@gmx.de", AdminEmail, $"{PageUrl} - {SiteReply.Status}", "messagebody");
            }
            else if(SiteReply.RoundtripTime > ServerResponseTime)
            {
                smtpClient.Send("sugarush@gmx.de", AdminEmail, $"{PageUrl} - Server time out", "messagebody");
            }

        }

        public override string ToString()
        {
            return $"Host: {PageUrl} - Admin email: {AdminEmail}";
        }
    }
}
