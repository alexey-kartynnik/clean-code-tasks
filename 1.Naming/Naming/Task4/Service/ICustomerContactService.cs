using Naming.Task4.ThirdParty;

namespace Naming.Task4.Service
{
    public interface ICustomerContactService
    {
        CustomerContact FindCustomerContactDetailsByCustomerId(float customerId);

        void UpdateCustomerContactDetails(CustomerContact customerContactDetails);
    }
}
