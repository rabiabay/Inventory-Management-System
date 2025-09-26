namespace StokYonetimSistemi.Models
{
    public class Satis
    {
        public int SatisID { get; set; }
        public int UrunID { get; set; }
        public int DepoID { get; set; }
        public int Miktar { get; set; }
        public decimal ToplamTutar { get; set; }
        public DateTime Tarih { get; set; }
        public int KullaniciID { get; set; }
        public string Aciklama { get; set; }
    }
}
