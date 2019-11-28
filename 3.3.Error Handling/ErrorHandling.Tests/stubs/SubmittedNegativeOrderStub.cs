
using ErrorHandling.Task1.ThirdParty;

namespace ErrorHandling.stubs
{
    public class SubmittedNegativeOrderStub : IOrder {
        public double Total() {
            return -1.0;
        }

        public bool IsSubmitted() {
            return true;
        }
    }
}
