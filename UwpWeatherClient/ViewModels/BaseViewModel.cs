using GalaSoft.MvvmLight;

namespace UwpWeatherClient.ViewModels
{
    public class BaseViewModel : ViewModelBase
    {
        private string _title;
        public string Title
        {
            get { return _title; }
            set
            {
                _title = value;
                RaisePropertyChanged(() => Title);
            }
        }
    }
}
