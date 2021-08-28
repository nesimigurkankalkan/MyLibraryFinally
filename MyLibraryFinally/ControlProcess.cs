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
    }
}
