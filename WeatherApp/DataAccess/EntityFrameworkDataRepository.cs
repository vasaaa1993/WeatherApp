using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Antlr.Runtime.Tree;
using WeatherApp.DataAccess.Entities;
using WeatherApp.Models;

namespace WeatherApp.DataAccess
{
	public class EntityFrameworkDataRepository : IDataRepository
	{
		private List<City> _cities;
		private int _id;
		public EntityFrameworkDataRepository()
		{
			_id = 7;
			_cities = new List<City>()
			{
				new City(){ Id=1, Name = "London"},
				new City(){ Id=2, Name = "Kiev"},
				new City(){ Id=3, Name = "Lviv"},
				new City(){ Id=4, Name = "Kharkiv"},
				new City(){ Id=5, Name = "Dnipropetrovsk"},
				new City(){ Id=6, Name = "Odessa"}
			};
		}
		public IEnumerable<City> GetAllCities()
		{
			return _cities;
		}

		public void DeleteCityById(int id)
		{
			_cities.Remove(_cities.FirstOrDefault(c => c.Id == id));
		}

		public void AddCity(string name)
		{
			_cities.Add(new City(){Name = name, Id = _id});
			_id++;
		}

		public IEnumerable<HistoryItemDB> GetAllHistoryItem()
		{
			throw new NotImplementedException();
		}

		public void ClearHistory()
		{
			throw new NotImplementedException();
		}

		public void AddHistory(string name)
		{
			throw new NotImplementedException();
		}
	}
}