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

        public async Task<IList<string>> SortFileAsync(string inputFilePath)
        {
            var names = _fileReader.ReadNamesAsync(inputFilePath);
            return await _sortingAlgorythms.SortByLastNameAndGivenNames(names);
        }

        public async Task WriteToFileAsync(string outputFilePath, IList<string> values)
        {
            await _fileWriter.WriteNamesAsync(outputFilePath, values);
        }
    }
}
