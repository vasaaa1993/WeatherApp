using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherApp.DataAccess.Repositories
{
	public interface IRepository<TEntity> where TEntity : class
	{
		Task<IEnumerable<TEntity>> GetAll();
		Task<bool> ClearAll();
		Task<TEntity> Get(int id);
		Task<bool> Delete(int id);
		Task<TEntity> Add(TEntity item);
	}
}
