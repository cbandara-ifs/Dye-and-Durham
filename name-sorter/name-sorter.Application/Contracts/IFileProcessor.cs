namespace name_sorter.Application.Contracts
{
    public interface IFileProcessor
    {
        Task<IList<string>> SortFileAsync(string inputFilePath);

        Task WriteToFileAsync(string outputFilePath, IList<string> values);

        bool SupportsExtension(string extension);
    }
}
