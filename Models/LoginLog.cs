using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StokYonetimSistemi.Models
{
    [Table("LoginLog")]
    public class LoginLog
    {
        [Key] public int LogID { get; set; }

        public int? KullaniciID { get; set; }

        public DateTime GirisZamani { get; set; } = DateTime.Now;

        [MaxLength(50)]
        public string? IP { get; set; }

        public bool Basarili { get; set; }

        [ForeignKey("KullaniciID")]
        public Kullanici? Kullanici { get; set; }
    }
}
