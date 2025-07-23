using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;

namespace UniqueRankList.Converters
{
    public class ServerStatusBackgroundConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var color = Colors.Gray;

            switch (value?.ToString()?.ToLowerInvariant())
            {
                case "full":
                    color = Colors.Red;
                    break;
                case "crowded":
                    color = Colors.Tomato;
                    break;
                case "populated":
                    color = Colors.Orange;
                    break;
                case "easy":
                    color = Colors.LightBlue;
                    break;
                case "offline":
                    color = Colors.DarkOrange;
                    break;
            }

            // NOT: Brush'ı freeze etmeden yeni oluştur
            return new SolidColorBrush(color);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) => throw new NotImplementedException();
    }
}
