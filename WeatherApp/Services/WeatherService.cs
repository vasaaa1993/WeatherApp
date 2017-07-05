using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using WeatherApp.Models;

namespace WeatherApp.Services
{
	public class WeatherService
	{
		//Weather curWeather;
		static string _csApiKey = "23b01724e74886b5b2c736310beeb965";
		public WeatherService()
		{
		}

		public Weather GetWeatherByTownName(string name, int dayPeriod)
		{
			HttpWebRequest apiRequest = WebRequest.Create($"http://api.openweathermap.org/data/2.5/forecast/daily?q=London&type=accurate&units=metric&cnt={dayPeriod}&APPID={_csApiKey}") as HttpWebRequest;
			string apiResponse = "";
			using (HttpWebResponse response = apiRequest.GetResponse() as HttpWebResponse)
			{
				StreamReader reader = new StreamReader(response.GetResponseStream());
				apiResponse = reader.ReadToEnd();
				return JsonConvert.DeserializeObject<Weather>(apiResponse);
			}
			return new Weather();
		}
	}
}