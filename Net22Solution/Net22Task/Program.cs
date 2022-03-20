using System;
using System.IO;
using System.Xml;
using System.Xml.Linq;
using System.Linq;
using System.Collections.Generic;
using System.Xml.XPath;
using System.Text.Json;
using Net22Task;


XMLToObjectDeserializer ser = new XMLToObjectDeserializer();
string path = string.Empty;
string xmlInputData = string.Empty;

path = Directory.GetCurrentDirectory() + @"\XMLConfig.xml";
xmlInputData = File.ReadAllText(path);

string pathForJSON = Directory.GetCurrentDirectory() + @"\Config";


// Create classes into manually created Config.cs
Config config = ser.Deserialize<Config>(xmlInputData);

//Create classes into XSD created XMLConfig.cs
config XMLConfig = ser.Deserialize<config>(xmlInputData);



Console.WriteLine($"{config.Login[0].Window[1].Left}");
Console.WriteLine(config.ToString());
Console.WriteLine("---------------------------");


Console.WriteLine("Validation result XMLConfig.xml");

foreach(var login in config.Login)
{
    Console.WriteLine($"{login.Name} - {login.LoginIsValid().ToString()}");
}

Console.WriteLine(config.PrintInvalidLogins());

Console.WriteLine("---------------------------");


Directory.CreateDirectory(pathForJSON);

ConfigToJSONSerializer loginsToJson = new(config);
loginsToJson.SerializeConfig();





