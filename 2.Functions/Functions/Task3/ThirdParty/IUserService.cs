namespace Functions.Task3.ThirdParty
{
    public interface IUserService
    {
        bool IsPasswordCorrect(IUser user, string password);

        IUser GetUserByName(string userName);
    }
}