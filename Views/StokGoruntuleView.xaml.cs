using System.Linq;
using System.Windows.Controls;
using StokYonetimSistemi.Data;
using StokYonetimSistemi.Helpers;

namespace StokYonetimSistemi.Views
{
    public partial class StokGoruntuleView : UserControl
    {
        public StokGoruntuleView()
        {
            InitializeComponent();
            StoklariYukle();
        }

        private void StoklariYukle()
        {
            using var context = new StokYonetimContext(VeritabaniBaglantisi.BaglantiGetir());

            var liste = (from s in context.Stok
                         join u in context.Urun on s.UrunID equals u.UrunID
                         join k in context.Kategori on u.KategoriID equals k.KategoriID
                         join d in context.Depo on s.DepoID equals d.DepoID
                         select new
                         {
                             u.UrunAdi,
                             KategoriAdi = k.KategoriAdi,
                             DepoAdi = d.DepoAdi,
                             s.Miktar
                         }).ToList();

            dgStoklar.ItemsSource = liste;
        }
    }
}
