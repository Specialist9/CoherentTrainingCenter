using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.NetworkInformation;
using System.Net.Mail;
using System.Net;
using System.Dynamic;
using System.Timers;

namespace Net24Task
{
    public class WebSite
    {
        public int CheckInterval { get; set; }
        public int ServerResponseTime { get; set; }
        public string PageUrl { get; set; }
        public string AdminEmail { get; set; }

        public Ping PingSite { get; set; }
        public PingReply SiteReply { get; set; }


        public WebSite(WebSiteConfig config)
        {
            CheckInterval = config.CheckInterval;
            ServerResponseTime = config.ServerResponseTime;
            PageUrl = config.PageUrl;
            AdminEmail = config.AdminEmail;
        }

        public void StartPingTimer()
        {
            System.Timers.Timer pingTimer = new();
            pingTimer.Interval = CheckInterval;
            pingTimer.Elapsed += ElapsedTimerEventHandler;
            pingTimer.Start();
        }
        
        async Task<PingReply> GetPingReplyAsync()
        {
            PingSite = new();
            SiteReply = PingSite.Send(PageUrl);

            return SiteReply;
        }

        async void ElapsedTimerEventHandler(object sender, System.Timers.ElapsedEventArgs e)
        {
            await GetPingReplyAsync();
            
            DisplayPingResult();
            LogWebSiteStatus();
            await SendEmailAsync();
        }



        public async Task SendEmailAsync()
        {
            var smtpClient = new SmtpClient("mail.gmx.net")
            {
                Port = 587,
                Credentials = new NetworkCredential(AdminEmail, "Defiant9?"),
                EnableSsl = true,
                UseDefaultCredentials = false,
                DeliveryMethod = SmtpDeliveryMethod.Network,
            };

            if (SiteReply.Status != IPStatus.Success || SiteReply.RoundtripTime > ServerResponseTime)
            {
                smtpClient.Send("sugarush@gmx.de", AdminEmail, $"{PageUrl} - Server time out", "messagebody");
            }
        }


        public async Task LogWebSiteStatus()
        {
            StringBuilder temp = new();

            if (SiteReply.Status == IPStatus.Success && SiteReply.RoundtripTime < ServerResponseTime)
            {
                temp.AppendLine($"{DateTime.Now} \tHost: {PageUrl} \tStatus: {SiteReply.Status} \tResponse time: {SiteReply.RoundtripTime}");

            }
            else if (SiteReply.Status != IPStatus.Success || SiteReply.RoundtripTime > ServerResponseTime)
            {
                temp.AppendLine($"{DateTime.Now} \tHost: {PageUrl} \tStatus: Unavailable");
            }

            File.AppendAllText($"{DateTime.UtcNow.ToString("yyyy-MM-dd")} SiteResponseLog.txt", temp.ToString());

        }

        public async Task DisplayPingResult()
        {
            if (SiteReply.Status == IPStatus.Success && SiteReply.RoundtripTime < ServerResponseTime)
            {
                Console.WriteLine($"Host: {PageUrl} \tStatus: {SiteReply.Status} \tResponse time: {SiteReply.RoundtripTime}");

            }
            else if (SiteReply.RoundtripTime > ServerResponseTime)
            {
                Console.WriteLine($"Host: {PageUrl} \tStatus: Unavailable");
            }
        }

        public override string ToString()
        {
            StringBuilder temp = new();
            temp.AppendLine($"Host: {PageUrl} \tInterval s: {CheckInterval/1000} \tResponse time: {AdminEmail}");
            return temp.ToString();
        }
    }
}
