using System.Data.Common;
using System.Data.Entity;
using WeatherApp.DataAccess.Entities;

namespace WeatherApp.DataAccess.Contexts
{
	public class EntityFrameworkContext : DbContext
	{
		public EntityFrameworkContext() : base("name=myConnectionString")
		{
			Database.SetInitializer(new CitiesDbInitializer());
		}

		public EntityFrameworkContext(DbConnection connection) : base(connection, true)
		{
		}

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			modelBuilder.Entity<HistoryItemDb>()
				.HasOptional(h => h.WeatherDb)
				.WithRequired(ad => ad.HistoryItemDb)
				.WillCascadeOnDelete(true);
			base.OnModelCreating(modelBuilder);
		}

		public DbSet<CityDb> Cities { get; set; }
		public DbSet<HistoryItemDb> History { get; set; }
	}
}
