namespace name_sorter.Application.Contracts
{
    public interface ISortingAlgorythms
    {
        Task<IList<string>> SortByLastNameAndGivenNames(IAsyncEnumerable<string>? names);
    }
}
