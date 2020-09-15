using AIS_Airoport.Core;
using System;
using System.Diagnostics;
using System.Globalization;

namespace AIS_Airoport
{    /// <summary>
     /// Converts the <see cref="ApplicationPage"/> to an actual view/page
     /// </summary>
    public class ApplicationPageValueConverter : BaseValueConverter<ApplicationPageValueConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            // Find the appropriate page
            switch ((ApplicationPage)value)
            {
                case ApplicationPage.Login:
                    return new LoginPage();

                case ApplicationPage.Register:
                    throw new NotImplementedException("Implement Register Page");

                case ApplicationPage.MainMenu:
                    return new MainMenuPage();

                case ApplicationPage.TicketSelling:
                    throw new NotImplementedException("Implement TicketSelling Page");

                case ApplicationPage.FlightList:
                    throw new NotImplementedException("Implement FlightList Page");

                case ApplicationPage.Passengers:
                    throw new NotImplementedException("Implement Passengers Page");

                case ApplicationPage.Statistics:
                    throw new NotImplementedException("Implement Statistics Page");

                default:
                    Debugger.Break();
                    return null;
            }
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}