using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StokYonetimSistemi.Models
{
    [Table("Stok")]
    public class Stok
    {
        [Key] public int StokID { get; set; }

        [Required] public int UrunID { get; set; }

        [Required] public int DepoID { get; set; }

        [Required] public int Miktar { get; set; }

        [ForeignKey("UrunID")]
        public Urun? Urun { get; set; }

        [ForeignKey("DepoID")]
        public Depo? Depo { get; set; }
    }
}
