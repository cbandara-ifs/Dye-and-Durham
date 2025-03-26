using name_sorter.Application.Contracts;

namespace name_sorter.Application.File.TextFile
{
    public class TextFileProcessor : IFileProcessor
    {
        private readonly IFileReader _fileReader;
        private readonly IFileWriter _fileWriter;
        private readonly ISortingAlgorythms _sortingAlgorythms;

        public TextFileProcessor(IFileReader fileReader, IFileWriter fileWriter, ISortingAlgorythms sortingAlgorythms)
        {
            _fileReader = fileReader;
            _fileWriter = fileWriter;
            _sortingAlgorythms = sortingAlgorythms;
        }
        public bool SupportsExtension(string extension) => extension.Equals(".txt", StringComparison.OrdinalIgnoreCase);

        public IList<string> SortFile(string inputFilePath)
        {
            var names = _fileReader.ReadNames(inputFilePath);
            return _sortingAlgorythms.SortByLastNameAndGivenNames(names);
        }

        public void WriteToFile(string outputFilePath, IList<string> values)
        {
            _fileWriter.WriteNames(outputFilePath, values);
        }
    }
}
