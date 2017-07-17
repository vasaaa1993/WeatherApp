using System.Collections.Generic;
using System.Data.Entity;
using WeatherApp.DataAccess.Entities;

namespace WeatherApp.DataAccess.Contexts
{
	public class CitiesDbInitializer : CreateDatabaseIfNotExists<EntityFrameworkContext>
	{
		protected override void Seed(EntityFrameworkContext context)
		{
			IList<CityDb> deafaultCities = new List<CityDb>
			{
				new CityDb {Name = "Kiev"},
				new CityDb {Name = "Lviv"},
				new CityDb {Name = "Kharkiv"},
				new CityDb {Name = "Dnipropetrovsk"},
				new CityDb {Name = "Odessa"}
			};
			foreach (var city in deafaultCities)
				context.Cities.Add(city);
			base.Seed(context);
		}
	}
}