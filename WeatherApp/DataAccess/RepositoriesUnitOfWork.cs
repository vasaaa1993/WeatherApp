using System;
using WeatherApp.DataAccess.Contexts;
using WeatherApp.DataAccess.Repositories;

namespace WeatherApp.DataAccess
{
	public class RepositoriesUnitOfWork : IDisposable
	{
		private readonly EntityFrameworkContext _ctx;
		private CityDbRepository _cityRepository;
		private HistoryDbRepository _historyDbRepository;

		public RepositoriesUnitOfWork(EntityFrameworkContext ctx = null)
		{
			_ctx = ctx ?? new EntityFrameworkContext();
		}
		public CityDbRepository Cities => _cityRepository ?? (_cityRepository = new CityDbRepository(_ctx));

		public HistoryDbRepository History => _historyDbRepository ?? (_historyDbRepository = new HistoryDbRepository(_ctx));

		public void Save()
		{
			_ctx.SaveChanges();
		}

		private bool _disposed;

		public virtual void Dispose(bool disposing)
		{
			if (!_disposed)
			{
				if (disposing)
				{
					_ctx.Dispose();
				}
				_disposed = true;
			}
		}

		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}
	}
}