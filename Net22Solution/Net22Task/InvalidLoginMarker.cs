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
    internal class InvalidLoginMarker
    {
        string XMLFileName { get; set; }
        string FilePath { get; set; }
        XDocument xmlDoc { get; set; }

        public InvalidLoginMarker(string fileName)
        {
            XMLFileName = fileName;
            FilePath = Directory.GetCurrentDirectory() + $@"\{fileName}";
            xmlDoc = XDocument.Load(FilePath);
        }

        public void MarkInvalidLogins()
        {
            foreach(var log in xmlDoc.Descendants("login"))
            {
                log.Add(new XAttribute("isvalid", " "));
            }

            foreach (var log in xmlDoc.Descendants("login"))
            {
                var numberOfMainWindows = (from window in log.Descendants("window")
                                           where (window.Attribute("title").Value == "main")
                                           select window).Count();

                if(numberOfMainWindows == 0)
                {
                    var loginWithNoMainWindow = from login in xmlDoc.Descendants("login")
                                                select login;
                    foreach(var item in loginWithNoMainWindow)
                    {
                        item.SetAttributeValue("isvalid", "true");
                    }
                }
                else if(numberOfMainWindows == 1)
                {
                    log.SetAttributeValue("isvalid", "true");

                    var loginWithMissingWindowSetting = from login in xmlDoc.Descendants("login")
                                                        from window in login.Descendants("window")
                                                        where (window.Attribute("title").Value == "main")
                                                        where (window.Element("top") == null ||
                                                                window.Element("left") == null ||
                                                                window.Element("width") == null ||
                                                                window.Element("height") == null)
                                                        select login;
                    foreach(var item in loginWithMissingWindowSetting)
                    {
                        item.SetAttributeValue("isvalid", "false");
                    }
                }
                else if(numberOfMainWindows > 1)
                {
                    var loginWithSeveralMainWindows = from login in xmlDoc.Descendants("login")
                                                    select login;

                    foreach (var item in loginWithSeveralMainWindows)
                    {
                        item.SetAttributeValue("isvalid", "false");
                    }
                }
            }

            xmlDoc.Save("XMLConfigMarked.xml");
        }
    }
}
