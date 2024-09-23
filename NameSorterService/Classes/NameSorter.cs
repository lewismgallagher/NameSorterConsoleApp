using NameSorterService.DTOs;
using NameSorterService.Interfaces;
using static System.Net.Mime.MediaTypeNames;

namespace NameSorterService.Classes
{
    public class NameSorter : INameSorter
    {

        public IOrderedEnumerable<FullName> SortNames(List<FullName> unsortedNames)
        {
            return unsortedNames.OrderBy(n => n.LastName).ThenBy(n => n.GivenNames);
        }

        public string RejoinSortedNames(IOrderedEnumerable<FullName> sortedNames)
        {
            string sortedNamesString = "";

            foreach (var item in sortedNames)
            {
               sortedNamesString += item.GivenNames + " " + item.LastName + " \r\n";
            }
            return sortedNamesString;
        }

        public List<FullName> SplitNames(string names)
        {
            List<FullName> formattedFullNames = new List<FullName>();

            string[] namesList = names.Split(new string[] { "\n", "\r\n" }, StringSplitOptions.RemoveEmptyEntries);

            foreach (string name in namesList) {
               var splitName = name.Split(" ");

                string lastName = splitName.Last();      
                
                string givenNames = string.Join(" ", splitName.Take(splitName.Length - 1));

                FullName fullName = new FullName() { LastName = lastName, GivenNames = givenNames };
                 
                formattedFullNames.Add(fullName);
            }

            return formattedFullNames;
        }


    }
}
