using System;

namespace UwpWeatherClient.Models
{
	public class History
	{
		public int Id { get; set; }
		public Weather Weather { get; set; }
		public DateTime Time { get; set; }
	}
}