using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StokYonetimSistemi.Models
{
    [Table("StokHareketi")]
    public class StokHareketi
    {
        [Key] public int HareketID { get; set; }

        [Required] public int UrunID { get; set; }

        [Required] public int DepoID { get; set; }

        [Required, MaxLength(10)]
        public string HareketTipi { get; set; } 

        [Required]
        [Range(1, int.MaxValue)]
        public int Miktar { get; set; }

        public DateTime Tarih { get; set; } = DateTime.Now;

        [MaxLength(255)]
        public string? Aciklama { get; set; }

        public int? KullaniciID { get; set; }

        [ForeignKey("UrunID")]
        public Urun? Urun { get; set; }

        [ForeignKey("DepoID")]
        public Depo? Depo { get; set; }
    }
}
