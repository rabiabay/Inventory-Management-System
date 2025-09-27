using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Collections.ObjectModel;
using StokYonetimSistemi.Data;
using StokYonetimSistemi.Models;
using StokYonetimSistemi.Helpers;

namespace StokYonetimSistemi.Views
{
    public partial class SatisView : UserControl
    {
        private readonly StokYonetimContext _context;
        private ObservableCollection<StokHareketViewModel> stokHareketleri;

        public SatisView()
        {
            InitializeComponent();
            _context = new StokYonetimContext(VeritabaniBaglantisi.BaglantiGetir());
            stokHareketleri = new ObservableCollection<StokHareketViewModel>();
            dgStokHareketleri.ItemsSource = stokHareketleri;
            UrunleriYukle();
            StokHareketleriniYukle();
        }

        private void UrunleriYukle()
        {
            cbUrunler.ItemsSource = _context.Urun.ToList();
            cbUrunler.DisplayMemberPath = "UrunAdi";
            cbUrunler.SelectedValuePath = "UrunID";
        }

        private void StokHareketleriniYukle()
        {
            var hareketler = _context.StokHareketi
                .Where(h => h.HareketTipi == "Cikis" && h.KullaniciID == 3) 
                .Select(h => new StokHareketViewModel
                {
                    UrunAdi = h.Urun.UrunAdi,
                    HareketTipi = h.HareketTipi,
                    Miktar = h.Miktar,
                    Tarih = h.Tarih,
                    Aciklama = h.Aciklama
                }).ToList();

            stokHareketleri.Clear();
            foreach (var h in hareketler)
                stokHareketleri.Add(h);
        }

        private void BtnSatisOnayla_Click(object sender, RoutedEventArgs e)
        {
            if (cbUrunler.SelectedValue == null)
            {
                MessageBox.Show("Lütfen ürün seçiniz.");
                return;
            }

            if (!int.TryParse(txtMiktar.Text, out int miktar) || miktar <= 0)
            {
                MessageBox.Show("Geçerli bir miktar giriniz.");
                return;
            }

            int urunID = (int)cbUrunler.SelectedValue;

            var stok = _context.Stok.FirstOrDefault(s => s.UrunID == urunID && s.DepoID == 1);
            if (stok == null || stok.Miktar < miktar)
            {
                MessageBox.Show("Yetersiz stok. Mevcut miktar: " + (stok?.Miktar ?? 0));
                return;
            }

            stok.Miktar -= miktar;

            var satis = new Satis
            {
                UrunID = urunID,
                Miktar = miktar,
                Tarih = DateTime.Now,
                KullaniciID = 3,
                DepoID = 1
            };
            _context.Satis.Add(satis);

            var hareket = new StokHareketi
            {
                UrunID = urunID,
                DepoID = 1,
                HareketTipi = "Cikis",
                Miktar = miktar,
                Tarih = DateTime.Now,
                Aciklama = txtAciklama.Text,
                KullaniciID = 3
            };
            _context.StokHareketi.Add(hareket);

            _context.SaveChanges();

            MessageBox.Show("Satış başarıyla gerçekleştirildi.");

            cbUrunler.SelectedIndex = -1;
            txtMiktar.Clear();
            txtAciklama.Clear();

            StokHareketleriniYukle(); 
        }
    }

    public class StokHareketViewModel
    {
        public string UrunAdi { get; set; }
        public string HareketTipi { get; set; }
        public int Miktar { get; set; }
        public DateTime Tarih { get; set; }
        public string Aciklama { get; set; }
    }
}
