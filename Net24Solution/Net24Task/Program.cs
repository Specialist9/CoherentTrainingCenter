using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
using Microsoft.Extensions.Logging;
using System.Text.Json;
using Newtonsoft.Json;
using NLog;
using System.Net.NetworkInformation;
using Net24Task;

class Program
{


    async static Task Main(string[] args)
    {
        //await PingUrl();

        string jsonString = File.ReadAllText("appsettings2.json");
        MonitoringApp mApp1 = new();

        mApp1.SiteData = JsonConvert.DeserializeObject<List<WebSiteData>>(jsonString);

        foreach (WebSiteData item in mApp1.SiteData)
        {
            Console.WriteLine(item);
            item.SendStatusEmail();

        }
        Console.WriteLine("-----------------------");
        mApp1.DisplayPingStatus();
        

        Console.WriteLine("-----------------------");
        /*
        Logger log = LogManager.GetCurrentClassLogger();
        log.Debug("This is a debug message");
        log.Error(new Exception(), "This is an error message");
        log.Fatal("This is a fatal message");
        */

        //WebSiteData yahooSite = new();
        //yahooSite.PingUrl();


        /*
        async Task PingUrl()
        {
            var hostUrl = "www.yahoo.com";
            Ping ping = new();
            PingReply result = await ping.SendPingAsync(hostUrl);
            var res =  result.RoundtripTime;
            Console.WriteLine(res);
        }
        */

        //Console.ReadLine();

    }

}
    




