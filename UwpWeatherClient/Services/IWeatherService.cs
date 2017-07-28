using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UwpWeatherClient.Models;

namespace UwpWeatherClient.Services
{
	interface IWeatherService
	{
		Task<Weather> GetWeather(string city, int period);
	}
}
