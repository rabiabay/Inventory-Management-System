using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Microsoft.EntityFrameworkCore;
using StokYonetimSistemi.Data;
using StokYonetimSistemi.Helpers;
using StokYonetimSistemi.Models;

namespace StokYonetimSistemi.Views
{
    public partial class KullaniciSayfasi : UserControl

    {
        private readonly StokYonetimContext _context;

        public KullaniciSayfasi()
        {
            InitializeComponent();
            _context = new StokYonetimContext(VeritabaniBaglantisi.BaglantiGetir());
            RollerYukle();
            KullanicilariListele();
        }

        private void RollerYukle()
        {
            cbRol.ItemsSource = _context.Roller.ToList();
        }

        private void KullanicilariListele()
        {
            dgKullanicilar.ItemsSource = _context.Kullanici.Include(k => k.Rol).ToList();
        }

        private void BtnEkle_Click(object sender, RoutedEventArgs e)
        {
            var kullanici = new Kullanici
            {
                Ad = txtAd.Text.Trim(),
                Soyad = txtSoyad.Text.Trim(),
                KullaniciAdi = txtKullaniciAdi.Text.Trim(),
                SifreHash = SifrelemeHelper.Sifrele(txtSifre.Password),
                RolID = cbRol.SelectedValue != null ? (int)cbRol.SelectedValue : 0,
                Aktif = true
            };

            if (kullanici.RolID == 0)
            {
                MessageBox.Show("Lütfen bir rol seçin!");
                return;
            }

            _context.Kullanici.Add(kullanici);
            _context.SaveChanges();
            MessageBox.Show("Kullanıcı eklendi.");
            KullanicilariListele();
        }

        private void BtnSil_Click(object sender, RoutedEventArgs e)
        {
            var secili = (Kullanici)dgKullanicilar.SelectedItem;
            if (secili == null)
            {
                MessageBox.Show("Lütfen silinecek kullanıcıyı seçin.");
                return;
            }

            _context.Kullanici.Remove(secili);
            _context.SaveChanges();
            MessageBox.Show("Kullanıcı silindi.");
            KullanicilariListele();
        }

        private void BtnGuncelle_Click(object sender, RoutedEventArgs e)
        {
            var secili = (Kullanici)dgKullanicilar.SelectedItem;
            if (secili == null)
            {
                MessageBox.Show("Lütfen güncellenecek kullanıcıyı seçin.");
                return;
            }

            secili.Ad = txtAd.Text.Trim();
            secili.Soyad = txtSoyad.Text.Trim();
            secili.KullaniciAdi = txtKullaniciAdi.Text.Trim();
            secili.SifreHash = SifrelemeHelper.Sifrele(txtSifre.Password);
            secili.RolID = cbRol.SelectedValue != null ? (int)cbRol.SelectedValue : secili.RolID;

            _context.SaveChanges();
            MessageBox.Show("Kullanıcı güncellendi.");
            KullanicilariListele();
        }

        private void dgKullanicilar_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var secili = (Kullanici)dgKullanicilar.SelectedItem;
            if (secili != null)
            {
                txtAd.Text = secili.Ad;
                txtSoyad.Text = secili.Soyad;
                txtKullaniciAdi.Text = secili.KullaniciAdi;
                cbRol.SelectedValue = secili.RolID;
            }
        }

        private void BtnGeri_Click(object sender, RoutedEventArgs e)
        {
           
        }

        private void TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            if (sender is TextBox txt && txt.Text is string value && value == txt.Name.Replace("txt", ""))
                txt.Clear();
        }
    }
}
