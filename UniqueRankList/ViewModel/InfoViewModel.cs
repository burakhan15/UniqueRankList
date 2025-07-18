using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniqueRankList.Model;

namespace UniqueRankList.ViewModel
{
    public class InfoViewModel : ViewModelBase
    {
        private string _tigerGirl;
        public string TigerGirl
        {
            get => _tigerGirl;
            set
            {
                _tigerGirl = value;
                OnPropertyChanged(nameof(TigerGirl));
            }
        }

        private string _cerberus;
        public string Cerberus
        {
            get => _cerberus;
            set
            {
                _cerberus = value;
                OnPropertyChanged(nameof(Cerberus));
            }
        }

        private string _captainIvy;
        public string CaptainIvy
        {
            get => _captainIvy;
            set
            {
                _captainIvy = value;
                OnPropertyChanged(nameof(CaptainIvy));
            }
        }

        private string _uruchi;
        public string Uruchi
        {
            get => _uruchi;
            set
            {
                _uruchi = value;
                OnPropertyChanged(nameof(Uruchi));
            }
        }

        private string _isyutaru;
        public string Isyutaru
        {
            get => _isyutaru;
            set
            {
                _isyutaru = value;
                OnPropertyChanged(nameof(Isyutaru));
            }
        }

        private string _lordYarkan;
        public string LordYarkan
        {
            get => _lordYarkan;
            set
            {
                _lordYarkan = value;
                OnPropertyChanged(nameof(LordYarkan));
            }
        }

        private string _demonShaitan;
        public string DemonShaitan
        {
            get => _demonShaitan;
            set
            {
                _demonShaitan = value;
                OnPropertyChanged(nameof(DemonShaitan));
            }
        }

        private bool _isCollapsed;
        public bool IsCollapsed
        {
            get => _isCollapsed;
            set
            {
                _isCollapsed = value;
                OnPropertyChanged(nameof(IsCollapsed));
                OnPropertyChanged(nameof(WindowWidth));
            }
        }

        public double WindowWidth => IsCollapsed ? 50 : 300;

        public InfoViewModel(MainViewModel mainVM)
        {

            TigerGirl = mainVM.TigerGirl;
            Cerberus = mainVM.Cerberus;
            CaptainIvy = mainVM.CaptainIvy;
            Uruchi = mainVM.Uruchi;
            Isyutaru = mainVM.Isyutaru;
            LordYarkan = mainVM.LordYarkan;
            DemonShaitan = mainVM.DemonShaitan;

            // Event'e abone ol
            mainVM.InfoUpdated += MainVM_InfoUpdated;
        }

        private void MainVM_InfoUpdated(object sender, EventArgs e)
        {
            var mainVM = (MainViewModel)sender;

            TigerGirl = mainVM.TigerGirl;
            Cerberus = mainVM.Cerberus;
            CaptainIvy = mainVM.CaptainIvy;
            Uruchi = mainVM.Uruchi;
            Isyutaru = mainVM.Isyutaru;
            LordYarkan = mainVM.LordYarkan;
            DemonShaitan = mainVM.DemonShaitan;
        }
    }
}
