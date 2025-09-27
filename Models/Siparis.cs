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
        public virtual Tedarikci Tedarikci { get; set; }  

        public DateTime Tarih { get; set; }

        [MaxLength(50)]
        public string Durum { get; set; }

        

        public int KullaniciID { get; set; } 

       
        public virtual ICollection<SiparisDetay> SiparisDetaylari { get; set; }
    }
}
