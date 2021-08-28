using System;
using System.Management;
using System.Runtime.InteropServices;

namespace MyLibraryFinally
{
    public class ControlProcess
    {
        //Using
        //IsthereFirewall
        //bool control = ControlProcess.FirewallOpened();
        public static bool FirewallOpened()
        {
            Type t = Type.GetTypeFromProgID("HNetCfg.FwMgr");
            dynamic dy = Activator.CreateInstance(t);
            return Convert.ToBoolean(dy.LocalPolicy.CurrentProfile.FirewallEnabled);
        }
        //Using
        //IsthereAntivirus
        //bool control = AntivirusInstalled();
        public static bool AntivirusInstalled()
        {
            string wmipathstr = @"\\" + Environment.MachineName + @"\root\SecurityCenter";
            try
            {
                ManagementObjectSearcher searcher = new ManagementObjectSearcher(wmipathstr, "SELECT * FROM AntivirusProduct");
                ManagementObjectCollection instances = searcher.Get();
                return instances.Count > 0;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return false;
        }
    }
}
