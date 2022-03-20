using System;
using System.Globalization;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.ComponentModel;
using Newtonsoft.Json;

namespace Net22Task
{

	[XmlRoot(ElementName = "window")]
	public class Window
	{

		[XmlElement(ElementName = "top")]
		public int? Top { get; set; }

		[XmlElement(ElementName = "left")]
		public int? Left { get; set; }


		[XmlElement(ElementName = "width")]
		public int? Width { get; set; }

		[XmlElement(ElementName = "height")]
		public int? Height { get; set; }

		[XmlAttribute(AttributeName = "title")]
		public string Title { get; set; }

		public bool MainWindowHasAllElements()
        {
			return Top > 0 && Left > 0 && Width > 0 && Height > 0 && Title == "main";
        }

		
		[XmlText]
		public string Text { get; set; }
	}

	[XmlRoot(ElementName = "login")]
	public class Login
	{

		[XmlElement(ElementName = "window")]
		public List<Window> Window { get; set; }

		[XmlAttribute(AttributeName = "name")]
		public string Name { get; set; }

		public bool LoginHasOnlyOneMainWindow()
        {
			return Window.Where(x => x.Title == "main").Count() == 1;
        }

		public bool LoginHasNoMainWindow()
        {
			return Window.Where(x => x.Title == "main").Count() == 0;
		}

		public bool LoginIsValid()
        {
			if(LoginHasOnlyOneMainWindow() && Window.Where(x => x.MainWindowHasAllElements()).Any())
            {
				return true;
            }
			else if (LoginHasNoMainWindow())
            {
				return true;
            }
            else
            {
				return false;
            }
		}
		

        public override string ToString()
        {
			StringBuilder sb = new();
			sb.AppendLine(Name);
			foreach (var window in Window)
			{
				sb.Append($"{window.Title.ToString()} ({window.Top}, {window.Left}, {window.Width}, {window.Height}) \n");
			}
			return sb.ToString();
        }


        [XmlText]
		public string Text { get; set; }
	}

	[XmlRoot(ElementName = "config")]
	public class Config
	{

		[XmlElement(ElementName = "login")]
		public List<Login> Login { get; set; }

		public string PrintInvalidLogins()
        {
			StringBuilder sb = new();
			sb.AppendLine("Invalid Logins:");
			foreach(var login in Login)
            {
				if(!login.LoginIsValid())
				sb.Append(login.ToString());
            }
			return sb.ToString();
        }

        public override string ToString()
        {
            StringBuilder sb = new ();
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
    }
}
