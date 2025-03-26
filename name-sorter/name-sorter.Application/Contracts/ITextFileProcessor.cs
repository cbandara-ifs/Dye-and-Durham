namespace name_sorter.Application.Contracts
{
    public interface ITextFileProcessor
    {
        void Sort(string inputFilePath, string outputFilePath);
    }
}
