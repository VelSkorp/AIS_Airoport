using System;
using System.Linq;
using System.Text;

namespace AIS_Airport.Relational
{
    public class MD5
    {
        private byte[] _byteData;
        private int[] _S = new int[]
        {
            7, 12, 17, 22, 7, 12, 17, 22, 7, 12, 17, 22, 7, 12, 17, 22,
            5,  9, 14, 20, 5,  9, 14, 20, 5,  9, 14, 20, 5,  9, 14, 20,
            4, 11, 16, 23, 4, 11, 16, 23, 4, 11, 16, 23, 4, 11, 16, 23,
            6, 10, 15, 21, 6, 10, 15, 21, 6, 10, 15, 21, 6, 10, 15, 21
        };

        public MD5(string text)
        {
            _byteData = Encoding.Default.GetBytes(text);
        }

        public string GetHashCode()
        {
            var addLength = (56 - ((_byteData.Length + 1) % 64)) % 64;
            var processedInput = new byte[_byteData.Length + 1 + addLength + 8];

            Array.Copy(_byteData, processedInput, _byteData.Length);

            processedInput[_byteData.Length] = 0x80;

            byte[] length = BitConverter.GetBytes(_byteData.Length * 8);

            Array.Copy(length, 0, processedInput, processedInput.Length - 8, 4);

            Buffer oldBuffer = InitializeBuffer();
            var newBuffer = new Buffer();

            for (int j = 0; j < processedInput.Length / 64; j++)
            {
                uint[] M = new uint[16];

                for (int k = 0; k < 16; k++)
                {
                    M[k] = BitConverter.ToUInt32(processedInput, (j * 64) + (k * 4));
                }

                newBuffer.Copy(oldBuffer);

                for (uint i = 0; i < 64; i++)
                {
                    uint F = 0;
                    uint g = 0;

                    if (i <= 15)
                    {
                        F = this.F(newBuffer.B, newBuffer.C, newBuffer.D);
                        g = i;
                    }
                    else if (i >= 16 && i <= 31)
                    {
                        F = G(newBuffer.B, newBuffer.C, newBuffer.D);
                        g = ((5 * i) + 1) % 16;
                    }
                    else if (i >= 32 && i <= 47)
                    {
                        F = H(newBuffer.B, newBuffer.C, newBuffer.D);
                        g = ((3 * i) + 5) % 16;
                    }
                    else if (i >= 48)
                    {
                        F = I(newBuffer.B, newBuffer.C, newBuffer.D);
                        g = (7 * i) % 16;
                    }

                    F += newBuffer.A + newBuffer.T[i] + M[g];

                    newBuffer.A = newBuffer.D;
                    newBuffer.D = newBuffer.C;
                    newBuffer.C = newBuffer.B;
                    newBuffer.B += LeftShift(F, _S[i]);
                }

                oldBuffer.A += newBuffer.A;
                oldBuffer.B += newBuffer.B;
                oldBuffer.C += newBuffer.C;
                oldBuffer.D += newBuffer.D;
            }

            return GetByteString(oldBuffer.A) + GetByteString(oldBuffer.B) + GetByteString(oldBuffer.C) + GetByteString(oldBuffer.D);
        }

        private Buffer InitializeBuffer()
        {
            var buffer = new Buffer
            {
                A = 0x67452301,
                B = 0xefcdab89,
                C = 0x98badcfe,
                D = 0x10325476,
                T = new uint[64]
            };

            for (int i = 0; i < 64; i++)
            {
                buffer.T[i] = (uint)Math.Floor(Math.Pow(2, 32) * Math.Abs(Math.Sin(i + 1)));
            }

            return buffer;
        }

        private static string GetByteString(uint x) => string.Join("", BitConverter.GetBytes(x).Select(y => y.ToString("x2")));

        private uint LeftShift(uint x, int n) => (x << n) | (x >> (32 - n));

        private uint F(uint x, uint y, uint z) => (x & y) | (~x & z);

        private uint G(uint x, uint y, uint z) => (x & z) | (~z & y);

        private uint H(uint x, uint y, uint z) => x ^ y ^ z;

        private uint I(uint x, uint y, uint z) => y ^ (~z | x);
    }
}