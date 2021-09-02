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

        #region ConvertToVariable
        public static int? _ToInteger(this object gelen)
        {
            try
            {
                if (gelen == null) throw new Exception();
                int x = Convert.ToInt32(gelen);
                return x;
            }
            catch (Exception)
            {
                try
                {
                    if (gelen == DBNull.Value) throw new Exception();
                    int x = Convert.ToInt32(gelen);
                    return x;
                }
                catch (Exception)
                {
                    return null;
                }
            }
        }

        public static double? _ToDouble(this object gelen)
        {
            try
            {
                if (gelen == null) throw new Exception();
                double x = Convert.ToDouble(gelen);
                return x;
            }
            catch (Exception)
            {
                try
                {
                    if (gelen == DBNull.Value) throw new Exception();
                    double x = Convert.ToDouble(gelen);
                    return x;
                }
                catch (Exception)
                {
                    return null;
                }
            }
        }

        public static decimal? _ToDecimal(this object gelen)
        {
            try
            {
                if (gelen == null) throw new Exception();
                decimal x = Convert.ToDecimal(gelen);
                return x;
            }
            catch (Exception)
            {
                try
                {
                    if (gelen == DBNull.Value) throw new Exception();
                    decimal x = Convert.ToDecimal(gelen);
                    return x;
                }
                catch (Exception)
                {
                    return null;
                }
            }
        }

        public static bool? _ToBoolean(this object gelen)
        {
            try
            {
                if (gelen == null) throw new Exception();
                bool x = Convert.ToBoolean(gelen);
                return x;
            }
            catch (Exception)
            {
                try
                {
                    if (gelen == DBNull.Value) throw new Exception();
                    bool x = Convert.ToBoolean(gelen);
                    return x;
                }
                catch (Exception)
                {
                    return null;
                }
            }
        }

        public static DateTime? _ToDateTime(this object gelen)
        {
            try
            {
                if (gelen == null) throw new Exception();
                DateTime x = Convert.ToDateTime(gelen);
                return x;
            }
            catch (Exception)
            {
                try
                {
                    if (gelen == DBNull.Value) throw new Exception();
                    DateTime x = Convert.ToDateTime(gelen);
                    return x;
                }
                catch (Exception)
                {
                    return null;
                }
            }
        }

        public static float? _ToFloat(this string gelen)
        {
            try
            {
                if (gelen == null) throw new Exception();
                float x = float.Parse(gelen);
                return x;
            }
            catch (Exception)
            {
                try
                {
                    if (string.IsNullOrEmpty(gelen) || string.IsNullOrWhiteSpace(gelen)) throw new Exception();
                    float x = float.Parse(gelen);
                    return x;
                }
                catch (Exception)
                {
                    return null;
                }
            }
        }

        public static string _ToString(this object gelen)
        {
            try
            {
                if (gelen == null) throw new Exception();
                return gelen.ToString();
            }
            catch (Exception)
            {
                try
                {
                    if (gelen == DBNull.Value) throw new Exception();
                    return gelen.ToString();
                }
                catch (Exception)
                {
                    return "";
                }
            }
        }

        public static int _ToIntegerR(this object gelen)
        {
            try
            {
                if (gelen == null) throw new Exception();
                int x = Convert.ToInt32(gelen);
                return x;
            }
            catch (Exception)
            {
                try
                {
                    if (gelen == DBNull.Value) throw new Exception();
                    int x = Convert.ToInt32(gelen);
                    return x;
                }
                catch (Exception)
                {
                    return 0;
                }
            }
        }

        public static double _ToDoubleR(this object gelen)
        {
            try
            {
                if (gelen == null) throw new Exception();
                double x = Convert.ToDouble(gelen);
                return x;
            }
            catch (Exception)
            {
                try
                {
                    if (gelen == DBNull.Value) throw new Exception();
                    double x = Convert.ToDouble(gelen);
                    return x;
                }
                catch (Exception)
                {
                    return 0;
                }
            }
        }

        public static decimal _ToDecimalR(this object gelen)
        {
            try
            {
                if (gelen == null) throw new Exception();
                decimal x = Convert.ToDecimal(gelen);
                return x;
            }
            catch (Exception)
            {
                try
                {
                    if (gelen == DBNull.Value) throw new Exception();
                    decimal x = Convert.ToDecimal(gelen);
                    return x;
                }
                catch (Exception)
                {
                    return 0;
                }
            }
        }

        public static bool _ToBooleanR(this object gelen)
        {
            try
            {
                if (gelen == null) throw new Exception();
                bool x = Convert.ToBoolean(gelen);
                return x;
            }
            catch (Exception)
            {
                try
                {
                    if (gelen == DBNull.Value) throw new Exception();
                    bool x = Convert.ToBoolean(gelen);
                    return x;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }

        public static DateTime _ToDateTimeR(this object gelen)
        {
            try
            {
                if (gelen == null) throw new Exception();
                DateTime x = Convert.ToDateTime(gelen);
                return x;
            }
            catch (Exception)
            {
                try
                {
                    if (gelen == DBNull.Value) throw new Exception();
                    DateTime x = Convert.ToDateTime(gelen);
                    return x;
                }
                catch (Exception)
                {
                    return DateTime.MinValue;
                }
            }
        }

        public static float _ToFloatR(this string gelen)
        {
            try
            {
                if (gelen == null) throw new Exception();
                float x = float.Parse(gelen);
                return x;
            }
            catch (Exception)
            {
                try
                {
                    if (string.IsNullOrEmpty(gelen) || string.IsNullOrWhiteSpace(gelen)) throw new Exception();
                    float x = float.Parse(gelen);
                    return x;
                }
                catch (Exception)
                {
                    return 0;
                }
            }
        }
        #endregion
    }
}
