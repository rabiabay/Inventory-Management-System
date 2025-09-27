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
           
            txtUrunSayisi.Text = _context.Urun.Count().ToString();

           
            

            txtSiparisMiktari.Text = _context.SiparisDetaylari.Sum(sd => sd.Miktar).ToString();

            
            txtKullaniciSayisi.Text = _context.Kullanici.Count().ToString();
        }
    }
}
