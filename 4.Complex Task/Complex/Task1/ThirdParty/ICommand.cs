namespace Complex.Task1.ThirdParty
{
    public interface ICommand
    {
        bool CanProcess(string command);

        void Process(string command);
    }
}
