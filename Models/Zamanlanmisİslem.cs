using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StokYonetimSistemi.Models
{
    [Table("ZamanlanmisIslem")]
    public class ZamanlanmisIslem
    {
        [Key] public int IslemID { get; set; }

        [MaxLength(100)]
        public string IslemAdi { get; set; }

        [MaxLength(255)]
        public string? Aciklama { get; set; }

        [MaxLength(50)]
        public string? CronIfadesi { get; set; }

        public bool Aktif { get; set; } = true;
    }
}
