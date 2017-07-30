using System.Threading.Tasks;
using UwpWeatherClient.Models;

namespace UwpWeatherClient.Services
{
	public interface IWeatherService
	{
		Task<Weather> GetWeather(string city, int period);
	}
}
