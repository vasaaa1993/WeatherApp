using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WeatherApp.DataAccess
{
	public class EnityFrameworkContext : DbContext
	{
		public System.Data.Entity.DbSet<WeatherApp.DataAccess.Entities.CityDB> Cities { get; set; }
	}
}