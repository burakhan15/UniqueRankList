using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Input;
using UniqueRankList.Model;
using UniqueRankList.View;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolTip;

namespace UniqueRankList.ViewModel
{
    public class CharacterDetailViewModel : ViewModelBase
    {

        public ICommand CloseCommand { get; }
        public int _selectedServerID { get; set; }
        public string _gCharName { get; set; }


        private string _charName;
        public string CharName
        {
            get => _charName;
            set
            {
                _charName = value;
                OnPropertyChanged("CharName");
            }
        }

        private string _jobName;
        public string JobName
        {
            get => _jobName;
            set
            {
                _jobName = value;
                OnPropertyChanged("JobName");
            }
        }

        private string _charPoint;
        public string CharPoint
        {
            get => _charPoint;
            set
            {
                _charPoint = value;
                OnPropertyChanged("CharPoint");
            }
        }

        private string _guild;
        public string Guild
        {
            get => _guild;
            set
            {
                _guild = value;
                OnPropertyChanged("Guild");
            }
        }

        private string _race;
        public string Race
        {
            get => _race;
            set
            {
                _race = value;
                OnPropertyChanged("Race");
            }
        }

        private string _level;
        public string Level
        {
            get => _level;
            set
            {
                _level = value;
                OnPropertyChanged("Level");
            }
        }

        private string _honorPoint;
        public string HonorPoint
        {
            get => _honorPoint;
            set
            {
                _honorPoint = value;
                OnPropertyChanged("HonorPoint");
            }
        }

        private string _title;
        public string Title
        {
            get => _title;
            set
            {
                _title = value;
                OnPropertyChanged("Title");
            }
        }

        private string _hp;
        public string HP
        {
            get => _hp;
            set
            {
                _hp = value;
                OnPropertyChanged("HP");
            }
        }

        private string _mp;
        public string MP
        {
            get => _mp;
            set
            {
                _mp = value;
                OnPropertyChanged("MP");
            }
        }

        private string _str;
        public string STR
        {
            get => _str;
            set
            {
                _str = value;
                OnPropertyChanged("STR");
            }
        }

        private string _int;
        public string INT
        {
            get => _int;
            set
            {
                _int = value;
                OnPropertyChanged("INT");
            }
        }

        private const string BaseUrl = "https://silkroad.gamegami.com/";

        private string _characterImage;
        public string CharacterImage
        {
            get => _characterImage;
            set
            {
                _characterImage = value;
                OnPropertyChanged("CharacterImage");
            }
        }

        private string _weapon;
        public string Weapon
        {
            get => _weapon;
            set { _weapon = value; OnPropertyChanged("Weapon"); }
        }

        private string _weaponID;
        public string WeaponID
        {
            get => _weaponID;
            set { _weaponID = value; OnPropertyChanged("WeaponID"); }
        }

        private string _shield;
        public string Shield
        {
            get => _shield;
            set { _shield = value; OnPropertyChanged("Shield"); }
        }

        private string _shieldID;
        public string ShieldID
        {
            get => _shieldID;
            set { _shieldID = value; OnPropertyChanged("ShieldID"); }
        }

        private string _head;
        public string Head
        {
            get => _head;
            set { _head = value; OnPropertyChanged("Head"); }
        }

        private string _headID;
        public string HeadID
        {
            get => _headID;
            set { _headID = value; OnPropertyChanged("HeadID"); }
        }

        private string _chest;
        public string Chest
        {
            get => _chest;
            set { _chest = value; OnPropertyChanged("Chest"); }
        }

        private string _chestID;
        public string ChestID
        {
            get => _chestID;
            set { _chestID = value; OnPropertyChanged("ChestID"); }
        }

        private string _legs;
        public string Legs
        {
            get => _legs;
            set { _legs = value; OnPropertyChanged("Legs"); }
        }

        private string _legsID;
        public string LegsID
        {
            get => _legsID;
            set { _legsID = value; OnPropertyChanged("LegsID"); }
        }

        private string _foot;
        public string Foot
        {
            get => _foot;
            set { _foot = value; OnPropertyChanged("Foot"); }
        }

        private string _footID;
        public string FootID
        {
            get => _footID;
            set { _footID = value; OnPropertyChanged("FootID"); }
        }

