using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherApp.DataAccess.Repositories
{
	public interface IRepository<TEntity> where TEntity : class
	{
		IEnumerable<TEntity> GetAll();
		void ClearAll();
		TEntity Get(int id);
		void Delete(int id);
		void Add(TEntity item);
	}
}
