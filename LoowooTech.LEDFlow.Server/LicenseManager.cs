using LoowooTech.LEDFlow.Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Management;
using System.Text;
using System.Text.RegularExpressions;

namespace LoowooTech.LEDFlow.Server
{
    internal static class LicenseManager
    {
        private static Regex _caRegex = new Regex(@"\[([^\[\]]+)\]", RegexOptions.Compiled);
        public static LicenseInfo GetLicenseInfo()
        {
            var result = new LicenseInfo();
            try
            {

                var caPath = Environment.CurrentDirectory + "/ca.crt";
                var content = File.ReadAllText(caPath);
                content = EncryptHelper.AESDecrypt(EncryptHelper.FromBase64String(content));
                var i = 0;
                foreach (Match m in _caRegex.Matches(content))
                {
                    var val = m.Groups[1].Value;
                    if (i == 0)
                    {
                        result.NetName = val;
                    }
                    if (i == 1)
                    {
                        result.ExpireDay = DateTime.Parse(val);
                    }
                    if (i == 2)
                    {
                        result.HardwareID = val;
                    }
                    i++;
                }
                if (!string.IsNullOrEmpty(result.HardwareID))
                {
                    //硬件不匹配
                    if (GetProcessorID() + "|" + GetBoardID() != result.HardwareID)
                    {
                        return null;
                    }
                }

                return result;
            }
            catch
            {
                return null;
            }
        }

        public static void CreateSnFile()
        {
            var filePath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "sn.txt");
            //自动生成sn序列号文件
            if (!System.IO.File.Exists(filePath))
            {
                var sn = GetProcessorID() + "|" + GetBoardID() + "|" + DateTime.Now.Ticks;
                var content = Convert.ToBase64String(EncryptHelper.AESEncrypt(sn));
                System.IO.File.WriteAllText(filePath, content);
            }
        }

        private static string GetBoardID()
        {
            var searcher = new ManagementObjectSearcher("SELECT * FROM Win32_BaseBoard");
            foreach (ManagementObject mo in searcher.Get())
            {
                return (string)mo["SerialNumber"];
            }

            return null;
        }

        private static string GetProcessorID()
        {
            var searcher = new ManagementObjectSearcher("SELECT * FROM Win32_Processor");
            foreach (ManagementObject mo in searcher.Get())
            {
                return (string)mo["ProcessorId"];
            }

            return null;
        }

    }
}
