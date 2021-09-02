using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace MyLibraryFinally
{
    public class OtherMethods
    {
        //Using
        //SeperateWord("Gürkan Nesimi Kalkan");
        public static string SeperateWord(string word)
        {
            string[] s;
            s = word.Split(' ');
            string tamad = s[1] + " " + s[0] + " " + s[2];
            return tamad;
        }
        //Using
        //FlushMemory
        [DllImportAttribute("kernel32.dll", EntryPoint = "SetProcessWorkingSetSize", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        private static extern int SetProcessWorkingSetSize(IntPtr process, int minimumWorkingSetSize, int maximumWorkingSetSize);
        public static void FlushMemory()
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
            if (Environment.OSVersion.Platform == PlatformID.Win32NT)
                SetProcessWorkingSetSize(System.Diagnostics.Process.GetCurrentProcess().Handle, -1, -1);
        }
    }
}
