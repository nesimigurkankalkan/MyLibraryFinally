using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLibraryFinally
{
    public class ErrorTypes
    {
        /*
        Message (Mesaj): Ortaya çıkan hatayla ilgili açıklayıcı bir mesaj saklar.
        Source (Kaynak): İstisnai durum nesnesinin gönderildiği uygulama ya da dosyanın adıdır.
        StackTrace (Yığınİzi): Hatanın oluştuğu metod ve program hakkında bilgi içerir.
        HelpLink (YardımBağlantısı): Hatayla ilgili olan yardım dosyasının yol bilgisini saklar.
        TargetSite (HedefAlanı): İstisnai durumu yaratan metod ile ilgili bilgi verir.
        InnerException (Dahiliİstisna): "catch" bloğu içerisinden bir hata yaratılırsa "catch" bloğuna gelinmesine yol açan istisnai durumun Exception nesnesidir.
        ToString (Dizgiye): Bu metod ilgili hataya ilişkin hata metninin tamamını dizi olarak döndürür.
        */

        /*
        System.OutOfMemoryException: Programın çalışması için yeterli bellek kalmadıysa oluşur.
        System.StackOverflowException: Stack (Yığın) bellek bölgesinin birden fazla metod için kullanılması durumunda oluşur. Genellikle kendini çağıran metodların hatalı kullanılmasıyla meydana gelir.
        System.NullReferenceException: Bellekte yer ayrılmamış bir nesne üzerinden sınıfın üye elemanlarına erişmeye çalışırken oluşur.
        System.OverflowException: Bir veri türüne kapasitesinden fazla veri yüklemeye çalışılırken oluşur.
        System.InvalidCastException: Tür dönüştürme operatörüyle geçersiz tür dönüşümü yapılmaya çalışıldığında oluşur.
        System.IndexOutOfRangeException: Bir dizinin olmayan elemanına erişilmeye çalışılırken fırlatılır.
        System.ArrayTypeMismatchException: Bir dizinin elemanına yanlış türde veri atanmaya çalışılırken oluşur.
        System.DividedByZero: Sıfıra bölme yapıldığı zaman oluşur.
        System.ArithmeticException: DividedByZero ve OverflowException bu sınıftan türemiştir. Hemen hemen matematikle ilgili tüm istisnaları yakalayabilir.
        System.FormatException: Metodlara yanlış biçimde parametre verildiğinde oluşur.
        */
    }
}
