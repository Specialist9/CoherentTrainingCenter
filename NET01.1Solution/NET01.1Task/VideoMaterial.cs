using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NET01._1Task
{
    public class VideoMaterial : Entity
    {
        public string URLVideo { get; set; }
        public string? URLSplashScreen { get; set; }

        public enum VideoFormat
        {
            Unknown,
            Avi,
            Mp4,
            Flv
        };

        public VideoFormat VideoFormatValue { get; set; }

        public VideoMaterial(string description, string urlvideo, string urlsplash, VideoFormat vidformatval) : base (description)
        {
            URLVideo = String.IsNullOrEmpty(description)? throw new ArgumentNullException(nameof(urlvideo), "URL cannot be empty") : urlvideo;
            URLSplashScreen = urlsplash;
            VideoFormatValue = vidformatval;
        }

        public override string ToString()
        {
            return Description.ToString();
        }
    }
}
