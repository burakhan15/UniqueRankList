using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace UniqueRankList.Converters
{
    public class CapacityToWidthConverter : IValueConverter
    {
        private const double MaxWidth = 204.5; // bar için en geniş alan

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is string kapasiteStr && kapasiteStr.StartsWith("%"))
            {
                if (int.TryParse(kapasiteStr.TrimStart('%'), out int yuzde))
                {
                    return (yuzde / 100.0) * MaxWidth;
                }
            }

            return 0;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) => throw new NotImplementedException();
    }
}
