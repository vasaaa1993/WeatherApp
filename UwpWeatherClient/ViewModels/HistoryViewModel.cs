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
	class HistoryViewModel : BaseViewModel
	{
		private INavigationService _navigationService;
		private IHistoryService _historyService;

		public ObservableCollection<History> History { get; private set; }
		public HistoryViewModel(INavigationService navigationService,
			IHistoryService historyService)
		{
			_navigationService = navigationService;
			_historyService = historyService;
		}
	}
}
