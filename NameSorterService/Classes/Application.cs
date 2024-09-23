using NameSorterService.DTOs;
using NameSorterService.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NameSorterService.Classes
{
    public class Application :IApplication
    {
        private readonly INameSorter _nameSorter;
        private readonly ITextFileHelper _textFileHelper;
        public Application(INameSorter nameSorter, ITextFileHelper textFileHelper)
        {
            _nameSorter = nameSorter;
            _textFileHelper = textFileHelper;
        }

        public void StartSortNamesProcess()
        {
            var inputPath = Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), @"..\..\..\", "unsorted-names-list.txt"));
            string namesFromFile = _textFileHelper.ReadTextFile(inputPath);

            IOrderedEnumerable<FullName> sortedNames = _nameSorter.SortNames(_nameSorter.SplitNames(namesFromFile));
            string rejoinedSortedNames = _nameSorter.RejoinSortedNames(sortedNames);

            var outputPath = Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), @"..\..\..\", "sorted-names-list.txt"));
            _textFileHelper.WriteTextFile(outputPath, rejoinedSortedNames);

            Console.WriteLine(rejoinedSortedNames);
        }
    }
}
