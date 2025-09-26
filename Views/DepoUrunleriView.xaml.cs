using System.Linq;
using System.Windows.Controls;
using StokYonetimSistemi.Data;
using StokYonetimSistemi.Helpers;
using StokYonetimSistemi.Models;


namespace StokYonetimSistemi.Views
{
    public partial class DepoUrunleriView : UserControl
    {
        private int depoId = 1; 

        public DepoUrunleriView()
        {
            InitializeComponent();
            UrunleriYukle();
        }

        private void UrunleriYukle()
        {
            using var context = new StokYonetimContext(VeritabaniBaglantisi.BaglantiGetir());

            var liste = (from s in context.Stok
                         join u in context.Urun on s.UrunID equals u.UrunID
                         join k in context.Kategori on u.KategoriID equals k.KategoriID
                         where s.DepoID == depoId
                         select new
                         {
                             u.UrunAdi,
                             KategoriAdi = k.KategoriAdi,
                             s.Miktar,
                             u.KritikStok
                         }).ToList();

            dgDepoUrunleri.ItemsSource = liste;
        }

    }
}
