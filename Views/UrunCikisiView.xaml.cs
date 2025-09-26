using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using StokYonetimSistemi.Data;
using StokYonetimSistemi.Models;
using StokYonetimSistemi.Helpers;

namespace StokYonetimSistemi.Views
{
    public partial class UrunCikisiView : UserControl
    {
        private readonly StokYonetimContext _context;

        public UrunCikisiView()
        {
            InitializeComponent();
            _context = new StokYonetimContext(VeritabaniBaglantisi.BaglantiGetir());
            UrunleriYukle();
        }

        private void UrunleriYukle()
        {
            cbUrun.ItemsSource = _context.Urun.ToList();
            cbUrun.DisplayMemberPath = "UrunAdi";
            cbUrun.SelectedValuePath = "UrunID";
        }

        private void BtnUrunCikisi_Click(object sender, RoutedEventArgs e)
        {
            if (cbUrun.SelectedValue == null || string.IsNullOrWhiteSpace(txtMiktar.Text))
            {
                MessageBox.Show("Lütfen ürün ve miktar giriniz.");
                return;
            }

            if (!int.TryParse(txtMiktar.Text, out int miktar) || miktar <= 0)
            {
                MessageBox.Show("Geçerli bir miktar girin.");
                return;
            }

            int urunID = (int)cbUrun.SelectedValue;

            var stok = _context.Stok.FirstOrDefault(s => s.UrunID == urunID);

            if (stok == null || stok.Miktar < miktar)
            {
                MessageBox.Show("Yetersiz stok. Mevcut miktar: " + (stok?.Miktar ?? 0));
                return;
            }

            stok.Miktar -= miktar;

            var hareket = new StokHareketi
            {
                UrunID = urunID,
                DepoID = 1, // Giriş yapan kullanıcının deposu ileride dinamik olabilir
                HareketTipi = "Cikis",
                Miktar = miktar,
                Tarih = DateTime.Now,
                Aciklama = txtAciklama.Text,
                KullaniciID = 1 // Giriş yapan kullanıcıdan alınabilir
            };
            _context.StokHareketi.Add(hareket);
            _context.SaveChanges();

            MessageBox.Show("Ürün çıkışı başarıyla yapıldı!");
            txtMiktar.Clear();
            txtAciklama.Clear();
            cbUrun.SelectedIndex = -1;
        }
    }
}
