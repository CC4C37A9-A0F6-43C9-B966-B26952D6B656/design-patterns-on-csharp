namespace ICustomerInterface
{
    /// <summary>
    /// We already have a general interface for “Customer” in the same way let us create a general interface for validation algorithm we will term 
    /// this interface as “IValidationStratergy”.Also note we have made the interface generic so that we can use this interface tomorrow 
    /// for other types like “Supplier” , “Accounts” etc
    /// </summary>
    /// <typeparam name="AnyType"></typeparam>
    public interface IValidationStrategy<AnyType>
    {
        void Validate(AnyType obj);
    }
}
