using System.Collections.Generic;

namespace UwpWeatherClient.Models
{
	public class Weather
	{
		public Weather()
		{
			WeatherList = new List<WeatherListItem>();
		}

		public string CityName { get; set; }
		public string CountryCodeOfTheCity { get; set; }
		public List<WeatherListItem> WeatherList { get; set; }
	}
}