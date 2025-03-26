namespace name_sorter.Application.Contracts
{
    public interface IFileWriter
    {
        void WriteNames(string filePath, IList<string> names);
    }
}
