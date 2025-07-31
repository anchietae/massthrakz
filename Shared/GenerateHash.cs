namespace massthrakz.Shared;
using System.Security.Cryptography;
using System.Text;

public static class GenerateHash
{
    public static ulong Hash(string input)
    {
        var inputBytes = Encoding.UTF8.GetBytes(input);
        var hashBytes = SHA256.HashData(inputBytes);
        if (hashBytes.Length >= 8)
        {
            return BitConverter.ToUInt64(hashBytes, 0);
        }
        var paddedHash = new byte[8];
        Array.Copy(hashBytes, paddedHash, hashBytes.Length);
        return BitConverter.ToUInt64(paddedHash, 0);
    }
}