        private string _hand;
        public string Hand
        {
            get => _hand;
            set { _hand = value; OnPropertyChanged("Hand"); }
        }

        private string _handID;
        public string HandID
        {
            get => _handID;
            set { _handID = value; OnPropertyChanged("HandID"); }
        }

        private string _shoulder;
        public string Shoulder
        {
            get => _shoulder;
            set { _shoulder = value; OnPropertyChanged("Shoulder"); }
        }

        private string _shoulderID;
        public string ShoulderID
        {
            get => _shoulderID;
            set { _shoulderID = value; OnPropertyChanged("ShoulderID"); }
        }

        private string _necklace;
        public string Necklace
        {
            get => _necklace;
            set { _necklace = value; OnPropertyChanged("Necklace"); }
        }

        private string _necklaceID;
        public string NecklaceID
        {
            get => _necklaceID;
            set { _necklaceID = value; OnPropertyChanged("NecklaceID"); }
        }

        private string _ringOne;
        public string RingOne
        {
            get => _ringOne;
            set { _ringOne = value; OnPropertyChanged("RingOne"); }
        }

        private string _ringOneID;
        public string RingOneID
        {
            get => _ringOneID;
            set { _ringOneID = value; OnPropertyChanged("RingOneID"); }
        }

        private string _earring;
        public string Earring
        {
            get => _earring;
            set { _earring = value; OnPropertyChanged("Earring"); }
        }

        private string _earringID;
        public string EarringID
        {
            get => _earringID;
            set { _earringID = value; OnPropertyChanged("EarringID"); }
        }

        private string _ringTwo;
        public string RingTwo
        {
            get => _ringTwo;
            set { _ringTwo = value; OnPropertyChanged("RingTwo"); }
        }

        private string _ringTwoID;
        public string RingTwoID
        {
            get => _ringTwoID;
            set { _ringTwoID = value; OnPropertyChanged("RingTwoID"); }
        }


        private string _avatar;
        public string Avatar
        {
            get => _avatar;
            set { _avatar = value; OnPropertyChanged("Avatar"); }
        }

        private string _avatarID;
        public string AvatarID
        {
            get => _avatarID;
            set { _avatarID = value; OnPropertyChanged("AvatarID"); }
        }

        private string _avatarHat;
        public string AvatarHat
        {
            get => _avatarHat;
            set { _avatarHat = value; OnPropertyChanged("AvatarHat"); }
        }

        private string _avatarHatID;
        public string AvatarHatID
        {
            get => _avatarHatID;
            set { _avatarHatID = value; OnPropertyChanged("AvatarHatID"); }
        }

        private string _avatarAcc;
        public string AvatarAcc
        {
            get => _avatarAcc;
            set { _avatarAcc = value; OnPropertyChanged("AvatarAcc"); }
        }

        private string _avatarAccID;
        public string AvatarAccID
        {
            get => _avatarAccID;
            set { _avatarAccID = value; OnPropertyChanged("AvatarAccID"); }
        }

        private string _devil;
        public string Devil
        {
            get => _devil;
            set { _devil = value; OnPropertyChanged("Devil"); }
        }

        private string _devilID;
        public string DevilID
        {
            get => _devilID;
            set { _devilID = value; OnPropertyChanged("DevilID"); }
        }

        private string _flag;
        public string Flag
        {
            get => _flag;
            set { _flag = value; OnPropertyChanged("Flag"); }
        }

        private string _flagID;
        public string FlagID
        {
            get => _flagID;
            set { _flagID = value; OnPropertyChanged("FlagID"); }
        }

        private string _raceIcon;
        public string RaceIcon
        {
            get => _raceIcon;
            set { _raceIcon = value; OnPropertyChanged("RaceIcon"); }
        }


        private bool _hasWeaponSeal = false;
        public bool HasWeaponSeal
        {
            get => _hasWeaponSeal;
            set { _hasWeaponSeal = value; OnPropertyChanged("HasWeaponSeal"); }
        }

        private bool _hasShieldSeal = false;
        public bool HasShieldSeal
        {
            get => _hasShieldSeal;
            set { _hasShieldSeal = value; OnPropertyChanged("HasShieldSeal"); }
        }

