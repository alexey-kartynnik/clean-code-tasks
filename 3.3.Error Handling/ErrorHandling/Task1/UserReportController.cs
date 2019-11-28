using ErrorHandling.Task1.ThirdParty;

namespace ErrorHandling.Task1
{
    public class UserReportController
    {

        private UserReportBuilder userReportBuilder;

        public string GetUserTotalOrderAmountView(string userId, IModel model)
        {
            string totalMessage = GetUserTotalMessage(userId);
            if (totalMessage == null)
                return "technicalError";
            model.AddAttribute("userTotalMessage", totalMessage);
            return "userTotal";
        }

        private string GetUserTotalMessage(string userId)
        {

            double? amount = userReportBuilder.GetUserTotalOrderAmount(userId);

            if (amount == null)
                return null;

            if (amount == -1)
                return "WARNING: User ID doesn't exist.";
            if (amount == -2)
                return "WARNING: User have no submitted orders.";
            if (amount == -3)
                return "ERROR: Wrong order amount.";

            return "User Total: " + amount + "$";
        }


        public UserReportBuilder GetUserReportBuilder()
        {
            return userReportBuilder;
        }

        public void SetUserReportBuilder(UserReportBuilder userReportBuilder)
        {
            this.userReportBuilder = userReportBuilder;
        }
    }
}
