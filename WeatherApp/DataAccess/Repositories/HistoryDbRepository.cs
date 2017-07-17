using System.Collections.Generic;
using System.Linq;
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
		public IEnumerable<HistoryItemDb> GetAll()
		{
			return _ctx.History.ToList();
		}

		public void ClearAll()
		{
			foreach (var historyItemDb in _ctx.History)
				_ctx.History.Remove(historyItemDb);
		}

		public HistoryItemDb Get(int id)
		{
			return _ctx.History.FirstOrDefault(h => h.Id == id);
		}

		public void Delete(int id)
		{
			var history = _ctx.History.FirstOrDefault(h => h.Id == id);
			if (history != null)
				_ctx.History.Remove(history);
		}

		public void Add(HistoryItemDb item)
		{
			if(item != null)
				_ctx.History.Add(item);
		}
	}
}