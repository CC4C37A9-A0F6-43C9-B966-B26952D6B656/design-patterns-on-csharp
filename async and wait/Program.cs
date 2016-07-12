using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace async_and_wait
{
    class Program
    {
        //static void Main(string[] args)
        //{
        //    //async and await are markers which mark code positions from where control should resume after a task (thread) completes
        //    //1.Method() gets called from the Static void main() entry point. 
        //    //2.Method() spawns a Task(thread) LongTask which waits for 10 seconds.
        //    //3.At the same time the control comes back to Method() to execute the remaining code after the task was called.
        //    //In other words as the invocation is multi - threaded(Task.Run…), LongTask is also running i.e., waiting for 10 seconds and the remaining code of your Method() is also executed.
        //    Method();
        //    Console.WriteLine("Main thread");
        //    Console.ReadLine();
        //}

        //private static void Method()
        //{
        //    Task.Run(new Action(LongTask));
        //    Console.WriteLine("New thread");
        //}

        //private static void LongTask()
        //{
        //    Thread.Sleep(10000);
        //    Console.WriteLine("LongTask finished");
        //}
        static void Main()
        {
            Method();
            Console.WriteLine("Main thread");
            Console.ReadLine();
        }

        private static async void Method()
        {
            await Task.Run(new Action(LongTask));
            Console.WriteLine("New thread");
        }

        private static void LongTask()
        {
            Thread.Sleep(10000);
            Console.WriteLine("LongTask finished");
        }
    }
}
