using System.Collections.Generic;
using System.Threading.Tasks;
using WeatherApp.Models;

namespace WeatherApp.Services.Data
{
	public interface IDataService
	{
		//Cities
		Task<IEnumerable<City>> GetAllCities();

		Task<bool> DeleteCity(int id);
		Task<City> GetCity(int id);
		Task<City> AddCity(string name);

		//History
		Task<IEnumerable<HistoryResponse>> GetAllHistoryItems();

		Task<bool> ClearHistory();
		Task<bool> AddResponseToHistory(Weather weather);
	}
}
