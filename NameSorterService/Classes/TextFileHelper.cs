using NameSorterService.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace NameSorterService.Classes
{
    public class TextFileHelper : ITextFileHelper
    {
        public string ReadTextFile(string fileName)
        {
            try
            {
                if (File.Exists(fileName) == false)
                {
                    throw new FileNotFoundException("Error, File Not Found, Please check the file path and your file / folder permissions.");
                }
                return File.ReadAllText(fileName);
            }
            catch (Exception ex)
            {
                // would have middleware to catch unhandled exceptions and log them
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        public void WriteTextFile(string fileName, string text)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(fileName))
                { throw new ArgumentNullException("Error, Filepath cannot be null"); }

                File.WriteAllText(fileName, text);
            }
            catch (Exception ex)
            {
                // would have middleware to catch unhandled exceptions and log them
                Console.WriteLine(ex.Message);
                throw;
            }
        }

    }
}
