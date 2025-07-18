using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Threading;
using TimeZoneConverter;
using UniqueRankList.Model;
using UniqueRankList.View;

namespace UniqueRankList.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        public ObservableCollection<UniqueInfo> UniqueList { get; set; }
        private readonly DispatcherTimer _timer;
        public ObservableCollection<ServerModels> ServerList { get; set; }

        private ServerModels selectedServer;
        public ServerModels SelectedServer
        {
            get => selectedServer;
            set
            {
                if (selectedServer != value)
                {
                    selectedServer = value;
                    _ = LoadDataAsync();
                    OnPropertyChanged("SelectedServer");
                }
            }
        }

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

        private string _lastUpdate;
        public string LastUpdate
        {
            get => _lastUpdate;
            set
            {
                _lastUpdate = value;
                OnPropertyChanged(nameof(LastUpdate));
            }
        }

        string[] uniqueNames = new[]
       {
            "Tiger Girl", "Cerberus", "Captain Ivy", "Uruchi", "Isyutaru", "Lord Yarkan", "Demon Shaitan"
        };

        private InfoWindow _overlayWindow;
        private ControlWindow _controlWindow;

        public ICommand ToggleOverlayCommand { get; }

        public ICommand CloseCommand { get; }
        public MainViewModel()
        {

            UniqueList = new ObservableCollection<UniqueInfo>();
            ServerList = new ObservableCollection<ServerModels>()
            {
                new ServerModels{Server ="Troya", ServerID=2},
                new ServerModels{Server ="Knidos", ServerID=16},
                new ServerModels{Server ="Milet", ServerID=17},
                new ServerModels{Server ="Harput", ServerID=18},
                new ServerModels{Server ="Nemrut", ServerID=19},
            };

            SelectedServer = ServerList.First();

            _ = LoadDataAsync();

            ToggleOverlayCommand = new RelayCommand(ToggleOverlay);
            CloseCommand = new RelayCommand(Close);

            _timer = new DispatcherTimer
            {
                Interval = TimeSpan.FromSeconds(20)
            };
            _timer.Tick += async (s, e) => await LoadDataAsync();
            _timer.Start();
        }

        private void Close()
        {
            Application.Current.Shutdown();
        }

        private void ToggleOverlay()
        {
            if (_overlayWindow == null || !_overlayWindow.IsVisible)
            {
                var overlayVM = new InfoViewModel(this);
                _controlWindow = new ControlWindow();
                _overlayWindow = new InfoWindow
                {
                    DataContext = overlayVM
                };
                _overlayWindow.Show();
                _controlWindow.Show();
                //control.Left = control.Left + control.Width + 5;
                //control.Top = control.Top;
            }
            else
            {
                _overlayWindow.Close();
                _controlWindow.Close();
                _overlayWindow = null;
                _controlWindow = null;
            }
        }
        public async Task LoadDataAsync()
        {
            try
            {
                var url = $"https://silkroad.gamegami.com/instantuniques.php?id={SelectedServer.ServerID}";

                using var client = new HttpClient();
                client.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0");

                var html = await client.GetStringAsync(url);

                var doc = new HtmlDocument();
                doc.LoadHtml(html);

                var rows = doc.DocumentNode.SelectNodes("//table[contains(@class, 'table_rank')]/tr");

                if (rows != null && rows.Count > 1)
                {
                    UniqueList.Clear();
                    for (int i = 1; i < rows.Count; i++)
                    {
                        var cols = rows[i].SelectNodes("td");
                        if (cols != null && cols.Count == 5)
                        {
                            UniqueList.Add(new UniqueInfo
                            {
                                Unique = cols[0].InnerText.Trim(),
                                SpawnTime = ConvertToAtlantaTime(cols[1].InnerText.Trim()),
                                KillTime = ConvertToAtlantaTime(cols[2].InnerText.Trim()),
                                Killer = cols[3].InnerText.Trim().Replace("&nbsp;", ""),
                                KillerIcon = cols[3].FirstChild.OuterHtml.Contains("chinese.png") ?
                                "pack://application:,,,/Assets/Icons/chinese.png" :
                                "pack://application:,,,/Assets/Icons/european.png",
                                Region = cols[4].InnerText.Trim(),
                            });
                        }
                    }

                    var filteredByUnique = uniqueNames.ToDictionary(
                                                              name => name,
                                                              name => UniqueList
                                                                  .Where(x => x.Unique == name)
                                                                  .OrderBy(x =>
                                                                  {
                                                                      return DateTime.TryParseExact(x.KillTime, "dd.MM.yyyy HH:mm", CultureInfo.InvariantCulture, DateTimeStyles.None, out var dt)
                                                                          ? dt
                                                                          : DateTime.MaxValue;
                                                                  })
                                                                  .ToList());

                    foreach (var unique in uniqueNames)
                    {
                        var lastKill = filteredByUnique[unique].LastOrDefault();
                        if (lastKill != null &&
                        DateTime.TryParseExact(lastKill.KillTime, "dd.MM.yyyy HH:mm", CultureInfo.InvariantCulture, DateTimeStyles.None, out var killDateTime))
                        {
                            var now = DateTime.Now;
                            var timeDiff = now - killDateTime;

                            string formatted;
                            if (timeDiff.TotalHours < 1)
                            {
                                // 1 saatten küçükse sadece dakika
                                formatted = $"{timeDiff.Minutes} dk";
                            }
                            else
                            {
                                // 1 saat veya üzerindeyse HH:mm formatı
                                formatted = $"{(int)timeDiff.TotalHours} saat {timeDiff.Minutes} dk";
                            }

                            switch (unique)
                            {
                                case "Tiger Girl":
                                    TigerGirl = formatted;
                                    break;
                                case "Cerberus":
                                    Cerberus = formatted;
                                    break;
                                case "Captain Ivy":
                                    CaptainIvy = formatted;
                                    break;
                                case "Uruchi":
                                    Uruchi = formatted;
                                    break;
                                case "Isyutaru":
                                    Isyutaru = formatted;
                                    break;
                                case "Lord Yarkan":
                                    LordYarkan = formatted;
                                    break;
                                case "Demon Shaitan":
                                    DemonShaitan = formatted;
                                    break;
                                default:
                                    break;
                            }

                        }
                        else
                        {
                            Console.WriteLine("Geçerli KillTime bulunamadı.");
                        }
                    }
                    OnInfoUpdated();
                    LastUpdate = DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss");

                }
            }
            catch (Exception)
            {
            }

        }

        public event EventHandler InfoUpdated;

        protected virtual void OnInfoUpdated()
        {
            InfoUpdated?.Invoke(this, EventArgs.Empty);
        }

        private string ConvertToAtlantaTime(string turkishTime)
        {
            try
            {
                // Türkçe tarihi parse edebilmek için TurkishCulture kullan
                var culture = new CultureInfo("tr-TR");
                if (DateTime.TryParseExact(turkishTime, "dd.MM.yyyy HH:mm", culture, DateTimeStyles.None, out var parsedTime))
                {
                    // Türkiye saat diliminden al
                    var turkeyTime = new DateTimeOffset(parsedTime, TimeSpan.FromHours(3)); // GMT+3

                    // Atlanta saat dilimine çevir (Eastern Time)
                    var atlantaZone = TZConvert.GetTimeZoneInfo("Eastern Standard Time"); // Windows ID
                    var atlantaTime = TimeZoneInfo.ConvertTime(turkeyTime, atlantaZone);

                    return atlantaTime.ToString("dd.MM.yyyy HH:mm", CultureInfo.InvariantCulture);
                }
            }
            catch
            {
                // Gerekirse logla
            }

            return turkishTime; // Parse edilemezse orijinali kalsın
        }
    }
}
