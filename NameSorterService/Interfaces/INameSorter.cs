using NameSorterService.DTOs;

namespace NameSorterService.Interfaces
{
    public interface INameSorter
    {
        public IOrderedEnumerable<FullName> SortNames(List<FullName> unsortedNames);

        public List<FullName> SplitNames(string names);

        public string RejoinSortedNames(IOrderedEnumerable<FullName> sortedNames);
    }
}
