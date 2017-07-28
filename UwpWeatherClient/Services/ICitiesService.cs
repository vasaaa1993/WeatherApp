using System.Collections.Generic;
using System.Threading.Tasks;
using UwpWeatherClient.Models;

namespace UwpWeatherClient.Services
{
	public interface ICitiesService
	{
		Task<IEnumerable<City>> GetAllCities();

		Task<bool> AddCity(City city);

		Task<bool> DeleteCity(int id);

		Task<City> GetCity(int id);
	}
}
