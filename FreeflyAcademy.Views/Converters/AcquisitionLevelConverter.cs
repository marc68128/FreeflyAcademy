using System;
using System.Globalization;
using System.Windows.Data;
using FreeflyAcademy.Enums;

namespace FreeflyAcademy.Views.Converters
{
    public class AcquisitionLevelConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return ((AcquisitionLevel)parameter == (AcquisitionLevel)value);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (bool)value ? parameter : null;
        }
    }
}
