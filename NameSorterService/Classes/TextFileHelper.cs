using NameSorterService.Interfaces;


namespace NameSorterService.Classes
{
    public class TextFileHelper : ITextFileHelper
    {
        public string ReadTextFile(string fileName)
        {
            try
            {
                if (File.Exists(fileName))
                {
                    return File.ReadAllText(fileName);
                }
                else
                {
                    throw new FileNotFoundException("Error, File Not Found, Please check the file path and your file / folder permissions.");
                }
            }
            catch (Exception ex)
            {
                ExceptionLogger.LogException(ex);
                throw;
            }
        }

        public void WriteTextFile(string fileName, string text)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(fileName) == false)
                {
                    File.WriteAllText(fileName, text);
                }
                else
                {
                    throw new ArgumentNullException("Error, Filepath cannot be null");
                }
            }
            catch (Exception ex)
            {
                ExceptionLogger.LogException(ex);
                throw;
            }
        }



    }
}
