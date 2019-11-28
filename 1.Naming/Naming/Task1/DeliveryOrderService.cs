using System.Collections.Generic;
using Naming.Task1.ThirdParty;

namespace Naming.Task1
{
    public class DeliveryOrderService : IOrderService
    {
        private readonly IDeliveryService mDeliveryService;
        private readonly IOrderFulfilmentService mOrderFulfilmentService;

        public DeliveryOrderService(IDeliveryService pDeliveryService, IOrderFulfilmentService pOrderFulfilmentService)
        {
            mDeliveryService = pDeliveryService;
            mOrderFulfilmentService = pOrderFulfilmentService;
        }

        public void SubmitOrder(IOrder pOrder)
        {
            if (mDeliveryService.IsDeliverable())
            {
                IList<IProduct> products = pOrder.GetProducts();
                mOrderFulfilmentService.FulfilProducts(products);
            }
            else
            {
                throw new NotDeliverableOrderException();
            }
        }
    }
}
