using System;
using System.Web.Mvc;
using WeatherApp.DataAccess;

namespace WeatherApp.Controllers
{
    public class HistoryController : Controller
    {
	    private static IDataRepository _repository;
		// GET: History
	    public HistoryController(IDataRepository repository)
	    {
			if (_repository == null)
			{
				if (repository != null)
				{
					_repository = repository;
				}
				else
				{
					throw new ArgumentNullException("repository");
				}
			}
		}
		public ActionResult Index()
        {
	        return View(_repository.GetAllHistoryItem());
        }

	    public ActionResult Clear()
	    {
			_repository.ClearHistory();
		    return RedirectToAction("Index");
	    }
	}
}