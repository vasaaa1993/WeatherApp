using GalaSoft.MvvmLight.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UwpWeatherClient.Models;
using UwpWeatherClient.Services;

namespace UwpWeatherClient.ViewModels
{
	class CitiesViewModel : BaseViewModel
	{
		private INavigationService _navigationService;
		private ICitiesService _citiesService;

		public ObservableCollection<City> Cities { get; private set; }

		public CitiesViewModel(INavigationService navigationService,
			ICitiesService citiesService)
		{
			_navigationService = navigationService;
			_citiesService = citiesService;
		}


	}
}