        private bool _hasHatSeal = false;
        public bool HasHatSeal
        {
            get => _hasHatSeal;
            set { _hasHatSeal = value; OnPropertyChanged("HasHatSeal"); }
        }

        private bool _hasChestSeal = false;
        public bool HasChestSeal
        {
            get => _hasChestSeal;
            set { _hasChestSeal = value; OnPropertyChanged("HasChestSeal"); }
        }

        private bool _hasLegsSeal = false;
        public bool HasLegsSeal
        {
            get => _hasLegsSeal;
            set { _hasLegsSeal = value; OnPropertyChanged("HasLegsSeal"); }
        }

        private bool _hasSholdersSeal = false;
        public bool HasSholdersSeal
        {
            get => _hasSholdersSeal;
            set { _hasSholdersSeal = value; OnPropertyChanged("HasSholdersSeal"); }
        }

        private bool _hasHandSeal = false;
        public bool HasHandSeal
        {
            get => _hasHandSeal;
            set { _hasHandSeal = value; OnPropertyChanged("HasHandSeal"); }
        }

        private bool _hasFootSeal = false;
        public bool HasFootSeal
        {
            get => _hasFootSeal;
            set { _hasFootSeal = value; OnPropertyChanged("HasFootSeal"); }
        }

        private bool _hasNecklaceSeal = false;
        public bool HasNecklaceSeal
        {
            get => _hasNecklaceSeal;
            set { _hasNecklaceSeal = value; OnPropertyChanged("HasNecklaceSeal"); }
        }

        private bool _hasEarringSeal = false;
        public bool HasEarringSeal
        {
            get => _hasEarringSeal;
            set { _hasEarringSeal = value; OnPropertyChanged("HasEarringSeal"); }
        }

        private bool _hasRing1Seal = false;
        public bool HasRing1Seal
        {
            get => _hasRing1Seal;
            set { _hasRing1Seal = value; OnPropertyChanged("HasRing1Seal"); }
        }

        private bool _hasRing2Seal = false;
        public bool HasRing2Seal
        {
            get => _hasRing2Seal;
            set { _hasRing2Seal = value; OnPropertyChanged("HasRing2Seal"); }
        }

        private bool _isBusy;
        public bool IsBusy
        {
            get => _isBusy;
            set
            {
                _isBusy = value;
                OnPropertyChanged(nameof(IsBusy));
            }
        }

        public CharacterDetailViewModel(int selectedServerID, string charName)
        {
            CloseCommand = new RelayCommand<string>(Close);
            _selectedServerID = selectedServerID;
            _gCharName = charName;

            _ = LoadCharDetail();
        }

        private void Close(object obj)
        {

            var wd = (CharacterDetailWindow)obj;
            wd.Close();
        }


