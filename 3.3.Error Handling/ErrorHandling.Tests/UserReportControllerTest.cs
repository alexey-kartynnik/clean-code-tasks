using System;
using System.Collections.Generic;
using ErrorHandling.stubs;
using ErrorHandling.Task1;
using ErrorHandling.Task1.ThirdParty;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ErrorHandling
{
    [TestClass]
    public class UserReportControllerTest
    {
        private UserReportController userReportController = new UserReportController();
        private readonly UserReportBuilder userReportBuilder = new UserReportBuilder();

        [TestInitialize]
        public void SetUp()
        {
            userReportController.SetUserReportBuilder(userReportBuilder);
            userReportBuilder.SetUserDao(new UserDaoStub());
        }


        [TestMethod]
        public void ShouldCalculateSumOfAllSubmittedOrders()
        {

            IModel model = new ModelStub();
            string amount = userReportController.GetUserTotalOrderAmountView("123", model);

            Assert.AreEqual("userTotal", amount);
            Assert.AreEqual(String.Format("User Total: {0}$", 363.15), model.GetAttribute("userTotalMessage"));
        }

        [TestMethod]
        public void ShouldGetWarningMessageWhenUserDoesntExist()
        {
            IModel model = new ModelStub();
            String amount = userReportController.GetUserTotalOrderAmountView("0001", model);

            Assert.AreEqual("userTotal", amount);
            Assert.AreEqual("WARNING: User ID doesn't exist.", model.GetAttribute("userTotalMessage"));
        }

        [TestMethod]
        public void ShouldGetErrorMessageWhenOrderHaveNegativeAmount()
        {
            userReportController.GetUserReportBuilder().GetUserDao().GetUser("123").GetAllOrders().Add(new SubmittedNegativeOrderStub());


            IModel model = new ModelStub();
            String amount = userReportController.GetUserTotalOrderAmountView("123", model);

            Assert.AreEqual("userTotal", amount);
            Assert.AreEqual("ERROR: Wrong order amount.", model.GetAttribute("userTotalMessage"));
        }


        [TestMethod]
        public void ShouldGetWarningMessageWhenUserHaveNoSubmittedOrders()
        {

            userReportController.GetUserReportBuilder().GetUserDao().GetUser("123").GetAllOrders().Clear();

            IModel model = new ModelStub();
            String amount = userReportController.GetUserTotalOrderAmountView("123", model);

            Assert.AreEqual("userTotal", amount);
            Assert.AreEqual("WARNING: User have no submitted orders.", model.GetAttribute("userTotalMessage"));
        }

        [TestMethod]
        public void ShouldRedirectToErrorPageWhenConnectionToDbIsNull()
        {

            userReportBuilder.SetUserDao(null);

            String amount = userReportController.GetUserTotalOrderAmountView("123", new ModelStub());

            Assert.AreEqual("technicalError", amount);
        }
    };
}
