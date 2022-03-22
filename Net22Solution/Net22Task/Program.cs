using System;
using System.IO;
using System.Xml;
using System.Xml.Linq;
using System.Linq;
using System.Collections.Generic;
using System.Xml.XPath;
using System.Text.Json;
using Net22Task;

//Check XML file for valid logins and display result
XmlLoginValidator configVal1 = new("XMLConfig.xml");
Console.WriteLine(configVal1.DisplayLoginValidity());

//Mark XML file Login elements with isvalid attribute according to validity
InvalidLoginMarker marker1 = new("XMLConfig.xml");
marker1.MarkInvalidLogins();

//Deserialize Marked XML file to objects
XMLToObjectDeserializer ser = new XMLToObjectDeserializer();
string path = string.Empty;
string xmlInputData = string.Empty;

path = Directory.GetCurrentDirectory() + @"\XMLConfigMarked.xml";
xmlInputData = File.ReadAllText(path);

// Create classes from Marked XML into manually created Config.cs
Config config = ser.Deserialize<Config>(xmlInputData);

//Display all logins
Console.WriteLine(config.ToString());

//Display invalid logins
Console.WriteLine(config.DisplayInvalidLogins().ToString());

//Create JSON Serializer and serialize created classes into JSON file
ConfigToJSONSerializer loginsToJson = new(config);
loginsToJson.SerializeConfig();



//Create classes into XSD created XMLConfig.cs
//config XMLConfig = ser.Deserialize<config>(xmlInputData);


//Console.WriteLine($"{config.Login[0].Window[1].Left}");












