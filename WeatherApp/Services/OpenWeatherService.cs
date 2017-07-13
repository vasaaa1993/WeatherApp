using System;
using System.Configuration;
using System.Net.Http;
using System.Threading.Tasks;
using WeatherApp.ApiResponseConvenrters;
using WeatherApp.Models;

namespace WeatherApp.Services
{
	public class OpenWeatherService : IWeatherService
	{
		private readonly IApiResponseConverter _converter;

		//Weather curWeather;
		public OpenWeatherService(IApiResponseConverter converter)
		{
			if(converter == null)
				throw new ArgumentNullException("converter");
			_converter = converter;
		}

		public async Task<Weather> GetWeatherByTownName(string name, string dayPeriod)
		{
			if (name == null)
				return null;
			int nDayPeriod;
			if (!int.TryParse(dayPeriod, out nDayPeriod))
				nDayPeriod = 1;
			var sUrl =
				$"http://api.openweathermap.org/data/2.5/forecast/daily?q={name}&type=accurate&units=metric&cnt={nDayPeriod}&APPID={ConfigurationManager.AppSettings["apiKey"]}";
			try
			{
				using (var client = new HttpClient())
				using (var response = await client.GetAsync(sUrl))
				using (var content = response.Content)
				{
					var apiResponse = await content.ReadAsStringAsync();
					return _converter.Convert(apiResponse);
				}
			}
			catch (Exception)
			{
				return null;
			}
		}
	}
}