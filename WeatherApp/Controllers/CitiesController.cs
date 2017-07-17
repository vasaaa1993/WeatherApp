using System;
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
		public ActionResult Index()
		{
			return View(_dataService.GetAllCities());
		}

		public ActionResult Add(string name)
		{
			_dataService.AddCity(name);
			return RedirectToAction("Index");
		}

		public ActionResult Delete(int id)
		{
			_dataService.DeleteCity(id);
			return RedirectToAction("Index");
		}
	}
}