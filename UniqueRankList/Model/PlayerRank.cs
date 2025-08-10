using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniqueRankList.Model
{
    public class PlayerRank
    {
        public int Rank { get; set; }
        public string CharacterName { get; set; }
        public int Points { get; set; }
        public string MedalIcon { get; set; }
        public string RaceIcon { get; set; }
        public string ChangeIcon { get; set; }
        public string ChangeDescription { get; set; }
    }
}
