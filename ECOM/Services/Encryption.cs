using Konscious.Security.Cryptography;
using System.Security.Cryptography;
using System.Text;

namespace ECOM.Services
{
    public static class Encryption
    {
        private static readonly ILogger _logger;
        private const int SaltSize = 16;        // 16 byte salt
        private const int HashSize = 32;        // 32 byte hash (256 bit)
        private const int Iterations = 3;       // Time cost
        private const int MemoryKb = 32768;     // 32 MB
        private const int DegreeOfParallelism = 2; // CPU core sayısı

        public static string? HashPassword(string password)
        {
            try
            {
                // 1) Rastgele salt oluştur
                var salt = RandomNumberGenerator.GetBytes(SaltSize);

                // 2) Argon2id nesnesi ile hash oluştur
                var argon2 = new Argon2id(Encoding.UTF8.GetBytes(password))
                {
                    Salt = salt,
                    Iterations = Iterations,
                    MemorySize = MemoryKb,
                    DegreeOfParallelism = DegreeOfParallelism
                };

                var hash = argon2.GetBytes(HashSize);

                // 3) DB'ye saklanacak formatı oluştur
                // Örnek format: base64(salt) + "$" + base64(hash) + "$" + params (opsiyonel)
                return $"{Convert.ToBase64String(salt)}$" +
                       $"{Convert.ToBase64String(hash)}$" +
                       $"{Iterations}.{MemoryKb}.{DegreeOfParallelism}";
            }
            catch (Exception ex)
            {
                _logger?.LogError($"HashPassword Error => {ex}");
                return null;
            }
        }

        // Login sırasında çağrılacak
        public static bool VerifyPassword(string password, string stored)
        {
            try
            {
                // stored format: saltB64$hashB64$meta
                var parts = stored.Split('$', StringSplitOptions.RemoveEmptyEntries);
                if (parts.Length != 3) return false;

                var salt = Convert.FromBase64String(parts[0]);
                var hashStored = Convert.FromBase64String(parts[1]);
                var meta = parts[2].Split('.');
                if (meta.Length != 3) return false;

                int iterations = int.Parse(meta[0]);
                int memoryKb = int.Parse(meta[1]);
                int degree = int.Parse(meta[2]);

                var argon2 = new Argon2id(Encoding.UTF8.GetBytes(password))
                {
                    Salt = salt,
                    Iterations = iterations,
                    MemorySize = memoryKb,
                    DegreeOfParallelism = degree
                };

                var hashCalculated = argon2.GetBytes(hashStored.Length);

                // Sabit zamanlı karşılaştırma (timing attack'i azaltmak için)
                return CryptographicOperations.FixedTimeEquals(hashCalculated, hashStored);
            }
            catch (Exception ex)
            {
                _logger?.LogError($"VerifyPassword Error => {ex}");
                return false;
            }
        }
    }
}
