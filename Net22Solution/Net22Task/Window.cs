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
}
