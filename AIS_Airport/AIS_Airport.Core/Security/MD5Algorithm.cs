using System.Text;

namespace AIS_Airport.Core
{
	public static class MD5
	{
		private static readonly int[] S =
		[
			7, 12, 17, 22, 7, 12, 17, 22, 7, 12, 17, 22, 7, 12, 17, 22,
			5,  9, 14, 20, 5,  9, 14, 20, 5,  9, 14, 20, 5,  9, 14, 20,
			4, 11, 16, 23, 4, 11, 16, 23, 4, 11, 16, 23, 4, 11, 16, 23,
			6, 10, 15, 21, 6, 10, 15, 21, 6, 10, 15, 21, 6, 10, 15, 21
		];

		public static string Encrypt(string text)
		{
			var byteData = Encoding.Default.GetBytes(text);
			var addLength = (56 - ((byteData.Length + 1) % 64)) % 64;
			var processedInput = new byte[byteData.Length + 1 + addLength + 8];

			Array.Copy(byteData, processedInput, byteData.Length);

			processedInput[byteData.Length] = 0x80;

			var length = BitConverter.GetBytes(byteData.Length * 8);

			Array.Copy(length, 0, processedInput, processedInput.Length - 8, 4);

			var oldBuffer = InitializeBuffer();
			var newBuffer = new Buffer();

			for (var j = 0; j < processedInput.Length / 64; j++)
			{
				var M = new uint[16];

				for (var k = 0; k < 16; k++)
				{
					M[k] = BitConverter.ToUInt32(processedInput, (j * 64) + (k * 4));
				}

				newBuffer.Copy(oldBuffer);

				for (uint i = 0; i < 64; i++)
				{
					uint f = 0;
					uint g = 0;

					if (i <= 15)
					{
						f = F(newBuffer.B, newBuffer.C, newBuffer.D);
						g = i;
					}
					else if (i >= 16 && i <= 31)
					{
						f = G(newBuffer.B, newBuffer.C, newBuffer.D);
						g = ((5 * i) + 1) % 16;
					}
					else if (i >= 32 && i <= 47)
					{
						f = H(newBuffer.B, newBuffer.C, newBuffer.D);
						g = ((3 * i) + 5) % 16;
					}
					else if (i >= 48)
					{
						f = I(newBuffer.B, newBuffer.C, newBuffer.D);
						g = (7 * i) % 16;
					}

					f += newBuffer.A + newBuffer.T[i] + M[g];

					newBuffer.A = newBuffer.D;
					newBuffer.D = newBuffer.C;
					newBuffer.C = newBuffer.B;
					newBuffer.B += LeftShift(f, S[i]);
				}

				oldBuffer.A += newBuffer.A;
				oldBuffer.B += newBuffer.B;
				oldBuffer.C += newBuffer.C;
				oldBuffer.D += newBuffer.D;
			}

			return GetByteString(oldBuffer.A) + GetByteString(oldBuffer.B) + GetByteString(oldBuffer.C) + GetByteString(oldBuffer.D);
		}

		private static Buffer InitializeBuffer()
		{
			var buffer = new Buffer
			{
				A = 0x67452301,
				B = 0xefcdab89,
				C = 0x98badcfe,
				D = 0x10325476,
				T = new uint[64]
			};

			for (var i = 0; i < 64; i++)
			{
				buffer.T[i] = (uint)Math.Floor(Math.Pow(2, 32) * Math.Abs(Math.Sin(i + 1)));
			}

			return buffer;
		}

		private static string GetByteString(uint x) => string.Join("", BitConverter.GetBytes(x).Select(y => y.ToString("x2")));

		private static uint LeftShift(uint x, int n) => (x << n) | (x >> (32 - n));

		private static uint F(uint x, uint y, uint z) => (x & y) | (~x & z);

		private static uint G(uint x, uint y, uint z) => (x & z) | (~z & y);

		private static uint H(uint x, uint y, uint z) => x ^ y ^ z;

		private static uint I(uint x, uint y, uint z) => y ^ (~z | x);
	}
}