        private async Task LoadCharDetail()
        {
            IsBusy = true;

            var url = $"https://silkroad.gamegami.com/character.php?shardid={_selectedServerID}&char={_gCharName}";

            using var client = new HttpClient();
            client.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0");

            var html = await client.GetStringAsync(url);

            HtmlDocument doc = new HtmlDocument();
            doc.LoadHtml(html); // Buraya HTML response'u yerleştir

            var character = new CharacterDetail();
            var container = doc.GetElementbyId("chardetail_container");

            // --- LABEL ---
            var label = container.SelectSingleNode(".//div[@id='chardetail_label']");
            character.CharacterName = label.SelectSingleNode(".//div[@id='chardetail_label_charname']").InnerText.Trim();
            character.ImageUrl = label.SelectSingleNode(".//div[@id='chardetail_label_charimage']/img")?.GetAttributeValue("src", "");
            character.CharPoints = doc.DocumentNode.SelectSingleNode("//span[@class='charpoint']").InnerText.Trim();


            // --- DETAILS ---
            var rows = container.SelectNodes(".//div[@id='chardetail_details']//table//tr");
            foreach (var row in rows)
            {
                var key = row.SelectSingleNode("./td[1]").InnerText.Trim();
                var value = row.SelectSingleNode("./td[3]").InnerText.Trim();

                switch (key)
                {
                    case "Takma Adı": character.Nickname = value; break;
                    case "Guild":
                        var guildLink = row.SelectSingleNode(".//td[3]/a");
                        character.Guild = guildLink?.InnerText ?? value;
                        break;
                    case "Irk": character.Race = value.Split('&')[0].Trim(); break;
                    case "Seviye": character.Level = value; break;
                    case "Onur Puanı": character.HonorPoints = int.Parse(value); break;
                    case "Ünvan": character.Title = value; break;
                }
            }

            // --- INVENTORY ITEM DETAIL'ları önceden alalım ---
            var allItemDetails = doc.DocumentNode.SelectNodes("//div[starts-with(@id,'gg_equip_item_')]");
            var itemDetailDict = allItemDetails?.ToDictionary(
                node => node.Id.Replace("gg_equip_item_", ""),
                node => node.InnerHtml.Trim()) ?? new();

            // --- INVENTORY ---
            var inventorySlots = container.SelectNodes(".//div[@id='chardetail_inventory']//div[contains(@class, 'chardetail_inventory_slot')]");
            foreach (var slot in inventorySlots)
            {
                var slotId = slot.GetAttributeValue("id", "");
                var img = slot.SelectSingleNode(".//img")?.GetAttributeValue("src", "")?.Replace("\\", "/");
                var onmouseover = slot.GetAttributeValue("onmouseover", "");
                var itemId = System.Text.RegularExpressions.Regex.Match(onmouseover, @"print_item\((\d+),").Groups[1].Value;
                var hasSeal = slot.SelectSingleNode(".//div[contains(@class, 'seal')]") != null;

                character.Equipment.Add(new InventoryItem
                {
                    SlotId = slotId,
                    IconUrl = img,
                    ItemId = itemId,
                    ItemDetailHtml = itemDetailDict.ContainsKey(itemId) ? itemDetailDict[itemId] : null,
                    ItemDetail = SplitByBrToList(itemDetailDict[itemId]),
                    HasSealEffect = hasSeal
                });
            }

            // --- ACCESSORIES ---
            var accessorySlots = container.SelectNodes(".//div[@id='chardetail_accessory']//div[contains(@class, 'chardetail_accessory_slot')]");
            foreach (var slot in accessorySlots)
            {
                var slotId = slot.GetAttributeValue("id", "");
                var img = slot.SelectSingleNode(".//img")?.GetAttributeValue("src", "")?.Replace("\\", "/");
                var onmouseover = slot.GetAttributeValue("onmouseover", "");
                var itemId = System.Text.RegularExpressions.Regex.Match(onmouseover, @"print_item\((\d+),").Groups[1].Value;
                var hasSeal = slot.SelectSingleNode(".//div[contains(@class, 'seal')]") != null;

                character.Accessories.Add(new AccessoryItem
                {
                    SlotId = slotId,
                    IconUrl = img,
                    ItemId = itemId,
                    ItemDetailHtml = itemDetailDict.ContainsKey(itemId) ? itemDetailDict[itemId] : null,
                    HasSealEffect = hasSeal
                });
            }


            // --- HP, MP, STR, INT ---
            var infoBox = container.SelectSingleNode(".//div[@id='chardetail_info_container']");
            character.HP = int.Parse(infoBox.SelectSingleNode(".//div[@id='hpbar']").InnerText.Trim());
            character.MP = int.Parse(infoBox.SelectSingleNode(".//div[@id='mpbar']").InnerText.Trim());
            character.STR = int.Parse(infoBox.SelectSingleNode(".//div[contains(text(),'Kuvvet')]/div").InnerText.Trim());
            character.INT = int.Parse(infoBox.SelectSingleNode(".//div[contains(text(),'Zihin Gücü')]/div").InnerText.Trim());


            CharName = character.CharacterName;
            JobName = character.Nickname;
            CharPoint = character.CharPoints;
            HonorPoint = character.HonorPoints.ToString();
            Guild = character.Guild;
            Race = character.Race;
            RaceIcon = Race.Contains("Çin") ? "/Assets/Icons/chinese.png" : "/Assets/Icons/european.png";
            Level = character.Level.Split("/")[0];
            Title = character.Title;
            HP = character.HP.ToString();
            MP = character.MP.ToString();
            STR = character.STR.ToString();
            INT = character.INT.ToString();

            CharacterImage = GetFullImageUrl(character.ImageUrl);



            foreach (var item in character.Equipment)
            {

                switch (item.SlotId)
                {
                    case "chardetail_inventory_slot0":
                        Head = GetFullImageUrl(item.IconUrl);
                        HeadID = item.ItemId;
                        HasHatSeal = item.HasSealEffect;
                        break;
                    case "chardetail_inventory_slot1":
                        Chest = GetFullImageUrl(item.IconUrl);
                        ChestID = item.ItemId;
                        HasChestSeal = item.HasSealEffect;
                        break;
                    case "chardetail_inventory_slot2":
                        Shoulder = GetFullImageUrl(item.IconUrl);
                        ShoulderID = item.ItemId;
                        HasSholdersSeal = item.HasSealEffect;
                        break;
                    case "chardetail_inventory_slot3":
                        Hand = GetFullImageUrl(item.IconUrl);
                        HandID = item.ItemId; 
                        HasHandSeal = item.HasSealEffect;
                        break;
                    case "chardetail_inventory_slot4":
                        Legs = GetFullImageUrl(item.IconUrl);
                        LegsID = item.ItemId;
                        HasLegsSeal = item.HasSealEffect;
                        break;
                    case "chardetail_inventory_slot5":
                        Foot = GetFullImageUrl(item.IconUrl);
                        FootID = item.ItemId;
                        HasFootSeal = item.HasSealEffect;
                        break;
                    case "chardetail_inventory_slot6":
                        Weapon = GetFullImageUrl(item.IconUrl);
                        WeaponID = item.ItemId;
                        HasWeaponSeal = item.HasSealEffect;
                        break;
                    case "chardetail_inventory_slot7":
                        Shield = GetFullImageUrl(item.IconUrl);
                        ShieldID = item.ItemId;
                        HasShieldSeal = item.HasSealEffect;
                        break;
                    case "chardetail_inventory_slot9":
                        Earring = GetFullImageUrl(item.IconUrl);
                        EarringID = item.ItemId;
                        HasEarringSeal = item.HasSealEffect;
                        break;
                    case "chardetail_inventory_slot10":
                        Necklace = GetFullImageUrl(item.IconUrl);
                        NecklaceID = item.ItemId;
                        HasNecklaceSeal = item.HasSealEffect;
                        break;
                    case "chardetail_inventory_slot11":
                        RingOne = GetFullImageUrl(item.IconUrl);
                        RingOneID = item.ItemId;
                        HasRing1Seal = item.HasSealEffect;
                        break;
                    case "chardetail_inventory_slot12":
                        RingTwo = GetFullImageUrl(item.IconUrl);
                        RingTwoID = item.ItemId;
                        HasRing2Seal = item.HasSealEffect;
                        break;
                    default:
                        break;
                }
            }

            foreach (var item in character.Accessories)
            {
                switch (item.SlotId)
                {
                    case "chardetail_accessory_slot0":
                        Flag = GetFullImageUrl(item.IconUrl);
                        FlagID = item.ItemId;
                        break;
                    case "chardetail_accessory_slot1":
                        Avatar = GetFullImageUrl(item.IconUrl);
                        AvatarID = item.ItemId;
                        break;
                    case "chardetail_accessory_slot2":
                        AvatarHat = GetFullImageUrl(item.IconUrl);
                        AvatarHatID = item.ItemId;
                        break;
                    case "chardetail_accessory_slot3":
                        AvatarAcc = GetFullImageUrl(item.IconUrl);
                        AvatarAccID = item.ItemId;
                        break;
                    case "chardetail_accessory_slot4":
                        Devil = GetFullImageUrl(item.IconUrl);
                        DevilID = item.ItemId;
                        break;
                    default:
                        break;
                }
            }


            IsBusy = false;

        }

