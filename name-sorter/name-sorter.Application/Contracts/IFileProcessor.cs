namespace name_sorter.Application.Contracts
{
    public interface IFileProcessor
    {
        IList<string> SortFile(string inputFilePath);

        void WriteToFile(string outputFilePath, IList<string> values);

        bool SupportsExtension(string extension);
    }
}
