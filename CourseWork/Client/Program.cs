using Cryptography.Hash;
using Cryptography.Cipher;
using System.Runtime.CompilerServices;
using System.Text;
using System.Security.Cryptography;
using System.Numerics;
using System.Globalization;

namespace Client
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string test = "hello worldhello worldhello worldhello worldhello worldhello worldhello worldhello worldhello worldhello worldhello worldhello worldhello worldhello worldhello worldhello worldhello worldhello worldhello worldhello worldhello worldhello worldhello worldhello worldhello worldhello worldhello worldhello worldhello worldhello worldhello worldhello worldhello worldhello worldhello worldhello worldhello worldhello worldhello worldhello worldhello worldhello worldhello world";

            Sha256 sha = new Sha256();
            var hash = Convert.ToHexString(sha.ComputeHash(test));

            Rsa rsa = new Rsa();

            var cipher = rsa.Cipher(hash);

            var decipher = rsa.Decipher(cipher);

            //Console.WriteLine($"Hash: {hash}\r\nCipher: {cipher}\r\nDecipher: {decipher}\r\nHash is correct: {hash == decipher}");

            Console.WriteLine($"Hash: {hash}");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Cipher: {cipher}");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"Decipher: {decipher}");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"Hash is correct: {hash == decipher}");
        }
    }
}