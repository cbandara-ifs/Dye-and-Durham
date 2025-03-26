namespace name_sorter.Application.Contracts
{
    public interface IFilePathGenerator
    {
        string GenerateFilePath(string fileNameWithExtension);
    }
}
