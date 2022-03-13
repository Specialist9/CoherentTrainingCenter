using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NET01._1Task
{
    public class NetworkResource : Entity
    {
        public Uri ContentUri;

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
            ContentUri = Uri.TryCreate(urlContent, UriKind.Absolute, out ContentUri) ? new Uri(urlContent) : throw new ArgumentNullException(nameof(urlContent), "Content URL cannot be empty");

            LinkTypeValue = linkValue;
        }

    }
}
