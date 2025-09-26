using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StokYonetimSistemi.Models
{
    [Table("Log")]
    public class Log
    {
        [Key] public int LogID { get; set; }

        [MaxLength(50)]
        public string? TabloAdi { get; set; }

        [MaxLength(20)]
        public string? IslemTuru { get; set; } // örn: "Ekleme", "Güncelleme"

        public int? KullaniciID { get; set; }

        public DateTime Zaman { get; set; } = DateTime.Now;

        [ForeignKey("KullaniciID")]
        public Kullanici? Kullanici { get; set; }
    }
}
