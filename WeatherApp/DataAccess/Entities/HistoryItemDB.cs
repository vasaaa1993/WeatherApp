using System;

namespace WeatherApp.DataAccess.Entities
{
	public class HistoryItemDB
	{
		public int Id { get; set; }
		public DateTime Time { get; set; }
		public WeatherDB WeatherDb { get; set; }
	}
}