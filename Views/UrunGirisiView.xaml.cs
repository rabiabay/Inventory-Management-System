using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using StokYonetimSistemi.Data;
using StokYonetimSistemi.Models;
using StokYonetimSistemi.Helpers;

namespace StokYonetimSistemi.Views
{
    public partial class UrunGirisiView : UserControl
    {
        private readonly StokYonetimContext _context;

        public UrunGirisiView()
        {
            InitializeComponent();
            _context = new StokYonetimContext(VeritabaniBaglantisi.BaglantiGetir());
            KategorileriYukle();
        }

        private void KategorileriYukle()
        {
            cbKategori.ItemsSource = _context.Kategori.ToList();
            cbKategori.DisplayMemberPath = "KategoriAdi";
            cbKategori.SelectedValuePath = "KategoriID";
        }

        private void BtnUrunKaydet_Click(object sender, RoutedEventArgs e)
        {
            string urunAdi = txtUrunAdi.Text.Trim();
            string barkod = txtBarkod.Text.Trim();
            string urunAciklama = txtUrunAciklama.Text.Trim();
            string kritikStokStr = txtKritikStok.Text.Trim();
            string miktarStr = txtMiktar.Text.Trim();

            if (string.IsNullOrWhiteSpace(urunAdi) || cbKategori.SelectedValue == null ||
                !int.TryParse(kritikStokStr, out int kritikStok) ||
                !int.TryParse(miktarStr, out int miktar) || miktar <= 0)
            {
                MessageBox.Show("Lütfen tüm zorunlu alanları doğru şekilde doldurun.");
                return;
            }

            var urun = new Urun
            {
                UrunAdi = urunAdi,
                Barkod = string.IsNullOrWhiteSpace(barkod) ? Guid.NewGuid().ToString().Substring(0, 8) : barkod,
                Aciklama = urunAciklama,
                Birim = "Adet",
                KritikStok = kritikStok,
                KategoriID = (int)cbKategori.SelectedValue,
                Aktif = true
            };
            _context.Urun.Add(urun);
            _context.SaveChanges();

            var stok = _context.Stok.FirstOrDefault(s => s.UrunID == urun.UrunID && s.DepoID == 1);
            if (stok != null)
            {
                stok.Miktar += miktar;
            }
            else
            {
                stok = new Stok
                {
                    UrunID = urun.UrunID,
                    DepoID = 1,
                    Miktar = miktar
                };
                _context.Stok.Add(stok);
            }

            var hareket = new StokHareketi
            {
                UrunID = urun.UrunID,
                DepoID = 1,
                HareketTipi = "Giris",
                Miktar = miktar,
                Tarih = DateTime.Now,
                Aciklama = "", // Açıklama kısmı kaldırıldı
                KullaniciID = 1
            };
            _context.StokHareketi.Add(hareket);
            _context.SaveChanges();

            MessageBox.Show("Ürün başarıyla kaydedildi ve stoğa girildi.");

            txtUrunAdi.Clear();
            txtBarkod.Clear();
            txtUrunAciklama.Clear();
            txtKritikStok.Clear();
            txtMiktar.Clear();
            cbKategori.SelectedIndex = -1;
        }
    }
}