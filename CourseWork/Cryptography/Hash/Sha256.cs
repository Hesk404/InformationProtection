using System.Text;

namespace Cryptography.Hash
{
    public class Sha256
    {
        private uint[] H = new uint[8]
        {
            0x6A09E667,
            0xBB67AE85,
            0x3C6EF372,
            0xA54FF53A,
            0x510E527F,
            0x9B05688C,
            0x1F83D9AB,
            0x5BE0CD19
        };

        private uint[] K = new uint[64]
        {
            0x428A2F98, 0x71374491, 0xB5C0FBCF, 0xE9B5DBA5, 0x3956C25B, 0x59F111F1, 0x923F82A4, 0xAB1C5ED5,
            0xD807AA98, 0x12835B01, 0x243185BE, 0x550C7DC3, 0x72BE5D74, 0x80DEB1FE, 0x9BDC06A7, 0xC19BF174,
            0xE49B69C1, 0xEFBE4786, 0x0FC19DC6, 0x240CA1CC, 0x2DE92C6F, 0x4A7484AA, 0x5CB0A9DC, 0x76F988DA,
            0x983E5152, 0xA831C66D, 0xB00327C8, 0xBF597FC7, 0xC6E00BF3, 0xD5A79147, 0x06CA6351, 0x14292967,
            0x27B70A85, 0x2E1B2138, 0x4D2C6DFC, 0x53380D13, 0x650A7354, 0x766A0ABB, 0x81C2C92E, 0x92722C85,
            0xA2BFE8A1, 0xA81A664B, 0xC24B8B70, 0xC76C51A3, 0xD192E819, 0xD6990624, 0xF40E3585, 0x106AA070,
            0x19A4C116, 0x1E376C08, 0x2748774C, 0x34B0BCB5, 0x391C0CB3, 0x4ED8AA4A, 0x5B9CCA4F, 0x682E6FF3,
            0x748F82EE, 0x78A5636F, 0x84C87814, 0x8CC70208, 0x90BEFFFA, 0xA4506CEB, 0xBEF9A3F7, 0xC67178F2
        };

        private static uint Rotr(uint x, byte n)
        {
            return (x >> n) | (x << (32 - n));
        }

        private static uint sigma0(uint x)
        {
            return Rotr(x, 7) ^ Rotr(x, 18) ^ (x >> 3);
        }

        private static uint sigma1(uint x)
        {
            return Rotr(x, 17) ^ Rotr(x, 19) ^ (x >> 10);
        }

        private static uint Sigma0(uint x)
        {
            return Rotr(x, 2) ^ Rotr(x, 13) ^ Rotr(x, 22);
        }

        private static uint Sigma1(uint x)
        {
            return Rotr(x, 6) ^ Rotr(x, 11) ^ Rotr(x, 25);
        }

        private static uint Maj(uint x, uint y, uint z)
        {
            return (x & y) ^ (x & z) ^ (y & z);
        }

        private static uint Ch(uint x, uint y, uint z)
        {
            return (x & y) ^ ((~x) & z);
        }

        public byte[] ComputeHash(string str)
        {
            List<byte> strByte = Encoding.UTF8.GetBytes(str).ToList();

            string strBinary = "";

            foreach (var item in strByte)
            {
                strBinary += Convert.ToString(item, 2).PadLeft(8, '0');
            }

            var strBytes = BitConverter.GetBytes(strBinary.Length);
            if (BitConverter.IsLittleEndian)
                Array.Reverse(strBytes);
            
            var length = string.Concat(strBytes.Select(x => Convert.ToString(x, 2).PadLeft(8, '0'))).PadLeft(64, '0');

            strBinary += "1";
            while (strBinary.Length % 512 != 448)
            {
                strBinary += "0";
            }

            strBinary += length;

            List<string> tmpStrings = new List<string>();
            for(int i = 0; i< strBinary.Length; i+=512)
            {
                char[] tmp = new char[512];
                Array.Copy(strBinary.ToArray<char>(), i, tmp, 0, 512);
                tmpStrings.Add(string.Concat(tmp));
            }

            List<byte[]> blocks = new List<byte[]>();
            foreach (var s in tmpStrings)
                blocks.Add(BinaryToByteArray(s));


            foreach(var block in blocks)
            {
                var proceed = ToUintArray(block);
                uint[] W = new uint[64];
                for(int i = 0; i < 16; i++)
                {
                    W[i] = proceed[i];
                }
                for(int i = 16; i < 64; i++)
                {
                    W[i] = W[i - 16] + sigma0(W[i - 15]) + W[i - 7] + sigma1(W[i - 2]);
                }

                uint a = H[0],
                b = H[1],
                c = H[2],
                d = H[3],
                e = H[4],
                f = H[5],
                g = H[6],
                h = H[7];

                for (int i = 0; i < 64; i++)
                {
                    var T1 = h + Sigma1(e) + Ch(e, f, g) + K[i] + W[i];
                    var T2 = Sigma0(a) + Maj(a, b, c);
                    h = g;
                    g = f;
                    f = e;
                    e = d + T1;
                    d = c;
                    c = b;
                    b = a;
                    a = T1 + T2;
                }

                H[0] = a + H[0];
                H[1] = b + H[1];
                H[2] = c + H[2];
                H[3] = d + H[3];
                H[4] = e + H[4];
                H[5] = f + H[5];
                H[6] = g + H[6];
                H[7] = h + H[7];
            }


            return ToByteArray(H);
        }

        private static byte[] BinaryToByteArray(string strBinary)
        {
            int numberOfBytes = strBinary.Length / 8;
            byte[] bytes = new byte[numberOfBytes];
            for (int i = 0; i < numberOfBytes; i++)
            {
                bytes[i] = Convert.ToByte(strBinary.Substring(8 * i, 8), 2);
            }
            return bytes;
        }

        private static uint[] ToUintArray(byte[] src)
        {
            uint[] dest = new uint[16];
            for (uint i = 0, j = 0; i < dest.Length; ++i, j += 4)
            {
                dest[i] = ((uint)src[j + 0] << 24) | ((uint)src[j + 1] << 16) | ((uint)src[j + 2] << 8) | ((uint)src[j + 3]);
            }
            return dest;
        }

        private static byte[] ToByteArray(uint[] src)
        {
            byte[] dest = new byte[src.Length * 4];
            int pos = 0;

            for (int i = 0; i < src.Length; ++i)
            {
                dest[pos++] = (byte)(src[i] >> 24);
                dest[pos++] = (byte)(src[i] >> 16);
                dest[pos++] = (byte)(src[i] >> 8);
                dest[pos++] = (byte)(src[i]);
            }

            return dest;
        }
    }
}
