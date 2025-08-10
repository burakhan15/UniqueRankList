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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace UniqueRankList.View
{
    /// <summary>
    /// Interaction logic for CharacterDetailWindow.xaml
    /// </summary>
    public partial class CharacterDetailWindow : Window
    {

        public CharacterDetailWindow()
        {
            InitializeComponent();
            Loaded += OnLoadedWeapon;
            Loaded += OnLoadedShield;
            Loaded += OnLoadedHat;
            Loaded += OnLoadedChest;
            Loaded += OnLoadedLegs;
            Loaded += OnLoadedShoulders;
            Loaded += OnLoadedHand;
            Loaded += OnLoadedFoot;
            Loaded += OnLoadedNecklace;
            Loaded += OnLoadedEarring;
            Loaded += OnLoadedRing1;
            Loaded += OnLoadedRing2;
        }
        private void OnLoadedWeapon(object sender, RoutedEventArgs e)
        {
            const int FrameW = 32;
            const int FrameH = 32;
            const double Fps = 30.0;     // Daha yavaş ve okunaklı
            const int StartIndex = 0;   // Videoda gördüğün aralığı buradan ayarlarsın
            int _frame = 0, _totalFrames = 1, _columns = 1;

            BitmapImage _sprite;
            DispatcherTimer _timer;

            // Pack URI yolunu projendeki konuma göre güncelle:
            _sprite = new BitmapImage(new Uri("pack://application:,,,/Assets/Icons/seal.png", UriKind.Absolute));

            // Sprite ölçüsünden sütun/total frame hesapla (tek satır varsayıyorum)
            _columns = Math.Max(1, _sprite.PixelWidth / FrameW);
            _totalFrames = _columns; // tek satırda tüm kare sayısı

            _timer = new DispatcherTimer { Interval = TimeSpan.FromMilliseconds(1000.0 / Fps) };
            _timer.Tick += (s, a) =>
            {
                int index = StartIndex + (_frame % _totalFrames);
                int col = index % _columns;
                int row = index / _columns; // tek satırsa hep 0

                var rect = new Int32Rect(col * FrameW, row * FrameH, FrameW, FrameH);
                var cropped = new CroppedBitmap(_sprite, rect);
                SealWeapon.Source = cropped;

                _frame++;
            };
            _timer.Start();
        }
        private void OnLoadedShield(object sender, RoutedEventArgs e)
        {
            const int FrameW = 32;
            const int FrameH = 32;
            const double Fps = 30.0;     // Daha yavaş ve okunaklı
            const int StartIndex = 0;   // Videoda gördüğün aralığı buradan ayarlarsın
            int _frame = 0, _totalFrames = 1, _columns = 1;

            BitmapImage _sprite;
            DispatcherTimer _timer;

            // Pack URI yolunu projendeki konuma göre güncelle:
            _sprite = new BitmapImage(new Uri("pack://application:,,,/Assets/Icons/seal.png", UriKind.Absolute));

            // Sprite ölçüsünden sütun/total frame hesapla (tek satır varsayıyorum)
            _columns = Math.Max(1, _sprite.PixelWidth / FrameW);
            _totalFrames = _columns; // tek satırda tüm kare sayısı

            _timer = new DispatcherTimer { Interval = TimeSpan.FromMilliseconds(1000.0 / Fps) };
            _timer.Tick += (s, a) =>
            {
                int index = StartIndex + (_frame % _totalFrames);
                int col = index % _columns;
                int row = index / _columns; // tek satırsa hep 0

                var rect = new Int32Rect(col * FrameW, row * FrameH, FrameW, FrameH);
                var cropped = new CroppedBitmap(_sprite, rect);
                SealShield.Source = cropped;

                _frame++;
            };
            _timer.Start();
        }
        private void OnLoadedHat(object sender, RoutedEventArgs e)
        {
            const int FrameW = 32;
            const int FrameH = 32;
            const double Fps = 30.0;     // Daha yavaş ve okunaklı
            const int StartIndex = 0;   // Videoda gördüğün aralığı buradan ayarlarsın
            int _frame = 0, _totalFrames = 1, _columns = 1;

            BitmapImage _sprite;
            DispatcherTimer _timer;

            // Pack URI yolunu projendeki konuma göre güncelle:
            _sprite = new BitmapImage(new Uri("pack://application:,,,/Assets/Icons/seal.png", UriKind.Absolute));

            // Sprite ölçüsünden sütun/total frame hesapla (tek satır varsayıyorum)
            _columns = Math.Max(1, _sprite.PixelWidth / FrameW);
            _totalFrames = _columns; // tek satırda tüm kare sayısı

            _timer = new DispatcherTimer { Interval = TimeSpan.FromMilliseconds(1000.0 / Fps) };
            _timer.Tick += (s, a) =>
            {
                int index = StartIndex + (_frame % _totalFrames);
                int col = index % _columns;
                int row = index / _columns; // tek satırsa hep 0

                var rect = new Int32Rect(col * FrameW, row * FrameH, FrameW, FrameH);
                var cropped = new CroppedBitmap(_sprite, rect);
                SealHat.Source = cropped;

                _frame++;
            };
            _timer.Start();
        }
        private void OnLoadedChest(object sender, RoutedEventArgs e)
        {
            const int FrameW = 32;
            const int FrameH = 32;
            const double Fps = 30.0;     // Daha yavaş ve okunaklı
            const int StartIndex = 0;   // Videoda gördüğün aralığı buradan ayarlarsın
            int _frame = 0, _totalFrames = 1, _columns = 1;

            BitmapImage _sprite;
            DispatcherTimer _timer;

            // Pack URI yolunu projendeki konuma göre güncelle:
            _sprite = new BitmapImage(new Uri("pack://application:,,,/Assets/Icons/seal.png", UriKind.Absolute));

            // Sprite ölçüsünden sütun/total frame hesapla (tek satır varsayıyorum)
            _columns = Math.Max(1, _sprite.PixelWidth / FrameW);
            _totalFrames = _columns; // tek satırda tüm kare sayısı

            _timer = new DispatcherTimer { Interval = TimeSpan.FromMilliseconds(1000.0 / Fps) };
            _timer.Tick += (s, a) =>
            {
                int index = StartIndex + (_frame % _totalFrames);
                int col = index % _columns;
                int row = index / _columns; // tek satırsa hep 0

                var rect = new Int32Rect(col * FrameW, row * FrameH, FrameW, FrameH);
                var cropped = new CroppedBitmap(_sprite, rect);
                SealChest.Source = cropped;

                _frame++;
            };
            _timer.Start();
        }
        private void OnLoadedLegs(object sender, RoutedEventArgs e)
        {
            const int FrameW = 32;
            const int FrameH = 32;
            const double Fps = 30.0;     // Daha yavaş ve okunaklı
            const int StartIndex = 0;   // Videoda gördüğün aralığı buradan ayarlarsın
            int _frame = 0, _totalFrames = 1, _columns = 1;

            BitmapImage _sprite;
            DispatcherTimer _timer;

            // Pack URI yolunu projendeki konuma göre güncelle:
            _sprite = new BitmapImage(new Uri("pack://application:,,,/Assets/Icons/seal.png", UriKind.Absolute));

            // Sprite ölçüsünden sütun/total frame hesapla (tek satır varsayıyorum)
            _columns = Math.Max(1, _sprite.PixelWidth / FrameW);
            _totalFrames = _columns; // tek satırda tüm kare sayısı

            _timer = new DispatcherTimer { Interval = TimeSpan.FromMilliseconds(1000.0 / Fps) };
            _timer.Tick += (s, a) =>
            {
                int index = StartIndex + (_frame % _totalFrames);
                int col = index % _columns;
                int row = index / _columns; // tek satırsa hep 0

                var rect = new Int32Rect(col * FrameW, row * FrameH, FrameW, FrameH);
                var cropped = new CroppedBitmap(_sprite, rect);
                SealLegs.Source = cropped;

                _frame++;
            };
            _timer.Start();
        }
        private void OnLoadedShoulders(object sender, RoutedEventArgs e)
        {
            const int FrameW = 32;
            const int FrameH = 32;
            const double Fps = 30.0;     // Daha yavaş ve okunaklı
            const int StartIndex = 0;   // Videoda gördüğün aralığı buradan ayarlarsın
            int _frame = 0, _totalFrames = 1, _columns = 1;

            BitmapImage _sprite;
            DispatcherTimer _timer;

            // Pack URI yolunu projendeki konuma göre güncelle:
            _sprite = new BitmapImage(new Uri("pack://application:,,,/Assets/Icons/seal.png", UriKind.Absolute));

            // Sprite ölçüsünden sütun/total frame hesapla (tek satır varsayıyorum)
            _columns = Math.Max(1, _sprite.PixelWidth / FrameW);
            _totalFrames = _columns; // tek satırda tüm kare sayısı

            _timer = new DispatcherTimer { Interval = TimeSpan.FromMilliseconds(1000.0 / Fps) };
            _timer.Tick += (s, a) =>
            {
                int index = StartIndex + (_frame % _totalFrames);
                int col = index % _columns;
                int row = index / _columns; // tek satırsa hep 0

                var rect = new Int32Rect(col * FrameW, row * FrameH, FrameW, FrameH);
                var cropped = new CroppedBitmap(_sprite, rect);
                SealShoulders.Source = cropped;

                _frame++;
            };
            _timer.Start();
        }
        private void OnLoadedHand(object sender, RoutedEventArgs e)
        {
            const int FrameW = 32;
            const int FrameH = 32;
            const double Fps = 30.0;     // Daha yavaş ve okunaklı
            const int StartIndex = 0;   // Videoda gördüğün aralığı buradan ayarlarsın
            int _frame = 0, _totalFrames = 1, _columns = 1;

            BitmapImage _sprite;
            DispatcherTimer _timer;

            // Pack URI yolunu projendeki konuma göre güncelle:
            _sprite = new BitmapImage(new Uri("pack://application:,,,/Assets/Icons/seal.png", UriKind.Absolute));

            // Sprite ölçüsünden sütun/total frame hesapla (tek satır varsayıyorum)
            _columns = Math.Max(1, _sprite.PixelWidth / FrameW);
            _totalFrames = _columns; // tek satırda tüm kare sayısı

            _timer = new DispatcherTimer { Interval = TimeSpan.FromMilliseconds(1000.0 / Fps) };
            _timer.Tick += (s, a) =>
            {
                int index = StartIndex + (_frame % _totalFrames);
                int col = index % _columns;
                int row = index / _columns; // tek satırsa hep 0

                var rect = new Int32Rect(col * FrameW, row * FrameH, FrameW, FrameH);
                var cropped = new CroppedBitmap(_sprite, rect);
                SealHand.Source = cropped;

                _frame++;
            };
            _timer.Start();
        }
        private void OnLoadedFoot(object sender, RoutedEventArgs e)
        {
            const int FrameW = 32;
            const int FrameH = 32;
            const double Fps = 30.0;     // Daha yavaş ve okunaklı
            const int StartIndex = 0;   // Videoda gördüğün aralığı buradan ayarlarsın
            int _frame = 0, _totalFrames = 1, _columns = 1;

            BitmapImage _sprite;
            DispatcherTimer _timer;

            // Pack URI yolunu projendeki konuma göre güncelle:
            _sprite = new BitmapImage(new Uri("pack://application:,,,/Assets/Icons/seal.png", UriKind.Absolute));

            // Sprite ölçüsünden sütun/total frame hesapla (tek satır varsayıyorum)
            _columns = Math.Max(1, _sprite.PixelWidth / FrameW);
            _totalFrames = _columns; // tek satırda tüm kare sayısı

            _timer = new DispatcherTimer { Interval = TimeSpan.FromMilliseconds(1000.0 / Fps) };
            _timer.Tick += (s, a) =>
            {
                int index = StartIndex + (_frame % _totalFrames);
                int col = index % _columns;
                int row = index / _columns; // tek satırsa hep 0

                var rect = new Int32Rect(col * FrameW, row * FrameH, FrameW, FrameH);
                var cropped = new CroppedBitmap(_sprite, rect);
                SealFoot.Source = cropped;

                _frame++;
            };
            _timer.Start();
        }
        private void OnLoadedNecklace(object sender, RoutedEventArgs e)
        {
            const int FrameW = 32;
            const int FrameH = 32;
            const double Fps = 30.0;     // Daha yavaş ve okunaklı
            const int StartIndex = 0;   // Videoda gördüğün aralığı buradan ayarlarsın
            int _frame = 0, _totalFrames = 1, _columns = 1;

            BitmapImage _sprite;
            DispatcherTimer _timer;

            // Pack URI yolunu projendeki konuma göre güncelle:
            _sprite = new BitmapImage(new Uri("pack://application:,,,/Assets/Icons/seal.png", UriKind.Absolute));

            // Sprite ölçüsünden sütun/total frame hesapla (tek satır varsayıyorum)
            _columns = Math.Max(1, _sprite.PixelWidth / FrameW);
            _totalFrames = _columns; // tek satırda tüm kare sayısı

            _timer = new DispatcherTimer { Interval = TimeSpan.FromMilliseconds(1000.0 / Fps) };
            _timer.Tick += (s, a) =>
            {
                int index = StartIndex + (_frame % _totalFrames);
                int col = index % _columns;
                int row = index / _columns; // tek satırsa hep 0

                var rect = new Int32Rect(col * FrameW, row * FrameH, FrameW, FrameH);
                var cropped = new CroppedBitmap(_sprite, rect);
                SealNecklace.Source = cropped;

                _frame++;
            };
            _timer.Start();
        }
        private void OnLoadedEarring(object sender, RoutedEventArgs e)
        {
            const int FrameW = 32;
            const int FrameH = 32;
            const double Fps = 30.0;     // Daha yavaş ve okunaklı
            const int StartIndex = 0;   // Videoda gördüğün aralığı buradan ayarlarsın
            int _frame = 0, _totalFrames = 1, _columns = 1;

            BitmapImage _sprite;
            DispatcherTimer _timer;

            // Pack URI yolunu projendeki konuma göre güncelle:
            _sprite = new BitmapImage(new Uri("pack://application:,,,/Assets/Icons/seal.png", UriKind.Absolute));

            // Sprite ölçüsünden sütun/total frame hesapla (tek satır varsayıyorum)
            _columns = Math.Max(1, _sprite.PixelWidth / FrameW);
            _totalFrames = _columns; // tek satırda tüm kare sayısı

            _timer = new DispatcherTimer { Interval = TimeSpan.FromMilliseconds(1000.0 / Fps) };
            _timer.Tick += (s, a) =>
            {
                int index = StartIndex + (_frame % _totalFrames);
                int col = index % _columns;
                int row = index / _columns; // tek satırsa hep 0

                var rect = new Int32Rect(col * FrameW, row * FrameH, FrameW, FrameH);
                var cropped = new CroppedBitmap(_sprite, rect);
                SealEarring.Source = cropped;

                _frame++;
            };
            _timer.Start();
        }
        private void OnLoadedRing1(object sender, RoutedEventArgs e)
        {
            const int FrameW = 32;
            const int FrameH = 32;
            const double Fps = 30.0;     // Daha yavaş ve okunaklı
            const int StartIndex = 0;   // Videoda gördüğün aralığı buradan ayarlarsın
            int _frame = 0, _totalFrames = 1, _columns = 1;

            BitmapImage _sprite;
            DispatcherTimer _timer;

            // Pack URI yolunu projendeki konuma göre güncelle:
            _sprite = new BitmapImage(new Uri("pack://application:,,,/Assets/Icons/seal.png", UriKind.Absolute));

            // Sprite ölçüsünden sütun/total frame hesapla (tek satır varsayıyorum)
            _columns = Math.Max(1, _sprite.PixelWidth / FrameW);
            _totalFrames = _columns; // tek satırda tüm kare sayısı

            _timer = new DispatcherTimer { Interval = TimeSpan.FromMilliseconds(1000.0 / Fps) };
            _timer.Tick += (s, a) =>
            {
                int index = StartIndex + (_frame % _totalFrames);
                int col = index % _columns;
                int row = index / _columns; // tek satırsa hep 0

                var rect = new Int32Rect(col * FrameW, row * FrameH, FrameW, FrameH);
                var cropped = new CroppedBitmap(_sprite, rect);
                SealRing1.Source = cropped;

                _frame++;
            };
            _timer.Start();
        }
        private void OnLoadedRing2(object sender, RoutedEventArgs e)
        {
            const int FrameW = 32;
            const int FrameH = 32;
            const double Fps = 30.0;     // Daha yavaş ve okunaklı
            const int StartIndex = 0;   // Videoda gördüğün aralığı buradan ayarlarsın
            int _frame = 0, _totalFrames = 1, _columns = 1;

            BitmapImage _sprite;
            DispatcherTimer _timer;

            // Pack URI yolunu projendeki konuma göre güncelle:
            _sprite = new BitmapImage(new Uri("pack://application:,,,/Assets/Icons/seal.png", UriKind.Absolute));

            // Sprite ölçüsünden sütun/total frame hesapla (tek satır varsayıyorum)
            _columns = Math.Max(1, _sprite.PixelWidth / FrameW);
            _totalFrames = _columns; // tek satırda tüm kare sayısı

            _timer = new DispatcherTimer { Interval = TimeSpan.FromMilliseconds(1000.0 / Fps) };
            _timer.Tick += (s, a) =>
            {
                int index = StartIndex + (_frame % _totalFrames);
                int col = index % _columns;
                int row = index / _columns; // tek satırsa hep 0

                var rect = new Int32Rect(col * FrameW, row * FrameH, FrameW, FrameH);
                var cropped = new CroppedBitmap(_sprite, rect);
                SealRing2.Source = cropped;

                _frame++;
            };
            _timer.Start();
        }
    }
}
