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
        public ActionResult Index(Weather model)
        {
			var curWeather = (model.main   == null) ? _weatherService.GetWeatherByTownName("London") : model;
            return View(curWeather);
        }

		// GET: /Weather/Indexi
		[HttpPost]
		public ActionResult Index(string city)
		{
			//_curWeather = _weatherService.GetWeatherByTownName(city);
			return View(_weatherService.GetWeatherByTownName(city));
		}
	}
}