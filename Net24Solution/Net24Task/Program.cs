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

    public static void Main(string[] args)
    {

        if (!mutex.WaitOne(TimeSpan.FromSeconds(3), false))
        {
            Console.WriteLine("Another instance of the app is running. Bye!");
            return;
        }

        try
        {
            Console.WriteLine("Running. Press Enter to exit");
            MonitoringApp mApp1 = new();
            mApp1.StartTimers();
            Console.ReadLine();
        }
        finally { mutex.ReleaseMutex(); }

    }

}
    




