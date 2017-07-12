using System.Threading.Tasks;
using WeatherApp.Models;

namespace WeatherApp.Services
{
	public interface IWeatherService
	{
		Task<Weather> GetWeatherByTownName(string name, string dayPeriod);
	}
}