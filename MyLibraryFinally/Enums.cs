using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLibraryFinally
{
    public class Enums
    {
        public Enums()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        public enum ONAYLAMALAR
        {
            BEKLEME = 1,
            ONAYLA = 2,
            ONAYLAMA = 3
        };
        public enum Departman
        {
            SIZDE = 1,
            YONETICINIZDE = 2,
            BUTCESORUMLUSUNDA = 3,
            CFO = 4,
            FINANSDA = 5,
            DILEKTE = 6,
            OGRANIZASYONSORUMLUSU = 7
        };
        public enum FormTipi
        {
            GENELTALEPFORMU = 1,
            MASRAFFORMU = 2,
            IZINFORMU = 3
        };
        public enum PARATIPI
        {
            TurkLirasi_TL = 0,
            AmerikanDolari_USD = 1,
            Euro_EUR = 2,
            KanadaDolari_CAD = 3,
            DanimarkaKronu_DKK = 4,
            IsvecKronu_SEK = 5,
            IsvicreFrangi_CHF = 6,
            NorvecKronu_NOK = 7,
            JaponYeni_JPY = 8,
            SuudiArabRiyali_SAR = 9,
            KuveytDinari_KWD = 10,
            AvustralyaDolari_AUD = 11,
            IngilizPaundu_GBP = 12,
            IranRiyali_IRR = 13,
            SuriyeLirasi_SYP = 14,
            UrdunDinari_JOD = 15,
            BulgarLevasi_BGL = 16,
            YeniRumenLeyi_RON = 17,
            YeniIsrailSekeli_ILS = 18,
            GuneyKoreWonu_KRW = 19
        };
    }
}
