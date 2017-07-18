using System.Collections.Generic;
using WeatherApp.Models;

namespace WeatherApp.Services.Data
{
	public interface IDataService
	{
		//Cities
		IEnumerable<City> GetAllCities();

		void DeleteCity(int id);
		City GetCity(int id);
		City AddCity(string name);

		//History
		IEnumerable<HistoryResponse> GetAllHistoryItems();

		void ClearHistory();
		void AddResponseToHistory(Weather weather);
	}
}
