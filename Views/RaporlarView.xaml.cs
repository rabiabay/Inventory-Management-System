using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using StokYonetimSistemi.Data;
using Microsoft.EntityFrameworkCore;
using StokYonetimSistemi.Helpers;

namespace StokYonetimSistemi.Views
{
    public partial class RaporlarView : UserControl
    {
        private readonly StokYonetimContext _context;

        public RaporlarView()
        {
            InitializeComponent();
            _context = new StokYonetimContext(VeritabaniBaglantisi.BaglantiGetir());
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            
        }

        private void BtnKritik_Click(object sender, RoutedEventArgs e)
        {
            var liste = (
                from stok in _context.Stok
                join urun in _context.Urun on stok.UrunID equals urun.UrunID
                where stok.Miktar <= urun.KritikStok
                select new { urun.UrunAdi, stok.Miktar, urun.KritikStok }
            ).ToList();

            dgRapor.ItemsSource = liste;
        }

        private void BtnStokYok_Click(object sender, RoutedEventArgs e)
        {
            var liste = (
                from stok in _context.Stok
                join urun in _context.Urun on stok.UrunID equals urun.UrunID
                where stok.Miktar == 0
                select new { urun.UrunAdi, stok.Miktar }
            ).ToList();

            dgRapor.ItemsSource = liste;
        }

        private void BtnTopSiparis_Click(object sender, RoutedEventArgs e)
        {
            var liste = _context.SiparisDetaylari
                .GroupBy(sd => sd.Urun.UrunAdi)
                .Select(g => new { UrunAdi = g.Key, ToplamSiparis = g.Sum(x => x.Miktar) })
                .OrderByDescending(x => x.ToplamSiparis)
                .Take(5)
                .ToList();

            dgRapor.ItemsSource = liste;
        }

        private void BtnKategori_Click(object sender, RoutedEventArgs e)
        {
            var liste = _context.Urun
                .Include(u => u.Kategori)
                .GroupBy(u => u.Kategori.KategoriAdi)
                .Select(g => new { Kategori = g.Key, UrunSayisi = g.Count() })
                .ToList();

            dgRapor.ItemsSource = liste;
        }

        private void BtnTedarikci_Click(object sender, RoutedEventArgs e)
        {
            var liste = _context.Siparisler
                .Include(s => s.Tedarikci)
                .GroupBy(s => s.Tedarikci.FirmaAdi) 
                .Select(g => new { Tedarikci = g.Key, SiparisSayisi = g.Count() })
                .ToList();

            dgRapor.ItemsSource = liste;
        }

        private void BtnSonGiris_Click(object sender, RoutedEventArgs e)
        {
            DateTime son30gun = DateTime.Now.AddDays(-30);

            var liste = _context.StokHareketi
                .Include(sh => sh.Urun)
                .Where(sh => sh.Tarih >= son30gun) 
                .Select(sh => new { sh.Urun.UrunAdi, sh.Tarih, sh.Miktar })
                .ToList();

            dgRapor.ItemsSource = liste;
        }

        private void BtnSiparisYok_Click(object sender, RoutedEventArgs e)
        {
            var liste = _context.Urun
                .Where(u => !_context.SiparisDetaylari.Any(sd => sd.UrunID == u.UrunID))
                .Select(u => new { u.UrunAdi, u.KategoriID })
                .ToList();

            dgRapor.ItemsSource = liste;
        }
    }
}
