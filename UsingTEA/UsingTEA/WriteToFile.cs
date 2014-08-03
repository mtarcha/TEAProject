using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace UsingTEA
{
    class WriteToFile
    {
        string fileName;
        Byte[] scannedData;

        public void Writing(string fileName, Byte[] scannedData)
        {
            this.fileName = @fileName;
            this.scannedData = scannedData;
            using (FileStream fsNew = new FileStream(fileName, FileMode.Create, FileAccess.Write))
            {
                fsNew.Write(scannedData, 0, scannedData.Length);
            }
        }
    }
}
