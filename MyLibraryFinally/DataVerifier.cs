using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MyLibraryFinally
{
    public class DataVerifier
    {
        public enum KontrolTipleri
        {
            TC_Kimlik_No,
            VergiKimlik_No,
            IBAN_No,
            Email
        }
        #region Mail, TC, IBAN, VergiKimlik
        public static bool _TC_VD_IBAN_MAIL_Kontrol(this string gelenVeri, KontrolTipleri kontrolu)
        {
            if (kontrolu == KontrolTipleri.TC_Kimlik_No)
            {
                #region TCKimlikKontrol
                string tckimlik = gelenVeri;
                try
                {
                    int index = 0;
                    int toplam = 0;
                    foreach (char n in tckimlik)
                    {
                        if (index < 10)
                        {
                            toplam += Convert.ToInt32(char.ToString(n));
                        }
                        index++;
                    }
                    if (toplam % 10 == Convert.ToInt32(tckimlik[10].ToString()))
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                catch
                {
                    return false;
                }
                #endregion
            }
            else if (kontrolu == KontrolTipleri.VergiKimlik_No)
            {
                #region VergiKimlikNo
                string vergiNo = gelenVeri;
                try
                {
                    int v1, v2, v3, v4, v5, v6, v7, v8, v9, v10, v11, v22, v33, v44, v55, v66, v77, v88, v99, toplam2;
                    v1 = (Convert.ToInt32(gelenVeri.Substring(0, 1)) + 9) % 10;
                    v2 = (Convert.ToInt32(gelenVeri.Substring(1, 1)) + 8) % 10;
                    v3 = (Convert.ToInt32(gelenVeri.Substring(2, 1)) + 7) % 10;
                    v4 = (Convert.ToInt32(gelenVeri.Substring(3, 1)) + 6) % 10;
                    v5 = (Convert.ToInt32(gelenVeri.Substring(4, 1)) + 5) % 10;
                    v6 = (Convert.ToInt32(gelenVeri.Substring(5, 1)) + 4) % 10;
                    v7 = (Convert.ToInt32(gelenVeri.Substring(6, 1)) + 3) % 10;
                    v8 = (Convert.ToInt32(gelenVeri.Substring(7, 1)) + 2) % 10;
                    v9 = (Convert.ToInt32(gelenVeri.Substring(8, 1)) + 1) % 10;
                    v10 = (Convert.ToInt32(gelenVeri.Substring(9, 1))) % 10;
                    v11 = (v1 * 512) % 9;
                    v22 = (v2 * 256) % 9;
                    v33 = (v3 * 128) % 9;
                    v44 = (v4 * 64) % 9;
                    v55 = (v5 * 32) % 9;
                    v66 = (v6 * 16) % 9;
                    v77 = (v7 * 8) % 9;
                    v88 = (v8 * 4) % 9;
                    v99 = (v9 * 2) % 9;
                    if (v1 != 0 && v11 == 0) v11 = 9;
                    if (v2 != 0 && v22 == 0) v22 = 9;
                    if (v3 != 0 && v33 == 0) v33 = 9;
                    if (v4 != 0 && v44 == 0) v44 = 9;
                    if (v5 != 0 && v55 == 0) v55 = 9;
                    if (v6 != 0 && v66 == 0) v66 = 9;
                    if (v7 != 0 && v77 == 0) v77 = 9;
                    if (v8 != 0 && v88 == 0) v88 = 9;
                    if (v9 != 0 && v99 == 0) v99 = 9;
                    toplam2 = v11 + v22 + v33 + v44 + v55 + v66 + v77 + v88 + v99;
                    if ((toplam2 % 10) == 0)
                        toplam2 = 0;
                    else
                        toplam2 = 10 - (toplam2 % 10);
                    if (toplam2 == v10)
                        return true;
                    else
                        return false;
                }
                catch (Exception)
                {
                    return false;
                }
                #endregion
            }
            else if (kontrolu == KontrolTipleri.IBAN_No)
            {
                #region IBAN
                string ibanNo = gelenVeri.ToUpper();
                if (String.IsNullOrEmpty(ibanNo))
                    return false;
                else if (System.Text.RegularExpressions.Regex.IsMatch(ibanNo, "^[A-Z0-9]"))
                {
                    ibanNo = ibanNo.Replace(" ", String.Empty);
                    string bank =
                    ibanNo.Substring(4, ibanNo.Length - 4) + ibanNo.Substring(0, 4);
                    int asciiShift = 55;
                    StringBuilder sb = new StringBuilder();
                    foreach (char c in bank)
                    {
                        int v;
                        if (Char.IsLetter(c)) v = c - asciiShift;
                        else v = int.Parse(c.ToString());
                        sb.Append(v);
                    }
                    string checkSumString = sb.ToString();
                    int checksum = int.Parse(checkSumString.Substring(0, 1));
                    for (int i = 1; i < checkSumString.Length; i++)
                    {
                        int v = int.Parse(checkSumString.Substring(i, 1));
                        checksum *= 10;
                        checksum += v;
                        checksum %= 97;
                    }
                    return checksum == 1;
                }
                else
                    return false;
                #endregion
            }
            else if (kontrolu == KontrolTipleri.Email)
                return Regex.IsMatch(gelenVeri, @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$");
            else
                return false;
        }

        
        #endregion
    }
}
