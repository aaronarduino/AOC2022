namespace day1.Services
{
    public class FileReader
    {
        private string BasePath { get; set; }
        private string InputFileName { get; set; }
        private string TestFileName { get; set; }

        public FileReader(string basePath, string inputFileName, string testFileName)
        {
            BasePath = basePath;
            InputFileName = inputFileName;
            TestFileName = testFileName;
        }

        public string? ReadAll(bool test = false)
        {
            string? text = "";

            try
            {
                if (test)
                {
                    text = File.ReadAllText(BasePath + TestFileName);
                }
                else
                {
                    text = File.ReadAllText(BasePath + InputFileName);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                text = null;
            }

            return text;
        }

        public List<string>? ReadLines(bool test = false)
        {
            List<string>? text = null;

            try
            {
                if (test)
                {
                    text = File.ReadLines(BasePath + TestFileName).ToList();
                }
                else
                {
                    text = File.ReadLines(BasePath + InputFileName).ToList();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                text = null;
            }

            return text;
        }
    }
}

