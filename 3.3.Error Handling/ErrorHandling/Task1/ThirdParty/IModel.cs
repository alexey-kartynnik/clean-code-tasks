namespace ErrorHandling.Task1.ThirdParty
{
    public interface IModel
    {
        void AddAttribute(string name, string v);
        string GetAttribute(string name);
    }
}
