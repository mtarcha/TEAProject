using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Encode_DecodeAlgoritms
{
    public static class Algorithm
    {
        public static IEncryptor GetEncryptor(string name)
        {
            if (name == "TEA")
            {
                return new TEAEncryptor();
            }
            else
            {
                throw new Exception("There is not this encode algorithm");
            }
        }

        public static IDecryptor GetDecryptor(string name)
        {
            if (name == "TEA")
            {
                return new TEADecryptor();
            }
            else
            {
                throw new Exception("There is not this decode algorithm");
            }
        }
    }
}
