using System;
using System.Threading.Tasks;
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

		public async Task<ActionResult> Index()
		{
			return View(await _dataService.GetAllHistoryItems());
		}

		public async Task<ActionResult> Clear()
		{
			await _dataService.ClearHistory();
			return RedirectToAction("Index");
		}
	}
}