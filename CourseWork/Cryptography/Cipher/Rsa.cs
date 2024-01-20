using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Cryptography.Cipher
{
    public class Rsa
    {
        private BigInteger min;
        private BigInteger max;

        private static readonly Random rnd = new Random();

        public Rsa()
        {
            var n = 1024;

            min = BigInteger.Pow(2, n - 1) + 1;
            max = BigInteger.Pow(2, n) - 1;

        }

        public BigInteger GenerateRandom()
        {
            

            var result = BigInteger.Zero;

            var minVal = new List<int>();
            var maxVal = new List<int>();

            


            foreach (var item in min.ToString())
                minVal.Add(int.Parse(item.ToString()));
            foreach(var item in max.ToString())
                maxVal.Add(int.Parse(item.ToString()));

            var resultBytes = new byte[minVal.Count];

            while (true)
            {
                for(int i = 0; i < minVal.Count; i++)
                {
                    //var tmp = rnd.Next(0, 10 - minVal[i]);
                    resultBytes[i] = (byte)(minVal[i] + rnd.Next(0, 10 - minVal[i]));
                }

                result = new BigInteger(resultBytes) / 2;
                Console.WriteLine(result);
                if (result >= min && result <= max)
                    return result;
                else
                {
                    result = BigInteger.Zero;
                }
            }
        }
    }
}
