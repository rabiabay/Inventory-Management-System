using System.ComponentModel.DataAnnotations.Schema;

namespace StokYonetimSistemi.Models
{
    [Table("FavoriUrunler")]
    public class FavoriUrun
    {
        public int KullaniciID { get; set; }
        public int UrunID { get; set; }

        [ForeignKey("KullaniciID")]
        public Kullanici? Kullanici { get; set; }

        [ForeignKey("UrunID")]
        public Urun? Urun { get; set; }
    }
}
