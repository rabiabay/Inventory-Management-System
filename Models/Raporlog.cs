using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StokYonetimSistemi.Models
{
    [Table("RaporLog")]
    public class RaporLog
    {
        [Key] public int RaporLogID { get; set; }

        public int KullaniciID { get; set; }

        [MaxLength(100)]
        public string RaporAdi { get; set; }

        public DateTime AlinmaTarihi { get; set; } = DateTime.Now;

        [ForeignKey("KullaniciID")]
        public Kullanici? Kullanici { get; set; }
    }
}
