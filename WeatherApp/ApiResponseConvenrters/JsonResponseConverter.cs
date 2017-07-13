using System;
using System.Linq;
using Newtonsoft.Json;
using WeatherApp.Models;

namespace WeatherApp.ApiResponseConvenrters
{
	public class JsonResponseConverter : IApiResponseConverter
	{
		public Weather Convert(string sResponse)
		{
			if (sResponse == null)
				return null;
			var weather = JsonConvert.DeserializeObject<Models.OpenWeather.Weather>(sResponse);
			if (weather == null)
				return null;
			return OpenWeather2Weather(weather);
		}

		public static DateTime TimeStampToDateTime(int javaTimeStamp)
		{
			// Java timestamp is milliseconds past epoch
			var dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
			dtDateTime = dtDateTime.AddMilliseconds(javaTimeStamp).ToLocalTime();
			return dtDateTime;
		}

		private static Weather OpenWeather2Weather(Models.OpenWeather.Weather w)
		{
			var weather = new Weather
			{
				CityName = w.city.name,
				CountryCodeOfTheCity = w.city.country
			};
			foreach (var item in w.list)
				weather.WeatherList.Add(
					new WeatherListItem
					{
						Icon = $"{item.weather[0].id}{item.weather[0].icon.ElementAt(2)}.png",
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
			return weather;
		}
	}
}