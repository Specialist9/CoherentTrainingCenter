using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NET01._1Task
{
    public class NetworkResource : Entity
    {
        public string URLContent { get; set; }

        public enum LinkType
        {
            Unknown,
            Html,
            Image,
            Audio,
            Video
        }

        public LinkType LinkTypeValue { get; set; }
        public NetworkResource(string description, string urlContent, LinkType linkValue) : base (description)
        {
            URLContent = String.IsNullOrEmpty(urlContent)? throw new ArgumentNullException(nameof(urlContent), "URL link cannot be empty") : urlContent;
            LinkTypeValue = linkValue;
        }

        public override string ToString()
        {
            return Description.ToString();
        }
    }
}
