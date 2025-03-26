using name_sorter.Application.Contracts;
using static System.Console;

namespace name_sorter.Application.File
{
    public class FileProcessor
    {
        private readonly IEnumerable<IFileProcessor> _fileProcessors;
        private readonly IFileValidator _fileValidator;
        private readonly IFilePathGenerator _filePathGenerator;

        public FileProcessor(IEnumerable<IFileProcessor> fileProcessors, IFileValidator fileValidator, IFilePathGenerator filePathGenerator)
        {
            _fileProcessors = fileProcessors;
            _fileValidator = fileValidator;
            _filePathGenerator = filePathGenerator;
        }
        public async Task ProcessFileAsync(string inputFilePath)
        {
            WriteLine($"Begin process of {inputFilePath}");

            if (!_fileValidator.ValidateFileExists(inputFilePath))
            {
                return;
            }

            string extension = Path.GetExtension(inputFilePath);

            string outputFilePath = _filePathGenerator.GenerateFilePath("sorted-names-list.txt");

            var processor = _fileProcessors.FirstOrDefault(p => p.SupportsExtension(extension));

            if (processor != null)
            {
                var sortedNames = await processor.SortFileAsync(inputFilePath);
                await processor.WriteToFileAsync(outputFilePath, sortedNames);
                PrintToConsole(sortedNames);
            }
            else
            {
                WriteLine($"{extension} is an unsupported file type.");
            }
        }

        private void PrintToConsole(IList<string> values)
        {
            foreach (var value in values)
            {
                WriteLine(value);
            }
        }
    }
}
