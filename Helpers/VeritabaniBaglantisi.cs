using Microsoft.EntityFrameworkCore;
using StokYonetimSistemi.Data;

namespace StokYonetimSistemi.Helpers
{
    public static class VeritabaniBaglantisi
    {
        public static DbContextOptions<StokYonetimContext> BaglantiGetir()
        {
            var optionsBuilder = new DbContextOptionsBuilder<StokYonetimContext>();
            optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS02;Database=StokYonetimSistemi;Trusted_Connection=True;TrustServerCertificate=True;");
            return optionsBuilder.Options;
        }
    }
}
