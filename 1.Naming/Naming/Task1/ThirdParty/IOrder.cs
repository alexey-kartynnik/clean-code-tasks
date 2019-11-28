using System.Collections.Generic;

namespace Naming.Task1.ThirdParty
{
    public interface IOrder
    {
        IList<IProduct> GetProducts();
    }
}
