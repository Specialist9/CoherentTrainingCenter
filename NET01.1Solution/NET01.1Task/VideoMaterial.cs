﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NET01._1Task
{
    public class VideoMaterial : Entity, IVersionable
    {
        public byte[] Version;
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

        public VideoMaterial(string description, string urlVideo, string urlSplash, VideoFormat vidFormatVal) : base (description)
        {
            URLVideo = String.IsNullOrEmpty(description)? throw new ArgumentNullException(nameof(urlVideo), "URL cannot be empty") : urlVideo;
            URLSplashScreen = urlSplash;
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
