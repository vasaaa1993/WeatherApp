using System.Collections.Generic;
using System.Threading.Tasks;
using UwpWeatherClient.Models;

namespace UwpWeatherClient.Services
{
	public interface IHistoryService
	{
		Task<IEnumerable<History>> GetHistory();
		Task<bool> ClearHistory();
	}
}
