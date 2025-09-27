using StokYonetimSistemi.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

public class Kullanici
{
    [Key] public int KullaniciID { get; set; }

    [MaxLength(50)]
    public string? Ad { get; set; }

    [MaxLength(50)]
    public string? Soyad { get; set; }

    [Required, MaxLength(50)]
    public string KullaniciAdi { get; set; }

    [Required, MaxLength(255)]
    public string SifreHash { get; set; }

    public int? RolID { get; set; }

    [ForeignKey("RolID")]
    public Rol? Rol { get; set; }

    public bool Aktif { get; set; } = true;

    [MaxLength(50)]
    public string? GorevTuru { get; set; } 
}
