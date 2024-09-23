using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NameSorterService.Interfaces
{
    public interface ITextFileHelper
    {
        public string ReadTextFile(string fileName);

        public void WriteTextFile(string fileName, string text);
    }
}
