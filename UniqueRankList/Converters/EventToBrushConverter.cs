using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;

namespace UniqueRankList.Converters
{
    public class EventToBrushConverter : IValueConverter
    {
        private static readonly Dictionary<string, Brush> EventColors = new()
        {
            ["Capture Flag"] = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#2C8CBF")),
            ["Survival Arena(Bireysel)"] = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#B15E28")),
            ["Survival Arena(Party)"] = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#87421F")),
            ["Haroeris"] = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#2A4B6E")),
            ["Haroeris-Seth"] = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#2A4B6E")),
            ["Selketh-Neith"] = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#418D56")),
            ["Anubis-Isis"] = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#B7A840")),
            ["Medusa"] = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#7C5FA2")),
            ["Styria Clash"] = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#4A8D91")),
        };

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is string eventText)
            {
                foreach (var kvp in EventColors)
                {
                    if (eventText.Contains(kvp.Key, StringComparison.OrdinalIgnoreCase))
                        return kvp.Value;
                }
            }

            return Brushes.Transparent;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
            => throw new NotImplementedException();
    }
}
