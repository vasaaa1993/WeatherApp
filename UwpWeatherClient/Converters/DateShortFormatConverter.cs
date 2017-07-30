using System;
using Windows.UI.Xaml.Data;

namespace UwpWeatherClient.Converters
{
	class DateShortFormatConverter:IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, string language)
		{
			if (value == null)
				return null;
			DateTime dt = (DateTime)value;
			return dt.ToString("M");
		}

		public object ConvertBack(object value, Type targetType, object parameter, string language)
		{
			throw new NotImplementedException();
		}
	}
}
