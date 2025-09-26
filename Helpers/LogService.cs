using StokYonetimSistemi.Data;
using StokYonetimSistemi.Models;
using System;
using System.Windows;

namespace StokYonetimSistemi.Helpers
{
    public static class LogService
    {
        public static void LogEkle(string tabloAdi, string islemTuru, int? kullaniciId)
        {
            try
            {
                

                using var context = new StokYonetimContext(VeritabaniBaglantisi.BaglantiGetir());

                var log = new Log
                {
                    TabloAdi = tabloAdi,
                    IslemTuru = islemTuru,
                    KullaniciID = kullaniciId,
                    Zaman = DateTime.Now
                };

                context.Loglar.Add(log);
                context.SaveChanges();

              
            }
            catch (Exception ex)
            {
                string hataMesaji = "❌ Log eklenirken hata oluştu:\n\n" + ex.Message;

                if (ex.InnerException != null)
                {
                    hataMesaji += "\n\n➡ İç Hata: " + ex.InnerException.Message;
                }

                MessageBox.Show(hataMesaji);
            }
        }
    }
}
