using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;

namespace UniqueRankList.Services
{
    public static class HardwareInfoService
    {
        public static string GetBIOSSerial()
        {
            try
            {
                using var searcher = new ManagementObjectSearcher("SELECT SerialNumber FROM Win32_BIOS");
                foreach (ManagementObject wmi in searcher.Get())
                    return wmi["SerialNumber"]?.ToString();
            }
            catch { }
            return "Unknown";
        }

        public static string GetMachineGuid()
        {
            try
            {
                using var key = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Cryptography");
                return key?.GetValue("MachineGuid")?.ToString() ?? "Unknown";
            }
            catch { return "Unknown"; }
        }

        public static string GetOSVersion()
        {
            return Environment.OSVersion.ToString();
        }
    }
}
