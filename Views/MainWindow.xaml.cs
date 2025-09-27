using System.Windows;

namespace StokYonetimSistemi
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            
            MainGrid.Children.Clear();
            MainGrid.Children.Add(new Views.AdminPanel());

        }

    }


}
