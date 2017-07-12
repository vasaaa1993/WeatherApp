using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherApp.DataAccess.Entities;
using City = WeatherApp.Models.City;

namespace WeatherApp.DataAccess
{
	public interface IDataRepository
	{
		//Cities
		IEnumerable<City> GetAllCities();
		void DeleteCityById(int id);
		void AddCity(string name);
		
		//History
		IEnumerable<HistoryItemDB> GetAllHistoryItem();
		void ClearHistory();
		void AddHistory(string name);
	}
}
