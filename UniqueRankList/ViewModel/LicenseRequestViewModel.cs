using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using UniqueRankList.Model;
using UniqueRankList.Services;

namespace UniqueRankList.ViewModel
{
    public class LicenseRequestViewModel : ViewModelBase
    {
        public string FullName { get; set; }
        public string Email { get; set; }

      

        public ICommand SubmitCommand { get; }
        public ICommand CheckLicenseCommand { get; }

        public LicenseRequestViewModel()
        {
            SubmitCommand = new RelayCommand<string>(Submit);
            CheckLicenseCommand = new RelayCommand<string>(CheckLicense);

        }

        private async void Submit(string obj)
        {
            var model = new LicenseRequestModel
            {
                FullName = FullName,
                Email = Email,
                BIOSSerial = HardwareInfoService.GetBIOSSerial(),
            };

            try
            {
                var mailService = new LicenseEmailService();
                await mailService.SendLicenseRequestEmailAsync(model);
                MessageBox.Show("Lisans talebiniz başarıyla gönderildi.", "Başarılı", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Gönderim başarısız: {ex.Message}", "Hata", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }


        private void CheckLicense(string obj)
        {
            throw new NotImplementedException();
        }
    }
}
