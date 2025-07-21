using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniqueRankList.Model
{
    public class LicenseRequestModel
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public string BIOSSerial { get; set; }
        public string MachineGuid { get; set; }
        public string OSVersion { get; set; }
    }
}
