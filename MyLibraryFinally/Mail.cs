using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace MyLibraryFinally
{
    public class Mail
    {
        #region Logo
        public const string LogoBase64 = "<img src='data:image/png;base64, base64codehere' />";
        #endregion


        public Mail()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        public static void EpostaHtmlBireBir(string firma, string kime, string kimden, string kimdenAd, string konu, string icerik, params string[] CC)
        {
            try
            {
                Attachment dos = null;
                SendMail(firma, new string[] { kime }, kimden, kimdenAd, konu, icerik, true, dos, CC);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public static void MailHtmlDosyaliBireBir(string firma, string kime, string kimden, string kimdenAd, string konu, string icerik, Attachment dosya, params string[] CC)
        {
            try
            {
                Attachment dos = dosya;
                SendMail(firma, new string[] { kime }, kimden, kimdenAd, konu, icerik, true, dos, CC);
            }
            catch (Exception ex)
            { throw ex; }
        }

        private static void SendMail(string firmaAdi, string[] kime, string kimden, string kimdenAd, string konu, string icerik, bool isBodyHtml, Attachment dosya, params string[] CC)
        {
            try
            {
                MailMessage email = new MailMessage();
                if (firmaAdi == "" || firmaAdi == "firmaKodu")
                {
                    kimdenAd = (kimdenAd != "") ? kimdenAd : "Company 1 Name";
                }
                else
                {
                    kimdenAd = (kimdenAd != "") ? kimdenAd : "Company 2 Name";
                }
                email = EpostaMailMessage(kime, kimden, kimdenAd, konu, icerik, isBodyHtml, dosya, CC);
                if (firmaAdi == "" || firmaAdi == "Buraya Firmanın Kodu Gelecek Ona gore Mail Gidecek")
                {
                    MailCompany1Smtp(email);
                }
                else
                {
                    MailCompany2Smtp(email);
                }
            }
            catch (Exception ex)
            { throw ex; }
        }

        // Common for two company
        private static MailMessage EpostaMailMessage(string[] kime, string kimden, string kimdenAd, string konu, string icerik, bool isBodyHtml, Attachment dosya, params string[] CC)
        {
            try
            {
                MailMessage eposta = new MailMessage();
            
                eposta.From = new MailAddress(kimden, kimdenAd);

                foreach (string item in kime)
                {
                    eposta.To.Add(item);
                }

                foreach (string item in CC)
                {
                    eposta.CC.Add(item);
                }

                if (dosya != null)
                {
                    eposta.Attachments.Add(dosya);
                }

                eposta.IsBodyHtml = isBodyHtml;
                eposta.Subject = konu;
                eposta.Body = icerik;
                eposta.Priority = MailPriority.High;

                return eposta;
            }
            catch (Exception ex)
            { throw ex; }
        }

        private static void MailCompany1Smtp(MailMessage eposta)
        {
            try
            {
                SmtpClient smtp = new SmtpClient("firmanın smtp post adresi", 587);

                smtp.UseDefaultCredentials = true;
                smtp.Credentials = new System.Net.NetworkCredential("firmaMail", "firmaMailPassword");
                smtp.EnableSsl = true;
                smtp.Send(eposta);
            }
            catch (Exception ex)
            {
                Log.Logla("Mail Gönderimi " + ex.ToString());
                throw ex;
            }
        }
        private static void MailCompany2Smtp(MailMessage eposta)
        {
            try
            {
                SmtpClient smtp = new SmtpClient("firmanın smtp post adresi", 587);

                smtp.UseDefaultCredentials = true;
                smtp.Credentials = new System.Net.NetworkCredential("firmaMail", "firmaMailPassword");
                smtp.EnableSsl = true;
                smtp.Send(eposta);
            }
            catch (Exception ex)
            {
                Log.Logla("Mail Gönderimi " + ex.ToString());
                throw ex;
            }
        }
    }
}
