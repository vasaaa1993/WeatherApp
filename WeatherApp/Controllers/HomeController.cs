using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using WeatherApp.Services;

namespace WeatherApp.Controllers
{
	public class HomeController : Controller
	{
		private static WeatherService _weatherService;
		public HomeController()
		{
			if (_weatherService == null)
				_weatherService = new WeatherService();
		}

		public async Task<ActionResult> Index(string city, string time)
		{
			ViewBag.DefaultCities = new List<string>()
			{
				"Kiev",
				"Lviv",
				"Kharkiv",
				"Dnipropetrovsk",
				"Odessa"
			};

			var weather = await _weatherService.GetWeatherByTownName(city, time ?? "1");
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