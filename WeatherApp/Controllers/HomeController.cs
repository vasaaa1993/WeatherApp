using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using WeatherApp.DataAccess;
using WeatherApp.Services;

namespace WeatherApp.Controllers
{
	public class HomeController : Controller
	{
		private static IWeatherService _weatherService;
		private static IDataRepository _repository;
		public HomeController(IWeatherService service, IDataRepository repository)
		{
			_weatherService = service;
			_repository = repository;
		}

		public async Task<ActionResult> Index(string city, string time)
		{
			ViewBag.DefaultCities = _repository.GetAllCities(); 

			var weather = await _weatherService.GetWeatherByTownName(city, time ?? "1");
			if (weather != null)
			{
				_repository.AddResponseToHistory(weather);
			}
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