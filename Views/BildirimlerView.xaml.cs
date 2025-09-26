using System.Linq;
using System.Windows.Controls;
using StokYonetimSistemi.Data;
using StokYonetimSistemi.Helpers;
using StokYonetimSistemi.Models;

namespace StokYonetimSistemi.Views
{
    public partial class BildirimlerView : UserControl
    {
        private readonly StokYonetimContext _context;

        public BildirimlerView()
        {
            InitializeComponent();
            _context = new StokYonetimContext(VeritabaniBaglantisi.BaglantiGetir());
            BildirimleriYukle();
        }

        private void BildirimleriYukle()
        {
            int aktifKullaniciID = 3; // örnek: giriş yapan kullanıcı
            var bildirimler = _context.Bildirimler
                .Where(b => b.KullaniciID == aktifKullaniciID)
                .OrderByDescending(b => b.Tarih)
                .Select(b => new BildirimViewModel
                {
                    BildirimID = b.BildirimID,
                    Mesaj = b.Mesaj,
                    Tarih = b.Tarih,
                    OkunduMu = b.OkunduMu
                }).ToList();

            dgBildirimler.ItemsSource = bildirimler;
        }
    }
    public class BildirimViewModel
    {
        public int BildirimID { get; set; }
        public string Mesaj { get; set; }
        public DateTime Tarih { get; set; }
        public bool OkunduMu { get; set; }
    }

}
