using CustomerLibrary;
using ICustomerInterface;
using System.Collections.Generic;
using System;

namespace FactoryCustomer
{
    #region Step 8:- Improving performance of Factory class
    //In the above architecture the factory class will perform very badly if we have lot of concrete objects
    //tomorrow and if we are creating factory instances again and again it will lead to lot of memory consumption.
    #endregion

    /// <summary>
    /// It has a simple “Factory” class with a create method. 
    /// This “create” method takes a numeric value and depending on the numeric value it either 
    /// creates a “Lead” object or a “Customer” object. But the specialty of this “Create” function is that it 
    /// returns “ICustomer” interface type.
    /// </summary>
    public static class Factory //public class Factory //BEFORE Step 8:- Improving performance of Factory class
    {
        //Step 9:- Lazy Loading the Factory
        private static Lazy<List<ICustomer>> customers = null;//private static List<ICustomer> customers=null;// = new List<ICustomer>();//Step 1:-Create a list of collection of “ICustomer”.

        //Step 9:- Lazy Loading the Factory
        //static Factory()
        //{
        //    //Step 2:-In the constructor load the types of customer classes like lead and customer.
        //    //customers.Add(new Lead());
        //    //customers.Add(new Customer());
        //    customers = new List<ICustomer>
        //    {
        //        new Lead(),
        //        new Customer()
        //    };
        //}
        static Factory()
        {
            customers = new Lazy<List<ICustomer>>(() => LoadCustomers());
        }

        public static ICustomer Create (int CustomerType)
        {
            /*If there is polymorphism and if you see lots of IF conditions that means polymorphism benefit is not exploited”.
            * To remove “IF” condition is a three step process: - 
            * Step 1:-Create a list of collection of “ICustomer”.
            */
            #region before - using IF
            //if (CustomerType == 0)
            //{
            //    return new Lead();//Thought process 8:- “NEW” keyword is the main culprit for tight coupling .
            //}
            //else
            //{
            //    return new Customer();//Thought process 8:- “NEW” keyword is the main culprit for tight coupling .
            //} 
            #endregion
            #region after - using index
            if (customers == null) //Step 2 :- The create function will now first check if the object is NULL then load it or else just lookup in the collection.
            {
                LoadCustomers();//Step 9:- Lazy Loading the Factory
            }
            /*Now the “Create” function of the factory will call the clone method after the lookup from the collection. 
             * So the same reference of the object will not be sent it will be a fresh new copy of object.
             Pattern 4 Prototype pattern: - This is a creational design pattern where we create a fresh new clone / instance 
             of an object.
             */
            return customers.Value[CustomerType].Clone();//return customers.Value[CustomerType];//return customers[CustomerType];

            /*Note: -The biggest constraint of RIP pattern is that the concrete classes should come in inheritance hierarchy 
            and have same signatures. Polymorphism and Inheritance is a compulsory feature for RIP pattern to exist.*/

            /*Thought process 9:-In Polymorphism IF can be replaced with a dynamic polymorphic collection. 
            Pattern 1 RIP Pattern: -If you have the advantage of polymorphism and you see lots of IF condition, there is good 
            chance that you can replace the IF condition with a simple collection look up. This pattern falls in to Behavioral 
            category.*/
            #endregion
        }
        /// <summary>
        /// Step 9:- Lazy Loading the Factory 
        /// Below goes the full code with Lazy loading.
        /// </summary>
        private static List<ICustomer> LoadCustomers()//private static void LoadCustomers()
        {
            //Step 2 :- The create function will now first check if the object is NULL then load it or else just lookup in the collection.
            //customers = new List<ICustomer>
            //    {
            //        new Lead(),
            //        new Customer()
            //    };
            return new List<ICustomer>
                {
                    new Lead(),
                    new Customer()
                };
        }
    }
}
