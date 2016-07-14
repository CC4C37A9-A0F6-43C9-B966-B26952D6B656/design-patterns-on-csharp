using System;

namespace Structure.Bridge
{
    internal class TermPaper : ManuScript
    {
        public TermPaper(IFormatter formatter) : base(formatter)
        {
        }

        public string Class { get; internal set; }
        public string References { get; internal set; }
        public string Student { get; internal set; }
        public string Text { get; internal set; }

        public override void Print()
        {
            Console.WriteLine("Class: {0}", Class);
            Console.WriteLine("Student: {0}", Student);

            Console.WriteLine("Text: {0}", Text);
            Console.WriteLine(formatter.Format("References", References));

            Console.WriteLine();
        }
    }
}