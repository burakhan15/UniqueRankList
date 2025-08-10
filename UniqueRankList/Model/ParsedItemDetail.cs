using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniqueRankList.Model
{
    public record ParsedItemDetail
    {
        public string Name { get; init; }
        public int? Plus { get; init; }
        public string Seal { get; init; }                 // "Nova Mührü" vb.
        public List<string> GreenOptions { get; init; } = new(); // ör. "Immortality"
        public string ItemType { get; init; }             // "Robe Hat"
        public int? Degree { get; init; }                 // 11
        public double? PhysDef { get; init; }             // 255.9
        public int? PhysDefPct { get; init; }             // 80
        public double? MagDef { get; init; }              // 500.1
        public int? MagDefPct { get; init; }
        public int? DurabilityCur { get; init; }          // 94
        public int? DurabilityMax { get; init; }          // 198
        public int? DurabilityPct { get; init; }          // 0
        public int? BlockRate { get; init; }              // 72
        public int? BlockRatePct { get; init; }           // 78
        public double? PhysReinforce { get; init; }       // 30.5
        public int? PhysReinforcePct { get; init; }       // 80
        public double? MagReinforce { get; init; }        // 65.0
        public int? MagReinforcePct { get; init; }        // 80
        public List<(string Mastery, int Level)> Masteries { get; init; } = new();
        public string Gender { get; init; }               // "Kadın", "Erkek"
        public string Race { get; init; }                 // "Avrupalı", "Çinli" vb.
        public List<string> BlueOptions { get; init; } = new(); // mavi yazı bloğu
        public int? AdvancedElixirPlus { get; init; }     // 2
        public bool HasSealEffect { get; init; }          // İçerikten türetilen
    }
}
