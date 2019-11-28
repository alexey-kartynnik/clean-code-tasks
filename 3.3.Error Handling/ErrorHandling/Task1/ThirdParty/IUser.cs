using System.Collections.Generic;

namespace ErrorHandling.Task1.ThirdParty
{
    public interface IUser
    {
        IList<IOrder> GetAllOrders();
    }
}
