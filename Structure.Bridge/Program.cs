using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Structure.Bridge01
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            List<ManuScript> documents = new List<ManuScript>();
            var formatter = new ReverseFormatter();

            var faq = new Faq(formatter);
            faq.Title = "111 The Bridge01 pattern FAQ";
            faq.Questions.Add("What is it?", "A design pattern");
            faq.Questions.Add("When do we use it?", "When you need to separate an abstraction from an implementation");
            //faq.Print();
            documents.Add(faq);
            //--------------
            var book = new Book(formatter)
            {
                Title = "222 Lost of Patterns",
                Author = "Wanderson Pin",
                Text = "Blah Blah Blah "
            };
            //book.Print();
            documents.Add(book);

            var paper = new TermPaper(formatter)
            {
                Class = "333 Design patterns",
                Student = "Wanderson Pin",
                Text = "Blah Blah Blah ",
                References = "GoF"
            };
            //paper.Print();
            documents.Add(paper);

            foreach (var doc in documents)
            {
                doc.Print();
            }

            Console.ReadKey();
        }
    }

    //[Microsoft.VisualStudio.TestTools.UnitTesting.TestClass]
    //public class MyTestClass
    //{
    //    [TestMethod]
    //    public void MyTestMethod()
    //    {
    //        abc
    //    }
    //}
}