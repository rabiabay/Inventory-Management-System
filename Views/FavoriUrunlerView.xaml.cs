using System.Linq;
using System.Windows;
using System.Windows.Controls;
using StokYonetimSistemi.Data;
using StokYonetimSistemi.Helpers;
using StokYonetimSistemi.Models;

namespace StokYonetimSistemi.Views
{
    public partial class FavoriUrunlerView : UserControl
    {
        private readonly StokYonetimContext _context;

        public FavoriUrunlerView()
        {
            InitializeComponent();
            _context = new StokYonetimContext(VeritabaniBaglantisi.BaglantiGetir());

            int aktifKullaniciID = 3; // Giriş yapan kullanıcı ID'si
            EnCokSatilaniFavoriyeEkle(aktifKullaniciID);
            YukleFavoriler(aktifKullaniciID);
        }

        private void EnCokSatilaniFavoriyeEkle(int kullaniciId)
        {
            var enCokSatilanUrunID = _context.SiparisDetaylari
                .GroupBy(sd => sd.UrunID)
                .OrderByDescending(g => g.Count())
                .Select(g => g.Key)
                .FirstOrDefault();

            if (enCokSatilanUrunID == 0)
                return;

            bool zatenFavori = _context.FavoriUrunler
                .Any(f => f.KullaniciID == kullaniciId && f.UrunID == enCokSatilanUrunID);

            if (!zatenFavori)
            {
                _context.FavoriUrunler.Add(new FavoriUrun
                {
                    KullaniciID = kullaniciId,
                    UrunID = enCokSatilanUrunID
                });
                _context.SaveChanges();
            }
        }

        private void YukleFavoriler(int kullaniciId)
        {
            var favoriler = (from f in _context.FavoriUrunler
                             join u in _context.Urun on f.UrunID equals u.UrunID
                             where f.KullaniciID == kullaniciId
                             select new FavoriUrunViewModel
                             {
                                 UrunID = u.UrunID,
                                 UrunAdi = u.UrunAdi,
                                 Barkod = u.Barkod,
                                 Aciklama = u.Aciklama,
                                 Birim = u.Birim
                             }).ToList();

            dgFavoriler.ItemsSource = favoriler;
        }

        private void BtnSiparisEt_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            var urun = button?.Tag as FavoriUrunViewModel;

            if (urun == null)
            {
                MessageBox.Show("Ürün alınamadı.");
                return;
            }

            var siparis = new Siparis
            {
                TedarikciID = 1,
                Tarih = DateTime.Now,
                Durum = "Hazırlanıyor"
            };
            _context.Siparisler.Add(siparis);
            _context.SaveChanges();

            var siparisDetay = new SiparisDetay
            {
                SiparisID = siparis.SiparisID,
                UrunID = urun.UrunID,
                Miktar = 1
            };
            _context.SiparisDetaylari.Add(siparisDetay);
            _context.SaveChanges();

            MessageBox.Show($"'{urun.UrunAdi}' için sipariş oluşturuldu.");
        }
    }

    public class FavoriUrunViewModel
    {
        public int UrunID { get; set; }
        public string UrunAdi { get; set; }
        public string Barkod { get; set; }
        public string Aciklama { get; set; }
        public string Birim { get; set; }
    }
}
