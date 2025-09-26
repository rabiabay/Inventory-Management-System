using System.Security.Cryptography;
using System.Text;

namespace StokYonetimSistemi.Helpers
{
    public static class SifrelemeHelper
    {
        public static string Sifrele(string sifre)
        {
            using SHA256 sha256 = SHA256.Create();
            byte[] bytes = Encoding.UTF8.GetBytes(sifre);
            byte[] hashBytes = sha256.ComputeHash(bytes);

            return Convert.ToBase64String(hashBytes);
        }
    }
}
