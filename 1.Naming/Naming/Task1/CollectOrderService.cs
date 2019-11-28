using Naming.Task1.ThirdParty;

namespace Naming.Task1
{
    public class CollectOrderService : IOrderService
    {
        private readonly ICollectionService Ser1;
        private readonly INotificationManager Ser2;

        public CollectOrderService(ICollectionService pCollectionService, INotificationManager pNotificationManager)
        {
            Ser1 = pCollectionService;
            Ser2 = pNotificationManager;
        }

        public void SubmitOrder(IOrder pOrder)
        {
            if (Ser1.IsEligibleForCollect(pOrder))
            {
                Ser2.NotifyCustomer(Message.ReadyForCollect, 4); // 4 - info notification level
            }
            else
            {
                Ser2.NotifyCustomer(Message.ImpossibleToCollect, 1); // 1 - critical notification level
            }
        }
    }
}
