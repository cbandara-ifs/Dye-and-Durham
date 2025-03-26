using name_sorter.Application.Contracts;

namespace name_sorter.Application.File.TextFile
{
    public class TextFileActions : IFileWriter, IFileReader
    {
        public async IAsyncEnumerable<string> ReadNamesAsync(string filePath)
        {
            using var reader = new StreamReader(filePath);
            string? line;
            while ((line = await reader.ReadLineAsync()) != null)
            {
                yield return line;
            }
        }

        public async Task WriteNamesAsync(string filePath, IList<string> names)
        {
            using var outputStreamWriter = new StreamWriter(filePath);

            foreach (var name in names)
            {
                await outputStreamWriter.WriteLineAsync(name);
            }
        }
    }
}
