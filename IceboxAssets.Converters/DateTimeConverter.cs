using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace IceboxAssets.Converters
{
    public class DateTimeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            DateTime valueTime = (DateTime)value;
            DateTime nowTime = DateTime.Now;
            if (valueTime.Year == nowTime.Year && valueTime.Month == nowTime.Month)
            {
                var dayleft = valueTime.Day - nowTime.Day;
                if (dayleft < 0)
                {
                    return "*过期*";
                }
                else
                {
                    switch (dayleft)
                    {
                        case 0: return "今天";
                        case 1: return "明天";
                        case 2: return "后天";
                        case 3:
                        case 4:
                        case 5:
                        case 6:
                            return "本周";
                        default: return string.Format("{0}天", dayleft);
                    }
                }
            }
            else
            {
                if (valueTime.Year < nowTime.Year)
                {
                    return "*作废*";
                }
                else if (valueTime.Year == nowTime.Year)
                {
                    return valueTime.ToString("M/dd");
                }
                else
                {
                    return valueTime.ToString("yy/M");
                }
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
