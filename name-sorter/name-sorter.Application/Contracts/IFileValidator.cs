namespace name_sorter.Application.Contracts
{
    public interface IFileValidator
    {
        bool ValidateFileExists(string inputFilePath);
    }
}
