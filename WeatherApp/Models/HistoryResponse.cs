using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WeatherApp.Models
{
	public class HistoryResponse
	{
		public int Id { get; set; }
		public Weather Weather { get; set; }
		public DateTime Time { get; set; }
	}
}