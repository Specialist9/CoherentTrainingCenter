using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NET01._1Task
{
    public class VideoMaterial : Entity, IVersionable
    {
        public byte[] Version;
        public Uri VideoUri;
        public Uri SplashScreenUri;

        public enum VideoFormat
        {
            Unknown,
            Avi,
            Mp4,
            Flv
        };

        public VideoFormat VideoFormatValue { get; set; }

        public VideoMaterial(string description, string urlVideo, string urlSplash, VideoFormat vidFormatVal) : base (description)
        {
            VideoUri = Uri.TryCreate (urlVideo, UriKind.Absolute, out VideoUri)? new Uri(urlVideo) : throw new ArgumentNullException(nameof(urlVideo), "Video URL cannot be empty");
            SplashScreenUri = Uri.TryCreate(urlSplash, UriKind.Absolute, out SplashScreenUri) ? new Uri(urlSplash) : throw new ArgumentNullException(nameof(urlSplash), "Splash screen URL cannot be empty");
            VideoFormatValue = vidFormatVal;
            Version = new byte[8];
        }

        public string ReadVersion()
        {
            StringBuilder sb = new StringBuilder();

            foreach(var item in Version)
            {
                sb.Append($"{item.ToString()}.");
            };
            return sb.ToString();
        }

        public void WriteVersion(ulong version)
        {
            Version = BitConverter.GetBytes(version);
        }
    }
}
