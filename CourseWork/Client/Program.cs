using Cryptography.Hash;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;

namespace Client
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //string tester = "hello world hello world hello world hello world hello world hello world hello world hello world";

            //var hash = Sha256_test.Hash(tester);

            //Console.WriteLine(BitConverter.ToString(hash.ToArray<byte>()).Replace("-", ""));

            string tester = "hello k;hlf'ngfdjng;fdbgfdgmfd/kgbnsgzh13513zdgfhgxjh aT a31a&$%&*dhf e,gfdtretegfd  dfkgnlqew53151i35";

            using SHA256 test = SHA256.Create();

            var hash1 = BitConverter.ToString(test.ComputeHash(Encoding.UTF8.GetBytes(tester)));

            Console.WriteLine(hash1);

            Sha256 sha = new Sha256(); 
            var hash = BitConverter.ToString(sha.ComputeHash(tester));
            Console.WriteLine(hash);

            var s = hash == hash1;

            Console.WriteLine(s);

        }
    }
}