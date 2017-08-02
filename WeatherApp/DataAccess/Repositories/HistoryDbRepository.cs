using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using WeatherApp.DataAccess.Contexts;
using WeatherApp.DataAccess.Entities;

namespace WeatherApp.DataAccess.Repositories
{
	public class HistoryDbRepository : IRepository<HistoryItemDb>
	{
		private readonly EntityFrameworkContext _ctx;
		public HistoryDbRepository(EntityFrameworkContext ctx)
		{
			_ctx = ctx;
		}
		public async Task<IEnumerable<HistoryItemDb>> GetAll()
		{
			return await _ctx.History.ToArrayAsync();
		}

		public async Task<bool> ClearAll()
		{
			return await Task.Run(() => {
				_ctx.History.RemoveRange(_ctx.History);
				return true;
				});
		}

		public async Task<HistoryItemDb> Get(int id)
		{
			return await _ctx.History.FirstOrDefaultAsync(h => h.Id == id);
		}

		public async Task<bool> Delete(int id)
		{
			var history = await _ctx.History.FirstOrDefaultAsync(h => h.Id == id);
			return await Task.Run(() =>
			{
				if (history != null)
				{
					_ctx.History.Remove(history);
					return true;
				}
				return false;
			});
			
		}

		public async Task<HistoryItemDb> Add(HistoryItemDb item)
		{
			return await Task.Run(() => { return item != null ? _ctx.History.Add(item) : null; });
		}
	}
}