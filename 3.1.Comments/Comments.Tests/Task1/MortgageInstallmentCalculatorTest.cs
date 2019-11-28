using Comments.Task1.ThirdParty;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Comments.Task1
{
    [TestClass]
    public class MortgageInstallmentCalculatorTest
    {
        [TestMethod]
        public void ShouldCalculateMonthlyPaymentWhenInputValid()
        {
            var monthlyPaymentAmount = MortgageInstallmentCalculator.CalculateMonthlyPayment(1000, 1, 12);
            Assert.AreEqual(88.8487886783416d, monthlyPaymentAmount, 0.01d);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidInputException))]
        public void ShouldThrowInvalidInputExceptionOnNegativeTenure()
        {
            MortgageInstallmentCalculator.CalculateMonthlyPayment(-20, 1, 14.5);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidInputException))]
        public void ShouldThrowInvalidInputExceptionOnNegativeInterestRate()
        {
            MortgageInstallmentCalculator.CalculateMonthlyPayment(20, 1, -12);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidInputException))]
        public void ShouldThrowInvalidInputExceptionOnNegativePrincipalAmount()
        {
            MortgageInstallmentCalculator.CalculateMonthlyPayment(20, -10, 14.5);
        }
    }
}
