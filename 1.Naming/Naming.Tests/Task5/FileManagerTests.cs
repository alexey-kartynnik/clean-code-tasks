using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Naming.Task5.ThirdParty;

namespace Naming.Task5
{
    [TestClass]
    public class FileManagerTests
    {
        private readonly FileManager fileManager = new FileManager();

        [TestMethod]
        public void Should_ListAllImageFiles()
        {
            List<string> imageList = fileManager.ListAllImages();
            Assert.IsNotNull(imageList);
            Assert.AreEqual(1, imageList.Count);
            Assert.AreEqual("epam.png", imageList[0]);
        }

        [TestMethod]
        public void Should_ListAllDocuments()
        {
            List<string> docList = fileManager.ListAllDocuments();
            Assert.IsNotNull(docList);
            Assert.AreEqual(1, docList.Count);
            Assert.AreEqual("epam.doc", docList[0]);
        }

        [TestMethod]
        public void Should_RetrieveFile_When_ValidImage()
        {
            var file = fileManager.RetrieveFile("epam.png");
            Assert.IsTrue(file.Exists);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidFileTypeException))]
        public void Should_ThrowException_When_UnsupportedImageType()
        {
            fileManager.RetrieveFile("invalidfile.img");
        }

        [TestMethod]
        public void Should_ReturnEmpty_When_NoImageExists()
        {
            var file = fileManager.RetrieveFile("nofile.png");
            Assert.IsFalse(file.Exists);
        }

        [TestMethod]
        public void Should_RetrieveFile_When_ValidDocument()
        {
            var file = fileManager.RetrieveFile("epam.doc");
            Assert.IsNotNull(file.Exists);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidFileTypeException))]
        public void Should_ThrowException_When_UnsupportedDocType()
        {
            fileManager.RetrieveFile("invalidfile.cs");
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidFileTypeException))]
        public void Should_ThrowException_When_RetrieveFileWithNoExtension()
        {
            fileManager.RetrieveFile("noExtension");
        }

        [TestMethod]
        public void Should_ReturnEmpty_When_NoDocumentExists()
        {
            var file = fileManager.RetrieveFile("nofile.pdf");
            Assert.IsFalse(file.Exists);
        }
    }
}
