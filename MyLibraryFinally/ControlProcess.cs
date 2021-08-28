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
        //Using
        //Isthereinternetandconnectiontype
        //string control = ControlProcess.Isthereinternet();
        [DllImport("wininet.dll", CharSet = CharSet.Auto)]
        extern static bool InternetGetConnectedState(ref InternetGetConnectedStateFlags Description, int ReservedValue);
        [Flags]
        public enum InternetGetConnectedStateFlags
        {
            INTERNET_CONNECTION_MODEM = 0x01,
            INTERNET_CONNECTION_LAN = 0X02,
            INTERNET_CONNECTION_PROXY = 0X04,
            INTERNET_CONNECTION_RAS_INSTALLED = 0x10,
            INTERNET_CONNECTION_OFFLINE = 0x20,
            INTERNET_CONNECTION_CONFIGURED = 0x40
        }
        public static string Isthereinternet()
        {
            string Isconnection;
            string Connectiontype;
            InternetGetConnectedStateFlags flags = 0;
            bool baglanti = InternetGetConnectedState(ref flags, 0);
            if (baglanti)
            {
                Isconnection = "There is your connection.";
            }
            else
            {
                Isconnection = "There isn't your connection.";
            }
            if (flags == InternetGetConnectedStateFlags.INTERNET_CONNECTION_LAN)
                Connectiontype = " Your connection is LAN.";
            else
            {
                Connectiontype = " Your connection is WAN.";
            }
            return Isconnection + Connectiontype;
        }
    }
}
