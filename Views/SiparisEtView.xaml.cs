using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using StokYonetimSistemi.Data;
using StokYonetimSistemi.Helpers;
using StokYonetimSistemi.Models;

namespace StokYonetimSistemi.Views
{
    public partial class SiparisEtView : UserControl
    {
        private readonly StokYonetimContext _context;

        public SiparisEtView()
        {
            InitializeComponent();
            _context = new StokYonetimContext(VeritabaniBaglantisi.BaglantiGetir());
            UrunleriYukle();
        }

        private void UrunleriYukle()
        {
            var urunler = _context.Urun.ToList();
            cbUrunler.ItemsSource = urunler;
            cbUrunler.DisplayMemberPath = "UrunAdi";
            cbUrunler.SelectedValuePath = "UrunID";
        }

        private void BtnSiparisVer_Click(object sender, RoutedEventArgs e)
        {
            if (cbUrunler.SelectedValue == null || string.IsNullOrWhiteSpace(txtMiktar.Text))
            {
                MessageBox.Show("Lütfen ürün ve miktar giriniz.");
                return;
            }

            if (!int.TryParse(txtMiktar.Text, out int miktar) || miktar <= 0)
            {
                MessageBox.Show("Geçerli bir miktar giriniz.");
                return;
            }

            int urunID = (int)cbUrunler.SelectedValue;

            int tedarikciID = _context.Tedarikciler.Select(t => t.TedarikciID).FirstOrDefault();
            if (tedarikciID == 0)
            {
                MessageBox.Show("Sistemde tedarikçi bulunamadı. Lütfen tedarikçi ekleyin.");
                return;
            }

            var siparis = new Siparis
            {
                TedarikciID = tedarikciID,
                Tarih = DateTime.Now,
                Durum = "Hazırlanıyor",
                KullaniciID = AktifKullanici.KullaniciID // ✅ aktif kullanıcıdan al
            };

            try
            {
                _context.Siparisler.Add(siparis);
                _context.SaveChanges();

                var detay = new SiparisDetay
                {
                    SiparisID = siparis.SiparisID,
                    UrunID = urunID,
                    Miktar = miktar
                };

                _context.SiparisDetaylari.Add(detay);
                _context.SaveChanges();

                // ✅ LOG EKLE
                LogService.LogEkle("Siparis", "Ekleme", AktifKullanici.KullaniciID);

                MessageBox.Show("Sipariş başarıyla oluşturuldu.");
                txtMiktar.Clear();
                cbUrunler.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Sipariş oluşturulurken hata oluştu: " + ex.Message);
            }
        }
    }
}
