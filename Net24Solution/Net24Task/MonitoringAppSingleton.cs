using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Net24Task
{
    public sealed class MonitoringAppSingleton
    {
        private static MonitoringAppSingleton? instance = null;
        private static readonly object padlock = new();
        public int CheckInterval { get; private set; }
        public int ServerResponseTime { get; private set; }
        public string PageUrl { get; private set; }
        public string AdminEmail { get; private set; }

        private MonitoringAppSingleton()
        {

        }

        public static MonitoringAppSingleton Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new MonitoringAppSingleton();
                    }
                    return instance;
                }
            }
        }

        public void WriteSomething()
        {
            Console.WriteLine("MonitoringApp instance created");
        }
    }
}
