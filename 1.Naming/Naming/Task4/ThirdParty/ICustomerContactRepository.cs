namespace Naming.Task4.ThirdParty
{
    public interface ICustomerContactRepository
    {
        CustomerContact FindById(float customerId);

        void Update(CustomerContact contact);
    }
}
