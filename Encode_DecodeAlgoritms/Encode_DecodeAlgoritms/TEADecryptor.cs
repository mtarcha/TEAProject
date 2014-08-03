using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Encode_DecodeAlgoritms
{
    public class TEADecryptor:IDecryptor
    {
        Byte[] _inputArray;
        uint[] _key = new uint[4];
        Byte[] _outputArray;

        //в останній байт вхідного масиву, перед кодуванням було записано число доданих елементів
        // після декодування треба буде вилучити ці байти, в наступне число записуємо їхню кількість
        int sizeofsuperfluous;
        
        public Byte[] Decrypt(Byte[] data, Byte[] key)
        {
            _inputArray = data;
            _key = ChangeKeytoUint32(key);
            uint[][] Array2xInt32 = this.ChangeArray();

            int lengthOfInputArrayInByte = (int)Math.Ceiling(_inputArray.Length / 8.0);
            for (int i = 0; i < lengthOfInputArrayInByte; i++)
            {
                Сode(Array2xInt32[i], _key);
            }

            Byte[] _tempArray = this.ReturnArrayToByte(Array2xInt32);

            //зчитуємо з останнього декодованого байту число доданих байтів
            // при кодуванні
            sizeofsuperfluous = _tempArray[_tempArray.Length - 1];

            _outputArray = new Byte[_tempArray.Length - sizeofsuperfluous];
            for (int i = 0; i < _tempArray.Length - sizeofsuperfluous; i++)
            {
                _outputArray[i] = _tempArray[i];
            }
            return _outputArray;

        }


        private Byte[] ReturnArrayToByte(uint[][] NewArray)
        {
            int n = (int)Math.Ceiling(_inputArray.Length / 8.0);
            //int k = _inputArray.Length % 8;
            //int m = 8 - k;
            Byte[] ArrayInByte = new Byte[_inputArray.Length];
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


        private uint[][] ChangeArray()
        {
            int n = (int)Math.Ceiling(_inputArray.Length / 8.0);

            uint[][] _32xArray = new uint[n][];

            for (int i = 0; i < n; i++)
            {
                _32xArray[i] = new uint[2];
                for (int j = 0; j < 2; j++)
                {
                    _32xArray[i][j] = BitConverter.ToUInt32(_inputArray, 8 * i + 4 * j);
                }
            }
            return _32xArray;
        }

        private void Сode(uint[] v, uint[] k)
        {
            uint n = 32;
            uint sum;
            uint y = v[0];
            uint z = v[1];
            uint delta = 0x9e3779b9;

            sum = delta << 5;

            while (n-- > 0)
            {
                z -= (y << 4 ^ y >> 5) + y ^ sum + k[sum >> 11 & 3];
                sum -= delta;
                y -= (z << 4 ^ z >> 5) + z ^ sum + k[sum & 3];
            }

            v[0] = y;
            v[1] = z;
        }
    }
}
