﻿using System;
using System.Management;
using System.Net;
using System.Net.NetworkInformation;
using System.Runtime.InteropServices;

namespace MyLibraryFinally
{
    public class ControlProcess
    {
        //Using
        //ComputerName
        //string control = ControlProcess.Computername();
        public static string Computername()
        {
            string bilgisayarAdi = Dns.GetHostName();
            return bilgisayarAdi;
        }
        //Using
        //GetLanIpAdress
        //string control = ControlProcess.Lanipadress();
        public static string Lanipadress()
        {
            string cname = Computername();
            string internalip = Dns.GetHostByName(cname).AddressList[0].ToString();
            return internalip;
        }
        //Using
        //GetWanIpAdress
        //string control = ControlProcess.Wanipadress();
        public static string Wanipadress()
        {
            string externalip = new WebClient().DownloadString("http://icanhazip.com");
            return externalip;
        }
        //Using
        //GetMacAdress
        //string control = ControlProcess.Macadress();
        public static string Macadress()
        {
            string mac = "";
            foreach (NetworkInterface nic in NetworkInterface.GetAllNetworkInterfaces())
            {

                if (nic.OperationalStatus == OperationalStatus.Up && (!nic.Description.Contains("Virtual") && !nic.Description.Contains("Pseudo")))
                {
                    if (nic.GetPhysicalAddress().ToString() != "")
                    {
                        mac = nic.GetPhysicalAddress().ToString();
                    }
                }
            }
            return mac;
        }
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
        //Using
        //GetInfoCPU
        //string control = ControlProcess.InfoCpu();
        public static string InfoCpu()
        {
            string info = "";
            ManagementObjectSearcher cpu = new ManagementObjectSearcher
                ("Select Name, NumberOfLogicalProcessors, L2CacheSize From Win32_Processor");
            foreach (ManagementObject cpu_bilgi in cpu.Get())
            {
                info = "CPU Name : " + (cpu_bilgi["Name"]).ToString() +
                " CPU Core Number : " + (cpu_bilgi["NumberOfLogicalProcessors"]).ToString() +
                " L2 Cache Size : " + (cpu_bilgi["L2CacheSize"]).ToString();
            }
            return info;
        }
        //Using
        //GetInfoRam
        //string control = ControlProcess.InfoRam();
        [DllImport("kernel32.dll")]
        public static extern void GlobalMemoryStatusEx(ref MEMORYSTATUSEX hafiza);
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
        public struct MEMORYSTATUSEX
        {
            public uint dwLength;
            public uint dwMemoryLoad;
            public ulong ullTotalPhys;
            public ulong ullAvailPhys;
            public ulong ullTotalPageFile;
            public ulong ullAvailPageFile;
            public ulong ullTotalVirtual;
            public ulong ullAvailVirtual;
            public ulong ullAvailExtendedVirtual;
        }
        public static string InfoRam()
        {
            MEMORYSTATUSEX hafiza = new MEMORYSTATUSEX();
            hafiza.dwLength = 64;
            GlobalMemoryStatusEx(ref hafiza);

            return "Kullanılan bellek yüzdesi= " + (hafiza.dwMemoryLoad) + "\r\n" +
            "Toplam bellek miktarı= " + (hafiza.ullTotalPhys / (1024 * 1024)) + " mb \r\n" +
            "Boş bellek miktarı= " + (hafiza.ullAvailPhys / (1024 * 1024)) + " mb \r\n" +
            "Toplam page file miktarı= " + (hafiza.ullTotalPageFile / (1024 * 1024)) + " mb \r\n" +
            "Boş page file miktarı= " + (hafiza.ullAvailPageFile / (1024 * 1024)) + " mb \r\n" +
            "Toplam sanal bellek miktarı= " + (hafiza.ullTotalVirtual / (1024 * 1024)) + " mb \r\n" +
            "Boş sanal bellek miktarı= " + (hafiza.ullAvailVirtual / (1024 * 1024)) + " mb";
        }
        //Using
        //GetAllDiskInfo
        //string control = ControlProcess.Infoalldisk();
        public static string Infoalldisk()
        {
            string info = "";
            ManagementObjectSearcher disk = new ManagementObjectSearcher("Select FreeSpace,Size,Name from Win32_LogicalDisk where DriveType=3");
            foreach (ManagementObject disk_bilgi in disk.Get())
            {
                info = "Disk Name: " + disk_bilgi["Name"].ToString() +
                " Size (gb) : " + string.Format("{0:00.0}", Convert.ToDouble(disk_bilgi["Size"]) / (1024 * 1024)) +
                " Free Size (gb) : " + string.Format("{0:00.0}", Convert.ToDouble(disk_bilgi["FreeSpace"]) / (1024 * 1024));
            }
            return info;
        }
        //Using
        //GetCpuTypeInfo
        //string control = ControlProcess.CpuTypeInfo();
        [DllImport("kernel32.dll")]
        public static extern void GetSystemInfo([MarshalAs(UnmanagedType.Struct)] ref SYSTEM_INFO lpSystemInfo);

        [StructLayout(LayoutKind.Sequential)]
        public struct SYSTEM_INFO
        {
            internal _PROCESSOR_INFO_UNION uProcessorInfo;
            public uint dwPageSize;
            public IntPtr lpMinimumApplicationAddress;
            public IntPtr lpMaximumApplicationAddress;
            public IntPtr dwActiveProcessorMask;
            public uint dwNumberOfProcessors;
            public uint dwProcessorType;
            public uint dwAllocationGranularity;
            public ushort dwProcessorLevel;
            public ushort dwProcessorRevision;
        }
        [StructLayout(LayoutKind.Explicit)]
        public struct _PROCESSOR_INFO_UNION
        {
            [FieldOffset(0)]
            internal uint dwOemId;
            [FieldOffset(0)]
            internal ushort wProcessorArchitecture;
            [FieldOffset(2)]
            internal ushort wReserved;
        }
        public static string CpuTypeInfo()
        {
            string info = "";
            SYSTEM_INFO sysinfo = new SYSTEM_INFO();
            GetSystemInfo(ref sysinfo);

            switch (sysinfo.uProcessorInfo.wProcessorArchitecture)
            {
                case 9:
                    info = "CPU Type = AMDx64";
                    break;
                case 6:
                    info = "CPU Type = Itaniumx64";
                    break;
                case 0:
                    info = "CPU Type = Intelx86";
                    break;
                default:
                    info = "Unknown CPU Type";
                    break;
            }

            return info + " CPU Logical Core Number = " + sysinfo.dwNumberOfProcessors.ToString() +
             " Cache Memory Size = " + sysinfo.dwPageSize.ToString();
        }

    }
}
