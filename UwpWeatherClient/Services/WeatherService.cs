using System.Threading.Tasks;
using UwpWeatherClient.Models;

namespace UwpWeatherClient.Services
{
	public class WeatherService : BaseService, IWeatherService
	{
		public async Task<Weather> GetWeather(string city, int period)
		{
			string sUrl = baseApiPath + $"Weather/{city}/{period}";
			return await GetApiResponse<Weather>(sUrl);
		}
	}
}
