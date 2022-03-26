using System;
using System.Text;
using System.IO;

namespace Listeners
{
    public class TextListener : IListener
    {
        public TextListener(TextListenerConfig txtConfig)
        {
            MinLogLevel = txtConfig.MinLogLevel;
            FileName = txtConfig.FileName;
        }
        public int MinLogLevel { get; set; }
        public string FileName { get; set; }

        public void WriteToLogFile(string message)
        {
            File.WriteAllText(FileName, message);
            Console.WriteLine($"I'm writing to {FileName}");
        }
    }
}