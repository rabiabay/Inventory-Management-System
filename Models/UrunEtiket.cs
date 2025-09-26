using System.ComponentModel.DataAnnotations.Schema;

namespace StokYonetimSistemi.Models
{
    [Table("UrunEtiket")]
    public class UrunEtiket
    {
        public int UrunID { get; set; }
        public int EtiketID { get; set; }

        [ForeignKey("UrunID")]
        public Urun? Urun { get; set; }

        [ForeignKey("EtiketID")]
        public Etiket? Etiket { get; set; }
    }
}
