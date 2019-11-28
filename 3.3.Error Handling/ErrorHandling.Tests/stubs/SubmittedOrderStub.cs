using ErrorHandling.Task1.ThirdParty;

namespace ErrorHandling.stubs
{
    public class SubmittedOrderStub : IOrder {
        public double Total() {
            return 285.15;
        }

        public bool IsSubmitted() {
            return true;
        }
    }
}
