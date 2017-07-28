using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;

namespace UwpWeatherClient.Services
{
	abstract class BaseService
	{
		protected static string baseApiPath = "http://localhost:50185/api/";

		protected async Task<T> GetApiResponse<T>(string sUrl)
		{
			using (var client = new HttpClient())
			using (var response = await client.GetAsync(sUrl))
			using (var content = response.Content)
			{
				var apiResponse = await content.ReadAsStringAsync();
				var rez = JsonConvert.DeserializeObject<T>(apiResponse);
				return rez;
			}
		}

		protected async Task<bool> DeleteApiResponse(string sUrl)
		{
			using (var client = new HttpClient())
			using (var response = await client.DeleteAsync(sUrl))
			{
				return response.StatusCode == System.Net.HttpStatusCode.OK;
			}
		}

		protected async Task<bool> PostApiResponse<T>(string sUrl, T obj)
		{
			using (var client = new HttpClient())
			{
				string json = JsonConvert.SerializeObject(obj);
				using (var response = await client.PostAsync(sUrl, new StringContent(json)))
				{
					return response.StatusCode == System.Net.HttpStatusCode.OK;
				}
			}			
		}
	}
}
