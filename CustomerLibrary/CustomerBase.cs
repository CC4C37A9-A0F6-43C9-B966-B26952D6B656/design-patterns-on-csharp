using ICustomerInterface;
using System;

namespace CustomerLibrary
{
    public abstract class CustomerBase: ICustomer
    {
        public string CustomerName { get; set; }
        public string PhoneNumber { get; set; }
        public decimal BillAmount { get; set; }
        public DateTime BillDate { get; set; }
        public string Address { get; set; }

        //Now the base class will internally point to the general validation interface. Now the “Customer” and “Lead” class has no idea 
        //what kind of validation strategy will he be executing.
        private IValidationStrategy<ICustomer> _ValidationType;
        public IValidationStrategy<ICustomer> ValidationType
        {
            get { return _ValidationType; }
            set { _ValidationType = value; }
        }

        public CustomerBase(IValidationStrategy<ICustomer> _Validate)
        {
            _ValidationType = _Validate;
        }
        public virtual void Validate()
        {
            // Let this be define by the child classes 

            //Now the base class will internally point to the general validation interface. Now the “Customer” and “Lead” class has no idea 
            //what kind of validation strategy will he be executing.

            ValidationType.Validate(this);
        }

        public ICustomer Clone()
        {
            /*In order to create a “Clone” of a .NET object we have ready made “MemberwiseClone” function.In the base class 
             * of the customer we have implemented the same.With this approach any other type of customer class who is 
             * inheriting will also have the ability to clone objects.*/
            return (ICustomer)this.MemberwiseClone();
        }

       
    }

   
}
