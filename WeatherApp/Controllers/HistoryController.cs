using System;
using System.Web.Mvc;
using WeatherApp.Services.Data;

namespace WeatherApp.Controllers
{
	public class HistoryController : Controller
	{
		private static IDataService _dataService;

		// GET: History
		public HistoryController(IDataService dataService)
		{
			if (_dataService == null)
				if (dataService != null)
					_dataService = dataService;
				else
					throw new ArgumentNullException("dataService");
		}

		public ActionResult Index()
		{
			return View(_dataService.GetAllHistoryItems());
		}

		public ActionResult Clear()
		{
			_dataService.ClearHistory();
			return RedirectToAction("Index");
		}
	}
}