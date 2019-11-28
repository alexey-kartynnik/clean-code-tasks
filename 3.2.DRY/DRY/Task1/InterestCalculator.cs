using System;
using System.Globalization;
using DRY.Task1.ThirdParty;

namespace DRY.Task1
{
    public class InterestCalculator
    {
        private const int Age = 60;
        private const double InterestPercent = 4.5d;
        private const double SeniorPercent = 5.5d;
        private const int BonusAge = 13;

        public decimal CalculateInterest(AccountDetails accountDetails)
        {
            if (IsAccountStartedAfterBonusAge(accountDetails))
            {
                return Interest(accountDetails);
            }

            return 0;
        }

        private bool IsAccountStartedAfterBonusAge(AccountDetails accountDetails)
        {
            return DurationBetweenDatesInYears(accountDetails.Birth, accountDetails.StartDate) > BonusAge;
        }

        private int DurationBetweenDatesInYears(DateTime from, DateTime to)
        {
            Calendar calendar = new GregorianCalendar();
            int diffYear = calendar.GetYear(to) - calendar.GetYear(from);
            if (calendar.GetDayOfYear(to) < calendar.GetDayOfYear(from))
                return diffYear - 1;
            return diffYear;
        }

        private decimal Interest(AccountDetails accountDetails)
        {
            double interest = 0;
            if (IsAccountStartedAfterBonusAge(accountDetails))
            {
                if (Age <= accountDetails.Age)
                {
                    //interest = (PrincipalAmount * DurationInYears * AnnualInterestRate) / 100
                    interest = (double) accountDetails.Balance
                               * DurationSinceStartDateInYears(accountDetails.StartDate) * SeniorPercent / 100;
                }
                else
                {
                    interest = (double) accountDetails.Balance
                               * DurationSinceStartDateInYears(accountDetails.StartDate) * InterestPercent / 100;
                }
            }

            return (decimal) interest;
        }

        private double DurationSinceStartDateInYears(DateTime startDate)
        {
            var endDate = DateTime.Now;
            Calendar calendar = new GregorianCalendar();
            int diffYear = calendar.GetYear(endDate) - calendar.GetYear(startDate);
            if (calendar.GetDayOfYear(endDate) < calendar.GetDayOfYear(startDate))
                return diffYear - 1;
            return diffYear;
        }
    }
}
