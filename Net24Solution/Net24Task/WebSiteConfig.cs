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
    public class WebSiteConfig
    {
        public int CheckInterval { get; set; }
        public int ServerResponseTime { get; set; }
        public string PageUrl { get; set; }
        public string AdminEmail { get; set; }

        public override string ToString()
        {
            return $"{PageUrl} \t{CheckInterval/1000} \t{AdminEmail}";
        }
    }
}
