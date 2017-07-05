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

		public ActionResult Index()
        {
			return View();
        }

		// GET: /Weather/Index
		[HttpPost]
		public ActionResult Index(string city, string time)
		{
			if (city == "" || city == null)
			{
				return View("Index");
			}
			int nPeriod = int.Parse(time);
			var weather = _weatherService.GetWeatherByTownName(city, int.Parse(time));

			switch (nPeriod)
			{
				case 3:
					return View("ThreeDays", weather);
				case 7:
					return View("SevenDays", weather);
				default:
					return View("CurrentDay", weather);
			}
		}
	}
}