using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WeatherApp.DataAccess.Entities
{
	[Table("Weather")]
	public class WeatherDb
	{
		[Key]
		[ForeignKey("HistoryItemDb")]
		public int Id { get; set; }

		[Column(TypeName = "DateTime")]
		public DateTime Time { get; set; }

		public double MinTemp { get; set; }
		public double MaxTemp { get; set; }
		public double DayTemp { get; set; }

		[StringLength(50)]
		public string City { get; set; }

		[StringLength(10)]
		public string Country { get; set; }

		[StringLength(30)]
		public string Description { get; set; }

		public double Humidity { get; set; }
		public double Pressure { get; set; }
		public int Clouds { get; set; }
		public double WindSpeed { get; set; }

		[StringLength(20)]
		public string Icon { get; set; }

		public int StudentId { get; set; }
		public virtual HistoryItemDb HistoryItemDb { get; set; }
	}
}