using System.Windows;
using System.Windows.Controls;

namespace StokYonetimSistemi.Views
{
    public partial class SatisPanel : UserControl
    {
        public SatisPanel()
        {
            InitializeComponent();
        }

        private void BtnUrunSatis_Click(object sender, RoutedEventArgs e)
        {
            
            SatisView satisView = new SatisView();
            SatisContent.Content = satisView;
        }

        private void BtnStoklariGor_Click(object sender, RoutedEventArgs e)
        {
            
            SatisContent.Content = new SatisStokGoruntuleView();
        }

        private void BtnKritikUrunler_Click(object sender, RoutedEventArgs e)
        {
            SatisContent.Content = new KritikUrunlerView();
        }




        private void BtnFavoriUrunler_Click(object sender, RoutedEventArgs e)
        {
            SatisContent.Content = new FavoriUrunlerView();
        }


        private void BtnSiparisEt_Click(object sender, RoutedEventArgs e)
        {
            SiparisEtView siparisEtView = new SiparisEtView();
            SatisContent.Content = siparisEtView;
        }

        private void BtnSiparislerim_Click(object sender, RoutedEventArgs e)
        {
            SiparislerimView siparislerimView = new SiparislerimView();
            SatisContent.Content = siparislerimView;
        }

        private void BtnBildirimler_Click(object sender, RoutedEventArgs e)
        {
            SatisContent.Content = new TextBlock
            {
                Text = "Bildirimler Ekranı",
                FontSize = 24,
                VerticalAlignment = VerticalAlignment.Center,
                HorizontalAlignment = HorizontalAlignment.Center
            };
        }

        private void BtnFaturaGecmisi_Click(object sender, RoutedEventArgs e)
        {
           
            SatisContent.Content = new FaturaGecmisiView();
        }

        private void BtnCikis_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            
            BtnUrunSatis_Click(null, null);
        }

    }
}
