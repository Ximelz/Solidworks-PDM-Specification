namespace Solidworks_PDM_Specification
{
    public class RefFile
    {
        public RefFile(string filePath, string level, int count, string configuration)
        {
            Level = level;
            FilePath = filePath;
            Count = count;
            Configuration = configuration;
        }

        public string FilePath;
        public string Level;
        public int Count;
        public string Configuration;
    }
}
