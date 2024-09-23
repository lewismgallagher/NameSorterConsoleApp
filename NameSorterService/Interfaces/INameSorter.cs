using NameSorterService.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NameSorterService.Interfaces
{
    public interface INameSorter
    {
        public IOrderedEnumerable<FullName> SortNames(List<FullName> unsortedNames);

        public List<FullName> SplitNames(string names);

        public string RejoinSortedNames(IOrderedEnumerable<FullName> sortedNames);
    }
}
