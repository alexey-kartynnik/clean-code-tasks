using System.Collections.Generic;
using ErrorHandling.Task1.ThirdParty;

namespace ErrorHandling.stubs
{
    public class UserStub : IUser
    {
        private readonly IList<IOrder> orders = new List<IOrder>
        {
            new SubmittedOrderStub(),
            new AnotherSubmittedOrderStub(),
            new NotSubmittedOrderStub()
        };

        public IList<IOrder> GetAllOrders()
        {
            return orders;
        }
    };
}