using System.Collections.Generic;
using WeatherApp.Models;

namespace WeatherApp.DataAccess
{
	public interface IDataRepository
	{
		//Cities
		IEnumerable<City> GetAllCities();

		void DeleteCityById(int id);
		void AddCity(string name);

		//History
		IEnumerable<HistoryResponse> GetAllHistoryItem();

		void ClearHistory();
		void AddResponseToHistory(Weather weather);
	}
}