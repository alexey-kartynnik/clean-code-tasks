using System.Linq;
using Naming.Task5.ThirdParty;

namespace Naming.Task5
{
    public class FileExtPred : IPredicate<string>
    {
        private readonly string[] extns;

        public FileExtPred(string[] extns)
        {
            this.extns = extns;
        }

        public bool Test(string fileName)
        {
            fileName = fileName.ToLower();
            return extns.Any(fileName.EndsWith);
        }
    }
}
