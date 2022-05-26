using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solidworks_PDM_Specification
{
    public class RefFile
    {
        public RefFile(string filePath, string level)
        {
            Level = level;
            FilePath = filePath;
        }

        public string FilePath;
        public string Level;
    }
}
