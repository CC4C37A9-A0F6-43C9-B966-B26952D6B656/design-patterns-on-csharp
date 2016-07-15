using System;

namespace NullObjectPattern
{
    public class NullUser : IUser
    {
        public bool IsNull
        {
            get
            {
                return true;
            }
        }

        public string Name
        {
            get
            {
                return "unknown";
            }
        }

        public void IncrementSessionTicket()
        {
            //do nothing
        }
    }
}