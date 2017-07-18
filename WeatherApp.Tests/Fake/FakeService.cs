using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherApp.Models;
using WeatherApp.Services;
using WeatherApp.Services.WeatherAPI;

namespace WeatherApp.Tests.Fake
{
	class FakeService : IWeatherService
	{
		public Task<Weather> GetWeatherByTownName(string name, string dayPeriod)
		{
			if (name == null || name == "")
				return null;
			return new Task<Weather>(() => new Weather());
		}
	}
}
