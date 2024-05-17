using System.Globalization;

namespace AIS_Airport
{
	/// <summary>
	/// A converter that takes in a boolean and returns a inversed boolean value
	/// </summary>
	public class InverseBooleanConverter : BaseValueConverter<InverseBooleanConverter>
	{
		public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			return !(bool)value;
		}

		public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}
}