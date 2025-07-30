namespace massthrakz.Shared;
using System.Security.Cryptography;
using System.Text;

public class GenerateHash
{
    public static ulong Hash(string input)
    {
        using (var sha256 = SHA256.Create())
        {
            byte[] inputBytes = Encoding.UTF8.GetBytes(input);
            byte[] hashBytes = sha256.ComputeHash(inputBytes);
            if (hashBytes.Length >= 8)
            {
                return BitConverter.ToUInt64(hashBytes, 0);
            }
            byte[] paddedHash = new byte[8];
            Array.Copy(hashBytes, paddedHash, hashBytes.Length);
            return BitConverter.ToUInt64(paddedHash, 0);
        }
    }
}