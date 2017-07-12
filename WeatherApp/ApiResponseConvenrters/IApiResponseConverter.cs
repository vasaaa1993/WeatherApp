using WeatherApp.Models;

namespace WeatherApp.ApiResponseConvenrters
{
	public interface IApiResponseConverter
	{
		Weather Convert(string sResponse);
	}
}