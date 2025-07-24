using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniqueRankList.Model
{
    public class UniqueSpawnTime
    {
        public string Name { get; set; }
        public int Hour { get; set; }
        public int Minute { get; set; }

        public List<DayOfWeek> Days { get; set; }

        public UniqueSpawnTime(string name, int hour, int minute = 0, List<DayOfWeek> days = null)
        {
            Name = name;
            Hour = hour;
            Minute = minute;
            Days = days ?? new List<DayOfWeek>
        {
            DayOfWeek.Monday,
            DayOfWeek.Tuesday,
            DayOfWeek.Wednesday,
            DayOfWeek.Thursday,
            DayOfWeek.Friday,
            DayOfWeek.Saturday,
            DayOfWeek.Sunday
        };
        }
    }
}
