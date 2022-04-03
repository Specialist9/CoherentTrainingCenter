using System;
using System.Globalization;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Xml.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.ComponentModel;
using Newtonsoft.Json;

namespace Net22Task
{

	[XmlRoot(ElementName = "config")]
	public class Config
	{

		[XmlElement(ElementName = "login")]
		public List<Login> Login { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new ();
			sb.AppendLine("All logins");
			foreach(var login in Login)
            {
				sb.AppendLine($"Login: {login.Name}");

				foreach(var window in login.Window)
                {
					sb.Append($"{window.Title.ToString()} ({(window.Top == null ? "?" : window.Top)}," +
														$" {(window.Left == null ? "?" : window.Left)}," +
														$" {(window.Width == null ? "?" : window.Width)}," +
														$" {(window.Height == null ? "?" : window.Height)}) \n");
                }
            }
			return sb.ToString();
        }


		public string DisplayInvalidLogins2()
		{
			StringBuilder sb = new();
			sb.AppendLine("Invalid Logins");
			foreach (var login in Login)
			{
				if (login.LoginIsInvalid())
				{
					sb.AppendLine($"Login: {login.Name}");

					foreach (var window in login.Window)
					{
						sb.Append($"{window.Title.ToString()} ({(window.Top == null ? "?" : window.Top)}," +
															$" {(window.Left == null ? "?" : window.Left)}," +
															$" {(window.Width == null ? "?" : window.Width)}," +
															$" {(window.Height == null ? "?" : window.Height)}) \n");
					}
				}

			}
			return sb.ToString();
		}

        public string DisplayLoginValidity()
        {
            string fileName = "XMLConfig.xml";
            
            var xmlDoc = XDocument.Load(Directory.GetCurrentDirectory() + $@"\{fileName}");

            StringBuilder sb = new();

            foreach (var login in xmlDoc.Descendants("login"))
            {
                var numberOfMainWindows = (from window in login.Descendants("window")
                                           where (window.Attribute("title").Value == "main")
                                           select window).Count();

                if (numberOfMainWindows == 1)
                {
                    var allElementsSet = (from window in login.Descendants("window")
                                          where (window.Attribute("title").Value == "main")
                                          where (window.Element("top") != null &&
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
                else if (numberOfMainWindows == 0)
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
