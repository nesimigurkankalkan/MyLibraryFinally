using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLibraryFinally
{
    public class Log
    {
        public static string VeriEkle = " Tablosuna Yeni Veri Eklendi.";
        public static string VeriGüncelle = " Tablosunda Var Olan Veri Güncellendi.";
        public static string VeriSil = " Tablosunda Var Olan Veri Silindi.";
        public Log()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        public static void Logla(string strLogCumlesi)
        {

            //string tarih = DateTime_forSQLServer(System.DateTime.Now);
            //string strIp = HttpContext.Current.Request.UserHostAddress;
            //string strKullanici = "İsim Yok";
            //if (HttpContext.Current.Session["displayName"] != null)
            //{
            //    strKullanici = HttpContext.Current.Session["displayName"].ToString();
            //}

            //SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ExampleDB"].ToString());
            //cno.Open();
            //SqlCommand cmdLogAt = new SqlCommand("insert into log (TarihSaat,Kullanici,Ip,Mesaj) values ('" + tarih.ToString() + "','" + strKullanici + "','" + strIp + "','" + strLogCumlesi + "')", con);

            //cmdLogAt.ExecuteNonQuery();
            //cno.Close();

        }
        public static string DateTime_forSQLServer(DateTime value)
        {
            if (value == Convert.ToDateTime("01.01.0001"))
                return "NULL";
            else
                return Convert.ToDateTime(value).ToString("MM-dd-yyyy HH:mm:ss");

        }
    }
}
