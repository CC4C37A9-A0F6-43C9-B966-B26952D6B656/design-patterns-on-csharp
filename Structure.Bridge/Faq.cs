using Structure.Bridge;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Structure.Bridge
{
    public class Faq : ManuScript
    {
        public Dictionary<string, string> Questions { get; set; }

        public string Title { get; set; }

        public Faq(IFormatter formatter) : base(formatter)
        {
            Questions = new Dictionary<string, string>();
        }

        public override void Print()
        {
            Console.WriteLine("Title: {0}", Title);
            foreach (var question in Questions)
            {
                Console.WriteLine(" Question {0}", question.Key);
                Console.WriteLine(formatter.Format("Answer", question.Value));
            }
            Console.WriteLine();
        }
    }
}