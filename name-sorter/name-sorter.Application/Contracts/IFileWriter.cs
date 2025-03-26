namespace name_sorter.Application.Contracts
{
    public interface IFileWriter
    {
        Task WriteNamesAsync(string filePath, IList<string> names);
    }
}
