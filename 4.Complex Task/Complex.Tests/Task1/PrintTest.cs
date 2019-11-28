using System;
using System.Collections.Generic;
using Complex.Task1.ThirdParty;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Complex.Task1
{
    [TestClass]
    public class PrintTest
    {
        private readonly IDataSet dataSet = new DataSet();
        private ICommand command;
        private IDatabaseManager manager;
        private IView view;

        [TestInitialize]
        public void SetUp()
        {
            manager = Mock.Of<IDatabaseManager>();
            view = Mock.Of<IView>();
            command = new Print(view, manager);
        }

        [TestMethod]
        public void ShouldPrintTableWithOneColumn()
        {
            //given
            dataSet.Put("id", 1);
            PrepareSingleResult();
            //when
            command.Process("print test");
            //then
            AssertPrinted("╔════╗\n" +
                          "║ id ║\n" +
                          "╠════╣\n" +
                          "║ 1  ║\n" +
                          "╚════╝\n");
        }

        [TestMethod]
        public void ShouldPrintTableWithPaddingWhenOneShortColumn()
        {
            //given
            dataSet.Put("i", 1);
            PrepareSingleResult();
            //when
            command.Process("print test");
            //then
            AssertPrinted("╔════╗\n" +
                          "║ i  ║\n" +
                          "╠════╣\n" +
                          "║ 1  ║\n" +
                          "╚════╝\n");
        }

        [TestMethod]
        public void ShouldPrintAllColumnLengthsWithTheLongestValue()
        {
            //given
            dataSet.Put("i", 1);
            dataSet.Put("j", 1234567890);
            PrepareSingleResult();
            //when
            command.Process("print test");
            //then
            AssertPrinted("╔════════════╦════════════╗\n" +
                          "║     i      ║     j      ║\n" +
                          "╠════════════╬════════════╣\n" +
                          "║     1      ║ 1234567890 ║\n" +
                          "╚════════════╩════════════╝\n");
        }

        [TestMethod]
        public void ShouldPrintMessageForNotExistingTable()
        {
            //given
            Mock.Get(manager).Setup(p => p.GetTableData("testing")).Returns(new List<IDataSet>());
            //when
            command.Process("print testing");
            //then
            AssertPrinted("╔════════════════════════════════════════════╗\n" +
                          "║ Table 'testing' is empty or does not exist ║\n" +
                          "╚════════════════════════════════════════════╝\n");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ShouldTrowExceptionWhenCommandIsWrong()
        {
            command.Process("print");
        }

        [TestMethod]
        public void ShouldProcessValidCommand()
        {
            //when
            var canProcess = command.CanProcess("print test");
            //then
            Assert.IsTrue(canProcess);
        }

        [TestMethod]
        public void ShouldNotProcessInvalidCommand()
        {
            //when
            var canProcess = command.CanProcess("qwe");
            //then
            Assert.IsFalse(canProcess);
        }

        [TestMethod]
        public void ShouldPrintTableWithMultiDataSets()
        {
            //given
            CreateUserDataSets(CreateUser(1, "Steven Seagal", "123456"), CreateUser(2, "Eva Song", "789456"));
            //when
            command.Process("print users");
            //then
            AssertPrinted("╔════════════════╦════════════════╦════════════════╗\n" +
                          "║       id       ║      name      ║    password    ║\n" +
                          "╠════════════════╬════════════════╬════════════════╣\n" +
                          "║       1        ║ Steven Seagal  ║     123456     ║\n" +
                          "╠════════════════╬════════════════╬════════════════╣\n" +
                          "║       2        ║    Eva Song    ║     789456     ║\n" +
                          "╚════════════════╩════════════════╩════════════════╝\n");
        }


        private void CreateUserDataSets(params IDataSet[] users)
        {
            IList<IDataSet> dataSets = new List<IDataSet>();
            foreach (var usersSet in users)
                dataSets.Add(usersSet);
            Mock.Get(manager).Setup(p => p.GetTableData("users")).Returns(dataSets);
        }

        private IDataSet CreateUser(int id, string name, string password)
        {
            var user = new DataSet();
            user.Put("id", id);
            user.Put("name", name);
            user.Put("password", password);
            return user;
        }

        private void PrepareSingleResult()
        {
            IList<IDataSet> dataSets = new List<IDataSet>();
            dataSets.Add(dataSet);
            Mock.Get(manager).Setup(p => p.GetTableData("test")).Returns(dataSets);
        }


        private void AssertPrinted(string expected)
        {
            Mock.Get(view).Verify(p => p.Write(expected), () => Times.AtLeast(1));
        }
    }
}