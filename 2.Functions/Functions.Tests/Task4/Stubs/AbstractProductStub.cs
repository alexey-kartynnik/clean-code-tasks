using Functions.Task4.ThirdParty;

namespace Functions.Task4.Stubs
{
    public abstract class AbstractProductStub : IProduct
    {
        public double GetProductPrice()
        {
            return 10;
        }

        public abstract bool IsAvailable();
    }
}