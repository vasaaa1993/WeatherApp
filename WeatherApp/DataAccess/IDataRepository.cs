using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherApp.DataAccess.Entities;
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
