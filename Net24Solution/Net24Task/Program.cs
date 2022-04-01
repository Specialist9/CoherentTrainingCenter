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


    public async static Task Main(string[] args)
    {
        Console.WriteLine("---------STARTING--------------");

        MonitoringApp mApp1 = new();
         TimerTask();
         LoggerTask();

        //mApp1.ReportAllWebsiteStatus();

        async Task TimerTask()
        {
            mApp1.StartTimers();

        }
        async Task LoggerTask()
        {
            mApp1.StartLogger();

        }

        Console.ReadLine();

        //mApp1.WebSiteWatcher.Changed += delegate { Console.WriteLine("WRITE SOME STUFF"); };
        //mApp1.WebSiteWatcher.Changed += (sender, e) => Console.WriteLine("Lambda expression for eventhandler");


        Console.WriteLine("---------AFTER CHANGING FILE--------------");

        mApp1 = new();
        //mApp1.ReportAllWebsiteStatus();
        mApp1.StartTimers();
        //mApp1.StartLogger();



        Console.ReadLine();
        Console.WriteLine("----------END-------------");


    }

}
    




