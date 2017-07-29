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
	public class HistoryViewModel : BaseViewModel
	{
		private INavigationService _navigationService;
		private IHistoryService _historyService;

		public List<History> History { get; private set; }
		public HistoryViewModel(INavigationService navigationService,
			IHistoryService historyService)
		{
			_navigationService = navigationService;
			_historyService = historyService;

			History = new List<History>();
			GetHistory();
		}

		private async void GetHistory()
		{
			var h = await _historyService.GetHistory();
			if (h != null)
			{
				History.AddRange(h);
				RaisePropertyChanged(() => History);
			}
		}
	}
}
