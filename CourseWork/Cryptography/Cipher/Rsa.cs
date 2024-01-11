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

            var min = BigInteger.Pow(2, n - 1) + 1;
            var max = BigInteger.Pow(2, n) - 1;
        }

        public BigInteger GenerateRandom()
        {
            throw new NotImplementedException();
        }
    }
}
