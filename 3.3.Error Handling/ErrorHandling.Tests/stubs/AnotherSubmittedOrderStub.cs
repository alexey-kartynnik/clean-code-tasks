using ErrorHandling.Task1.ThirdParty;

namespace ErrorHandling.stubs
{
    public class AnotherSubmittedOrderStub : IOrder {
        public double Total() {
            return 78.00;
        }

        public bool IsSubmitted() {
            return true;
        }
    }
}
