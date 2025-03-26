using name_sorter.Application.Contracts;

namespace name_sorter.Application.File.TextFile
{
    public class TextFileActions : IFileWriter, IFileReader
    {
        public IEnumerable<string> ReadNames(string filePath)
        {
            using var reader = new StreamReader(filePath);
            string? line;
            while ((line = reader.ReadLine()) != null)
            {
                yield return line;
            }
        }

        public void WriteNames(string filePath, IList<string> names)
        {
            using var outputStreamWriter = new StreamWriter(filePath);

            foreach (var name in names)
            {
                outputStreamWriter.WriteLine(name);
            }
        }
    }
}
