
using ErrorHandling.Task1.ThirdParty;

namespace ErrorHandling.stubs
{
    public class NotSubmittedOrderStub : IOrder {
        public double Total() {
            return 99.99;
        }

        public bool IsSubmitted() {
            return false;
        }
    }
}
