using System.Security.Cryptography;
using System.Text;
using FreeflyAcademy.Services.Contracts.Technical;

namespace FreeflyAcademy.Services.Technical
{
    internal class HashService : IHashService
    {


        public string CalculateMD5Hash(string input)
        {
            // step 1, calculate MD5 hash from input
            MD5 md5 = MD5.Create();
            byte[] inputBytes = Encoding.ASCII.GetBytes(input);
            byte[] hash = md5.ComputeHash(inputBytes);

            // step 2, convert byte array to hex string
            StringBuilder sb = new StringBuilder();
            foreach (var t in hash)
            {
                sb.Append(t.ToString("X2"));
            }
            return sb.ToString();
        }

        public bool IsMatching(string input, string hash)
        {
            return CalculateMD5Hash(input) == hash;
        }
    }
}
