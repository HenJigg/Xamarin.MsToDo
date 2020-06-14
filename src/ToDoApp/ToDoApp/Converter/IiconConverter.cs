using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;

namespace ToDoApp.Converter
{
    public class IiconConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null && bool.TryParse(value.ToString(), out bool result))
            {
                var r = parameter.ToString();
                if (result)
                {
                    if (r == "L")
                        return "\xe69e";
                    else
                        return "\xe61a";
                }
                else
                {
                    if (r == "L")
                        return "\xe80c";
                    else
                        return "\xe625";
                }
            }
            return "";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return "";
        }
    }
}
