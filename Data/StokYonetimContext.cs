using Microsoft.EntityFrameworkCore;
using StokYonetimSistemi.Models;

namespace StokYonetimSistemi.Data
{
    public class StokYonetimContext : DbContext
    {
        public StokYonetimContext(DbContextOptions<StokYonetimContext> options)
            : base(options) { }

        public DbSet<Kategori> Kategori { get; set; }
        public DbSet<Urun> Urun { get; set; }
        public DbSet<Depo> Depo { get; set; }
        public DbSet<Stok> Stok { get; set; }
        public DbSet<StokHareketi> StokHareketi { get; set; }
        public DbSet<Tedarikci> Tedarikciler { get; set; }
        public DbSet<Siparis> Siparisler { get; set; }
        public DbSet<SiparisDetay> SiparisDetaylari { get; set; }
        public DbSet<Fatura> Faturalar { get; set; }
        public DbSet<FaturaDetay> FaturaDetaylar { get; set; }
        public DbSet<Kullanici> Kullanici { get; set; }
        public DbSet<Rol> Roller { get; set; }
        public DbSet<LoginLog> LoginLoglari { get; set; }
        public DbSet<Log> Loglar { get; set; }
        public DbSet<ZamanlanmisIslem> ZamanlanmisIslemler { get; set; }
        public DbSet<Etiket> Etiketler { get; set; }
        public DbSet<UrunEtiket> UrunEtiketleri { get; set; }
        public DbSet<FavoriUrun> FavoriUrunler { get; set; }
        public DbSet<RaporSablonu> RaporSablonlari { get; set; }
        public DbSet<RaporLog> RaporLoglari { get; set; }
        public DbSet<KritikUrun> KritikUrunler { get; set; }
        public DbSet<Satis> Satis { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UrunEtiket>().HasKey(ue => new { ue.UrunID, ue.EtiketID });
            modelBuilder.Entity<FavoriUrun>().HasKey(f => new { f.KullaniciID, f.UrunID });

            modelBuilder.Entity<Fatura>()
                .Property(f => f.ToplamTutar)
                .HasPrecision(12, 2);

          
        }
    }
}
