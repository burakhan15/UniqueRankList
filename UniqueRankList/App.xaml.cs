using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Net.Http;
using System.Runtime.InteropServices;
using System.Windows;
using UniqueRankList.Helper;
using UniqueRankList.Services;
using UniqueRankList.View;

namespace UniqueRankList
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private static Mutex mutex;

        [DllImport("user32.dll")]
        private static extern bool SetForegroundWindow(IntPtr hWnd);

        [DllImport("user32.dll")]
        private static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        private const int SW_RESTORE = 9;

        protected override void OnStartup(StartupEventArgs e)
        {

            try
            {
                const string mutexName = "SilkroadHelperAppMutex";

                bool createdNew;
                mutex = new Mutex(true, mutexName, out createdNew);

                if (!createdNew)
                {
                    // Başka bir örnek çalışıyorsa onu öne getir
                    BringExistingInstanceToFront();
                    Shutdown();
                    return;
                }



                base.OnStartup(e);

                Dispatcher.InvokeAsync(async () =>
                {
                    var isLicenseAvailable = await LoadDataAsync();

                    if (isLicenseAvailable)
                    {
                        new MainWindow().Show();
                    }
                    else
                    {
                        new LicenseRequestWindow().Show();
                    }
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Uygulama hata verdi:\n{ex}");
            }
         
        }

        protected override void OnExit(ExitEventArgs e)
        {
            mutex?.ReleaseMutex();
            mutex?.Dispose();
            base.OnExit(e);
        }

        private void BringExistingInstanceToFront()
        {
            // Şu anki process
            var current = Process.GetCurrentProcess();

            // Aynı adı taşıyan diğer process'i bul (kendisi hariç)
            var existingProcess = Process.GetProcessesByName(current.ProcessName)
                .FirstOrDefault(p => p.Id != current.Id);

            if (existingProcess != null)
            {
                IntPtr hWnd = existingProcess.MainWindowHandle;

                if (hWnd != IntPtr.Zero)
                {
                    // Minimize durumdaysa restore et
                    ShowWindow(hWnd, SW_RESTORE);
                    // Öne getir
                    SetForegroundWindow(hWnd);
                }
            }
        }

        public async Task<bool> LoadDataAsync()
        {
            try
            {
                var biosCode = HardwareInfoService.GetBIOSSerial();


                string baseUrl = "https://raw.githubusercontent.com/burakhan15/AccessibleFiles/main/licences";
                string url = $"{baseUrl}?t={DateTime.UtcNow.Ticks}"; // rastgele query parametresi
                using var httpClient = new HttpClient
                {
                    Timeout = TimeSpan.FromSeconds(5)
                };

                var response = await httpClient.GetAsync(url);
                var contentType = response.Content.Headers.ContentType?.ToString();
                var content = await response.Content.ReadAsStringAsync();

                // string content = await httpClient.GetStringAsync(url);


                if (content.Contains(","))
                {
                    var values = content.Split(',');

                    foreach (var value in values)
                    {
                        if (value == biosCode)
                            return true;
                    }
                }
              

                return false;
            }
            catch
            {
                return false;
            }
        }

    }

}
