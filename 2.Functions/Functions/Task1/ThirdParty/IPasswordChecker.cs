namespace Functions.Task1.ThirdParty
{
    public interface IPasswordChecker
    {
        CheckStatus Validate(string password);
    }
}