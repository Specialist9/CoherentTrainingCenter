using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Net24Task
{
    public class WebSiteConfig
    {
        public int CheckInterval { get; set; }
        public int ServerResponseTime { get; set; }
        public string PageUrl { get; set; }
        public string AdminEmail { get; set; }

        public const string SectionName = "yahoo";

        public override string ToString()
        {
            return $"{ SectionName} - {PageUrl}";
        }
    }
}
