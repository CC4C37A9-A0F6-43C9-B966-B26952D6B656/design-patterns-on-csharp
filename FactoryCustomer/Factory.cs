using CustomerLibrary;
using ICustomerInterface;
using Microsoft.Practices.Unity;

namespace FactoryCustomer
{
    public static class Factory<AnyTipe>
    {
        static IUnityContainer container;
        public static AnyTipe Create(string type)
        {
            if (container == null)
            {
                container = new UnityContainer();
                //Note :- I have changed the key from numeric “0” and “1” to “Lead” and “Customer” so that its more readable

                #region before injecting validation
                //container.RegisterType<ICustomer, Lead>("Lead");
                //container.RegisterType<ICustomer, Customer>("Customer"); 
                #endregion

                #region after -  validation injected
                container.RegisterType<ICustomer, Lead>("Lead", new InjectionConstructor(new LeadValidation()));//Pattern 5 Strategy pattern: - This is a behavioral design pattern which helps to select algorithms on runtime
                container.RegisterType<ICustomer, Customer>("Customer", new InjectionConstructor(new CustomerAllValidation()));//Pattern 5 Strategy pattern: - This is a behavioral design pattern which helps to select algorithms on runtime
                #endregion
            }
            return container.Resolve<AnyTipe>(type);
        }
    }
}
