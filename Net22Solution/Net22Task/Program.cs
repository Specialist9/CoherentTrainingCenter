using System;
using System.IO;
using System.Xml;
using System.Xml.Linq;
using System.Linq;
using System.Collections.Generic;
using System.Xml.XPath;


XDocument xml = XDocument.Load(@"C:\Users\KestutisKravcovas\source\repos\CoherentTrainingCenter\Net22Solution\Net22Task\XMLConfig.xml");


var query = from login in xml.Descendants("login").GroupBy(x => x.Attribute("name").Value)
			 from window in login.Elements("window").GroupBy(l => l.Attribute("title").Value)
			 from sizes in window.Elements()
			 select new
			 {
				 User = login.Key,
				 Window = window.Key,
				 Values = sizes.Value
			 };

var grouped2 = from item in query
			   group item by new { item.User, item.Window } into g
			   select g;


Console.WriteLine("---------Query-----------");
foreach (var element in grouped2)
{
	Console.WriteLine($"{element.Key}");
	foreach (var item in element)
	{
		Console.Write($"{item.Values},");

	}
	Console.WriteLine();

}

