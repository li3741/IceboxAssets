using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace IceboxAssets.Converters
{
    public class ShoppingStatusConverter<T> : IValueConverter
    {
        public T InList { get; set; }
        public T InShopCart { get; set; }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            T intvalue = (T)value;
            return intvalue.Equals(InShopCart);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return ((T)value).Equals(InShopCart);
        }
    }
}
