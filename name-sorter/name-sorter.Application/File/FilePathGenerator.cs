using name_sorter.Application.Contracts;

namespace name_sorter.Application.File
{
    public class FilePathGenerator : IFilePathGenerator
    {
        public string GenerateFilePath(string fileNameWithExtension)
        {
            return Path.Combine(Directory.GetCurrentDirectory(), fileNameWithExtension);
        }
    }
}
