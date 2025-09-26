using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StokYonetimSistemi.Models
{
    [Table("FaturaDetay")]
    public class FaturaDetay
    {
        [Key] public int FaturaDetayID { get; set; }

        public int FaturaID { get; set; }

        public int UrunID { get; set; }

        public int Miktar { get; set; }

        [ForeignKey("FaturaID")]
        public Fatura? Fatura { get; set; }

        [ForeignKey("UrunID")]
        public Urun? Urun { get; set; }
    }
}
