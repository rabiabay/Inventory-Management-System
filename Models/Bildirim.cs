using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace StokYonetimSistemi.Models
{
    [Table("Bildirim")]
    public class Bildirim
    {
        [Key]
        public int BildirimID { get; set; }

        public int KullaniciID { get; set; }

        [MaxLength(255)]
        public string Mesaj { get; set; } = string.Empty;

        public bool OkunduMu { get; set; } = false;

        public DateTime Tarih { get; set; } = DateTime.Now;

        [ForeignKey("KullaniciID")]
        public Kullanici? Kullanici { get; set; }
    }
}
