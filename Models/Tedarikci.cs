using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StokYonetimSistemi.Models
{
    [Table("Tedarikci")]
    public class Tedarikci
    {
        [Key] public int TedarikciID { get; set; }

        [Required, MaxLength(150)]
        public string FirmaAdi { get; set; }

        [MaxLength(20)]
        public string? Telefon { get; set; }

        [MaxLength(100)]
        public string? Eposta { get; set; }

        [MaxLength(255)]
        public string? Adres { get; set; }
    }
}
