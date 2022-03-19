using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml;
using System.Xml.Linq;

namespace Net22Task
{
    public  class XMLConfigValidator
    {
        string XMLFileName { get; set; }
        string FilePath { get; set; }
        XDocument xmlDoc { get; set; }

        public XMLConfigValidator(string fileName)
        {
            XMLFileName = fileName;
            FilePath = Directory.GetCurrentDirectory() + $@"\{fileName}";
            xmlDoc = XDocument.Load(FilePath);
        }

        public bool ValidateXMLFile()
        {
            int query = (from login in xmlDoc.Descendants("login")
                        from window in login.Elements("window")
                        where window.Attribute("title").Value == "main"
                        group window by login.Attribute("name").Value into g
                        select g).Distinct().Count();

            int mainCount;
            foreach(var login in xmlDoc.Descendants("login"))
            {
                int nrOfMainWindows = login.Elements("window").Where(x => x.Attribute("title").Value == "main").Count();
                if (nrOfMainWindows != 1)
                {
                    Console.WriteLine("Wrong numerb of Windows");
                }
                else
                {
                    Console.WriteLine("bla");
                }
            }
            return query == 1;

        }



    }
}
