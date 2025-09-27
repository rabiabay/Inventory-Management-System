using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Microsoft.EntityFrameworkCore;
using StokYonetimSistemi.Data;
using StokYonetimSistemi.Helpers;
using StokYonetimSistemi.Models;

namespace StokYonetimSistemi.Views
{
    public partial class SiparisTalepView : UserControl
    {
        private readonly StokYonetimContext _context;

        public SiparisTalepView()
        {
            InitializeComponent();
            _context = new StokYonetimContext(VeritabaniBaglantisi.BaglantiGetir());
            SiparisleriYukle();
        }

        private void SiparisleriYukle()
        {
            var siparisDetaylari = _context.SiparisDetaylari
                .Include(sd => sd.Siparis)
                .Include(sd => sd.Urun)
                .Where(sd => sd.Siparis.Durum == "Hazırlanıyor")
                .ToList();

            dgSiparisler.ItemsSource = siparisDetaylari;
        }

        private void BtnSiparisiGonder_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            var siparisDetay = button?.Tag as SiparisDetay;

            if (siparisDetay == null)
            {
                MessageBox.Show("Sipariş bilgisi alınamadı.");
                return;
            }

            int urunId = siparisDetay.UrunID;
            int miktar = siparisDetay.Miktar;

            
            var depoStok = _context.Stok
                .FirstOrDefault(s => s.UrunID == urunId && s.DepoID == 1);

            if (depoStok == null || depoStok.Miktar < miktar)
            {
                MessageBox.Show("Depoda yeterli stok yok.");
                return;
            }

            depoStok.Miktar -= miktar; 

            
            var satisStok = _context.Stok
                .FirstOrDefault(s => s.UrunID == urunId && s.DepoID == 2);

            if (satisStok != null)
            {
                satisStok.Miktar += miktar;
            }
            else
            {
                _context.Stok.Add(new Stok
                {
                    UrunID = urunId,
                    DepoID = 2,
                    Miktar = miktar
                });
            }

            
            var siparis = _context.Siparisler
                .FirstOrDefault(s => s.SiparisID == siparisDetay.SiparisID);

            if (siparis != null)
            {
                siparis.Durum = "Gönderildi";
            }

            _context.SaveChanges();

           
            var fatura = new Fatura
            {
                SiparisID = siparis.SiparisID,
                Tarih = DateTime.Now,
                ToplamTutar = 100,
                KullaniciID = AktifKullanici.KullaniciID
            };
            _context.Faturalar.Add(fatura);
            _context.SaveChanges();

            _context.FaturaDetaylar.Add(new FaturaDetay
            {
                FaturaID = fatura.FaturaID,
                UrunID = urunId,
                Miktar = miktar
            });
            _context.SaveChanges();

            
            LogService.LogEkle("Siparis", "SiparisGonderildi", AktifKullanici.KullaniciID);

            MessageBox.Show("Sipariş başarıyla gönderildi.");
            SiparisleriYukle();
        }


    }
}
