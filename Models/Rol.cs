using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StokYonetimSistemi.Models
{
    [Table("Rol")]
    public class Rol
    {
        [Key] public int RolID { get; set; }

        [Required, MaxLength(50)]
        public string RolAdi { get; set; }
    }
}
