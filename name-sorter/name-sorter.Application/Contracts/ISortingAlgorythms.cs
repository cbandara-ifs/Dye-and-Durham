namespace name_sorter.Application.Contracts
{
    public interface ISortingAlgorythms
    {
        IList<string> SortByLastNameAndGivenNames(IEnumerable<string>? names);
    }
}
