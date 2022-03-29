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
            var hostUrl = PageUrl;
            Ping ping = new();
            PingReply result = ping.Send(hostUrl);
            if(result.Status == IPStatus.Success && result.RoundtripTime < ServerResponseTime)
            {
                Console.WriteLine($"Host: {hostUrl} - Status: {result.Status} : Response time: {result.RoundtripTime}");

            }
            else
            {
                Console.WriteLine($"{hostUrl} - Something went wrong");
            }
        }

        public string LogPingReply()
        {
            var hostUrl = PageUrl;
            StringBuilder temp = new();
            Ping ping = new();
            PingReply result = ping.Send(hostUrl);
            if (result.Status == IPStatus.Success && result.RoundtripTime < ServerResponseTime)
            {
                temp.Append($"Host: {hostUrl} - Status: {result.Status} : Response time: {result.RoundtripTime}");

            }
            else
            {
                temp.Append($"{hostUrl} - Something went wrong");
            }
            return temp.ToString();
        }
        

        public void SendStatusEmail()
        {
            var smtpClient = new SmtpClient("mail.gmx.net")
            {
                Port = 587,
                Credentials = new NetworkCredential("sugarush@gmx.de", "Defiant9?") ,
                EnableSsl = true,
                UseDefaultCredentials = false,
                DeliveryMethod = SmtpDeliveryMethod.Network,

            };

            smtpClient.Send("sugarush@gmx.de", "sugarush@gmx.de", "subject1", "messagebody");
        }

        public override string ToString()
        {
            return $"{PageUrl} - {AdminEmail}";
        }
    }
}
