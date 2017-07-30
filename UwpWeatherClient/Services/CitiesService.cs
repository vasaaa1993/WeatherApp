using System.Collections.Generic;
using System.Threading.Tasks;
using UwpWeatherClient.Models;

namespace UwpWeatherClient.Services
{
	public class CitiesService : BaseService, ICitiesService 
	{
		private static string _cities = "Cities";
		public async Task<bool> AddCity(City city)
		{
			return await PostApiResponse($"{baseApiPath}{_cities}", new Dictionary<string, string>()
			{
				{ "name", city.Name }
			});
		}

		public async Task<bool> DeleteCity(int id)
		{
			return await DeleteApiResponse($"{baseApiPath}{_cities}/{id.ToString()}");
		}

		public async Task<IEnumerable<City>> GetAllCities()
		{
			return await GetApiResponse<IEnumerable<City>>($"{baseApiPath}{_cities}");
		}

		public async Task<City> GetCity(int id)
		{
			string sUrl = $"{baseApiPath}{_cities}/{id.ToString()}";
			return await GetApiResponse<City>(sUrl);
		}
	}
}
