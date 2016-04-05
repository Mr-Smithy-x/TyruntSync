using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;

namespace TyruntSync.Utils
{
    public class SystemInfo
    {
        public static String getOperatingSystemInfo()
        {
            String os = "", bit = "";
            ManagementObjectSearcher mos = new ManagementObjectSearcher("select * from Win32_OperatingSystem");
            foreach (ManagementObject managementObject in mos.Get())
            {
                if (managementObject["Caption"] != null)
                {
                    os = managementObject["Caption"].ToString();   //Display operating system caption
                }
                if (managementObject["OSArchitecture"] != null)
                {
                    bit = managementObject["OSArchitecture"].ToString();   //Display operating system architecture.
                }
            }
            return os + " " + bit;
        }

        public static String getProcessorInfo()
        {
            RegistryKey processor_name = Registry.LocalMachine.OpenSubKey(@"Hardware\Description\System\CentralProcessor\0", RegistryKeyPermissionCheck.ReadSubTree);   //This registry entry contains entry for processor info.
            if (processor_name != null)
            {
                if (processor_name.GetValue("ProcessorNameString") != null)
                {
                    return processor_name.GetValue("ProcessorNameString").ToString();
                }
            }
            return "";
        }
    }
}
