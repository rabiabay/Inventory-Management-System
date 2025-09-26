using System.Linq;
using System.Windows.Controls;
using StokYonetimSistemi.Data;
using StokYonetimSistemi.Helpers;
using StokYonetimSistemi.Models;

namespace StokYonetimSistemi.Views
{
    public partial class FaturaGecmisiView : UserControl
    {
        private readonly StokYonetimContext _context;

        public FaturaGecmisiView()
        {
            InitializeComponent();
            _context = new StokYonetimContext(VeritabaniBaglantisi.BaglantiGetir());
            FaturalariYukle();
        }

        private void FaturalariYukle()
        {
            
            int gecerliSiparisID = _context.Siparisler
                .Select(s => s.SiparisID)
                .FirstOrDefault();

            if (gecerliSiparisID != 0)
            {
                _context.Faturalar.Add(new Fatura
                {
                    SiparisID = gecerliSiparisID,
                    Tarih = DateTime.Now,
                    ToplamTutar = 123,
                    KullaniciID = 1
                });

                _context.SaveChanges();
            }

            var faturalar = _context.Faturalar
                .OrderByDescending(f => f.Tarih)
                .ToList();

            dgFaturalar.ItemsSource = faturalar;
        }
    }
}
