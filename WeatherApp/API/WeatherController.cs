using System;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;
using WeatherApp.Services.Data;
using WeatherApp.Services.WeatherAPI;

namespace WeatherApp.API
{
	[EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
	public class WeatherController : ApiController
    {
		readonly IWeatherService _weatherService;
		private readonly IDataService _dataService;

		public WeatherController(IWeatherService weatherService, IDataService dataService)
	    {
			if(weatherService != null)
				_weatherService = weatherService;
			else
				throw new ArgumentNullException("WeatherService");

			if (dataService != null)
				_dataService = dataService;
			else
				throw new ArgumentNullException("dataService");
		}
		//GET: api/Weather/{name}/{period}
		[Route("api/Weather/{city}/{period}")]
	    public async Task<IHttpActionResult> GetWeather(string city, string period)
		{
			if (string.IsNullOrEmpty(city))
				return BadRequest("City name cannt be empty");
			int nPeriod;
			if (!int.TryParse(period, out nPeriod) || (nPeriod != 1 && nPeriod != 3 && nPeriod != 7))
				return BadRequest("Wrong period of forecast. Period can be one of following value: 1, 3, 7.");
		    var weather = await _weatherService.GetWeatherByTownName(city, period);
			if(weather == null)
				return NotFound();
			_dataService.AddResponseToHistory(weather);
			return Ok(weather);
	    }
    }
}
