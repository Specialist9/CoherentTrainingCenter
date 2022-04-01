using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.NetworkInformation;
using System.Net.Mail;
using System.Net;
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

        public PingReply PingWebsite()
        {
            PingSite = new();
            SiteReply = PingSite.Send(PageUrl);
            return SiteReply;
        }

        async Task<PingReply> GetPingReplyAsync()
        {
            PingSite = new();
            SiteReply = PingSite.Send(PageUrl);

            return SiteReply;
        }

        void ElapsedTimerEventHandler(object sender, System.Timers.ElapsedEventArgs e)
        {
            PingWebsite();
            DisplayPingResult();
            LogWebSiteStatus();
            SendEmailAsync();
        }


        public void DisplayPingReply()
        {
            System.Timers.Timer pingTimer = new();
            pingTimer.Interval = CheckInterval;
            pingTimer.Elapsed += ElapsedTimerEventHandler;
            pingTimer.Start();
            
            void ElapsedTimerEventHandler(object sender, System.Timers.ElapsedEventArgs e)
            {
                DisplayPingResult();
            }

            void DisplayPingResult()
            {
                PingSite = new();
                SiteReply = PingSite.Send(PageUrl);
                if (SiteReply.Status == IPStatus.Success && SiteReply.RoundtripTime < ServerResponseTime)
                {
                    Console.WriteLine($"Host: {PageUrl} - Status: {SiteReply.Status} - Response time: {SiteReply.RoundtripTime}");

                }
                else if (SiteReply.RoundtripTime > ServerResponseTime)
                {
                    Console.WriteLine($"Host: {PageUrl} - Status: Unavailable");
                }
            }

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


        public async Task<string> LogWebSiteStatus()
        {
            StringBuilder temp = new();
            //PingSite = new();

            //SiteReply = PingSite.Send(PageUrl);
            PingReply pingReplyAsync2 = await GetPingReplyAsync();

            if (pingReplyAsync2.Status == IPStatus.Success && pingReplyAsync2.RoundtripTime < ServerResponseTime)
            {
                temp.Append($"Host: {PageUrl} - Status: {SiteReply.Status} - Response time: {SiteReply.RoundtripTime}");

            }
            else if(pingReplyAsync2.Status != IPStatus.Success || pingReplyAsync2.RoundtripTime > ServerResponseTime)
            {
                temp.Append($"Host: {PageUrl} - Status: Unavailable");
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
            smtpClient.Send("sugarush@gmx.de", AdminEmail, $"{PageUrl} - Server time out", "messagebody");

        }

        public override string ToString()
        {
            return $"Host: {PageUrl} - Admin email: {AdminEmail}";
        }

        void DisplayPingResult()
        {
            //PingSite = new();
            //SiteReply = PingSite.Send(PageUrl);
            if (SiteReply.Status == IPStatus.Success && SiteReply.RoundtripTime < ServerResponseTime)
            {
                Console.WriteLine($"Host: {PageUrl} - Status: {SiteReply.Status} - Response time: {SiteReply.RoundtripTime}");

            }
            else if (SiteReply.RoundtripTime > ServerResponseTime)
            {
                Console.WriteLine($"Host: {PageUrl} - Status: Unavailable");
            }
        }


    }
}
