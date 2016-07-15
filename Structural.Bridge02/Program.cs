using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Structural.Bridge02
{
    public class Program
    {
        private static void Main(string[] args)
        {
        }
    }

    //bridge interface to display list classes
    /// <summary>
    /// Now we want to define a single interface that remains the same regardless of the type and complexity of the actual
    /// implementation classes. We’ll start by defining a Bridger interface.
    /// </summary>
    public interface Bridger
    {
        void addData(ArrayList col);
    }

    public class Product : IComparable
    {
        private string quantity;
        private string name;

        public Product()
        {
            //1000
        }

        public Product(string line)
        {
            int i = line.IndexOf("--");
            name = line.Substring(0, i).Trim();
            quantity = line.Substring(i + 2);
        }
    }
}