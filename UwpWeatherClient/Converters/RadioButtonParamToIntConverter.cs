using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Data;

namespace UwpWeatherClient.Converters
{
	class RadioButtonParamToIntConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, string language)
		{
			if (value == null || parameter == null)
				return false;
			return parameter.ToString().Equals(value.ToString());
		}

		public object ConvertBack(object value, Type targetType, object parameter, string language)
		{
			string param = parameter as string;

			bool val = (bool)value;
			if (val && param != null && int.TryParse(param, out int numb))
			{
				return numb;
			}
			return DependencyProperty.UnsetValue;
		}
	}
}
