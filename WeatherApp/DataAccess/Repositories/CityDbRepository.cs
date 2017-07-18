using System.Collections.Generic;
using System.Linq;
using WeatherApp.DataAccess.Contexts;
using WeatherApp.DataAccess.Entities;

namespace WeatherApp.DataAccess.Repositories
{
	public class CityDbRepository:IRepository<CityDb>
	{
		private readonly EntityFrameworkContext _ctx;
		public CityDbRepository(EntityFrameworkContext ctx)
		{
			_ctx = ctx;
		}
		public IEnumerable<CityDb> GetAll()
		{
			return _ctx.Cities.ToList();
		}

		public void ClearAll()
		{
			foreach (var item in _ctx.Cities)
				_ctx.Cities.Remove(item);
		}

		public CityDb Get(int id)
		{
			return _ctx.Cities.FirstOrDefault(c => c.Id == id);
		}

		public void Delete(int id)
		{
			var city = _ctx.Cities.FirstOrDefault(c => c.Id == id);
			if (city != null)
				_ctx.Cities.Remove(city);
		}

		public CityDb Add(CityDb item)
		{
			return item != null ? _ctx.Cities.Add(item) : null;
		}
	}
}