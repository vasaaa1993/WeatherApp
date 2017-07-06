using System;
using System.Collections.Generic;
using System.Linq;
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

		public ActionResult Index()
		{
			return View();
		}

		public ActionResult About()
		{
			ViewBag.Message = "Your application description page.";

			return View();
		}

		public ActionResult Contact()
		{
			ViewBag.Message = "Your contact page.";

			return View();
		}
	}
}