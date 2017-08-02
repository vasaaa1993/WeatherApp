using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
		public async Task<IEnumerable<City>> GetAllCities()
		{
			var arr = await _repo.Cities.GetAll();
			return arr.Select(CityDb2City).ToArray();
		}

		public async Task<bool> DeleteCity(int id)
		{
			bool rez = await _repo.Cities.Delete(id);
			_repo.Save();
			return rez;
		}

		public async Task<City> GetCity(int id)
		{
			return CityDb2City( await _repo.Cities.Get(id));
		}

		public async Task<City> AddCity(string name)
		{
			if (string.IsNullOrEmpty(name)) return null;
			var city = await _repo.Cities.Add(new CityDb(){Name = name});
			_repo.Save();
			return CityDb2City(city);
		}

		public async Task<IEnumerable<HistoryResponse>> GetAllHistoryItems()
		{
			var history =  await _repo.History.GetAll();
			return history.Select(HistoryDb2HistoryResponse).ToArray();
		}

		public async Task<bool> ClearHistory()
		{
			var rez = await _repo.History.ClearAll();
			_repo.Save();
			return rez;
		}

		public async Task<bool> AddResponseToHistory(Weather weather)
		{
			var history = HistoryDbItemFromWeather(weather);
			HistoryItemDb item = null;
			if (history != null)
			{
				item = await _repo.History.Add(history);
				_repo.Save();
			}
			return (item == null) ? true : false;
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