using System.Collections.Generic;
using System.Linq;
using Functions.Task4.ThirdParty;

namespace Functions.Task4
{
    public class Order
    {
        public IList<IProduct> Products { get; set; }

        public double GetPriceOfAvailableProducts()
        {
            IEnumerator<IProduct> enumerator = Products.ToList().GetEnumerator();
            while (enumerator.MoveNext())
            {
                IProduct p1 = enumerator.Current;
                if (!p1.IsAvailable())
                {
                    Products.Remove(p1);
                }
            }

            var orderPrice = 0.0;
            foreach (IProduct p in Products)
            {
                orderPrice += p.GetProductPrice();
            }
            return orderPrice;
        }
    }
}
