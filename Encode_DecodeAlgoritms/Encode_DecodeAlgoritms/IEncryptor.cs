using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Encode_DecodeAlgoritms
{
    public interface IEncryptor
    {
        Byte[] Encrypt(Byte[] data, Byte[] key);
    }
}
