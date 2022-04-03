using System;
using System.IO;
using System.Xml;
using System.Xml.Linq;
using System.Linq;
using System.Collections.Generic;
using System.Xml.XPath;
using System.Text.Json;
using Net22Task;


//Deserialize XML file into manually created classes

XmlConfigReader ser = new XmlConfigReader();
string path = string.Empty;
string xmlInputData = string.Empty;

path = Directory.GetCurrentDirectory() + @"\XMLConfig.xml";
xmlInputData = File.ReadAllText(path);

//Check XML file for valid logins and display result
Config configX = ser.Deserialize<Config>(xmlInputData);

Console.WriteLine(configX.DisplayLoginValidity());

//Display all logins
Console.WriteLine(configX.ToString());

//Display invalid logins
Console.WriteLine(configX.DisplayInvalidLogins2().ToString());

//Create JSON Serializer and serialize created classes into JSON file
ConfigToJsonWriter loginsToJson = new(configX);
loginsToJson.SerializeConfig();



//Create classes into XSD created XMLConfig.cs
//config XMLConfig = ser.Deserialize<config>(xmlInputData);


//Console.WriteLine($"{config.Login[0].Window[1].Left}");












