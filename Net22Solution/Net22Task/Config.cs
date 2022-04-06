using System;
using System.Globalization;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Xml.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.ComponentModel;
using Newtonsoft.Json;

namespace Net22Task
{

	[XmlRoot(ElementName = "config")]
	public class Config
	{

		[XmlElement(ElementName = "login")]
		public List<Login> Logins { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new ();
			sb.AppendLine("All logins");
			foreach(var login in Logins)
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


		public string DisplayInvalidLogins()
		{
			StringBuilder sb = new();
			sb.AppendLine("Invalid Logins");
			foreach (var login in Logins)
			{
				if (login.LoginIsInvalid())
				{
					sb.AppendLine($"Login: {login.Name}");

					foreach (var window in login.Window)
					{
						sb.Append($"{window.Title.ToString()} ({(window.Top == null ? "?" : window.Top)}," +
															$" {(window.Left == null ? "?" : window.Left)}," +
															$" {(window.Width == null ? "?" : window.Width)}," +
															$" {(window.Height == null ? "?" : window.Height)}) \n");
					}
				}

			}
			return sb.ToString();
		}

    }
}
