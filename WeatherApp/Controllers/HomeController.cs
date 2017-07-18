using System;
using System.Threading.Tasks;
using System.Web.Mvc;
using WeatherApp.Services.Data;
using WeatherApp.Services.WeatherAPI;

namespace WeatherApp.Controllers
{
	public class HomeController : Controller
	{
		private readonly IWeatherService _weatherService;
		private readonly IDataService _dataService;

		public HomeController(IWeatherService service, IDataService dataService)
		{
			_weatherService = service;
			_dataService = dataService;
		}

		public async Task<ActionResult> Index(string city, string time)
		{
			var list = _dataService.GetAllCities();
			ViewBag.DefaultCities = list;

			var weather = await _weatherService.GetWeatherByTownName(city, time ?? "1");
			_dataService.AddResponseToHistory(weather);;
			return View(weather);
		}

		public ActionResult About()
		{
			return View();
		}

		public ActionResult Contact()
		{
			ViewBag.Message = "Contact page.";

			return View();
		}
	}
}