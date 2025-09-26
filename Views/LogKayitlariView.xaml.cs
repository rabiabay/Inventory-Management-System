using System.Linq;
using System.Windows.Controls;
using Microsoft.EntityFrameworkCore;
using StokYonetimSistemi.Data;
using StokYonetimSistemi.Helpers;

namespace StokYonetimSistemi.Views
{
    public partial class LogKayitlariView : UserControl
    {
        private readonly StokYonetimContext _context;

        public LogKayitlariView()
        {
            InitializeComponent();
            _context = new StokYonetimContext(VeritabaniBaglantisi.BaglantiGetir());
        }

        private void UserControl_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            var liste = _context.Loglar
                .Include(l => l.Kullanici)
                .Select(l => new
                {
                    Kullanici = l.Kullanici != null ? l.Kullanici.KullaniciAdi : "Bilinmiyor",
                    Islem = l.IslemTuru,
                    Tarih = l.Zaman,
                    Tablo = l.TabloAdi
                })
                .OrderByDescending(l => l.Tarih)
                .ToList();

            dgLoglar.ItemsSource = liste;
        }
    }
}
