﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
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
			_converter = converter;
		}

		public async Task<Weather> GetWeatherByTownName(string name, string dayPeriod)
		{
			if (name == null)
				return null;
			int nDayPeriod;
			if (!int.TryParse(dayPeriod, out nDayPeriod))
				nDayPeriod = 1;
			string sUrl = $"http://api.openweathermap.org/data/2.5/forecast/daily?q={name}&type=accurate&units=metric&cnt={nDayPeriod}&APPID={ConfigurationManager.AppSettings["apiKey"]}";
			try
			{
				using (HttpClient client = new HttpClient())
				using (HttpResponseMessage response = await client.GetAsync(sUrl))
				using (HttpContent content = response.Content)
				{
					string apiResponse = await content.ReadAsStringAsync();
					return _converter.Convert(apiResponse);
				}
			}
			catch(Exception)
			{
				return null;
			}
		}
	}
}