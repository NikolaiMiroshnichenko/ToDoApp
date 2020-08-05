using System;
using System.Globalization;
using ToDoApp.Models;
using Xamarin.Forms;

namespace ToDoApp.Converter
{
    public class ToDoStatusToColorConverter: IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var status = (ToDoStatus)value; 
            if (status == ToDoStatus.Completed)
            {
                return Color.LightGreen;
            }
            return Color.LightGray;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
