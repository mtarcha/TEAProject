using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsingTEA
{
    class ArgsDictionary
    {

        Dictionary<string, string> argDictionary = new Dictionary<string, string>();
        string[] argString;

        public Dictionary<string, string> GetDictionary
        {
            get
            {
                return argDictionary;
            }
        }

        public ArgsDictionary(string[] argString)
        {
            this.argString = argString;
        }

        public void CreateDictionary()
        {
            if (argString[0] == "-e")
            {
                argDictionary.Add("Code", "encoding");
            }
            else
            {
                argDictionary.Add("Code", "decoding");
            }
            for (int i = 0; i < argString.Length; i++)
            {
                
                if (argString[i] == "-input")
                {
                    argDictionary.Add("Input", argString[i + 1]);
                    i = i + 1;
                }
                if (argString[i] == "-output")
                {
                    argDictionary.Add("Output", argString[i + 1]);
                    i = i + 1;
                }
                if (argString[i] == "-key")
                {
                    argDictionary.Add("Key", argString[i + 1]);
                    i = i + 1;
                }
                if (argString[i] == "-data")
                {
                    argDictionary.Add("Data", argString[i + 1]);
                    i = i + 1;
                }
                if (argString[i] == "-name")
                {
                    argDictionary.Add("Name", argString[i + 1]);
                    i = i + 1;
                }
            }
        }
    }
}
