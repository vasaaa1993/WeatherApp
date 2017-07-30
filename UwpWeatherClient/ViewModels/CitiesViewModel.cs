using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using System.Collections.ObjectModel;
using System.Windows.Input;
using UwpWeatherClient.Commands;
using UwpWeatherClient.Common;
using UwpWeatherClient.Models;
using UwpWeatherClient.Services;

namespace UwpWeatherClient.ViewModels
{
	public class CitiesViewModel : BaseViewModel
	{
		private INavigationService _navigationService;
		private ICitiesService _citiesService;

		public ObservableCollection<City> Cities { get; private set; }

		public string CityName { get; set; }

		public ICommand AddCityCommand { get; set; }
		public ICommand DeleteCityCommand { get; set; }

		public CitiesViewModel(INavigationService navigationService,
			ICitiesService citiesService)
		{
			_navigationService = navigationService;
			_citiesService = citiesService;

			Init();
		}
		private void Init()
		{
			Cities = new ObservableCollection<City>();
			AddCityCommand = new RelayCommand(AddCity);
			DeleteCityCommand = new DeleteCityCommand(DleteCity);

			LoadCities();
		}

		private async void LoadCities()
		{
			var rez = await _citiesService.GetAllCities();
			if (rez != null)
			{
				Cities.Clear();
				foreach (var item in rez)
					Cities.Add(item);

				RaisePropertyChanged(() => Cities);
				MessengerInstance.Send(new ReloadCitiesEvent());
			}
		}

		private async void AddCity()
		{
			var rez = await _citiesService.AddCity(new City() { Name = CityName});
			if(rez)
				LoadCities();
		}


		private async void DleteCity(object param)
		{
			if (int.TryParse(param.ToString(), out int id))
			{
				var rez = await _citiesService.DeleteCity(id);
				if(rez)
					LoadCities();
			}
		}
	}
}
