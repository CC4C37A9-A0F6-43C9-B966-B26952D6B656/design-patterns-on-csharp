using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Structure.Bridge
{
    public class BackWardsBook : Book
    {
        public BackWardsBook(IFormatter formatter) : base(formatter)
        {
        }

        public override void Print()
        {
            Console.WriteLine("Title: {0}", new String(Title.Reverse().ToArray()));
            Console.WriteLine("Author: {0}", new String(Author.Reverse().ToArray()));
            Console.WriteLine("Text: {0}", new String(Text.Reverse().ToArray()));

            Console.WriteLine();
        }
    }
}