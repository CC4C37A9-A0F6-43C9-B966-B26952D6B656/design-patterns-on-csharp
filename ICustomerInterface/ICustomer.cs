using System;

namespace ICustomerInterface
{
    /// <summary>
    /// This interface we will reference in the UI. Below is how the interface “ICustomer” looks like , 
    /// just empty definitions and empty methods.
    /// 
    /// Thought process 7:- The primary work of interfaces is to decouple classes from each other
    /// </summary>
    public interface ICustomer
    {
        string CustomerName { get; set; }
        string PhoneNumber { get; set; }
        decimal BillAmount { get; set; }
        DateTime BillDate { get; set; }
        string Address { get; set; }
        //void Validate();
        /*Step 10:- Implementing cloning (Prototype pattern)
        Now the above factory pattern class has a defect, can you guess what it is ?.
        icust = Factory.Create(0);
        Now why does it return the same instance because the factory pattern is pointing to the same instance of 
        the collection.Now that’s disastrous because the whole point of factory is to create new instance and not return 
        the same instance

        So we need some kind of mechanism where in rather than returning the same object a CLONE of the object should be returned, 
        something like a BY VAL copy. That’s where prototype pattern comes to picture.
        So the first step is to define a “Clone” method in the “ICustomer” interface.
        */
        /// <summary>
        /// Note: -The biggest constraint of RIP pattern is that the concrete classes should come in inheritance hierarchy 
        /// </summary>
        /// <returns></returns>
        ICustomer Clone();// Added an extra method clone 
        void Validate();
    }
}
