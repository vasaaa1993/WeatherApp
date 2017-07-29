﻿using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using UwpWeatherClient.Models;
using UwpWeatherClient.Services;

namespace UwpWeatherClient.ViewModels
{
	public class HistoryViewModel : BaseViewModel
	{
		private INavigationService _navigationService;
		private IHistoryService _historyService;

		public ObservableCollection<History> History { get; private set; }

		public ICommand ReloadHistoryCommand { get; set; }
		public ICommand ClearHistoryCommand { get; set; }

		public HistoryViewModel(INavigationService navigationService,
			IHistoryService historyService)
		{
			_navigationService = navigationService;
			_historyService = historyService;

			Init();
		}
		private void Init()
		{
			History = new ObservableCollection<History>();
			ReloadHistoryCommand =  new RelayCommand(ReloadHistory);
			ClearHistoryCommand = new RelayCommand(ClearHistory);
			ReloadHistory();
		}
		private async void ReloadHistory()
		{
			var h = await _historyService.GetHistory();
			if (h != null)
			{
				foreach(var item in h)
					History. Add(item);

				RaisePropertyChanged(() => History);
			}
		}

		private async void ClearHistory()
		{
			var rez = await _historyService.ClearHistory();
			if(rez)
				RaisePropertyChanged(() => History);
		}
	}
}
