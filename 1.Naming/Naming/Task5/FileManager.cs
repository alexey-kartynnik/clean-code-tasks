using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Microsoft.Extensions.FileProviders;
using Naming.Task5.ThirdParty;

namespace Naming.Task5
{
    public class FileManager
    {
        private static readonly string[] TYPES = {"jpg", "png"};
        private static readonly string[] TYPES2 = {"pdf", "doc"};

        private const string bn = "Naming.Resources";
        private readonly IFileProvider fp = new EmbeddedFileProvider(Assembly.GetExecutingAssembly(), bn);

        public IFileInfo RetrieveFile(string fileName)
        {
            ValidateFileType(fileName);
            return fp.GetFileInfo(fileName);
        }

        #region RetrieveFile

        private static void ValidateFileType(string fileName)
        {
            if (IsInValidFileType(fileName))
            {
                throw new InvalidFileTypeException();
            }
        }

        private static bool IsInValidFileType(string fileName)
        {
            return IsInValidImage(fileName) && IsInValidDocument(fileName);
        }

        private static bool IsInValidImage(string fileName)
        {
            var imageExtensionsPredicate = new FileExtPred(TYPES);
            return !imageExtensionsPredicate.Test(fileName);
        }

        private static bool IsInValidDocument(string fileName)
        {
            var documentExtensionsPredicate = new FileExtPred(TYPES2);
            return !documentExtensionsPredicate.Test(fileName);
        }

        #endregion

        public List<string> ListAllImages()
        {
            return Files(TYPES);
        }

        public List<string> ListAllDocuments()
        {
            return Files(TYPES2);
        }

        private List<string> Files(string[] allowedExtensions)
        {
            var pred = new FileExtPred(allowedExtensions);
            return fp.GetDirectoryContents(string.Empty)
                .Select(f => f.Name)
                .Where(pred.Test)
                .ToList();
        }
    }
}
