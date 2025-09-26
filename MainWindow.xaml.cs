using System.Windows;

namespace StokYonetimSistemi
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            // Örnek: başlangıç sayfası olarak AdminPanel yükleniyor
            MainGrid.Children.Clear();
            MainGrid.Children.Add(new Views.AdminPanel());

        }

    }


}
