using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using System.Collections.ObjectModel;
using System.Windows.Input;
using UwpWeatherClient.Common;
using UwpWeatherClient.Models;
using UwpWeatherClient.Services;

namespace UwpWeatherClient.ViewModels
{
	public class WeatherViewModel : BaseViewModel
	{
		private INavigationService _navigationService;
		private IWeatherService _weatherService;
		private ICitiesService _citiesService;

		public Weather Weather { get; private set; }

		public string CityName { get; set; }

		public int Period { get; set; }

		public ObservableCollection<City> Cities { get; private set; }

		public WeatherViewModel(INavigationService navigationService,
			IWeatherService weatherService,
			ICitiesService citiesService)
		{
			_navigationService = navigationService;
			_citiesService = citiesService;
			_weatherService = weatherService;

			InitValues();
		}

		private void InitValues()
		{
			Cities = new ObservableCollection<City>();
			Period = 1;
			SearchCommand = new RelayCommand(Search);

			MessengerInstance.Register<ReloadCitiesEvent>(this, reloadEvent =>
			{
				ReloadCities();
			});

			ReloadCities();
		}
		public ICommand SearchCommand { get; set; }

		private async void Search()
		{
			var w = await _weatherService.GetWeather(CityName, Period);
			if(w != null)
			{
				Weather = w;
				RaisePropertyChanged(() => Weather);
				MessengerInstance.Send(new ReloadHistoryEvent());
			}
		}

		private async void ReloadCities()
		{
			var rez = await _citiesService.GetAllCities();
			if (rez != null)
			{
				Cities.Clear();
				foreach (var item in rez)
					Cities.Add(item);

				RaisePropertyChanged(() => Cities);
			}
		}
	}
}
