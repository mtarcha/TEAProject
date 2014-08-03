using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Encode_DecodeAlgoritms
{
    public class TEAEncryptor : IEncryptor
    {
        Byte[] _inputArray;
        uint[] _key = new uint[4];
        Byte[] _outputArray;

        public Byte[] Encrypt(Byte[] data, Byte[] key)
        {
            _inputArray = data;
            _key = ChangeKeytoUint32(key);
            uint[][] Array2xInt32 = this.ChangeArrayToUInt32();
            int n = _inputArray.Length / 8 + 1;
            for (int i = 0; i < n; i++)
            {
                Сode(Array2xInt32[i], _key);
            }
            _outputArray = this.ReturnArrayToByte(Array2xInt32);
            return _outputArray;
        }

        private Byte[] ReturnArrayToByte(uint[][] NewArray)
        {
            int n = _inputArray.Length / 8 + 1;
            int k = _inputArray.Length % 8;
            int m = 8 - k;
            Byte[] ArrayInByte = new Byte[_inputArray.Length + m];
            Byte[] d = new Byte[4];

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    d = BitConverter.GetBytes(NewArray[i][j]);
                    for (int l = 0; l < 4; l++)
                    {
                        ArrayInByte[8 * i + 4 * j + l] = d[l];
                    }
                }
            }

            return ArrayInByte;
        }

        private uint[] ChangeKeytoUint32(Byte[] KEY)
        {
            uint[] key = new uint[4];
            for (int i = 0; i < 4; i++)
            {
                key[i] = BitConverter.ToUInt32(KEY, 4 * i);
            }
            return key;
        }


        private uint[][] ChangeArrayToUInt32()
        {
            int LengthofEncodeArray = _inputArray.Length / 8 + 1;
            int t = _inputArray.Length / 8;
            Byte[] NewArr;
            if (LengthofEncodeArray > t + 1)
            {
                int k = _inputArray.Length % 8;
                int missingBytes = 8 - k;

                NewArr = new Byte[_inputArray.Length + missingBytes];
                for (int i = 0; i < _inputArray.Length; i++)
                {
                    NewArr[i] = _inputArray[i];
                }
                for (int i = 0; i < missingBytes - 1; i++)
                {
                    NewArr[_inputArray.Length + i] = 0x01;
                }

                //в останній байт записуємо число доданих байтів
                NewArr[_inputArray.Length + missingBytes - 1] = (byte)missingBytes;
            }
            else
            {
                NewArr = new Byte[_inputArray.Length + 8];
                for (int i = 0; i < _inputArray.Length; i++)
                {
                    NewArr[i] = _inputArray[i];
                }
                for (int i = 0; i < 7; i++)
                {
                    NewArr[_inputArray.Length + i] = 0x01;
                }

                //в останній байт записуємо число доданих байтів
                NewArr[_inputArray.Length + 7] = 8;
            }

            uint[][] _32xArray = new uint[LengthofEncodeArray][];

            for (int i = 0; i < LengthofEncodeArray; i++)
            {
                _32xArray[i] = new uint[2];
                for (int j = 0; j < 2; j++)
                {
                    _32xArray[i][j] = BitConverter.ToUInt32(NewArr, 8 * i + 4 * j);
                }
            }
            return _32xArray;
        }

        private void Сode(uint[] v, uint[] k)
        {
            uint y = v[0]; uint z = v[1];
            uint sum = 0;
            uint delta = 0x9E3779B9; uint n = 32;
            while (n-- > 0)
            {
                y += (z << 4 ^ z >> 5) + z ^ sum + k[sum & 3];
                sum += delta;
                z += (y << 4 ^ y >> 5) + y ^ sum + k[sum >> 11 & 3];
            }
            v[0] = y; v[1] = z;
        }
    }
}
