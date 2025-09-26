using Microsoft.EntityFrameworkCore;

namespace StokYonetimSistemi.Models
{
    [Keyless] // 🔥 Burası kritik
    public class KritikUrun
    {
        public string UrunAdi { get; set; }
        public string KategoriAdi { get; set; }
        public int Miktar { get; set; }
        public int KritikStok { get; set; }
    }
}
