using name_sorter.Application.Contracts;

namespace name_sorter.Application.Sort
{
    public class SortingAlgorythms : ISortingAlgorythms
    {
        public async Task<IList<string>> SortByLastNameAndGivenNames(IAsyncEnumerable<string>? names)
        {
            var nameList = new List<string>();

            if (names is null)
            {
                return nameList;
            }

            await foreach (var name in names)
            {
                nameList.Add(name);
            }

            var sortedNames = nameList
            .Select(name => new { FullName = name, Parts = name.Split(' ') })
            .OrderBy(x => x.Parts.Last(), StringComparer.OrdinalIgnoreCase)
            .ThenBy(x => string.Join(" ", x.Parts.Take(x.Parts.Length - 1)), StringComparer.OrdinalIgnoreCase)
            .Select(x => x.FullName)
            .ToList();

            return sortedNames;
        }
    }
}
