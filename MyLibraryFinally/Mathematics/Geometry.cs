using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLibraryFinally.Mathematics
{
    public class Geometry
    {
        public const double pi = 3.14;
        //Using
        //CircumferenceoftheCircle - Çemberin çevresini hesaplar. Buradaki R yarı çaptır.
        //Console.WriteLine("2*{0:F2} * {1:F2} = {2:F2}", Geometry.pi, r, Geometry.CircumferenceoftheCircle(r))
        public static double CircumferenceoftheCircle(double r)
        {
            return 2 * pi * r;
        }
        //Using
        //AreaoftheCircle - Dairenin alanini hesaplar. Buradaki R yarı çaptır.
        //Console.WriteLine("Alan = {0:F2}", Geometry.AreaoftheCircle(r))
        public static double AreaoftheCircle(double r) 
        {
            return pi * r * r;
        }
        //Using
        //Override Method
        //AreaoftheCircle - Dilimli dairenin alanini hesaplar. Buradaki R yarı çaptır.
        //Console.WriteLine("Alan = {0:F2}", Geometry.AreaoftheCircle(r,60))
        public static double AreaoftheCircle(double r, double angle)
        {
            return pi * r * r * angle / 360;
        }

    }
}
