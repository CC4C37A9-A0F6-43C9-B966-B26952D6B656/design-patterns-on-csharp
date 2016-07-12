using ICustomerInterface;

namespace CustomerLibrary
{
    public class Customer : CustomerBase
    {
        public Customer(IValidationStrategy<ICustomer> obj) : base(obj)
        {
        }
    }
}
