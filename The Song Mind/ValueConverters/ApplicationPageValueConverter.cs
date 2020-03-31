using System;
using System.Globalization;
using The_Song_Mind.Pages;
using The_Song_Mind.DataModels;
using System.Diagnostics;

namespace The_Song_Mind.ValueConverters
{
    /// <summary>
    /// Converts the <see cref="ApplicationPage"/> to an actual page
    /// </summary>
    public class ApplicationPageValueConverter : BaseValueConverter<ApplicationPageValueConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            // Find appropriate page
            switch ((ApplicationPage)value)
            {
                case ApplicationPage.MainMenu:
                    return new MainMenuPage();

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
