using name_sorter.Application.Contracts;
using name_sorter.Application.File;

namespace name_sorter
{
    public class App
    {
        private readonly FileProcessor _fileProcessor;

        public App(FileProcessor fileProcessor)
        {
            _fileProcessor = fileProcessor;
        }

        public void Run(string[] args) 
        {
            if (args.Length == 0)
            {
                Console.WriteLine("ERROR: No input file provided.");
                return;
            }

            string inputFile = args[0];

            _fileProcessor.ProcessFile(inputFile);
        }
    }
}
