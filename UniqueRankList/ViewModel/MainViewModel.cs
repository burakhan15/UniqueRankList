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

        private string _tigerGirlKiller;
        public string TigerGirlKiller
        {
            get => _tigerGirlKiller;
            set
            {
                _tigerGirlKiller = value;
                OnPropertyChanged(nameof(TigerGirlKiller));
            }
        }

        private string _cerberusKiller;
        public string CerberusKiller
        {
            get => _cerberusKiller;
            set
            {
                _cerberusKiller = value;
                OnPropertyChanged(nameof(CerberusKiller));
            }
        }

        private string _captainIvyKiller;
        public string CaptainIvyKiller
        {
            get => _captainIvyKiller;
            set
            {
                _captainIvyKiller = value;
                OnPropertyChanged(nameof(CaptainIvyKiller));
            }
        }

        private string _uruchiKiller;
        public string UruchiKiller
        {
            get => _uruchiKiller;
            set
            {
                _uruchiKiller = value;
                OnPropertyChanged(nameof(UruchiKiller));
            }
        }

        private string _isyutaruKiller;
        public string IsyutaruKiller
        {
            get => _isyutaruKiller;
            set
            {
                _isyutaruKiller = value;
                OnPropertyChanged(nameof(IsyutaruKiller));
            }
        }

        private string _lordYarkanKiller;
        public string LordYarkanKiller
        {
            get => _lordYarkanKiller;
            set
            {
                _lordYarkanKiller = value;
                OnPropertyChanged(nameof(LordYarkanKiller));
            }
        }

        private string _demonShaitanKiller;
        public string DemonShaitanKiller
        {
            get => _demonShaitanKiller;
            set
            {
                _demonShaitanKiller = value;
                OnPropertyChanged(nameof(DemonShaitanKiller));
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
        public ICommand KillerClickCommand => new RelayCommand<UniqueInfo>(OnKillerClicked);

        private readonly Dictionary<string, string> CountryTimeZones = new()
        {
            { "Türkiye", "Turkey Standard Time" },
            { "ABD - Doğu (Atlanta)", "Eastern Standard Time" },
            { "ABD - Pasifik (Los Angeles)", "Pacific Standard Time" },
            { "Almanya", "W. Europe Standard Time" },
            { "İngiltere", "GMT Standard Time" },
        };

        public List<string> Countries { get; } = new()
    {
        "Türkiye", "ABD - Doğu (Atlanta)", "ABD - Pasifik (Los Angeles)", "Almanya", "İngiltere"
    };

        private string _selectedCountry = "Türkiye";
        public string SelectedCountry
        {
            get => _selectedCountry;
            set
            {
                _selectedCountry = value;
                OnPropertyChanged("SelectedCountry");
                // Ayarlara kaydet
                Properties.Settings.Default.SelectedCountry = value;
                Properties.Settings.Default.Save();

                _ = LoadDataAsync();
                UpdateSpawnTimesByCountry();

            }
        }

        private void OnKillerClicked(object obj)
        {
            var info = (UniqueInfo)obj;

            if (info == null || string.IsNullOrWhiteSpace(info.Killer))
                return;

            string url = $"https://silkroad.gamegami.com/character.php?shardid={SelectedServer.ServerID}&char={info.Killer}";

            try
            {
                // .NET Core / .NET 5+ için:
                var psi = new System.Diagnostics.ProcessStartInfo
                {
                    FileName = url,
                    UseShellExecute = true // Bu şart!
                };
                System.Diagnostics.Process.Start(psi);
            }
            catch (Exception ex)
            {
                // Hata yönetimi
                MessageBox.Show("Bağlantı açılamadı: " + ex.Message);
            }
        }

        public ObservableCollection<UniqueSpawn> SpawnList { get; set; }

        public MainViewModel()
        {
            _selectedCountry = Properties.Settings.Default.SelectedCountry ?? "Türkiye";

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

            SpawnList = new ObservableCollection<UniqueSpawn>
                {
                    new UniqueSpawn
                    {
                        UniqueName = "Medusa",
                        SpawnTimesInTurkey = new List<string>
                        {
                            "14:00",
                            "17:00",
                            "22:00",
                            "04:00"
                        }
                    },
                    new UniqueSpawn
                    {
                        UniqueName = "Neith",
                        SpawnTimesInTurkey = new List<string>
                        {
                          "07:00",
                          "21:30",
                          "",
                          ""
                        }
                    },
                    new UniqueSpawn
                    {
                        UniqueName = "Selketh",
                        SpawnTimesInTurkey = new List<string>
                        {
                          "07:00",
                          "21:30",
                          "",
                          ""
                        }
                    },
                    new UniqueSpawn
                    {
                        UniqueName = "Anubis",
                        SpawnTimesInTurkey = new List<string>
                        {
                          "08:30",
                          "23:00",
                          "",
                          ""
                        }
                    },
                    new UniqueSpawn
                    {
                        UniqueName = "Isis",
                          SpawnTimesInTurkey = new List<string>
                        {
                          "08:30",
                          "23:00",
                          "",
                          ""
                        }
                    },
                    new UniqueSpawn
                    {
                        UniqueName = "Haroeris",
                        SpawnTimesInTurkey = new List<string>
                        {
                            "10:00",
                            "00:30",
                            "",
                            ""
                        }
                    },
                    new UniqueSpawn
                    {
                        UniqueName = "Seth",
                        SpawnTimesInTurkey = new List<string>
                        {
                            "10:00",
                            "00:30",
                          "",
                          ""
                        }
                    },
                    new UniqueSpawn
                    {
                        UniqueName = "Roc",
                        SpawnTimesInTurkey = new List<string>
                        {
                            "21:00",
                            "21:00",
                          "",
                          ""
                        }
                    },
                };


            _ = LoadDataAsync();
            UpdateSpawnTimesByCountry();

            ToggleOverlayCommand = new RelayCommand<string>(ToggleOverlay);
            CloseCommand = new RelayCommand<string>(Close);

            _timer = new DispatcherTimer
            {
                Interval = TimeSpan.FromSeconds(20)
            };
            _timer.Tick += async (s, e) => await LoadDataAsync();
            _timer.Start();
        }

        private void Close(object obj)
        {
            Application.Current.Shutdown();
        }

        private void ToggleOverlay(object obj)
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
                                SpawnTime = ConvertToSelectedTimeZone(cols[1].InnerText.Trim(), SelectedCountry),
                                KillTime = ConvertToSelectedTimeZone(cols[2].InnerText.Trim(), SelectedCountry),
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
                            DateTime selectedNow = GetCurrentTimeInTimeZone(SelectedCountry);

                            var timeDiff = selectedNow - killDateTime;

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
                                    TigerGirlKiller = lastKill.Killer;
                                    break;
                                case "Cerberus":
                                    Cerberus = formatted;
                                    CerberusKiller = lastKill.Killer;
                                    break;
                                case "Captain Ivy":
                                    CaptainIvy = formatted;
                                    CaptainIvyKiller = lastKill.Killer;
                                    break;
                                case "Uruchi":
                                    Uruchi = formatted;
                                    UruchiKiller = lastKill.Killer;
                                    break;
                                case "Isyutaru":
                                    Isyutaru = formatted;
                                    IsyutaruKiller = lastKill.Killer;
                                    break;
                                case "Lord Yarkan":
                                    LordYarkan = formatted;
                                    LordYarkanKiller = lastKill.Killer;
                                    break;
                                case "Demon Shaitan":
                                    DemonShaitan = formatted;
                                    DemonShaitanKiller = lastKill.Killer;
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

        public string ConvertToSelectedTimeZone(string turkishTime, string selectedCountry)
        {
            try
            {
                var culture = new CultureInfo("tr-TR");
                if (DateTime.TryParseExact(turkishTime, "dd.MM.yyyy HH:mm", culture, DateTimeStyles.None, out var parsedTime))
                {
                    var turkeyTime = new DateTimeOffset(parsedTime, TimeSpan.FromHours(3)); // Türkiye GMT+3

                    if (CountryTimeZones.TryGetValue(selectedCountry, out string timeZoneId))
                    {
                        var targetZone = TimeZoneInfo.FindSystemTimeZoneById(timeZoneId);
                        var convertedTime = TimeZoneInfo.ConvertTime(turkeyTime, targetZone);

                        return convertedTime.ToString("dd.MM.yyyy HH:mm", CultureInfo.InvariantCulture);
                    }
                }
            }
            catch
            {
                // Hata durumu
            }

            return turkishTime;
        }
        public DateTime GetCurrentTimeInTimeZone(string selectedCountry)
        {
            if (CountryTimeZones.TryGetValue(selectedCountry, out string timeZoneId))
            {
                var selectedZone = TimeZoneInfo.FindSystemTimeZoneById(timeZoneId);
                var utcNow = DateTime.UtcNow;
                return TimeZoneInfo.ConvertTimeFromUtc(utcNow, selectedZone);
            }
            else
            {
                // Eğer ülke bulunamazsa PC lokal zamanı döndür
                return DateTime.Now;
            }
        }
        public void UpdateSpawnTimesByCountry()
        {
            foreach (var spawn in SpawnList)
            {
                var convertedTimes = new List<string>();

                foreach (var time in spawn.SpawnTimesInTurkey)
                {
                    if (!string.IsNullOrEmpty(time))
                    {
                        // Bugünün tarihiyle birleştir (çünkü tarih formatı "dd.MM.yyyy HH:mm" istiyor)
                        var today = DateTime.Now.ToString("dd.MM.yyyy", CultureInfo.InvariantCulture);
                        var fullTime = $"{today} {time}";
                        var converted = ConvertToSelectedTimeZone(fullTime, SelectedCountry);

                        // Sadece saat kısmını göster (çünkü UI'de saat görüyoruz)
                        if (DateTime.TryParseExact(converted, "dd.MM.yyyy HH:mm", CultureInfo.InvariantCulture, DateTimeStyles.None, out var parsed))
                        {
                            convertedTimes.Add(parsed.ToString("HH:mm"));
                        }
                        else
                        {
                            convertedTimes.Add(time); // fallback
                        }
                    }
                    else
                    {
                        convertedTimes.Add(""); // boş ise yine boş
                    }
                }

                spawn.ConvertedSpawnTimes = convertedTimes;
            }
        }
    }
}
