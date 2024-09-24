using System;


namespace NameSorterService.Interfaces
{
    public interface ITextFileHelper
    {
        public string ReadTextFile(string fileName);

        public void WriteTextFile(string fileName, string text);
    }
}
