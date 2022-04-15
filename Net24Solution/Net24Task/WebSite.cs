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
        private int _checkInterval;
        private int _serverResponseTime;
        private string _pageUrl;
        private string _adminEmail;

        private Ping _pingSite;
        private PingReply _siteReply;


        public WebSite(WebSiteConfig config)
        {
            _checkInterval = config.CheckInterval;
            _serverResponseTime = config.ServerResponseTime;
            _pageUrl = config.PageUrl;
            _adminEmail = config.AdminEmail;
        }

        public void StartPingTimer()
        {
            System.Timers.Timer pingTimer = new();
            pingTimer.Interval = _checkInterval;
            pingTimer.Elapsed += ElapsedTimerEventHandler;
            pingTimer.Start();
        }
        
        async Task<PingReply> GetPingReplyAsync()
        {
            _pingSite = new();
            _siteReply = _pingSite.Send(_pageUrl);

            return _siteReply;
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
                Credentials = new NetworkCredential(_adminEmail, "Defiant9?"),
                EnableSsl = true,
                UseDefaultCredentials = false,
                DeliveryMethod = SmtpDeliveryMethod.Network,
            };

            if (_siteReply.Status != IPStatus.Success || _siteReply.RoundtripTime > _serverResponseTime)
            {
                smtpClient.Send("sugarush@gmx.de", _adminEmail, $"{_pageUrl} - Server time out", "messagebody");
            }
        }


        public void LogWebSiteStatus()
        {
            StringBuilder temp = new();

            if (_siteReply.Status == IPStatus.Success && _siteReply.RoundtripTime < _serverResponseTime)
            {
                temp.AppendLine($"{DateTime.Now} \tHost: {_pageUrl} \tStatus: {_siteReply.Status} \tResponse time: {_siteReply.RoundtripTime}");

            }
            else if (_siteReply.Status != IPStatus.Success || _siteReply.RoundtripTime > _serverResponseTime)
            {
                temp.AppendLine($"{DateTime.Now} \tHost: {_pageUrl} \tStatus: Unavailable");
            }

            File.AppendAllText($"{DateTime.UtcNow.ToString("yyyy-MM-dd")} SiteResponseLog.txt", temp.ToString());

        }

        public void DisplayPingResult()
        {
            if (_siteReply.Status == IPStatus.Success && _siteReply.RoundtripTime < _serverResponseTime)
            {
                Console.WriteLine($"Host: {_pageUrl} \tStatus: {_siteReply.Status} \tResponse time: {_siteReply.RoundtripTime}");

            }
            else if (_siteReply.RoundtripTime > _serverResponseTime)
            {
                Console.WriteLine($"Host: {_pageUrl} \tStatus: Unavailable");
            }
        }

        public override string ToString()
        {
            StringBuilder temp = new();
            temp.AppendLine($"Host: {_pageUrl} \tInterval s: {_checkInterval/1000} \tResponse time: {_adminEmail}");
            return temp.ToString();
        }
    }
}
