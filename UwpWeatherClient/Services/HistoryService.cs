using System.Collections.Generic;
using System.Threading.Tasks;
using UwpWeatherClient.Models;

namespace UwpWeatherClient.Services
{
	public class HistoryService : BaseService, IHistoryService
	{
		private static string _history = "History";
		public async Task<bool> ClearHistory()
		{
			string sUrl = $"{baseApiPath}{_history}";
			return await DeleteApiResponse(sUrl);
		}

		public async Task<IEnumerable<History>> GetHistory()
		{
			string sUrl = $"{baseApiPath}{_history}";
			return await GetApiResponse<IEnumerable<History>>(sUrl);
		}
	}
}
