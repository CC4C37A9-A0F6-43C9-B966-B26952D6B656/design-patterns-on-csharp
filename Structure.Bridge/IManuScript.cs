namespace Structure.Bridge01
{
    public abstract class ManuScript
    {
        public readonly IFormatter formatter;

        public ManuScript(IFormatter formatter)
        {
            this.formatter = formatter;
        }

        abstract public void Print();
    }
}