using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WeatherApp.DataAccess.Entities
{
	public class EntityFrameworkContext : DbContext
	{
		public EntityFrameworkContext():base("name=myConnectionString")
		{
			Database.SetInitializer(new CitiesDbInitializer());
		}
		public DbSet<CityDb> Cities { get; set; }
		public DbSet<HistoryItemDb> History { get; set; }
	}
}