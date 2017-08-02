using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;
using WeatherApp.Models;
using WeatherApp.Services.Data;

namespace WeatherApp.API
{
	[EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
	public class HistoryController : ApiController
    {
	    private readonly IDataService _dataService;
	    public HistoryController(IDataService service)
	    {
		    _dataService = service;
	    }
		// GET: api/History
	    public async Task<IEnumerable<HistoryResponse>> GetHistory()
	    {
		    return await _dataService.GetAllHistoryItems();
	    }

		// Delete /api/History
	    [ResponseType(typeof(void))]
	    [HttpDelete]
	    public async Task<IHttpActionResult> ClearHistory()
	    {
		    var rez = await _dataService.ClearHistory();
		    return Ok();
	    }
	}
}
