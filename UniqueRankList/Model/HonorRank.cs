using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniqueRankList.Model
{
    public class HonorRank
    {
        public int Rank { get; set; }
        public string MedalIcon { get; set; }     // Yeni
        public string RaceIcon { get; set; }      // Yeni
        public string CharacterName { get; set; }
        public int Points { get; set; }
        public string ChangeIcon { get; set; }    // Yeni
        public string ChangeDescription { get; set; }    // Yeni
    }
}
