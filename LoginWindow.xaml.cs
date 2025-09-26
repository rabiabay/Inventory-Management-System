using System.Linq;
using System.Windows;
using StokYonetimSistemi.Data;
using StokYonetimSistemi.Helpers;
using StokYonetimSistemi.Views;

namespace StokYonetimSistemi
{
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
        }

        private void BtnGiris_Click(object sender, RoutedEventArgs e)
        {
            string kullaniciAdi = txtKullaniciAdi.Text.Trim();
            string sifre = txtSifre.Password.Trim();

            if (string.IsNullOrEmpty(kullaniciAdi) || string.IsNullOrEmpty(sifre))
            {
                MessageBox.Show("Kullanıcı adı ve şifre zorunludur.");
                return;
            }

            using var context = new StokYonetimContext(VeritabaniBaglantisi.BaglantiGetir());

            var kullanici = context.Kullanici
                .Where(k => k.KullaniciAdi == kullaniciAdi && k.Aktif == true)
                .Select(k => new
                {
                    k.KullaniciID,
                    k.Ad,
                    k.Soyad,
                    k.KullaniciAdi,
                    k.RolID,
                    k.GorevTuru
                })
                .FirstOrDefault();

            if (kullanici == null)
            {
                MessageBox.Show("Kullanıcı adı hatalı veya kullanıcı pasif durumda.");
                return;
            }

            // ✅ Tüm roller için geçerli olacak şekilde aktif kullanıcı bilgisi atanıyor
            AktifKullanici.KullaniciID = kullanici.KullaniciID;
            AktifKullanici.KullaniciAdi = kullanici.KullaniciAdi;

            // ✅ Giriş yapan kullanıcı loga yazılıyor
            LogService.LogEkle("Kullanici", "Giriş", kullanici.KullaniciID);

            // ✅ Rol kontrolü ile panele yönlendirme
            if (kullanici.RolID == 1)
            {
                new AdminPanel().Show();
            }
            else if (kullanici.RolID == 3 && kullanici.GorevTuru == "Depo")
            {
                new Window
                {
                    Content = new DepoPanel(),
                    Width = 1000,
                    Height = 700,
                    Title = "Depo Paneli"
                }.Show();
            }
            else if (kullanici.RolID == 4 && kullanici.GorevTuru == "Satis")
            {
                new Window
                {
                    Content = new SatisPanel(),
                    Width = 1000,
                    Height = 700,
                    Title = "Satış Paneli"
                }.Show();
            }
            else
            {
                MessageBox.Show("Bu rol ile sisteme giriş yetkiniz yok.");
                return;
            }

            this.Close();
        }
    }
}
