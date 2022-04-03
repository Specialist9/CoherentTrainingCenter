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
    public class WebSiteData
    {
        public int CheckInterval { get; set; }
        public int ServerResponseTime { get; set; }
        public string PageUrl { get; set; }
        public string AdminEmail { get; set; }

        public Ping PingSite { get; set; }
        public PingReply SiteReply { get; set; }


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

        void ElapsedTimerEventHandler(object sender, System.Timers.ElapsedEventArgs e)
        {
            GetPingReplyAsync();
            DisplayPingResult();
            LogWebSiteStatus();
            SendEmailAsync();
        }



        public async Task SendEmailAsync()
        {
            PingReply pingReplyAsync = await GetPingReplyAsync();

            var smtpClient = new SmtpClient("mail.gmx.net")
            {
                Port = 587,
                Credentials = new NetworkCredential(AdminEmail, "Defiant9?"),
                EnableSsl = true,
                UseDefaultCredentials = false,
                DeliveryMethod = SmtpDeliveryMethod.Network,
            };

            if (pingReplyAsync.Status != IPStatus.Success || pingReplyAsync.RoundtripTime > ServerResponseTime)
            {
                smtpClient.Send("sugarush@gmx.de", AdminEmail, $"{PageUrl} - Server time out", "messagebody");
            }
        }


        public async Task LogWebSiteStatus()
        {
            StringBuilder temp = new();

            PingReply pingReply1 = await GetPingReplyAsync();

            if (pingReply1.Status == IPStatus.Success && pingReply1.RoundtripTime < ServerResponseTime)
            {
                temp.AppendLine($"{DateTime.Now} \tHost: {PageUrl} - Status: {SiteReply.Status} \tResponse time: {SiteReply.RoundtripTime}");

            }
            else if (pingReply1.Status != IPStatus.Success || pingReply1.RoundtripTime > ServerResponseTime)
            {
                temp.AppendLine($"{DateTime.Now} \tHost: {PageUrl} \tStatus: Unavailable");
            }

            File.AppendAllText($"{DateTime.UtcNow.ToString("yyyy-MM-dd")} SiteResponseLog.txt", temp.ToString());

        }

        public async Task DisplayPingResult()
        {
            PingReply pingReplyAsync2 = await GetPingReplyAsync();

            if (pingReplyAsync2.Status == IPStatus.Success && pingReplyAsync2.RoundtripTime < ServerResponseTime)
            {
                Console.WriteLine($"Host: {PageUrl} \tStatus: {SiteReply.Status} \tResponse time: {SiteReply.RoundtripTime}");

            }
            else if (pingReplyAsync2.RoundtripTime > ServerResponseTime)
            {
                Console.WriteLine($"Host: {PageUrl} \tStatus: Unavailable");
            }
        }
    }
}
