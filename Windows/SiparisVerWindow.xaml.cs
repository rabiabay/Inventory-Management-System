using System.Windows;
using System.Windows.Controls;
using System.Linq;
using StokYonetimSistemi.Data;
using StokYonetimSistemi.Models;
using StokYonetimSistemi.Helpers;

namespace StokYonetimSistemi.Views
{
    public partial class SiparisVerView : UserControl
    {
        private readonly StokYonetimContext _context;

        public SiparisVerView()
        {
            InitializeComponent();
            _context = new StokYonetimContext(VeritabaniBaglantisi.BaglantiGetir());

            YukleUrunler();
            YukleTedarikciler();
        }

        private void YukleUrunler()
        {
            cbUrunler.ItemsSource = _context.Urun.ToList();
            cbUrunler.DisplayMemberPath = "UrunAdi";
            cbUrunler.SelectedValuePath = "UrunID";
        }

        private void YukleTedarikciler()
        {
            cbTedarikciler.ItemsSource = _context.Tedarikciler.ToList();
            cbTedarikciler.DisplayMemberPath = "FirmaAdi";
            cbTedarikciler.SelectedValuePath = "TedarikciID";
        }

        private void BtnSiparisVer_Click(object sender, RoutedEventArgs e)
        {
            if (cbUrunler.SelectedValue == null || cbTedarikciler.SelectedValue == null || string.IsNullOrWhiteSpace(txtMiktar.Text))
            {
                MessageBox.Show("Lütfen tüm alanları doldurun.");
                return;
            }

            if (!int.TryParse(txtMiktar.Text, out int miktar) || miktar <= 0)
            {
                MessageBox.Show("Geçerli bir miktar girin.");
                return;
            }

            int urunID = (int)cbUrunler.SelectedValue;
            int tedarikciID = (int)cbTedarikciler.SelectedValue;

            var siparis = new Siparis
            {
                TedarikciID = tedarikciID,
                Tarih = DateTime.Now,
                Durum = "Hazırlanıyor",
               

            };
            _context.Siparisler.Add(siparis);
            _context.SaveChanges();

            var detay = new SiparisDetay
            {
                SiparisID = siparis.SiparisID,
                UrunID = urunID,
                Miktar = miktar
            };
            _context.SiparisDetaylari.Add(detay);
            _context.SaveChanges();

            MessageBox.Show("Sipariş başarıyla oluşturuldu.");
            txtMiktar.Clear();
            cbUrunler.SelectedIndex = -1;
            cbTedarikciler.SelectedIndex = -1;
        }
    }
}
