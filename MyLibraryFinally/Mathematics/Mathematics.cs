using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLibraryFinally
{
    public class Mathematics
    {
        //Using
        //IsOdd - Sayı tek mi ? Parametre olarak aldıgı sayının tek olup olmadığını kontrol eder.
        //Console.WriteLine("{0}", Mathematics.IsOdd(n) ? "Tek sayi." : "Tek sayi degil!");
        public static bool IsOdd(int n)
        {
            if (n % 2 == 1)
                return true;
            return false;
        }

        //Using
        //IsEven - Sayı çift mi ? Parametre olarak aldıgı sayının cift olup olmadığını kontrol eder.
        //Console.WriteLine("{0}", Mathematics.IsEven(n) ? "Cift sayi." : "Cift sayi degil!");
        public static bool IsEven(int n)
        {
            if (n % 2 == 0)
                return true;
            return false;
        }

        //Using
        //AbsoluteValue - Parametre olarak aldıgı sayının mutlak degerini doner.
        //Console.WriteLine("|{0}| = {1}", n, Mathematics.AbsoluteValue(n));
        public static int AbsoluteValue(int n)
        {
            if (n > 0)
                return n;
            else if (n < 0)
                return -1 * n;
            else
                return 0;
        }

        //Using
        //IsPrime - Asal sayı mı ?
        //Console.WriteLine("{0}", Mathematics.IsPrime(n) ? "Asal sayi." : "Asal sayi degil!");
        public static bool IsPrime(int n)
        {
            if (n<=1)
            {
                Console.WriteLine("En kucuk asal sayi 2 dir.");
                return false;
            }

            bool kontrol = true;
            for (int i = 2; i < n; i++)
                if (n % i == 0)
                {
                    kontrol = false;
                    break;

                }
            return kontrol;

        }

        //Using
        //SeperateEveryNumberAndSum - Parametre olarak aldıgı sayının her bir rakamını ayırıp birbirleriyle toplayıp sonucu geri doner.
        //Console.WriteLine("{0} sayinin rakamlari toplami = {1}",n, Mathematics.SeperateEveryNumberAndSum(n));
        public static int SeperateEveryNumberAndSum(int n)
        {
            int toplam = 0, rakam = 0;
            while (n>0)
	        {
                rakam = n % 10;
                toplam += rakam;
                n = n / 10; 
	        }
            return toplam;
        }
    }
}
