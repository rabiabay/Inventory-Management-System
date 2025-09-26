using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StokYonetimSistemi.Models
{
    [Table("RaporSablonu")]
    public class RaporSablonu
    {
        [Key] public int RaporID { get; set; }

        [MaxLength(100)]
        public string RaporAdi { get; set; }

        public string SorguMetni { get; set; }

        public int OlusturanKullaniciID { get; set; }

        public DateTime Tarih { get; set; } = DateTime.Now;

        [ForeignKey("OlusturanKullaniciID")]
        public Kullanici? Kullanici { get; set; }
    }
}
