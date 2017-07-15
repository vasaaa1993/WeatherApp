using System.Threading.Tasks;
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
			var list = _repository.GetAllCities();
			ViewBag.DefaultCities = list;

			var weather = await _weatherService.GetWeatherByTownName(city, time ?? "1");
			_repository.AddResponseToHistory(weather);
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