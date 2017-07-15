﻿using System;
using System.Collections.Generic;
using System.Linq;
using WeatherApp.DataAccess.Entities;
using WeatherApp.Models;

namespace WeatherApp.DataAccess
{
	public class EntityFrameworkDataRepository : IDataRepository
	{
		private readonly EntityFrameworkContext _ctx;

		public EntityFrameworkDataRepository(EntityFrameworkContext ctx = null)
		{
			_ctx = ctx ?? new EntityFrameworkContext();
		}

		public IEnumerable<City> GetAllCities()
		{
			IList<City> cities = new List<City>();
			foreach (var cityDb in _ctx.Cities)
				cities.Add(CityDb2City(cityDb));
			return cities;
		}

		public void DeleteCityById(int id)
		{
			var city = _ctx.Cities.FirstOrDefault(c => c.Id == id);
			if (city != null)
			{
				_ctx.Cities.Remove(city);
				_ctx.SaveChanges();
			}
		}

		public void AddCity(string name)
		{
			if (string.IsNullOrEmpty(name))
				return;
			_ctx.Cities.Add(new CityDb
			{
				Name = name
			});
			_ctx.SaveChanges();
		}

		public IEnumerable<HistoryResponse> GetAllHistoryItem()
		{
			IList<HistoryResponse> history = new List<HistoryResponse>();
			foreach (var historyDb in _ctx.History.ToList())
			{
				var w = historyDb.WeatherDb;
				history.Add(HistoryDb2HistoryResponse(historyDb));
			}
			return history;
		}

		public void ClearHistory()
		{
			foreach (var item in _ctx.History)
				_ctx.History.Remove(item);
			_ctx.SaveChanges();
		}

		public void AddResponseToHistory(Weather weather)
		{
			var history = HistoryDbItemFromWeather(weather);
			if (history != null)
			{
				_ctx.History.Add(history);
				_ctx.SaveChanges();
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