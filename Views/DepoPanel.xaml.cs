using System.Windows;
using System.Windows.Controls;
using StokYonetimSistemi.Views;

namespace StokYonetimSistemi.Views
{
    public partial class DepoPanel : UserControl
    {
        public DepoPanel()
        {
            InitializeComponent();
        }

        private void BtnStoklar_Click(object sender, RoutedEventArgs e)
        {
            DepoContent.Content = new StokGoruntuleView();
        }

        private void BtnHareket_Click(object sender, RoutedEventArgs e)
        {
            DepoContent.Content = new StokHareketView();
        }

        private void BtnDepoUrunleri_Click(object sender, RoutedEventArgs e)
        {
            DepoContent.Content = new DepoUrunleriView();
        }

        private void BtnKritik_Click(object sender, RoutedEventArgs e)
        {
            DepoContent.Content = new KritikUrunlerView();
        }

        private void BtnUrunGirisi_Click(object sender, RoutedEventArgs e)
        {
            DepoContent.Content = new UrunGirisiView();
        }

        private void BtnUrunCikisi_Click(object sender, RoutedEventArgs e)
        {
            DepoContent.Content = new UrunCikisiView();
        }

        private void BtnSiparisTalepleri_Click(object sender, RoutedEventArgs e)
        {
            DepoContent.Content = new SiparisTalepView();
        }

        private void BtnSiparisVer_Click(object sender, RoutedEventArgs e)
        {
            DepoContent.Content = new SiparisVerView();
        }

       
        private void BtnSiparisiGonder_Click(object sender, RoutedEventArgs e)
        {
            // Burada siparişi gönderme işlemi yapılacak
            // Örnek:
            MessageBox.Show("Sipariş gönderme işlemi bu methoda eklenecek.");
        }

        private void BtnRaporlar_Click(object sender, RoutedEventArgs e)
        {
            DepoContent.Content = new RaporlarView(); 
        }



        private void BtnCikis_Click(object sender, RoutedEventArgs e)
        {
            var loginWindow = new LoginWindow();
            loginWindow.Show();
            Window.GetWindow(this)?.Close();
        }
    }
}
