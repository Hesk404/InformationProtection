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
            string tester = "hello world hello world hello world hello world hello world hello world hello world hello world";

            var hash = Sha256_test.Hash(tester);

            //Console.WriteLine(BitConverter.ToString(hash.ToArray<byte>()).Replace("-", ""));

            using SHA256 sha = SHA256.Create();

            //Console.WriteLine(BitConverter.ToString(sha.ComputeHash(Encoding.UTF8.GetBytes(tester))));


            var str = "hello world";

            List<byte> strByte = Encoding.UTF8.GetBytes(str).ToList();

            List<string> strBinary = new List<string>();

            string strB = "";

            foreach(var b in strByte)
            {
                strBinary.Add(Convert.ToString(b, 2).PadLeft(8, '0'));
                strB += Convert.ToString(b, 2).PadLeft(8, '0');
            }

            var q = BitConverter.GetBytes(strB.Length);
            var l = string.Concat(q.Select(x => Convert.ToString(x, 2))).PadLeft(64, '0');

            strB += "1";
            while(strB.Length % 512 != 448)
            {
                strB += "0";
            }

            strB += l;


            var length = CountBits(strBinary);


            for(int i =0; i< strB.Length; i++)
            {
                if(i != 0 && i % 8 == 0)
                    Console.Write(" ");
                if(i % (8 * 4) == 0 && i != 0)
                    Console.WriteLine();
                Console.Write(strB[i]);
            }

        }


        static void AddOne(List<string> strBinary)
        {
            strBinary.Add("10000000");
        }

        static void AddZero(List<string> strBinary)
        {
            strBinary.Add("00000000");
        }

        static int CountBits(List<string> strBinary)
        {
            int result = 0;
            foreach(var b in strBinary)
            {
                result += 8;
            }
            return result;
        }
    }
}