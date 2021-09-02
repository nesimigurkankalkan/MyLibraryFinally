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
        #region KelimelerineAyir
        public static string SeperateWord(string word)
        {
            string[] s;
            s = word.Split(' ');
            string tamad = s[1] + " " + s[0] + " " + s[2];
            return tamad;
        }
        #endregion
        //Using
        //DateTime firstdayofweek = FirstWeekDay();
        #region Haftanın Ilk Ve Son Gunu
        public static DateTime FirstWeekDay
        {
            get
            {
                int bugunKacinciGun = (int)DateTime.Now.DayOfWeek;
                if (bugunKacinciGun == 0)
                    return DateTime.Now.AddDays(-6);
                else
                    return DateTime.Now.AddDays(1 - bugunKacinciGun);
            }
        }

        public static DateTime LastWeekDay
        {
            get { return FirstWeekDay.AddDays(6); }
        }
        #endregion
        //Using
        //DateTime firstdayofmonth = AyinIlkGunu();
        #region Ayın Ilk-Son Gunu
        //DateTime AyinIlkGunu = new DateTime(baslangictarihi.Year, bitistarihi.Month, 1);
        //DateTime AyinOnuncuGunu = AyinIlkGunu.AddDays(9);
        //DateTime AyinOnBirinciGunu = AyinIlkGunu.AddDays(10);
        //DateTime AyinYirminciGunu = AyinIlkGunu.AddDays(19);
        //DateTime AyinYirmiBirinciGunu = AyinIlkGunu.AddDays(20);
        //DateTime AyinSonGunu = AyinIlkGunu.AddMonths(1).AddDays(-1);
        public static DateTime AyinIlkGunu
        {
            get{
                DateTime rightnow = DateTime.Now;
                DateTime AyinIlkGunu = new DateTime(rightnow.Year, rightnow.Month, 1);
                return AyinIlkGunu;
            }
        }
        public static DateTime AyinOnuncuGunu
        {
            get
            {
                DateTime rightnow = DateTime.Now;
                DateTime AyinOnuncuGunu = AyinIlkGunu.AddDays(9);
                return AyinOnuncuGunu;
            }
        }
        public static DateTime AyinOnBirinciGunu
        {
            get
            {
                DateTime rightnow = DateTime.Now;
                DateTime AyinOnBirinciGunu = AyinIlkGunu.AddDays(10);
                return AyinOnBirinciGunu;
            }
        }
        public static DateTime AyinYirminciGunu
        {
            get
            {
                DateTime rightnow = DateTime.Now;
                DateTime AyinYirminciGunu = AyinIlkGunu.AddDays(19);
                return AyinYirminciGunu;
            }
        }
        public static DateTime AyinYirmiBirinciGunu
        {
            get
            {
                DateTime rightnow = DateTime.Now;
                DateTime AyinYirmiBirinciGunu = AyinIlkGunu.AddDays(20);
                return AyinYirmiBirinciGunu;
            }
        }
        public static DateTime AyinSonGunu
        {
            get
            {
                DateTime rightnow = DateTime.Now;
                DateTime AyinSonGunu = AyinIlkGunu.AddMonths(1).AddDays(-1);
                return AyinSonGunu;
            }
        }
        #endregion
        //Using
        //FlushMemory
        #region Bellek Temizle
        [DllImportAttribute("kernel32.dll", EntryPoint = "SetProcessWorkingSetSize", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        private static extern int SetProcessWorkingSetSize(IntPtr process, int minimumWorkingSetSize, int maximumWorkingSetSize);
        public static void FlushMemory()
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
            if (Environment.OSVersion.Platform == PlatformID.Win32NT)
                SetProcessWorkingSetSize(System.Diagnostics.Process.GetCurrentProcess().Handle, -1, -1);
        }
        #endregion
        //Using
        //int degisendeger = _ToInteger(objectvariable);
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
