namespace NullObjectPattern
{
    public interface IUser
    {
        void IncrementSessionTicket();

        bool IsNull { get; }
        string Name { get; }
    }
}