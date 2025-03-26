using name_sorter.Application.Contracts;

namespace name_sorter.Application.Sort
{
    public class SortingAlgorythms : ISortingAlgorythms
    {
        public IList<string> SortByLastNameAndGivenNames(IEnumerable<string>? names)
        {
            var sortedNames = names
            .Select(name => new { FullName = name, Parts = name.Split(' ') })
            .OrderBy(x => x.Parts.Last(), StringComparer.OrdinalIgnoreCase)
            .ThenBy(x => string.Join(" ", x.Parts.Take(x.Parts.Length - 1)), StringComparer.OrdinalIgnoreCase)
            .Select(x => x.FullName)
            .ToList();

            return sortedNames;
        }
    }
}
