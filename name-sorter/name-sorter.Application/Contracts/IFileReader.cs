namespace name_sorter.Application.Contracts
{
    public interface IFileReader
    {
        IEnumerable<string> ReadNames(string filePath);
    }
}
