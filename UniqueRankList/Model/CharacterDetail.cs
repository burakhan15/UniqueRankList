using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniqueRankList.Model
{
    public class CharacterDetail
    {
        public string CharacterName { get; set; }
        public string Nickname { get; set; }
        public string Guild { get; set; }
        public string Race { get; set; }
        public string Level { get; set; }
        public int HonorPoints { get; set; }
        public string CharPoints { get; set; }
        public string Title { get; set; }
        public string ImageUrl { get; set; }

        public List<InventoryItem> Equipment { get; set; } = new();
        public List<AccessoryItem> Accessories { get; set; } = new();

        public int HP { get; set; }
        public int MP { get; set; }
        public int STR { get; set; }
        public int INT { get; set; }
    }

    public class InventoryItem
    {
        public string SlotId { get; set; }
        public string IconUrl { get; set; }
        public string ItemId { get; set; }
        public string ItemDetailHtml { get; set; }
        public List<string> ItemDetail { get; set; }
        public bool HasSealEffect { get; set; } // <<< EKLENDİ
    }

    public class AccessoryItem
    {
        public string SlotId { get; set; }
        public string IconUrl { get; set; }
        public string ItemId { get; set; }
        public string ItemDetailHtml { get; set; }
        public bool HasSealEffect { get; set; } // <<< EKLENDİ
    }

}
