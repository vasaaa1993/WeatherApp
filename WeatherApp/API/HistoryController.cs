using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;
using WeatherApp.Models;
using WeatherApp.Services.Data;

namespace WeatherApp.API
{
	[EnableCors(origins: "http://localhost:50185", headers: "*", methods: "*")]
	public class HistoryController : ApiController
    {
	    private readonly IDataService _dataService;
	    public HistoryController(IDataService service)
	    {
		    _dataService = service;
	    }
		// GET: api/History
	    public IEnumerable<HistoryResponse> GetHistory()
	    {
		    return _dataService.GetAllHistoryItems();
	    }

		// Delete /api/History
	    [ResponseType(typeof(void))]
	    [HttpDelete]
	    public IHttpActionResult ClearHistory()
	    {
		    _dataService.ClearHistory();
		    return Ok();
	    }
	}
}
