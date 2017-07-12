using Newtonsoft.Json;
using System;
using System.Linq;
using WeatherApp.Models;

namespace WeatherApp.ApiResponseConvenrters
{
	public class JsonResponseConverter : IApiResponseConverter
	{
		public static DateTime TimeStampToDateTime(int javaTimeStamp)
		{
			// Java timestamp is milliseconds past epoch
			System.DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
			dtDateTime = dtDateTime.AddMilliseconds(javaTimeStamp).ToLocalTime();
			return dtDateTime;
		}

		private static Weather OpenWeather2Weather(WeatherApp.Models.OpenWeather.Weather w)
		{
			Weather weather = new Weather
			{
				CityName = w.city.name,
				CountryCodeOfTheCity = w.city.country
			};
			foreach (var item in w.list)
			{
				weather.WeatherList.Add(
					new WeatherListItem()
					{
						Icon = $"{ item.weather[0].id }{ item.weather[0].icon.ElementAt(2) }.png",
						Clouds = item.clouds,
						Description = item.weather[0].description,
						Humidity = item.humidity,
						Pressure = item.pressure,
						WindSpeed = item.speed,
						DayTemp = item.temp.day,
						MaxTemp = item.temp.max,
						MinTemp = item.temp.min,
						Time = TimeStampToDateTime(item.dt)
					});
			}
			return weather;
		}
		public Weather Convert(string sResponse)
		{
			var weather = JsonConvert.DeserializeObject<WeatherApp.Models.OpenWeather.Weather>(sResponse);
			return OpenWeather2Weather(weather);
		}
	}
}