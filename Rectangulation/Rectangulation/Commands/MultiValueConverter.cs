using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Data;

namespace Rectangulation
{
    public class MultiValueConverter : IMultiValueConverter
    {
        object IMultiValueConverter.Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            var canvas = values[0] as Canvas;
            var vmodel = values[1] as MainWindowVM;
            return null;
            //throw new NotImplementedException();
        }

        object[] IMultiValueConverter.ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
