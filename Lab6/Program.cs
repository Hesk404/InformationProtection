

using System.Numerics;

namespace Lab6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            BigNumber bg = new BigNumber(0x8fffffff);

            var test = Convert.ToByte("5");

            var randomNumberFirst = GenerateRandomPrimitiveNumber(1023);
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"First primitive big number: {randomNumberFirst}");

            var randomNumberSecond = GenerateRandomPrimitiveNumber(1023);
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine($"Second primitive big number: {randomNumberSecond}");

            var multiply = randomNumberFirst * randomNumberSecond;
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine($"Multiplying: {multiply}");

            Console.ForegroundColor = ConsoleColor.White;
        }

        static BigNumber GenerateRandomPrimitiveNumber(int n)
        {
            // 2^(n-1)+1 and 2^n-1''' 

            var one = new BigNumber(1);

            var min = BigNumber.Pow(2, n - 1) + one;
            var max = BigNumber.Pow(2, n) - one;

            BigNumber result = BigNumber.Random(min, max);

            while (IsPrimitive(result))
                result = BigNumber.Random(min, max);


            return result;
        }

        static bool IsPrimitive(BigNumber number)
        {
            List<BigNumber> primitives = new List<BigNumber> {
                new BigNumber(2), new BigNumber(3), new BigNumber(5), new BigNumber(7), new BigNumber(11), new BigNumber(13), new BigNumber(17), new BigNumber(19), new BigNumber(23), new BigNumber(29),
                new BigNumber(31), new BigNumber(37), new BigNumber(41), new BigNumber(43), new BigNumber(47), new BigNumber(53), new BigNumber(59), new BigNumber(61), new BigNumber(67),
                new BigNumber(71), new BigNumber(73), new BigNumber(79), new BigNumber(83), new BigNumber(89), new BigNumber(97), new BigNumber(101), new BigNumber(103),
                new BigNumber(107), new BigNumber(109), new BigNumber(113), new BigNumber(127), new BigNumber(131), new BigNumber(137), new BigNumber(139),
                new BigNumber(149), new BigNumber(151), new BigNumber(157), new BigNumber(163), new BigNumber(167), new BigNumber(173), new BigNumber(179),
                new BigNumber(181), new BigNumber(191), new BigNumber(193), new BigNumber(197), new BigNumber(199), new BigNumber(211), new BigNumber(223),
                new BigNumber(227), new BigNumber(229), new BigNumber(233), new BigNumber(239), new BigNumber(241), new BigNumber(251), new BigNumber(257),
                new BigNumber(263), new BigNumber(269), new BigNumber(271), new BigNumber(277), new BigNumber(281), new BigNumber(283), new BigNumber(293),
                new BigNumber(307), new BigNumber(311), new BigNumber(313), new BigNumber(317), new BigNumber(331), new BigNumber(337), new BigNumber(347), new BigNumber(349)
            };

            bool isPrimitive = true;
            foreach (var primitive in primitives)
            {
                if (number % primitive == BigNumber.Zero)
                {
                    isPrimitive = false;
                    break;
                }
            }

            return isPrimitive;
        }
    }
}