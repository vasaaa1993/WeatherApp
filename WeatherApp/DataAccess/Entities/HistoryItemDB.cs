using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WeatherApp.DataAccess.Entities
{
	[Table("History")]
	public class HistoryItemDb
	{
		[Key]
		public int Id { get; set; }
		[Column(TypeName = "DateTime2")]
		public DateTime Time { get; set; }
		public virtual WeatherDb WeatherDb { get; set; }
	}
}