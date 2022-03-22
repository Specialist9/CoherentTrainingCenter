using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.IO;



namespace Net22Task
{
    public class ConfigToJSONSerializer
    {
        string strJson { get; set; }
        Config ConfigToSerialize { get; set; }

        public ConfigToJSONSerializer(Config config)
        {
            ConfigToSerialize = config;
        }

        public void SerializeConfig()
        {
            string pathForJSON = Directory.GetCurrentDirectory() + @"\Config";
            Directory.CreateDirectory(pathForJSON);

            foreach(Login login in ConfigToSerialize.Login)
            {
                foreach(var window in login.Window)
                {
                    window.Top = window.Top == null ? 0 : window.Top.Value;
                    window.Left = window.Left == null ? 0 : window.Left.Value;
                    window.Width = window.Width == null ? 400 : window.Width.Value;
                    window.Height = window.Height == null ? 150 : window.Height.Value;
                }
            }

            foreach (Login login in ConfigToSerialize.Login)
            {
                string subDir = Path.Combine(pathForJSON, login.Name);
                Directory.CreateDirectory(subDir);

                string fileName = $"{login.Name}_config.json";
                string pathAndFileName = Path.Combine(subDir, fileName);

                string jsonString = JsonSerializer.Serialize(login);

                File.WriteAllText(pathAndFileName, jsonString);
                //Console.WriteLine(File.ReadAllText(pathAndFileName));
                
            }

        }


    }
}
