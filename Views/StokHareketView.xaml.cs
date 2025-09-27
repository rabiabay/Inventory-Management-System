using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using StokYonetimSistemi.Data;
using StokYonetimSistemi.Models;
using StokYonetimSistemi.Helpers;

namespace StokYonetimSistemi.Views
{
    public partial class StokHareketView : UserControl
    {
        private int depoId = 1; 

        public StokHareketView()
        {
            InitializeComponent();
            UrunleriYukle();
            HareketleriListele();
        }

        private void UrunleriYukle()
        {
            using var context = new StokYonetimContext(VeritabaniBaglantisi.BaglantiGetir());

            var urunler = context.Urun
                .Where(u => u.Aktif)
                .Select(u => new { u.UrunID, u.UrunAdi })
                .ToList();

            cmbUrunler.ItemsSource = urunler;
            cmbUrunler.DisplayMemberPath = "UrunAdi";
            cmbUrunler.SelectedValuePath = "UrunID";
        }

        private void BtnKaydet_Click(object sender, RoutedEventArgs e)
        {
            if (cmbUrunler.SelectedValue == null || cmbIslemTuru.SelectedItem == null || !int.TryParse(txtMiktar.Text, out int miktar))
            {
                MessageBox.Show("Lütfen tüm alanları doğru şekilde doldurun.");
                return;
            }

            int urunId = (int)cmbUrunler.SelectedValue;
            string islemTuru = ((ComboBoxItem)cmbIslemTuru.SelectedItem).Content.ToString();
            string aciklama = txtAciklama.Text.Trim();

            using var context = new StokYonetimContext(VeritabaniBaglantisi.BaglantiGetir());

            
            var hareket = new StokHareketi
            {
                UrunID = urunId,
                DepoID = depoId,
                HareketTipi = islemTuru,
                Miktar = miktar,
                Tarih = DateTime.Now,
                Aciklama = aciklama,
                KullaniciID = 1 
            };
            context.StokHareketi.Add(hareket);

            
            var stok = context.Stok.FirstOrDefault(s => s.UrunID == urunId && s.DepoID == depoId);
            if (stok == null)
            {
                stok = new Stok { UrunID = urunId, DepoID = depoId, Miktar = 0 };
                context.Stok.Add(stok);
            }

            if (islemTuru == "Giriş")
                stok.Miktar += miktar;
            else if (islemTuru == "Çıkış")
            {
                if (stok.Miktar < miktar)
                {
                    MessageBox.Show("Yetersiz stok!");
                    return;
                }
                stok.Miktar -= miktar;
            }

            context.SaveChanges();
            MessageBox.Show("İşlem başarıyla kaydedildi.");
            HareketleriListele();
        }

        private void HareketleriListele()
        {
            using var context = new StokYonetimContext(VeritabaniBaglantisi.BaglantiGetir());

            var hareketler = (from h in context.StokHareketi
                              join u in context.Urun on h.UrunID equals u.UrunID
                              where h.DepoID == depoId
                              orderby h.Tarih descending
                              select new
                              {
                                  u.UrunAdi,
                                  h.HareketTipi,
                                  h.Miktar,
                                  h.Tarih,
                                  h.Aciklama
                              }).ToList();

            dgHareketler.ItemsSource = hareketler;
        }
    }
}
