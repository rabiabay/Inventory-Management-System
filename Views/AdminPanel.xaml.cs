using System.Windows;
using System.Windows.Controls;
using StokYonetimSistemi.Views;

namespace StokYonetimSistemi.Views
{
    public partial class AdminPanel : Window
    {
        public AdminPanel()
        {
            InitializeComponent();

            // Açılışta Sistem Özeti yüklensin
            AnaPanelIcerik.Content = new SistemOzetiView();
        }

        private void BtnKullanicilar_Click(object sender, RoutedEventArgs e)
        {
            AnaPanelIcerik.Content = new KullaniciSayfasi();
        }

        private void BtnSistemOzeti_Click(object sender, RoutedEventArgs e)
        {
            AnaPanelIcerik.Content = new SistemOzetiView(); // ✅ Gerçek sistem özeti yükleniyor
        }

        private void BtnLogKayitlari_Click(object sender, RoutedEventArgs e)
        {
            AnaPanelIcerik.Content = new LogKayitlariView();
        }


        private void BtnCikis_Click(object sender, RoutedEventArgs e)
        {
            // Giriş ekranını aç
            var girisEkrani = new LoginWindow();
            girisEkrani.Show();

            // Admin paneli kapat
            this.Close();
        }

    }
}
