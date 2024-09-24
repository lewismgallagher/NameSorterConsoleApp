using NameSorterService.Classes;
using NameSorterService.DTOs;

namespace NameSorterTests
{
    public class NameSorterTests
    {
        private readonly NameSorter _sut;
        public NameSorterTests()
        {
            _sut = new NameSorter();
        }

        [Fact]
        public void RejoinSortedNamesTest()
        {
            string names = "Ashlin Kaylan Nelson\r\nKamren Tyreek Zephyr Molina\r\nPearl Kelley Lara";

            List<FullName> fullNames = new List<FullName>();

            fullNames = _sut.SplitNames(names);

            var sortedNames = _sut.SortNames(fullNames);

            string rejoinedSortedNamesString = _sut.RejoinSortedNames(sortedNames);

            Assert.Equal("Pearl Kelley Lara \r\nKamren Tyreek Zephyr Molina \r\nAshlin Kaylan Nelson \r\n", rejoinedSortedNamesString);
        }

        [Fact]
        public void SortNamesTest()
        {
            string names = "Ashlin Kaylan Nelson\r\nKamren Tyreek Zephyr Molina\r\nPearl Kelley Lara";

            List<FullName> fullNames = new List<FullName>();

            fullNames = _sut.SplitNames(names);

            var sortedNames = _sut.SortNames(fullNames);

            Assert.True(sortedNames.First().LastName == "Lara");
            Assert.True(sortedNames.Last().LastName == "Nelson");
        }

        // Spec didn't detail this scenario
        [Fact]
        public void SortNamesWithMissingGivenNamesTest()
        {
            string names = "Nelson\r\nMolina\r\nLara";

            List<FullName> fullNames = new List<FullName>();

            fullNames = _sut.SplitNames(names);

            var sortedNames = _sut.SortNames(fullNames);

            Assert.True(sortedNames.First().LastName == "Lara");
            Assert.True(sortedNames.Last().LastName == "Nelson");
        }

        [Fact]
        public void SplitNamesTest()
        {
            string names = "Ashlin Kaylan Nelson\r\nKamren Tyreek Zephyr Molina\r\nPearl Kelley Lara";

            List<FullName> fullNames = new List<FullName>();

            fullNames = _sut.SplitNames(names);

            Assert.Contains(fullNames.Select(y => y.LastName), x => x == "Nelson");
            Assert.Contains(fullNames.Select(y => y.LastName), x => x == "Molina");
            Assert.Contains(fullNames.Select(y => y.LastName), x => x == "Lara");

            Assert.Contains(fullNames.Select(y => y.GivenNames), x => x == "Ashlin Kaylan");
            Assert.Contains(fullNames.Select(y => y.GivenNames), x => x == "Kamren Tyreek Zephyr");
            Assert.Contains(fullNames.Select(y => y.GivenNames), x => x == "Pearl Kelley");
        }


        // Spec didn't detail this scenario
        [Fact]
        public void SplitNamesWithMissingGivenNamesTest()
        {
            string names = "Nelson\r\nMolina\r\nLara";

            List<FullName> fullNames = new List<FullName>();

            fullNames = _sut.SplitNames(names);
            Assert.True(fullNames.All(x => x.GivenNames == ""));
            Assert.Contains(fullNames.Select(y => y.LastName), x => x == "Nelson");
            Assert.Contains(fullNames.Select(y => y.LastName), x => x == "Molina");
            Assert.Contains(fullNames.Select(y => y.LastName), x => x == "Lara");
        }

        [Fact]
        public void SplitNamesWithMoreThan3GivenNamesTest()
        {
            string names = "Ashlin Kaylan Wendy Smith Nelson\r\nKamren Tyreek Josephine Zephyr Abigail Molina\r\nPearl Kelley Tilly Maeva Lara";

            List<FullName> fullNames = new List<FullName>();

            fullNames = _sut.SplitNames(names);
            Assert.True(fullNames.Count == 0);
        }

    }
}