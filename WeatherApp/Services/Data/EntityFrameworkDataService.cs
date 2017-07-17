using System;
using System.Collections.Generic;
using System.Linq;
using WeatherApp.DataAccess;
using WeatherApp.DataAccess.Entities;
using WeatherApp.Models;

namespace WeatherApp.Services.Data
{
	public class EntityFrameworkDataService : IDataService
	{
		readonly RepositoriesUnitOfWork _repo;

		public EntityFrameworkDataService()
		{
			_repo = new RepositoriesUnitOfWork();
		}
		public EntityFrameworkDataService(RepositoriesUnitOfWork repo)
		{
			if(repo != null)
				_repo = repo;
			else 
				_repo = new RepositoriesUnitOfWork();

		}
		public IEnumerable<City> GetAllCities()
		{
			return _repo.Cities.GetAll().Select(CityDb2City).ToList();
		}

		public void DeleteCity(int id)
		{
			_repo.Cities.Delete(id);
			_repo.Save();
		}

		public void AddCity(string name)
		{
			if (string.IsNullOrEmpty(name)) return;
			_repo.Cities.Add(new CityDb(){Name = name});
			_repo.Save();
		}

		public IEnumerable<HistoryResponse> GetAllHistoryItems()
		{
			return _repo.History.GetAll().Select(HistoryDb2HistoryResponse).ToList();
		}

		public void ClearHistory()
		{
			_repo.History.ClearAll();
			_repo.Save();
		}

		public void AddResponseToHistory(Weather weather)
		{
			var history = HistoryDbItemFromWeather(weather);
			if (history != null)
			{
				_repo.History.Add(history);
				_repo.Save();
			}
		}

		#region Helpers

		public static City CityDb2City(CityDb city)
		{
			if (city == null)
				return null;
			return new City
			{
				Id = city.Id,
				Name = city.Name
			};
		}

		public static CityDb City2CityDb(City city)
		{
			if (city == null)
				return null;
			return new CityDb
			{
				Id = city.Id,
				Name = city.Name
			};
		}

		public static Weather WeatherDb2Wearter(WeatherDb weather)
		{
			if (weather == null)
				return null;
			return new Weather
			{
				CityName = weather.City,
				CountryCodeOfTheCity = weather.Country,
				WeatherList = new List<WeatherListItem>
				{
					new WeatherListItem
					{
						Clouds = weather.Clouds,
						DayTemp = weather.DayTemp,
						Description = weather.Description,
						Humidity = weather.Humidity,
						Icon = weather.Icon,
						MaxTemp = weather.MaxTemp,
						MinTemp = weather.MinTemp,
						Pressure = weather.Pressure,
						Time = weather.Time,
						WindSpeed = weather.WindSpeed
					}
				}
			};
		}

		public static WeatherDb Weather2WearterDb(Weather weather)
		{
			if (weather == null || weather.WeatherList.Count == 0)
				return null;

			return new WeatherDb
			{
				City = weather.CityName,
				Country = weather.CountryCodeOfTheCity,
				Clouds = weather.WeatherList[0].Clouds,
				DayTemp = weather.WeatherList[0].DayTemp,
				Description = weather.WeatherList[0].Description,
				Humidity = weather.WeatherList[0].Humidity,
				Icon = weather.WeatherList[0].Icon,
				MaxTemp = weather.WeatherList[0].MaxTemp,
				MinTemp = weather.WeatherList[0].MinTemp,
				Pressure = weather.WeatherList[0].Pressure,
				Time = weather.WeatherList[0].Time,
				WindSpeed = weather.WeatherList[0].WindSpeed
			};
		}

		public static HistoryResponse HistoryDb2HistoryResponse(HistoryItemDb history)
		{
			if (history == null)
				return null;
			return new HistoryResponse
			{
				Id = history.Id,
				Time = history.Time,
				Weather = WeatherDb2Wearter(history.WeatherDb)
			};
		}

		public static HistoryItemDb HistoryDbItemFromWeather(Weather weather)
		{
			var w = Weather2WearterDb(weather);
			if (weather == null)
				return null;
			return new HistoryItemDb
			{
				Time = DateTime.Now,
				WeatherDb = w
			};
		}


		#endregion
	}
}