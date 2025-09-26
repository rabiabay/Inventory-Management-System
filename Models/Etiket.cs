using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StokYonetimSistemi.Models
{
    [Table("Etiket")]
    public class Etiket
    {
        [Key] public int EtiketID { get; set; }

        [MaxLength(50)]
        public string EtiketAdi { get; set; }
    }
}
