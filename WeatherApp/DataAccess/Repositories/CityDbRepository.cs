using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
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

		public async Task<IEnumerable<CityDb>> GetAll()
		{
			return await _ctx.Cities.ToArrayAsync();
		}

		public async Task<bool> ClearAll()
		{
			return await Task.Run(() => {
				_ctx.Cities.RemoveRange(_ctx.Cities);
				return true;
			});
		}

		public async Task<CityDb> Get(int id)
		{
			return await _ctx.Cities.FirstOrDefaultAsync(c => c.Id == id);
		}

		public async Task<bool> Delete(int id)
		{
			var city = await _ctx.Cities.FirstOrDefaultAsync(c => c.Id == id);
			return await Task.Run(() =>
			{
				if (city != null)
				{
					_ctx.Cities.Remove(city);
					return true;
				}
				return false;
			});

		}


		public async Task<CityDb> Add(CityDb item)
		{
			return await Task.Run(() => { return  item != null ? _ctx.Cities.Add(item) : null; });
		}

	}
}