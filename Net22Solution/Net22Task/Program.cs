using System;
using System.IO;
using System.Xml;
using System.Xml.Linq;
using System.Linq;
using System.Collections.Generic;
using System.Xml.XPath;
using Net22Task;


XDocument xml = XDocument.Load(@"C:\Users\KestutisKravcovas\source\repos\CoherentTrainingCenter\Net22Solution\Net22Task\XMLConfig.xml");


XMLToObjectDeserializer ser = new XMLToObjectDeserializer();
string path = string.Empty;
string xmlInputData = string.Empty;


// EXAMPLE 2
path = Directory.GetCurrentDirectory() + @"\XMLConfig.xml";
xmlInputData = File.ReadAllText(path);

Config config = ser.Deserialize<Config>(xmlInputData);

//Console.ReadLine();

Console.WriteLine($"{config.Login[0].Window[1].Left}");


/*
var query = from login in xml.Descendants("login")
			 from window in login.Elements("window")
			 from sizes in window.Elements()
			 select new
			 {
				 User = login.Attribute("name").Value,
				 Window = window.Attribute("title").Value,
				 Values = sizes.Value
			 };

var queryGrouped = from item in query
					group item by new { item.User, item.Window } into g
					select g;


Console.WriteLine("---------Query-----------");
foreach (var element in queryGrouped)
{
	Console.WriteLine($"{element.Key}");
	foreach (var item in element)
	{
		Console.Write($"{item.Values},");

	}
	Console.WriteLine();

}
*/
