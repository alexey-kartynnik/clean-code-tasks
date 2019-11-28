namespace Functions.Task3.ThirdParty
{
    public interface IController
    {
        void GenerateSuccessLoginResponse(string user);

        void GenerateFailLoginResponse();
    }
}