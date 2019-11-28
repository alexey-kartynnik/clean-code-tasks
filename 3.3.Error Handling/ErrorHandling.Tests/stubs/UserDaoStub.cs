using ErrorHandling.stubs;
using ErrorHandling.Task1.ThirdParty;

namespace ErrorHandling.stubs
{
    public class UserDaoStub : IUserDao
    {
        private static readonly string USER_ID = "123";
        IUser user = new UserStub();

        private bool IsNotExistUser(string userId)
        {
            return userId != USER_ID;
        }

        public IUser GetUser(string userId)
        {
            if (IsNotExistUser(userId))
                return null;
            return user;
        }
    }
}
