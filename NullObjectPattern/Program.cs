using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NullObjectPattern
{
    internal class Program
    {
        private static IUserRepository userRepository = new UserRepository();

        private static void Main(string[] args)
        {
            var user = userRepository.GetByID(Guid.NewGuid());

            #region before 1

            //without the null objects pattern, this line could throw an exception
            //if (user != null)//Is checking against null really the responsibility of all clients?
            //{
            //    user.IncrementSessionTicket();
            //}

            #endregion before 1

            #region before 2

            user.IncrementSessionTicket();
            string userName;
            if (!user.IsNull)
            {
                userName = user.Name;
            }
            else
            {
                userName = "unknown";
            }

            #endregion before 2

            #region before 3

            user = userRepository.GetByID(Guid.NewGuid());
            user.IncrementSessionTicket();

            #endregion before 3

            Console.WriteLine("The user's name is {0}", userName);

            Console.ReadKey();
        }
    }
}