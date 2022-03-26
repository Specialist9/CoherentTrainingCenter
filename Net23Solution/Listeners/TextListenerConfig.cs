﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Listeners
{
    public class TextListenerConfig
    {
        public string FileName { get; set; }
        public int MinLogLevel { get; set; }

        public const string SectionName = "fileListener";

        public override string ToString()
        {
            return $"{FileName} - {MinLogLevel}";
        }
    }
}
