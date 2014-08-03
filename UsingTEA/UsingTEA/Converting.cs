using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsingTEA
{
    class Converting
    {
        string input;
        Byte[] output;

        public Byte[] ConvertStringToByte(string input)
        {
            this.input = input;
            output = new byte[input.Length * sizeof(Char)];
            System.Buffer.BlockCopy(input.ToCharArray(), 0, output, 0, output.Length);
            return output;
        }
    }
}
