namespace name_sorter.Application.Contracts
{
    public interface IFileReader
    {
        IAsyncEnumerable<string> ReadNamesAsync(string filePath);
    }
}