        private string GetFullImageUrl(string src)
        {
            if (string.IsNullOrWhiteSpace(src))
                return null;

            return src.StartsWith("http") ? src : $"{BaseUrl}{src.TrimStart('/')}";
        }


        // Ortak sayı parse: ondalık noktayı '.' bekliyor (örnek metindeki gibi)
        private double? ParseDouble(string s)
            => double.TryParse(s, NumberStyles.Float, CultureInfo.InvariantCulture, out var v) ? v : null;

        private int? ParseInt(string s)
            => int.TryParse(s, NumberStyles.Integer, CultureInfo.InvariantCulture, out var v) ? v : null;

        public ParsedItemDetail Parse(string html)
        {
            if (string.IsNullOrWhiteSpace(html))
                return new ParsedItemDetail();

            // 1) <br> -> \n, ardından kalan etiketleri temizle
            var normalized = html
                .Replace("<br>", "\n", StringComparison.OrdinalIgnoreCase)
                .Replace("<br/>", "\n", StringComparison.OrdinalIgnoreCase)
                .Replace("<br />", "\n", StringComparison.OrdinalIgnoreCase);

            // Etiketleri sil fakat içeriği koru
            normalized = Regex.Replace(normalized, @"<[^>]+>", string.Empty, RegexOptions.Singleline);
            // HTML entity vs. varsa basit decode (gerekirse System.Web.HttpUtility.HtmlDecode kullan)
            normalized = System.Net.WebUtility.HtmlDecode(normalized);

            // Satırları çıkar
            var lines = normalized
                .Split('\n')
                .Select(l => l.Trim())
                .Where(l => !string.IsNullOrWhiteSpace(l))
                .ToList();

            var result = new ParsedItemDetail();

            // 2) İlk satır genelde "Soothsayer Hat (+9)" gibi
            //    Name + Plus
            if (lines.Count > 0)
            {
                var m = Regex.Match(lines[0], @"^(?<name>.+?)\s*\(\+(?<plus>\d+)\)$");
                if (m.Success)
                {
                    result = result with
                    {
                        Name = m.Groups["name"].Value.Trim(),
                        Plus = ParseInt(m.Groups["plus"].Value)
                    };
                }
                else
                {
                    // (+) yoksa adı yine alalım
                    result = result with { Name = lines[0] };
                }
            }

            // 3) Seal satırı (ör. "Nova Mührü") — genelde 2. satır
            //    Aynı renkte başka satırlar da olabilir; "Mührü" geçen ilk satırı yakalayalım
            var sealLine = lines.FirstOrDefault(l => l.Contains("Mührü", StringComparison.OrdinalIgnoreCase));
            if (!string.IsNullOrEmpty(sealLine))
            {
                result = result with { Seal = sealLine };
            }

            // 4) "Yeşil yazı" tekli/çoklu olabilir. Örn: "Immortality"
            //    Yeşil blok genelde seal ile tip/derece arasına düşer. Renk silindiği için
            //    güvenilir yol: bilinen başlık satırlarından önce görünen kısa tek kelimelik/özellik satırlarını yakalamak.
            //    Pratik yaklaşım: "İtem çeşidi:" ve "Derece:" gelene kadar, tek kelime/özellik görünümlü satırları yeşil say.
            var idxItemType = lines.FindIndex(l => l.StartsWith("İtem çeşidi:", StringComparison.OrdinalIgnoreCase));
            var idxDegree = lines.FindIndex(l => l.StartsWith("Derece:", StringComparison.OrdinalIgnoreCase));
            var limitIdx = new[] { idxItemType, idxDegree }.Where(i => i >= 0).DefaultIfEmpty(lines.Count).Min();

            var greenCandidates = new List<string>();
            for (int i = 0; i < Math.Min(limitIdx, lines.Count); i++)
            {
                var l = lines[i];
                if (i == 0) continue;                 // isim satırı
                if (l == result.Seal) continue;       // mühür satırı

                // Tipik "yeşil" kısa opsiyonlar: tek kelime ya da çok kısa
                if (l.Length <= 25 && !l.Contains(":") && !Regex.IsMatch(l, @"\d"))
                    greenCandidates.Add(l);
            }
            if (greenCandidates.Count > 0)
                result = result with { GreenOptions = greenCandidates.Distinct().ToList() };

            // 5) Item Type
            var typeLine = lines.FirstOrDefault(l => l.StartsWith("İtem çeşidi:", StringComparison.OrdinalIgnoreCase));
            if (!string.IsNullOrEmpty(typeLine))
            {
                var m = Regex.Match(typeLine, @"İtem çeşidi:\s*(?<t>.+)$", RegexOptions.IgnoreCase);
                if (m.Success) result = result with { ItemType = m.Groups["t"].Value.Trim() };
            }

            // 6) Degree
            var degreeLine = lines.FirstOrDefault(l => l.StartsWith("Derece:", StringComparison.OrdinalIgnoreCase));
            if (!string.IsNullOrEmpty(degreeLine))
            {
                var m = Regex.Match(degreeLine, @"Derece:\s*(?<deg>\d+)", RegexOptions.IgnoreCase);
                if (m.Success) result = result with { Degree = ParseInt(m.Groups["deg"].Value) };
            }

            // 7) Statlar
            foreach (var l in lines)
            {
                // Fiz. savnm. Gücü 255.9 (+80%)
                var mPhys = Regex.Match(l, @"Fiz\.\s*savnm\.\s*Gücü\s*(?<val>[\d\.]+)\s*\(\+(?<pct>\d+)%\)", RegexOptions.IgnoreCase);
                if (mPhys.Success)
                {
                    result = result with
                    {
                        PhysDef = ParseDouble(mPhys.Groups["val"].Value),
                        PhysDefPct = ParseInt(mPhys.Groups["pct"].Value)
                    };
                    continue;
                }

                // Büyü. savnm. Gücü 500.1 (+80%)
                var mMag = Regex.Match(l, @"Büyü\.\s*savnm\.\s*Gücü\s*(?<val>[\d\.]+)\s*\(\+(?<pct>\d+)%\)", RegexOptions.IgnoreCase);
                if (mMag.Success)
                {
                    result = result with
                    {
                        MagDef = ParseDouble(mMag.Groups["val"].Value),
                        MagDefPct = ParseInt(mMag.Groups["pct"].Value)
                    };
                    continue;
                }

                // Dayanıklılık 94/198 (+0%)
                var mDur = Regex.Match(l, @"Dayanıklılık\s*(?<cur>\d+)\/(?<max>\d+)\s*\(\+(?<pct>\d+)%\)", RegexOptions.IgnoreCase);
                if (mDur.Success)
                {
                    result = result with
                    {
                        DurabilityCur = ParseInt(mDur.Groups["cur"].Value),
                        DurabilityMax = ParseInt(mDur.Groups["max"].Value),
                        DurabilityPct = ParseInt(mDur.Groups["pct"].Value)
                    };
                    continue;
                }

                // Bertaraf Oranı 72 (+78%)
                var mBlock = Regex.Match(l, @"Bertaraf Oranı\s*(?<val>\d+)\s*\(\+(?<pct>\d+)%\)", RegexOptions.IgnoreCase);
                if (mBlock.Success)
                {
                    result = result with
                    {
                        BlockRate = ParseInt(mBlock.Groups["val"].Value),
                        BlockRatePct = ParseInt(mBlock.Groups["pct"].Value)
                    };
                    continue;
                }

                // Fiz.  Takviye 30.5 (+80%)
                var mPhysReinf = Regex.Match(l, @"Fiz\.\s*Takviye\s*(?<val>[\d\.]+)\s*\(\+(?<pct>\d+)%\)", RegexOptions.IgnoreCase);
                if (mPhysReinf.Success)
                {
                    result = result with
                    {
                        PhysReinforce = ParseDouble(mPhysReinf.Groups["val"].Value),
                        PhysReinforcePct = ParseInt(mPhysReinf.Groups["pct"].Value)
                    };
                    continue;
                }

                // Büyü. takviye 65.0 (+80%)
                var mMagReinf = Regex.Match(l, @"Büyü\.\s*takviye\s*(?<val>[\d\.]+)\s*\(\+(?<pct>\d+)%\)", RegexOptions.IgnoreCase);
                if (mMagReinf.Success)
                {
                    result = result with
                    {
                        MagReinforce = ParseDouble(mMagReinf.Groups["val"].Value),
                        MagReinforcePct = ParseInt(mMagReinf.Groups["pct"].Value)
                    };
                    continue;
                }
            }

            // 8) Mastery’ler: "Mastery level: Wizard Mastery 101"
            foreach (var l in lines)
            {
                var m = Regex.Match(l, @"Mastery level:\s*(?<name>.+?)\s+(?<lvl>\d+)$", RegexOptions.IgnoreCase);
                if (m.Success)
                {
                    var list = result.Masteries.ToList();
                    list.Add((m.Groups["name"].Value.Trim(), ParseInt(m.Groups["lvl"].Value) ?? 0));
                    result = result with { Masteries = list };
                }
            }

            // 9) Cinsiyet (Kadın/Erkek) — satırda tek başına geçiyor
            var genderLine = lines.FirstOrDefault(l =>
                l.Equals("Kadın", StringComparison.OrdinalIgnoreCase) ||
                l.Equals("Erkek", StringComparison.OrdinalIgnoreCase));
            if (!string.IsNullOrEmpty(genderLine))
                result = result with { Gender = genderLine };

            // 10) Irk: "Avrupalı" / "Çinli" vb.
            var raceLine = lines.FirstOrDefault(l =>
                l.Contains("Avrupalı", StringComparison.OrdinalIgnoreCase) ||
                l.Contains("Çinli", StringComparison.OrdinalIgnoreCase));
            if (!string.IsNullOrEmpty(raceLine))
                result = result with { Race = raceLine };

            // 11) Blue options bloğu: "Ölümsüz(1 Süre/Süreler)..." satırları
            // Hepsi tek blokta gelmiş; pratikçe "Advanced elixir" satırına kadar olan bold mavi satırları split etmiştik zaten.
            // Renk bilgisi gidince ayırmak zor; bu yüzden anahtar kelimelerden yakalayalım:
            // tipik olarak `% Artma`, `Süre/Süreler`, `HP ... Artma`, `MP ... Artma`, `Int ...`, `Str ...`.
            var blue = lines
                .SkipWhile(l => !Regex.IsMatch(l, @"Ölümsüz|Durağan|Şanslı|Astral|HP\s+\d+|MP\s+\d+|Int\s+\d+|Str\s+\d+|Artma", RegexOptions.IgnoreCase))
                .TakeWhile(l => !l.Contains("Advanced elixir", StringComparison.OrdinalIgnoreCase))
                .Where(l => !string.IsNullOrWhiteSpace(l))
                .ToList();

            if (blue.Count > 0)
                result = result with { BlueOptions = blue };

            // 12) Advanced Elixir
            var advLine = lines.FirstOrDefault(l => l.Contains("Advanced elixir", StringComparison.OrdinalIgnoreCase));
            if (!string.IsNullOrEmpty(advLine))
            {
                var m = Regex.Match(advLine, @"\[\+(?<adv>\d+)\]");
                if (m.Success)
                    result = result with { AdvancedElixirPlus = ParseInt(m.Groups["adv"].Value) };
            }

            // 13) Seal effect flag — içerikte "Mührü" veya benzeri ipucu varsa true
            var hasSeal = !string.IsNullOrEmpty(result.Seal) ||
                          lines.Any(l => l.Contains("Mührü", StringComparison.OrdinalIgnoreCase) ||
                                         l.Contains("Seal", StringComparison.OrdinalIgnoreCase));
            result = result with { HasSealEffect = hasSeal };

            return result;
        }

        public static List<string> SplitByBrToList(string html)
        {
            if (string.IsNullOrWhiteSpace(html))
                return new List<string>();

            // 1) <br>, <br/>, <br /> -> satır sonu işareti
            var normalized = Regex.Replace(html, @"<br\s*/?>", "\n", RegexOptions.IgnoreCase);

            // 2) Kalan tüm HTML etiketlerini temizle (font, b vs.)
            var noTags = Regex.Replace(normalized, @"<.*?>", string.Empty);

            // 3) HTML entity'lerini çöz (ör. &nbsp;)
            var decoded = WebUtility.HtmlDecode(noTags);

            // 4) Satırlara böl, kırp, boşları at
            return decoded
                .Split('\n')
                .Select(s => s.Trim())
                .Where(s => !string.IsNullOrWhiteSpace(s))
                .ToList();
        }
    }


  
}
