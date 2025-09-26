using System.Linq;
using System.Windows.Controls;
using StokYonetimSistemi.Data;
using Microsoft.EntityFrameworkCore;
using StokYonetimSistemi.Helpers;

namespace StokYonetimSistemi.Views
{
    public partial class SistemOzetiView : UserControl
    {
        private readonly StokYonetimContext _context;

        public SistemOzetiView()
        {
            InitializeComponent();
            _context = new StokYonetimContext(VeritabaniBaglantisi.BaglantiGetir());
        }

        private void UserControl_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            // 1. Toplam Ürün Sayısı
            txtUrunSayisi.Text = _context.Urun.Count().ToString();

            // 2. Kritik Stoklu Ürün Sayısı
            

            // 3. Toplam Sipariş Miktarı (Miktar olarak düzeltildi)
            txtSiparisMiktari.Text = _context.SiparisDetaylari.Sum(sd => sd.Miktar).ToString();

            // 4. Kullanıcı Sayısı
            txtKullaniciSayisi.Text = _context.Kullanici.Count().ToString();
        }
    }
}
