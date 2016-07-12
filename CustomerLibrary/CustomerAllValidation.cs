using ICustomerInterface;
using System;

namespace CustomerLibrary
{
    /// <summary>
    /// Pattern 5 Strategy pattern: - This is a behavioral design pattern which helps to select algorithms on runtime
    /// </summary>
    public class CustomerAllValidation : IValidationStrategy<ICustomer>
    {
        public void Validate(ICustomer obj)
        {
            if (obj.CustomerName.Length==0)
            {
                throw new Exception("Customer Name is required");
            }
            if (obj.PhoneNumber.Length == 0)
            {
                throw new Exception("Phone number is required");
            }
            if (obj.BillAmount == 0)
            {
                throw new Exception("Bill Amount is required");
            }
            if (obj.BillDate >= DateTime.Now)
            {
                throw new Exception("Bill date  is not proper");
            }
        }
    }
}
