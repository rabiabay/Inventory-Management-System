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

            
            AnaPanelIcerik.Content = new SistemOzetiView();
        }

        private void BtnKullanicilar_Click(object sender, RoutedEventArgs e)
        {
            AnaPanelIcerik.Content = new KullaniciSayfasi();
        }

        private void BtnSistemOzeti_Click(object sender, RoutedEventArgs e)
        {
            AnaPanelIcerik.Content = new SistemOzetiView(); 
        }

        private void BtnLogKayitlari_Click(object sender, RoutedEventArgs e)
        {
            AnaPanelIcerik.Content = new LogKayitlariView();
        }


        private void BtnCikis_Click(object sender, RoutedEventArgs e)
        {
            
            var girisEkrani = new LoginWindow();
            girisEkrani.Show();

            
            this.Close();
        }

    }
}
