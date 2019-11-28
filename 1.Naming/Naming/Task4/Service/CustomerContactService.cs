using Naming.Task4.ThirdParty;

namespace Naming.Task4.Service
{
    public class CustomerContactService : ICustomerContactService
    {
        private readonly ICustomerContactRepository customerContactRepository;

        public CustomerContactService(ICustomerContactRepository customerContactRepository)
        {
            this.customerContactRepository = customerContactRepository;
        }

        public CustomerContact FindCustomerContactDetailsByCustomerId(float customerId)
        {
            return customerContactRepository.FindById(customerId);
        }

        public void UpdateCustomerContactDetails(CustomerContact customerContactDetails)
        {
            customerContactRepository.Update(customerContactDetails);
        }
    }
}
