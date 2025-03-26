namespace name_sorter.Tests
{
    public static class Utility
    {
        public static async IAsyncEnumerable<string> GetAsyncEnumerable(IEnumerable<string> names)
        {
            foreach (var name in names)
            {
                yield return name;
                await Task.Yield();
            }
        }
    }
}
