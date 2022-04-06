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

        public bool LoginIsInvalid()
        {
			if (LoginHasOnlyOneMainWindow())
            {
				Window temp = Window.Where(x => x.Title == "main").FirstOrDefault();

				if (temp.MainWindowHasAllElements() == true)
                {
					return false;
                }
            }
			else if (LoginHasNoMainWindow())
            {
				return false;
            }
			return true;
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
}
