﻿using System;

namespace WeatherApp.DataAccess.Entities
{
	public class WeatherDB
	{
		public int Id { get; set; }

		public DateTime Time { get; set; }

		public int MinTemp { get; set; }
		public int MaxTemp { get; set; }
		public int DayTemp { get; set; }

		public string City { get; set; }

		public string Description { get; set; }
		public double Humidity { get; set; }
		public double Pressure { get; set; }
		public int Clouds { get; set; }
		public double WindSpeed { get; set; }

		public string Icon { get; set; }
	}
}