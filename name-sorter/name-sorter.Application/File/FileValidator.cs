using name_sorter.Application.Contracts;
using static System.Console;

namespace name_sorter.Application.File
{
    public class FileValidator : IFileValidator
    {
        public bool ValidateFileExists(string filePath)
        {
            if (!System.IO.File.Exists(filePath))
            {
                WriteLine($"ERROR: file {filePath} does not exist.");
                return false;
            }
            return true;
        }
    }
}
