using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WeatherApp.Services;
using WeatherApp.Models;

namespace WeatherApp.Controllers
{
    public class WeatherController : Controller
    {
		private static WeatherService _weatherService;

		public WeatherController()
		{
			if (_weatherService == null)
				_weatherService = new WeatherService();
		}

		// GET: /Weather/Index
		public ActionResult Index(Weather model, string city, string time)
		{
			var weather = _weatherService.GetWeatherByTownName(city, time ?? "1");
			return View(weather);
		}
	}
}