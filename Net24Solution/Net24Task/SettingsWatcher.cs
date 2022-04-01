using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Net24Task
{
    public class SettingsWatcher
    {
        public string AppSettingsFilePath { get; set; }

        public SettingsWatcher()
        {
            AppSettingsFilePath = Directory.GetCurrentDirectory();
            var fileWatcher = new FileSystemWatcher(AppSettingsFilePath);
            fileWatcher.EnableRaisingEvents = true;

            fileWatcher.Filter = "appsettings2.json";
            fileWatcher.NotifyFilter = NotifyFilters.LastWrite | NotifyFilters.LastAccess;

            fileWatcher.Changed += OnChanged;

        }

        private void OnChanged(object source, FileSystemEventArgs e)
        {
            Console.WriteLine("File: " + e.FullPath + " " + e.ChangeType);

        }
    }
}
