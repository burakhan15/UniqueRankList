using System.Configuration;
using System.Data;
using System.IO;
using System.Net.Http;
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
        protected override void OnStartup(StartupEventArgs e)
        {

            try
            {
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
