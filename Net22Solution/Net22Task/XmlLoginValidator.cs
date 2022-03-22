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
    public  class XmlLoginValidator
    {
        string XMLFileName { get; set; }
        string FilePath { get; set; }
        XDocument xmlDoc { get; set; }

        public XmlLoginValidator(string fileName)
        {
            XMLFileName = fileName;
            FilePath = Directory.GetCurrentDirectory() + $@"\{fileName}";
            xmlDoc = XDocument.Load(FilePath);
        }


        public string DisplayLoginValidity()
        {
            StringBuilder sb = new();

            foreach (var login in xmlDoc.Descendants("login"))
            {
                var numberOfMainWindows = (from window in login.Descendants("window")
                                            where(window.Attribute("title").Value == "main")
                                            select window).Count();

                if(numberOfMainWindows == 1)
                {
                    var allElementsSet = (from window in login.Descendants("window")
                                            where(window.Attribute("title").Value == "main")
                                            where(window.Element("top") != null && 
                                                    window.Element("left") != null &&
                                                    window.Element("width") != null &&
                                                    window.Element("height") != null)
                                            select window).Any();


                    if (allElementsSet == true)
                    {
                        sb.AppendLine($"Login: {login.Attribute("name").Value} is valid");
                    }
                    else
                    {
                        sb.AppendLine($"Login: {login.Attribute("name").Value} is NOT valid");
                    }
                }
                else if(numberOfMainWindows == 0)
                {
                    sb.AppendLine($"Login: {login.Attribute("name").Value} is valid");
                }
                else
                {
                    sb.AppendLine($"Login: {login.Attribute("name").Value} is NOT valid");
                }
            }
            return sb.ToString();
        }
    }
}
