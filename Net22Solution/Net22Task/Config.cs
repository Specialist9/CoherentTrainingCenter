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

		/*
		[XmlText]
		public int Text { get; set; }*/
	}

	[XmlRoot(ElementName = "login")]
	public class Login
	{

		[XmlElement(ElementName = "window")]
		public List<Window> Window { get; set; }

		[XmlAttribute(AttributeName = "name")]
		public string Name { get; set; }

		/*
		[XmlText]
		public double Text { get; set; }*/
	}

	[XmlRoot(ElementName = "config")]
	public class Config
	{

		[XmlElement(ElementName = "login")]
		public List<Login> Login { get; set; }

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
				sb.AppendLine();
            }
			return sb.ToString();
        }
    }
}
