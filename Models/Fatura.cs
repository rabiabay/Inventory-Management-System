using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StokYonetimSistemi.Models
{
    [Table("Fatura")]
    public class Fatura
    {
        [Key] public int FaturaID { get; set; }

        public int SiparisID { get; set; }

        public DateTime Tarih { get; set; } = DateTime.Now;

        public decimal ToplamTutar { get; set; }

        public int? KullaniciID { get; set; }

        [ForeignKey("SiparisID")]
        public Siparis? Siparis { get; set; }
    }
}
