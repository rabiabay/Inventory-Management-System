using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StokYonetimSistemi.Models
{
    [Table("Kategori")]
    public class Kategori
    {
        [Key] public int KategoriID { get; set; }

        [Required, MaxLength(100)]
        public string KategoriAdi { get; set; }

        [MaxLength(255)]
        public string? Aciklama { get; set; }
    }
}
