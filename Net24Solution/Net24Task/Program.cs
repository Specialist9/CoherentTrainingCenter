using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Hosting;
using System.Text.Json;
using Newtonsoft.Json;
using NLog;
using System.Net.NetworkInformation;
using Net24Task;

class Program
{
    static Mutex mutex = new Mutex(false, "MyApp");


    async static Task Main(string[] args)
    {
        CancellationTokenSource cancelT1 = new();
        CancellationToken token1 = cancelT1.Token;

        //SiteMonitoringApp siteMonitor1 = new();

        Task task1 = new Task(() =>
        {
            SiteMonitoringApp siteMonitor1 = new();
            siteMonitor1.StartTimers();
            while (true)
            {
                if (token1.IsCancellationRequested)
                {
                    return;
                }
            }

        }, token1);


        FileSystemWatcher WebSiteWatcher = new FileSystemWatcher(Directory.GetCurrentDirectory());
        WebSiteWatcher.Filter = "appsettings.json";
        WebSiteWatcher.EnableRaisingEvents = true;
        WebSiteWatcher.NotifyFilter = NotifyFilters.LastWrite | NotifyFilters.LastAccess;

        WebSiteWatcher.Changed += OnChanged;

        void OnChanged(object source, FileSystemEventArgs e)
        {
            Console.WriteLine("File: " + e.FullPath + " " + e.ChangeType);
            cancelT1.Cancel();
 
        }


        if (!mutex.WaitOne(TimeSpan.FromSeconds(3), false))
        {
            Console.WriteLine("Another instance of the app is running. Bye!");
            return;
        }

        try
        {
            Console.WriteLine("Running. Press Enter to exit");
            
            task1.Start();
            //Console.ReadLine();
            //cancelT1.Cancel();
            task1.Wait();
            

            Console.ReadLine();

        }
        catch (AggregateException ae)
        {
            foreach (Exception e in ae.InnerExceptions)
            {
                if (e is System.OperationCanceledException)
                    Console.WriteLine("Task cancelled");
                else
                    Console.WriteLine(e.Message);
            }

        }
        finally 
        { 
            mutex.ReleaseMutex();
            cancelT1.Dispose();

        }

    }

}
    




