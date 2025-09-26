using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StokYonetimSistemi.Models
{
    [Table("SiparisDetay")]
    public class SiparisDetay
    {
        [Key]
        public int SiparisDetayID { get; set; }

        public int SiparisID { get; set; }

        public int UrunID { get; set; }

        public int Miktar { get; set; } // Sipariş edilen ürün miktarı

        [ForeignKey("SiparisID")]
        public virtual Siparis Siparis { get; set; }

        [ForeignKey("UrunID")]
        public virtual Urun Urun { get; set; }
    }
}
