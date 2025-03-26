using name_sorter.Application.Sort;

namespace name_sorter.Tests.Sort
{
    public class SortingAlgorythmsTests
    {
        private readonly SortingAlgorythms _sut;

        public SortingAlgorythmsTests()
        {
            _sut = new SortingAlgorythms();
        }

        [Fact]
        public void SortByLastNameAndGivenNames_NonEmptyList_ShouldReturnSortedNames()
        {
            IEnumerable<string> unsortedNames = new List<string>()
            {
                "Janet Parsons", "Vaughn Lewis", "Hunter Uriah Mathew Clarke", "Marin Alvarez"
            };

            IList<string> expectedResult = new List<string>()
            {
                "Marin Alvarez", "Hunter Uriah Mathew Clarke", "Vaughn Lewis", "Janet Parsons"
            };

            var result = _sut.SortByLastNameAndGivenNames(unsortedNames);

            Assert.Equal(expectedResult, result);
        }
    }
}
