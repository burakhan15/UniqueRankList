using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace UniqueRankList.View
{
    /// <summary>
    /// Interaction logic for ControlWindow.xaml
    /// </summary>
    public partial class ControlWindow : Window
    {
        public static event Action ToggleOverlayRequested;
        public ControlWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            // Başlangıç konumu: ekranın sağ üstü (overlay ile hizalanacak)
            var screenWidth = SystemParameters.PrimaryScreenWidth;
            Left = screenWidth - Width - 240;
            Top = 5;
        }

        private void ToggleSize_Click(object sender, RoutedEventArgs e)
        {
            ToggleOverlayRequested?.Invoke();
        }
    }
}
