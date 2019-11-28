using System.Collections.Generic;

namespace Naming.Task1.ThirdParty
{
    public interface IOrderFulfilmentService
    {
        void FulfilProducts(IList<IProduct> products);
    }
}
