using System;
using System.Collections.Generic;

//using System.Diagnostics.Contracts;
using System.Linq;

namespace NullObjectPattern
{
    public class UserRepository : IUserRepository
    {
        private ICollection<User> users;

        public UserRepository()
        {
            users = new List<User>
            {
                new User(Guid.NewGuid()),
                new User(Guid.NewGuid()),
                new User(Guid.NewGuid()),
                new User(Guid.NewGuid())
            };
        }

        public IUser GetByID(Guid userID)
        {
            //Contract.Ensures(Contract.Result<IUser>() != null);
            IUser userFound = users.SingleOrDefault(k => k.ID == userID);
            if (userFound == null)
            {
                userFound = new NullUser();
            }
            return userFound;
        }
    }
}