namespace Functions.Task4.Stubs
{
    public class UnavailableProductStub : AbstractProductStub
    {
        public override bool IsAvailable()
        {
            return false;
        }
    }
}