using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Antlr.Runtime.Misc;
using WeatherApp.DataAccess;
using WeatherApp.Models;

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