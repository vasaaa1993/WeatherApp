using System;
using System.Web.Mvc;
using WeatherApp.DataAccess;

namespace WeatherApp.Controllers
{
    public class CitiesController : Controller
    {
	    private static IDataRepository _repository;
	    public CitiesController(IDataRepository repository)
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
        // GET: Product
        public ActionResult Index()
        {
            return View(_repository.GetAllCities());
        }

	    public ActionResult Add(string name)
	    {
			_repository.AddCity(name);
		    return RedirectToAction("Index");
	    }

	    public ActionResult Delete(int id)
	    {
			_repository.DeleteCityById(id);
		    return RedirectToAction("Index");
	    }
    }
}