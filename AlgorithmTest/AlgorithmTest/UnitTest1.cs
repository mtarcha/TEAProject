using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Encode_DecodeAlgoritms;
using System.IO;

namespace AlgorithmTest
{
    [TestClass]
    public class UnitTest1
    {

        [TestMethod]
        public void FileTest()
        {
            string pathSource = @"b:\tests\source.txt";
            string pathNew = @"b:\tests\newfile.txt";
            byte[] inputBytes;
            byte[] outputBytes;

            using (FileStream fsSource = new FileStream(pathSource,
            FileMode.Open, FileAccess.Read))
            {
                inputBytes = new byte[fsSource.Length];
                int numBytesToRead = (int)fsSource.Length;
                int numBytesRead = 0;
                while (numBytesToRead > 0)
                {
                    int n = fsSource.Read(inputBytes, numBytesRead, numBytesToRead);

                    if (n == 0)
                        break;

                    numBytesRead += n;
                    numBytesToRead -= n;
                }
                numBytesToRead = inputBytes.Length;

                Byte[] Key = new Byte[16] { 1, 1, 1, 1, 1, 1, 1, 1, 2, 2, 2, 2, 2, 2, 2, 2 };                

                IEncryptor enc = Algorithm.GetEncryptor("TEA");

                Byte[] encoded = enc.Encrypt(inputBytes, Key);

                IDecryptor dec = Algorithm.GetDecryptor("TEA");

                Byte[] decoded = dec.Decrypt(encoded, Key);

                using (FileStream fsNew = new FileStream(pathNew,
                    FileMode.Create, FileAccess.Write))
                {
                    fsNew.Write(decoded, 0, numBytesToRead);
                }
            }
            using (FileStream fssSource = new FileStream(pathNew, FileMode.Open, FileAccess.Read))
            {
                outputBytes = new byte[fssSource.Length];
                int numBytesToRead = (int)fssSource.Length;
                int numBytesRead = 0;
                while (numBytesToRead > 0)
                {
                    int n = fssSource.Read(outputBytes, numBytesRead, numBytesToRead);

                    if (n == 0)
                        break;

                    numBytesRead += n;
                    numBytesToRead -= n;
                }
                numBytesToRead = outputBytes.Length;
            }
            for (int i = 0; i < outputBytes.Length; i++)
            {
                if (inputBytes[i] != outputBytes[i])
                    throw new Exception();
            }

        }

        [TestMethod]
        public void _64xbitArray1()
        {
            Byte[] MyArray = new Byte[8] { 1, 1, 1, 1, 1, 1, 1, 1 };        
            
            Byte[] Key = new Byte[16] { 1, 1, 1, 1, 1, 1, 1, 1, 2, 2, 2, 2, 2, 2, 2, 2 };

            IEncryptor enc = Algorithm.GetEncryptor("TEA");

            Byte[] encoded = enc.Encrypt(MyArray, Key);

            IDecryptor dec = Algorithm.GetDecryptor("TEA");

            Byte[] decoded = dec.Decrypt(encoded, Key);

            for (int i = 0; i < MyArray.Length; i++)
            {
                if (MyArray[i] != decoded[i])
                    throw new Exception();
            }
        }

        [TestMethod]
        public void _64xbitArray2()
        {
            Byte[] MyArray = new Byte[8] { 1, 1, 1, 1, 1, 1, 1, 1 };

            Byte[] Key = new Byte[16] { 1, 1, 1, 1, 1, 1, 1, 1, 2, 2, 2, 2, 2, 2, 2, 2 };

            IEncryptor enc = Algorithm.GetEncryptor("TEA");

            Byte[] encoded = enc.Encrypt(MyArray, Key);

            IDecryptor dec = Algorithm.GetDecryptor("TEA");

            Byte[] decoded = dec.Decrypt(encoded, Key);

            for (int i = 0; i < decoded.Length; i++)
            {
                if (MyArray[i] != decoded[i])
                    throw new Exception();
            }
        }

        [TestMethod]
        public void Less64xbit1()
        {
            Byte[] MyArray = new Byte[7] { 3, 4, 5, 6, 7, 8, 9 };

            Byte[] Key = new Byte[16] { 1, 1, 1, 1, 1, 1, 1, 1, 2, 2, 2, 2, 2, 2, 2, 2 };

            IEncryptor enc = Algorithm.GetEncryptor("TEA");

            Byte[] encoded = enc.Encrypt(MyArray, Key);

            IDecryptor dec = Algorithm.GetDecryptor("TEA");

            Byte[] decoded = dec.Decrypt(encoded, Key);

            for (int i = 0; i < MyArray.Length; i++)
            {
                if (MyArray[i] != decoded[i])
                    throw new Exception();
            }
        }

        [TestMethod]
        public void Less64xbit2()
        {
            Byte[] MyArray = new Byte[7] { 3, 4, 5, 6, 7, 8, 9 };

            Byte[] Key = new Byte[16] { 1, 1, 1, 1, 1, 1, 1, 1, 2, 2, 2, 2, 2, 2, 2, 2 };

            IEncryptor enc = Algorithm.GetEncryptor("TEA");

            Byte[] encoded = enc.Encrypt(MyArray, Key);

            IDecryptor dec = Algorithm.GetDecryptor("TEA");

            Byte[] decoded = dec.Decrypt(encoded, Key);

            for (int i = 0; i < decoded.Length; i++)
            {
                if (MyArray[i] != decoded[i])
                    throw new Exception();
            }
        }
    }
}
