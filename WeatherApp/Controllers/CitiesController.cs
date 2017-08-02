using System;
using System.Threading.Tasks;
using System.Web.Mvc;
using WeatherApp.Services.Data;

namespace WeatherApp.Controllers
{
	public class CitiesController : Controller
	{
		private readonly IDataService _dataService;

		public CitiesController(IDataService dataService)
		{
			if (_dataService == null)
				if (dataService != null)
					_dataService = dataService;
				else
					throw new ArgumentNullException("dataService");
		}

		// GET: Product
		public async Task<ActionResult> Index()
		{
			var cities = await _dataService.GetAllCities();
			return View(cities);
		}

		public async Task<ActionResult> Add(string name)
		{
			await _dataService.AddCity(name);
			return RedirectToAction("Index");
		}

		public async Task<ActionResult> Delete(int id)
		{
			await _dataService.DeleteCity(id);
			return RedirectToAction("Index");
		}
	}
}