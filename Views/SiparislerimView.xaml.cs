using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Microsoft.EntityFrameworkCore;
using StokYonetimSistemi.Data;
using StokYonetimSistemi.Helpers;
using StokYonetimSistemi.Models;

namespace StokYonetimSistemi.Views
{
    public partial class SiparislerimView : UserControl
    {
        private readonly StokYonetimContext _context;

        public SiparislerimView()
        {
            InitializeComponent();
            _context = new StokYonetimContext(VeritabaniBaglantisi.BaglantiGetir());
            SiparisleriYenile();
        }

        public void SiparisleriYenile()
        {
            var siparisler = _context.Siparisler
                .Include(s => s.SiparisDetaylari)
                .ToList();

            dgSiparisler.ItemsSource = siparisler;
        }

        private void BtnIptalEt_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            var siparis = button?.Tag as Siparis;

            if (siparis == null)
                return;

            if (siparis.Durum == "İptal Edildi")
            {
                MessageBox.Show("Bu sipariş zaten iptal edilmiş.", "Uyarı", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }

            
            siparis.Durum = "İptal Edildi";
            _context.SaveChanges();
            SiparisleriYenile(); 
        }
    }
}
