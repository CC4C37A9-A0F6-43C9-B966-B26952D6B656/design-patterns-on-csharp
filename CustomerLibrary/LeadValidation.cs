using ICustomerInterface;
using System;

namespace CustomerLibrary
{
    /// <summary>
    /// Pattern 5 Strategy pattern: - This is a behavioral design pattern which helps to select algorithms on runtime
    /// </summary>
    public class LeadValidation : IValidationStrategy<ICustomer>
    {
        public void Validate(ICustomer obj)
        {
            string msg = "";
            if (obj.CustomerName.Length == 0)
            {
                //throw new Exception("Customer Name is required");
                msg += "Customer Name is required";
            }
            if (obj.PhoneNumber.Length == 0)
            {
                //throw new Exception("Phone number is required");
                msg += "\r\nPhone number is required";
            }
            if (msg.Length!=0)
            {
                throw new Exception(msg);
            }
        }
    }
}
