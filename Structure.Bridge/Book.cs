using System;

namespace Structure.Bridge
{
    public class Book : ManuScript
    {
        public Book(IFormatter formatter) : base(formatter)
        {
        }

        public string Author { get; internal set; }
        public string Text { get; internal set; }
        public string Title { get; internal set; }

        public override void Print()
        {
            Console.WriteLine("Title: {0}", Title);
            Console.WriteLine(formatter.Format("Author", Author));

            Console.WriteLine(formatter.Format("Text", Text));

            Console.WriteLine();
        }
    }
}