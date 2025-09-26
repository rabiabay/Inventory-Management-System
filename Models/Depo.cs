using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StokYonetimSistemi.Models
{
    [Table("Depo")]
    public class Depo
    {
        [Key] public int DepoID { get; set; }

        [Required, MaxLength(100)]
        public string DepoAdi { get; set; }

        [MaxLength(255)]
        public string? Adres { get; set; }

        public int? SorumluPersonelID { get; set; }
    }
}
