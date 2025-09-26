using System.Linq;
using System.Windows.Controls;
using Microsoft.EntityFrameworkCore;
using StokYonetimSistemi.Data;
using StokYonetimSistemi.Helpers;

namespace StokYonetimSistemi.Views
{
    public partial class SatisStokGoruntuleView : UserControl
    {
        private readonly StokYonetimContext _context;

        public SatisStokGoruntuleView()
        {
            InitializeComponent();
            _context = new StokYonetimContext(VeritabaniBaglantisi.BaglantiGetir());
            SatisStoklariYukle();
        }

        private void SatisStoklariYukle()
        {
            var satisStoklari = _context.Stok
                .Include(s => s.Urun)
                .Where(s => s.DepoID == 2) // 2 = Satış Paneli DepoID'si
                .ToList();

            dgSatisStoklar.ItemsSource = satisStoklari;
        }
    }
}
