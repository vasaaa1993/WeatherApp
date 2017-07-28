using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using UwpWeatherClient.Models;
using Newtonsoft.Json;

namespace UwpWeatherClient.ViewModels
{
	public class StartPageViewModel : BaseViewModel
	{
		private bool _isLoading = false;
		public bool IsLoading
		{
			get
			{
				return _isLoading;
			}
			set
			{
				_isLoading = value;
				RaisePropertyChanged("IsLoading");

			}
		}

		public StartPageViewModel()
		{
			var rez = GetWeatherByTownName("Lviv", "1");
			Title = "Hello Mia.";
		}

		public async Task<Weather> GetWeatherByTownName(string name, string dayPeriod)
		{
			if (name == null)
				return null;
			int nDayPeriod;
			if (!int.TryParse(dayPeriod, out nDayPeriod))
				nDayPeriod = 1;
			var sUrl =
				$"http://localhost:50185/api/Weather/{name}/{dayPeriod}";
			try
			{
				using (var client = new HttpClient())
				using (var response = await client.GetAsync(sUrl))
				using (var content = response.Content)
				{
					var apiResponse = await content.ReadAsStringAsync();
					var rez = JsonConvert.DeserializeObject<Weather>(apiResponse);
					return rez;
				}
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
	}
}
