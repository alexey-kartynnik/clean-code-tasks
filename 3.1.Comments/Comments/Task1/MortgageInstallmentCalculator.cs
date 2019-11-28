using System;
using Comments.Task1.ThirdParty;

namespace Comments.Task1
{
    public static class MortgageInstallmentCalculator
    {
        /// <summary>
        ///     Calculates Monthly Payment
        /// </summary>
        /// <param name="p">p principal amount</param>
        /// <param name="t">t term of mortgage in years</param>
        /// <param name="r">r rate of interest</param>
        /// <returns>monthly payment amount</returns>
        public static double CalculateMonthlyPayment(int p, int t, double r)
        {
            //cannot have negative loanAmount, term duration and rate of interest
            if (p < 0 || t < 0 || r < 0)
            {
                throw new InvalidInputException("Negative values are not allowed");
            }

            // convert interest rate into a decimal - eg. 6.5% = 0.065
            r /= 100;

            // convert term in years to term in months
            int tim = t * 12;

            //for zero interest rates
            if (r == 0)
                return (double) p / tim;

            // convert into monthly rate
            double m = r / 12;

            // Calculate the monthly payment
            // The Math.Pow() method is used calculate values raised to a power
            double monthlyPayment = p * m / (1 - Math.Pow(1 + m, -tim));

            return monthlyPayment;
        }
    }
}
