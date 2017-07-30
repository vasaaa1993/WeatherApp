using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace UwpWeatherClient.Services
{
	public abstract class BaseService
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

		protected async Task<bool> PostApiResponse(string sUrl, IDictionary<string, string> values)
		{
			using (var client = new HttpClient())
			using (var content = new FormUrlEncodedContent(values))
			using (var response = await client.PostAsync(sUrl, content))
			{
				return response.StatusCode == System.Net.HttpStatusCode.Created;
			}
		}
	}
}
