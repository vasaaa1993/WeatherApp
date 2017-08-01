using System;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;
using WeatherApp.DataAccess.Entities;
using WeatherApp.Models;
using WeatherApp.Services.Data;

namespace WeatherApp.API
{
	[EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
	public class CitiesController : ApiController
    {
	    private readonly IDataService _dataService;

	    public CitiesController(IDataService dataService)
	    {
		    if (dataService != null)
			    _dataService = dataService;
		    else
			    throw new ArgumentNullException("dataService");
	    }

        // GET: api/Cities
        public IEnumerable<City> GetCities()
        {
            return _dataService.GetAllCities();
        }

		// GET: api/Cities/5
		[ResponseType(typeof(City))]
        public IHttpActionResult GetCity(int id)
        {
            City city = _dataService.GetCity(id);
            if (city == null)
            {
                return NotFound();
            }
	   
            return Ok(city);
        }

		// POST: api/Cities
		[ResponseType(typeof(City))]
        public IHttpActionResult PostCity(City city)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

	        var addedCity = _dataService.AddCity(city.Name);

            return CreatedAtRoute("DefaultApi", new { id = addedCity.Id }, addedCity);
        }

		// DELETE: api/Cities/5
		[ResponseType(typeof(CityDb))]
        public IHttpActionResult DeleteCity(int id)
        {
            City city = _dataService.GetCity(id);
			if (city == null)
            {
                return NotFound();
            }
			_dataService.DeleteCity(id);

			return Ok(city);
        }
    }
}