using Cryptography.Models;
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

        public Key publicKey;
        public Key secretKey;

        public Rsa()
        {
            var n = 1024;

            min = BigInteger.Pow(2, n - 1) + 1;
            max = BigInteger.Pow(2, n) - 1;

        }

        private BigInteger GenerateRandom()
        {
            BigInteger result;

            var minStr = min.ToString();
            var maxStr = max.ToString();

            var resultStr = "";

            while (true)
            {
                for(int i = 0; i < minStr.Length; i++)
                {
                    resultStr += (int.Parse(minStr[i].ToString()) + rnd.Next(0, 10 - int.Parse(minStr[i].ToString()))).ToString();
                }

                result = BigInteger.Parse(resultStr);
                //Console.WriteLine(result);
                if (result >= min && result <= max)
                    return result;
                else
                {
                    result = BigInteger.Zero;
                }
            }
        }

        private BigInteger GenerateRandom(BigInteger minValue, BigInteger maxValue)
        {
            BigInteger result;

            var minStr = minValue.ToString();
            var maxStr = maxValue.ToString();

            var maxCount = maxStr.Length - 1;

            var count = rnd.Next(minStr.Length, maxStr.Length); 

            var resultStr = "";

            while(true)
            {
                for(int i = 0; i < count; i++)
                {
                    resultStr += int.Parse(maxStr[maxCount].ToString()) - rnd.Next(0, int.Parse(maxStr[maxCount].ToString()));
                }
                result = BigInteger.Parse(resultStr);
                if (result >= minValue && result <= maxValue)
                    return result;
                else
                {
                    result = BigInteger.Zero;
                }
            }

        }

        private bool CheckPrimitive(BigInteger number)
        {
            bool result = false;

            result = SimplePrimitiveCheck(number);
            if(result)
                result = MillerRabinTest(number, 10);

            return result;
        }

        private bool SimplePrimitiveCheck(BigInteger number)
        {
            var primitives = new List<int>
            {
                2, 3, 5, 7, 11, 13, 17, 19, 23, 29,
                31, 37, 41, 43, 47, 53, 59, 61, 67,
                71, 73, 79, 83, 89, 97, 101, 103,
                107, 109, 113, 127, 131, 137, 139,
                149, 151, 157, 163, 167, 173, 179,
                181, 191, 193, 197, 199, 211, 223,
                227, 229, 233, 239, 241, 251
            };

            foreach (var primitive in primitives)
            {
                if (number % primitive == 0)
                {
                    return false;
                }
            }

            return true;
        }

        private bool MillerRabinTest(BigInteger number, int k)
        {
            if (number == 2 || number == 3)
                return true;
            if (number < 2 || number % 2 == 0)
                return false;

            BigInteger t = number - 1;
            int s = 0;
            while(t % 2 == 0)
            {
                t /= 2;
                s++;
            }

            for(int i = 0; i < k; i++)
            {
                var a = GenerateRandom(2, number - 2);

                var x = BigInteger.ModPow(a, t, number);

                if (x == 1 || x == number - 1)
                    continue;

                for(int j = 0; j < s; j++)
                {
                    x = BigInteger.ModPow(x, 2, number);

                    if (x == 1)
                        return false;

                    if (x == number - 1)
                        break;
                }

                if (x != number - 1)
                    return false;
            }

            return true;
        }

        private static BigInteger Egcd(BigInteger left, BigInteger right, out BigInteger leftFactor, out BigInteger rightFactor)
        {
            leftFactor = 0;
            rightFactor = 1;
            BigInteger u = 1;
            BigInteger v = 0;
            BigInteger gcd = 0;

            while (left != 0)
            {
                BigInteger q = right / left;
                BigInteger r = right % left;

                BigInteger m = leftFactor - u * q;
                BigInteger n = rightFactor - v * q;

                right = left;
                left = r;
                leftFactor = u;
                rightFactor = v;
                u = m;
                v = n;

                gcd = right;
            }

            return gcd;
        }

        private BigInteger ModInverse(BigInteger value, BigInteger modulo)
        {
            BigInteger x, y;

            if (1 != Egcd(value, modulo, out x, out y))
                throw new ArgumentException("Invalid modulo!", "modulo");

            if (x < 0)
                x += modulo;

            return x % modulo;
        }

        public void GenerateKeys()
        {
            BigInteger p;
            BigInteger q;

            BigInteger n;

            var e = 65537;



            do
            {
                p = GenerateRandom();
            } while (!CheckPrimitive(p));

            do
            {
                q = GenerateRandom();
            } while(!CheckPrimitive(q));

            n = p * q;

            var eilerFunction = (p - 1) * (q - 1);

            var d = ModInverse(e, eilerFunction);

            publicKey = new Key { First = e, Second = n };
            secretKey = new Key { First = d, Second = n };
        }
    }
}
