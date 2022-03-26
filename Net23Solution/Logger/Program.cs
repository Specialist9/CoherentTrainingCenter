using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
using System.Configuration;
using System.ComponentModel;
using LoggerApp;

namespace LoggerApp
{
    public class Program
    {
        static void Main(string[] args)
        {

            Student student1 = new(18, "John Doe", 27, "+37012345678", "johndoe@gmail.com");
            Logger logger1 = new();
            logger1.Track(student1, Logger.LogLevel.Error);

        }
    }
}



