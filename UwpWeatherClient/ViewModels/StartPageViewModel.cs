using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using UwpWeatherClient.Models;
using Newtonsoft.Json;
using UwpWeatherClient.Services;

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
			//var service = new WeatherService();
			//var rez = service.GetWeather("London", 3);
			Title = "Hello Mia.";
			Some();
		}
		public async void Some()
		{
			var ser = new CitiesService();
			var rez = await ser.AddCity(new City() { Name = "Poltava" });
			int a = 3;
		}

	}
}
