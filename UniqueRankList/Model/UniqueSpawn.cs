using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniqueRankList.Model
{
    public class UniqueSpawn : ViewModelBase
    {
        public string UniqueName { get; set; }
        public List<string> SpawnTimesInTurkey { get; set; }

        private List<string> _convertedSpawnTimes = new();
        public List<string> ConvertedSpawnTimes
        {
            get => _convertedSpawnTimes;
            set
            {
                _convertedSpawnTimes = value;
                OnPropertyChanged(nameof(ConvertedSpawnTimes));
            }
        }
    }
}
