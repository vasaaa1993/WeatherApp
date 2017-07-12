using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Antlr.Runtime.Misc;
using WeatherApp.Models;

namespace WeatherApp.Controllers
{
    public class HistoryController : Controller
    {
        // GET: History
        public ActionResult Index()
        {
            return View(new List<HistoryResponse>()
			{
				new HistoryResponse()
				{
					Id = 1,
					Time = DateTime.Now,
					Weather = new Weather()
					{
						CityName = "Lviv",
						CountryCodeOfTheCity = "UA",
						WeatherList = new ListStack<WeatherListItem>()
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
					WeatherList = new ListStack<WeatherListItem>()
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
						WeatherList = new ListStack<WeatherListItem>()
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

			});
        }
    }
}