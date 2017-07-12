using System;

namespace WeatherApp.DataAccess.Entities
{
	public class HistoryItemDb
	{
		public int Id { get; set; }
		public DateTime Time { get; set; }
		public WeatherDb WeatherDb { get; set; }
	}
}