using NameSorterService.DTOs;
using NameSorterService.Interfaces;

namespace NameSorterService.Classes
{
    public class NameSorter : INameSorter
    {

        public IOrderedEnumerable<FullName> SortNames(List<FullName> unsortedNames)
        {
            try
            {
                if (unsortedNames.Count > 0)
                {
                    return unsortedNames.OrderBy(n => n.LastName).ThenBy(n => n.GivenNames);
                }
                else
                {
                    throw new ArgumentNullException("Error, There are no names in the list to sort");
                }
            }
            catch (Exception ex)
            {
                ExceptionLogger.LogException(ex);
                throw;
            }
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

            foreach (string name in namesList)
            {
                var splitName = name.Split(" ");

                //In spec stated you should only be able to have 3 given names
                if (splitName.Length >= 5 || splitName.Length <= 1) { continue; }

                string lastName = splitName.Last();

                string givenNames = string.Join(" ", splitName.Take(splitName.Length - 1));

                FullName fullName = new FullName() { LastName = lastName, GivenNames = givenNames };

                formattedFullNames.Add(fullName);
            }

            return formattedFullNames;
        }


    }
}
