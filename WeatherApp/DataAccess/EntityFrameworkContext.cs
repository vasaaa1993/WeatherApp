using System.Data.Entity;
using WeatherApp.DataAccess.Entities;

namespace WeatherApp.DataAccess
{
	public class EntityFrameworkContext : DbContext
	{
		public EntityFrameworkContext() : base("name=myConnectionString")
		{
			Database.SetInitializer(new CitiesDbInitializer());
		}

		public DbSet<CityDb> Cities { get; set; }
		public DbSet<HistoryItemDb> History { get; set; }
	}
}