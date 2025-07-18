using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using UniqueRankList.Model;
using UniqueRankList.ViewModel;

namespace UniqueRankList.View
{
    /// <summary>
    /// Interaction logic for InfoWindow.xaml
    /// </summary>
    public partial class InfoWindow : Window
    {
        private const int GWL_EXSTYLE = -20;
        private const int WS_EX_TRANSPARENT = 0x00000020;
        private const int WS_EX_TOOLWINDOW = 0x00000080;
        private const int WS_EX_NOACTIVATE = 0x08000000;

        [DllImport("user32.dll")]
        static extern int GetWindowLong(IntPtr hWnd, int nIndex);

        [DllImport("user32.dll")]
        static extern int SetWindowLong(IntPtr hWnd, int nIndex, int dwNewLong);

        public InfoWindow()
        {
            InitializeComponent();
            ControlWindow.ToggleOverlayRequested += OnToggleOverlay;
        }

        private void OnToggleOverlay()
        {
            // Toggle Visibility
            Dispatcher.Invoke(() =>
            {
                this.Visibility = this.Visibility == Visibility.Visible
                    ? Visibility.Collapsed
                    : Visibility.Visible;
            });
        }

        protected override void OnClosed(EventArgs e)
        {
            ControlWindow.ToggleOverlayRequested -= OnToggleOverlay;
            base.OnClosed(e);
        }

        protected override void OnSourceInitialized(EventArgs e)
        {
            base.OnSourceInitialized(e);
            SetClickThrough(true);      
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var hwnd = new WindowInteropHelper(this).Handle;
            int extendedStyle = GetWindowLong(hwnd, GWL_EXSTYLE);
            extendedStyle |= WS_EX_TRANSPARENT | WS_EX_TOOLWINDOW | WS_EX_NOACTIVATE;
            SetWindowLong(hwnd, GWL_EXSTYLE, extendedStyle);

            // Sağ üst köşe konumlandırması
            var screenWidth = SystemParameters.PrimaryScreenWidth;
            Left = screenWidth - Width - 230;
            Top = 5;

            // Hook input
            ComponentDispatcher.ThreadPreprocessMessage += ThreadPreprocessMessageMethod;
        }
        private void ThreadPreprocessMessageMethod(ref MSG msg, ref bool handled)
        {
            const int WM_LBUTTONDOWN = 0x0201;

            if (msg.message == WM_LBUTTONDOWN && Keyboard.IsKeyDown(Key.LeftShift))
            {
                // Shift basılıysa mouse olaylarını yakalayabilmek için "transparent" flag kaldırılır
                var hwnd = new WindowInteropHelper(this).Handle;
                int style = GetWindowLong(hwnd, GWL_EXSTYLE);
                style &= ~WS_EX_TRANSPARENT;
                SetWindowLong(hwnd, GWL_EXSTYLE, style);

                DragMove();

                // Tekrar şeffaf yap
                style |= WS_EX_TRANSPARENT;
                SetWindowLong(hwnd, GWL_EXSTYLE, style);

                handled = true;
            }
        }

        private void CollapseButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void SetClickThrough(bool enable)
        {
            var hwnd = new System.Windows.Interop.WindowInteropHelper(this).Handle;
            int exStyle = NativeMethods.GetWindowLong(hwnd, NativeMethods.GWL_EXSTYLE);

            if (enable)
                exStyle |= NativeMethods.WS_EX_TRANSPARENT;
            else
                exStyle &= ~NativeMethods.WS_EX_TRANSPARENT;

            NativeMethods.SetWindowLong(hwnd, NativeMethods.GWL_EXSTYLE, exStyle);
        }

        private void CollapseButton_MouseEnter(object sender, MouseEventArgs e)
        {
            SetClickThrough(false); // Tıklanabilir yap
        }

        private void CollapseButton_MouseLeave(object sender, MouseEventArgs e)
        {
            SetClickThrough(true); // Geri geçirgen yap
        }
    }
}
