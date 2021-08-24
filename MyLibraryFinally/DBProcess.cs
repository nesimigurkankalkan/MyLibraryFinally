using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MyLibraryFinally
{
    //Model olmadan depolayabileceğin bir veriyi ekleyemezsin.
    //Burada model eklemek yerine modeli parametre olarak buraya gönderebilirsin.
    public class DBProcess
    {
        public static DbContext contextEntities;
        //Listele
        //var liste = DBProcess.Select<Ogrenciler>(_db);
        public static List<T> Select<T>(DbContext context) where T : class
        {
            contextEntities = context;
            DbSet<T> dbset = contextEntities.Set<T>();
            return dbset.ToList();
        }
        //Ekle
        //DBProcess.Add<Models.Ogrenciler>(yeniogrenci,_db);
        public static void Add<T>(T item, DbContext getentity) where T : class
        {
            contextEntities = getentity;
            //entity.Configuration.LazyLoadingEnabled = false;
            contextEntities.Set<T>().Add(item);
            contextEntities.SaveChanges();
            //Log.Logla(item.ToString() + Log.VeriEkle);
        }
        //Güncelle
        //DBProcess.Update<Models.Ogrenciler>(yeniogrenci,1011,_db);
        public static void Update<T>(T item, int Id, DbContext getentity) where T : class
        {
            contextEntities = getentity;
            var updateitem = contextEntities.Set<T>().Find(Id);
            contextEntities.Entry<T>(updateitem).CurrentValues.SetValues(item);
            contextEntities.SaveChanges();
            //Log.Logla(item.ToString() + Log.VeriGüncelle);
        }
        //Sil
        ////DBProcess.Delete<Ogrenciler>(1011, _db);
        public static void Delete<T>(int Id, DbContext getentity) where T : class
        {
            contextEntities = getentity;
            var selectrecord = contextEntities.Set<T>().Find(Id);
            PropertyInfo[] propertyInfos;
            propertyInfos = selectrecord.GetType().GetProperties();
            string result = "Silinen Tablo Adı:" + typeof(T).Name + " | Silinen Kayit:";
            foreach (PropertyInfo item in propertyInfos)
            {
                result += " | " + item.Name + ": " + item.GetValue(selectrecord, null) + " | ";
            }

            contextEntities.Set<T>().Remove(selectrecord);
            contextEntities.SaveChanges();
            //Log.Logla(result + Log.VeriSil);
        }
        //Seçili Olanı Güncelle
        public static void UpdateSelectParameter<T>(T item, string[] SelectParameter, DbContext getentity) where T : class
        {
            contextEntities = getentity;
            var updateItem = contextEntities.Set<T>().Find(item.GetType().GetProperty("Id").GetValue(item, null));
            PropertyInfo[] propertyInfos;
            propertyInfos = item.GetType().GetProperties();
            foreach (PropertyInfo item2 in propertyInfos)
            {
                object selectValue = item2.GetValue(item, null);
                if (SelectParameter.Contains(item2.Name))
                {
                    updateItem.GetType().GetProperty(item2.Name).SetValue(updateItem, selectValue, null);
                }
            }
            contextEntities.Entry<T>(updateItem).CurrentValues.SetValues(updateItem);
            contextEntities.SaveChanges();
            //Log.Logla(item.ToString() + Log.VeriGüncelle);
        }
        //Birden Çok Veri Sil
        public static void DeleteMultiple<T>(Expression<Func<T, bool>> where, DbContext getentity) where T : class
        {
            contextEntities = getentity;
            foreach (var item in contextEntities.Set<T>().Where(where))
            {
                contextEntities.Set<T>().Remove(item);
                string tablename = item.ToString();
                //Log.Logla(tablename + Log.VeriSil);
            }
        }
        //Var Mı Yok Mu
        //DatabaseIslemleri.Exists<Model.RehberIsim>(p => p.KullaniciAdi == kisiAdKontrol && p.Aktif == true)
        public static bool Exists<T>(Expression<Func<T, bool>> where, DbContext getentity) where T : class
        {
            contextEntities = getentity;
            return contextEntities.Set<T>().Any(where);

        }

        //Veriyi Yakalamak İçin
        //ID'den Yakala
        public static T SelectFromId<T>(DbContext context, int Id) where T : class
        {
            contextEntities = context;
            var item = contextEntities.Set<T>().Find(Id);
            return item;
        }
        //Satırdan Idyi Yakala --Bu Test edilecek return T degeri (int) castti.
        public static T SelectIdFromValue<T>(Expression<Func<T, bool>> where, DbContext getentity) where T : class
        {
            //using (var entity = new ContextEntities())
            //{
            contextEntities = getentity;
            object selectedItem = contextEntities.Set<T>().FirstOrDefault(where);
            return (T)selectedItem.GetType().GetProperty("Id").GetValue(selectedItem, null);
            //}
        }

        //Tek satır nesneyi geri döndürür
        public static T SelectedValueOneRow<T>(Expression<Func<T, bool>> where, DbContext getentity) where T : class
        {
            //using (var entity = new ContextEntities())
            //{
            return contextEntities.Set<T>().FirstOrDefault(where);
            //}
        }


        public static void EntityDispose()
        {
            //if (_db != null)
            //{
            //_db.Dispose();
            //}
            if (contextEntities != null)
            {
                contextEntities.Dispose();
            }
        }


        //public static void InsertTransaction<T1, T2>(T1 item1, T2 item2) where T1 : class
        //{
        //    using (var entity = new contextentities())
        //    {
        //        entity.Set<T1>().Add(item1);
        //        entity.SaveChanges();
        //        var Id = entity.Set<T1>().Local.Last().Id;
        //    }
        //}

    }
}
