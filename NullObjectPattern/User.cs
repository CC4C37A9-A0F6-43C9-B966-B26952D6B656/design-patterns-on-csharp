using System;

namespace NullObjectPattern
{
    internal class User : IUser
    {
        private DateTime sessionExpiry;
        private Guid guid;

        public User(Guid guid)
        {
            this.guid = guid;
        }

        public Guid ID { get; set; }

        public bool IsNull
        {
            get
            {
                return false;
            }
        }

        public string Name { get; set; }

        public void IncrementSessionTicket()
        {
            throw new NotImplementedException();
        }
    }
}