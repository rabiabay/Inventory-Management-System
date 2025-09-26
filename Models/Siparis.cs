using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StokYonetimSistemi.Models
{
    [Table("Siparis")]
    public class Siparis
    {
        [Key]
        public int SiparisID { get; set; }

        public int TedarikciID { get; set; }

        [ForeignKey("TedarikciID")]
        public virtual Tedarikci Tedarikci { get; set; }  // Nav property ekledik

        public DateTime Tarih { get; set; }

        [MaxLength(50)]
        public string Durum { get; set; }

        // public int Miktar { get; set; } // Bu alanı detayda tutmak daha mantıklı, gerek yoksa kaldırabilirsin

        public int KullaniciID { get; set; } // Siparişi veren kullanıcı

        // Sipariş detayları
        public virtual ICollection<SiparisDetay> SiparisDetaylari { get; set; }
    }
}
