using System.Linq;
using System.Windows.Controls;
using Microsoft.EntityFrameworkCore;
using StokYonetimSistemi.Data;
using StokYonetimSistemi.Helpers;
using StokYonetimSistemi.Models; // KritikUrun modelini kullanacağız

namespace StokYonetimSistemi.Views
{
    public partial class KritikUrunlerView : UserControl
    {
        public KritikUrunlerView()
        {
            InitializeComponent();
            KritikUrunleriYukle();
        }

        private void KritikUrunleriYukle()
        {
            using var context = new StokYonetimContext(VeritabaniBaglantisi.BaglantiGetir());

            // Kritik ürünleri view'den çekiyoruz
            var liste = context
                .Set<KritikUrun>() // <--- Burada artık modelimizi kullanıyoruz
                .FromSqlRaw("SELECT * FROM vw_KritikStoklar")
                .ToList();

            dgKritikUrunler.ItemsSource = liste;
        }
    }
}
