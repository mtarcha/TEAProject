using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Encode_DecodeAlgoritms;

namespace UsingTEA
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> argDictionary = new Dictionary<string, string>();

            if (args.Length > 0)
            {
                ArgsDictionary ard = new ArgsDictionary(args);
                ard.CreateDictionary();
                argDictionary = ard.GetDictionary;
            }

            ReadFromFile redFile = new ReadFromFile();
            Converting pars = new Converting();
            WriteToFile wrfile = new WriteToFile();

            if (args.Length == 0)
            {
                Console.WriteLine("Please, input name of file whith data for encription");
                string fileName = Console.ReadLine();
                Console.WriteLine("Please, input (16-symboll) key for encription");
                string stringKey = Console.ReadLine();

                Byte[] input = redFile.Reading(fileName);
                Byte[] key = pars.ConvertStringToByte(stringKey);

                IEncryptor enc = Algorithm.GetEncryptor("TEA");
                Byte[] encoded = enc.Encrypt(input, key);

                Console.WriteLine("Please, input name of file for encription data");
                string newfileName = Console.ReadLine();

                wrfile.Writing(newfileName, encoded);
            }

            if (argDictionary.ContainsKey("Input"))
            {
                string fileName = argDictionary["Input"];
                string newfileName = argDictionary["Output"];                
                Byte[] input = redFile.Reading(fileName);
                Byte[] encoded;
                Byte[] decoded;
                string strKey = argDictionary["Key"];
                Byte[] key = pars.ConvertStringToByte(strKey);

                if (strKey.Length == 16)
                {

                    key = pars.ConvertStringToByte(strKey);
                }
                else
                {
                    System.Console.WriteLine("Please,enter the 16-symbol key");
                    return;
                }

                if (argDictionary["Code"] == "encoding")
                {                
                    IEncryptor enc = Algorithm.GetEncryptor(argDictionary["Name"]);
                    encoded = enc.Encrypt(input, key);
                    wrfile.Writing(newfileName, encoded);

                }
                else
                {
                    IDecryptor dec = Algorithm.GetDecryptor(argDictionary["Name"]);
                    decoded = dec.Decrypt(input, key);
                    wrfile.Writing(newfileName, decoded);
                }
            }
            
            if (argDictionary.ContainsKey("Data"))
            {

                Byte[] input = pars.ConvertStringToByte(argDictionary["Data"]);
                Byte[] encoded;
                Byte[] decoded;
                string strKey = argDictionary["Key"];
                Byte[] key = pars.ConvertStringToByte(strKey);

                if (strKey.Length == 16)
                {

                    key = pars.ConvertStringToByte(strKey);
                }
                else
                {
                    System.Console.WriteLine("Please,enter the 16-symbol key");
                    return;
                }

                if (argDictionary["Code"] == "encoding")
                {
                    IEncryptor enc = Algorithm.GetEncryptor(argDictionary["Name"]);
                    encoded = enc.Encrypt(input, key);
                    char[] encodedInChar=new Char[encoded.Length];
                    for (int i = 0; i < encoded.Length; i++)
                    {
                       encodedInChar[i] = (char)encoded[i];
                    }   
                 
                    for (int i = 0; i < encoded.Length; i++)
                    {
                        System.Console.WriteLine(encodedInChar[i]);
                    }
                    /*string myfile = @"b:\tests\myfile3.txt";
                    wrfile.Writing(myfile, encoded);*/

                }
                else
                {
                    IDecryptor dec = Algorithm.GetDecryptor(argDictionary["Name"]);
                    decoded = dec.Decrypt(input, key);
                    for (int i = 0; i < decoded.Length; i++)
                    {
                        System.Console.WriteLine(decoded[i]);
                    }
                }
            }

        }
    }
}
