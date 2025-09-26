using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StokYonetimSistemi.Models
{
    [Table("Urun")]
    public class Urun
    {
        [Key] public int UrunID { get; set; }

        [Required, MaxLength(150)]
        public string UrunAdi { get; set; }

        [Required, MaxLength(50)]
        public string Barkod { get; set; }

        [MaxLength(255)]
        public string? Aciklama { get; set; }

        [MaxLength(20)]
        public string? Birim { get; set; }

        public int? KritikStok { get; set; }

        public bool Aktif { get; set; } = true;

        public int? KategoriID { get; set; }

        [ForeignKey("KategoriID")]
        public Kategori? Kategori { get; set; }
    }
}
