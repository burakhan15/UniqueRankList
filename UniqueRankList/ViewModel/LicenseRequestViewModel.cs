using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using UniqueRankList.Helper;
using UniqueRankList.Model;
using UniqueRankList.Services;

namespace UniqueRankList.ViewModel
{
    public class LicenseRequestViewModel : ViewModelBase
    {
        private string _biosData;
        public string BiosData
        {
            get => _biosData;
            set
            {
                _biosData = value;
                OnPropertyChanged(nameof(BiosData));
            }
        }
        public LicenseRequestViewModel()
        {
            BiosData = HardwareInfoService.GetBIOSSerial();
        }
    }
}
