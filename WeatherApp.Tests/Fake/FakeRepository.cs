using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherApp.DataAccess;
using WeatherApp.Models;

namespace WeatherApp.Tests.Fake
{
	class FakeRepository:IDataRepository
	{
		private List<HistoryResponse> _history;
		public IEnumerable<City> GetAllCities()
		{
			throw new NotImplementedException();
		}

		public void DeleteCityById(int id)
		{
			throw new NotImplementedException();
		}

		public void AddCity(string name)
		{
			throw new NotImplementedException();
		}

		public IEnumerable<HistoryResponse> GetAllHistoryItem()
		{
			return _history;
		}

		public void ClearHistory()
		{
			_history.Clear();
		}

		public void AddResponseToHistory(Weather weather)
		{
			_history.Add(new HistoryResponse());
		}
	}
}
