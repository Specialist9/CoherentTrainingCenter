using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Net22Task
{

	[XmlRoot(ElementName = "window")]
	public class Window
	{

		[XmlElement(ElementName = "top")]
		public int Top { get; set; }

		[XmlElement(ElementName = "left")]
		public int Left { get; set; }

		[XmlElement(ElementName = "width")]
		public int Width { get; set; }

		[XmlElement(ElementName = "height")]
		public int Height { get; set; }

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

		public bool LoginIsValid()
        {
			return LoginHasOnlyOneMainWindow() && Window.Where(x => x.MainWindowHasAllElements()).Any();
		}
		

        public override string ToString()
        {
			StringBuilder sb = new();
			sb.Append(Name);
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
			StringBuilder stringBuilder = new();
			foreach(var login in Login)
            {
				if(!login.LoginIsValid())
				stringBuilder.Append(login.ToString());
            }
			return stringBuilder.ToString();
        }

        public override string ToString()
        {
            StringBuilder sb = new ();
			foreach(var login in Login)
            {
				sb.AppendLine($"Login: {login.Name}");

				foreach(var window in login.Window)
                {
					sb.Append($"{window.Title.ToString()} ({window.Top}, {window.Left}, {window.Width}, {window.Height}) \n");
                }
            }
			return sb.ToString();
        }
    }
}
