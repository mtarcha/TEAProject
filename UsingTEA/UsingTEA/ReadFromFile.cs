using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace UsingTEA
{
    class ReadFromFile
    {
        string fileName;
        Byte[] scannedData;

        public Byte[] Reading(string fileName)
        {
            this.fileName = @fileName;
            using (FileStream fsSource = new FileStream(fileName,
                    FileMode.Open, FileAccess.Read))
            {

                scannedData = new Byte[fsSource.Length];
                int numBytesToRead = (int)fsSource.Length;
                int numBytesRead = 0;
                while (numBytesToRead > 0)
                {
                    int n = fsSource.Read(scannedData, numBytesRead, numBytesToRead);

                    if (n == 0)
                        break;

                    numBytesRead += n;
                    numBytesToRead -= n;
                }
                numBytesToRead = scannedData.Length;
            }
            return scannedData;
        }
    }
}
