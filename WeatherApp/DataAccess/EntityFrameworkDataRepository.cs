using System;
using System.Collections.Generic;
using System.Linq;
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

		public IEnumerable<HistoryResponse> GetAllHistoryItem()
		{
		  return new List<HistoryResponse>()
		   {
			   new HistoryResponse()
			   {
				   Id = 1,
				   Time = DateTime.Now,
				   Weather = new Weather()
				   {
					   CityName = "Lviv",
					   CountryCodeOfTheCity = "UA",
					   WeatherList = new List<WeatherListItem>()
					   {
						   new WeatherListItem()
						   {
							   Clouds = 20,
							   DayTemp = 22,
							   Description = "sky is clear",
							   Humidity = 75,
							   Icon = "800n.png",
							   MaxTemp = 25,
							   MinTemp = 18,
							   Pressure = 815,
							   Time = DateTime.Now,
							   WindSpeed = 5
						   }
					   }
				   }
			   },
			   new HistoryResponse()
			   {
			   Id = 2,
			   Time = DateTime.Now,
			   Weather = new Weather()
			   {
				   CityName = "Lviv",
				   CountryCodeOfTheCity = "UA",
				   WeatherList = new List<WeatherListItem>()
				   {
					   new WeatherListItem()
					   {
						   Clouds = 20,
						   DayTemp = 22,
						   Description = "sky is clear",
						   Humidity = 75,
						   Icon = "800n.png",
						   MaxTemp = 25,
						   MinTemp = 18,
						   Pressure = 815,
						   Time = DateTime.Now,
						   WindSpeed = 5
					   }
				   }
			   }
		   },
			   new HistoryResponse()
			   {
				   Id = 3,
				   Time = DateTime.Now,
				   Weather = new Weather()
				   {
					   CityName = "Lviv",
					   CountryCodeOfTheCity = "UA",
					   WeatherList = new List<WeatherListItem>()
					   {
						   new WeatherListItem()
						   {
							   Clouds = 20,
							   DayTemp = 22,
							   Description = "sky is clear",
							   Humidity = 75,
							   Icon = "800n.png",
							   MaxTemp = 25,
							   MinTemp = 18,
							   Pressure = 815,
							   Time = DateTime.Now,
							   WindSpeed = 5
						   }
					   }
				   }
			   }

		   };
		}

		public void ClearHistory()
		{
			;
		}

		public void AddResponseToHistory(Weather weather)
		{
			;
		}
	}
}