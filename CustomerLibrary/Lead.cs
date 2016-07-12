using ICustomerInterface;

namespace CustomerLibrary
{
    public class Lead : CustomerBase
    {
        public Lead(IValidationStrategy<ICustomer> obj) : base(obj)
        {
        }
    }
}
