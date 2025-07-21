using System.Configuration;
using System.Data;
using System.IO;
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
            base.OnStartup(e);

            // AppData\Roaming\UniqueHelper yolunu hazırla
            string licenseFolder = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
                "UniqueHelper");

            if (!Directory.Exists(licenseFolder))
                Directory.CreateDirectory(licenseFolder);


            new MainWindow().Show();
            //string licenseFilePath = Path.Combine(licenseFolder, "license.lic");


            //if (!File.Exists(licenseFilePath))
            //{
            //    MessageBox.Show("Lisans dosyası bulunamadı. Lütfen lisans talebinde bulunun.", "Lisans Eksik", MessageBoxButton.OK, MessageBoxImage.Warning);
            //    new LicenseRequestWindow().Show();
            //}
            //else
            //{

            //    var bios = HardwareInfoService.GetBIOSSerial();
            //    string encrypted = File.ReadAllText(licenseFilePath).Trim();
            //    string decrypted;
            //    try
            //    {
            //        decrypted = AesEncryptionHelper.Decrypt(encrypted);

            //        if (decrypted == bios)
            //        {
            //            // Lisans geçerli, uygulamayı başlat
            //            new MainWindow().Show();
            //        }
            //        else
            //        {
            //            MessageBox.Show("Geçersiz lisans dosyası. Lütfen yeni lisans talebinde bulunun.", "Lisans Eksik", MessageBoxButton.OK, MessageBoxImage.Warning);
            //            new LicenseRequestWindow().Show();
            //        }

            //    }
            //    catch
            //    {
            //    }
            //}

        }
    }

}
