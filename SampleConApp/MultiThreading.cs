using System;
using System.Threading;
//namespace can span across multiple files...
/*
 * Threads in .NET are represented by objects of a Class called Thread under the namespace System.Threading.
 * A thread starts by calling the method called Start. A Thread object is initially created with the argument of the thread Function to invoke. Once the thread is created, U could suspend the thread or resume the thread. The Thread has a Thread State that determines the current status of the thread.  
 */
namespace SampleConApp
{
    class ThreadingExample
    {
        static void loopFuncWithArg(object arg)
        {
            //Synchronization is achieved using lock keyword of C# which internally uses a Class called Monitor, however U could still use the Monitor class directly
            //lock (typeof(ThreadingExample))
            Monitor.Enter(typeof(ThreadingExample));//typeof only for static methods else U could pass the object on which the synchronization is to be applied...
            {
                //arg should be of the type object only
                //Array arr = arg as Array;
                //int no = (int)arr.GetValue(0);
                //string name = arr.GetValue(1).ToString();
                //for (int i = 0; i < no; i++)
                //{
                //    Console.WriteLine($"{name}'s thread beep#" + i);
                //    Thread.Sleep(1000);
                //}

                object[] arr = arg as object[];
                int no = (int)arr[0];
                string name = arr[1].ToString();
                for (int i = 0; i < no; i++)
                {
                    Console.WriteLine($"{name}'s thread beep#" + i);
                    Thread.Sleep(1000);
                }
            }
            Monitor.Exit(typeof(ThreadingExample));
        }
        static void loopFunc()
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine($"Thread with beep#{i}");
                Thread.Sleep(1000);//Suspends the thread for a speculated interval of time in milliseconds and resumes after the time is over...
            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Main Thread is executing...");
            Thread th = new Thread(loopFuncWithArg);//Internally the constructor takes ThreadStart delegate object as arg which is a void Func with no args...
            th.IsBackground = true;
            th.Start(new object[] { 10, "Thread1" });//Creating a Thread Func with args....
            Thread th2 = new Thread(loopFuncWithArg);
            th2.IsBackground = true;
            th2.Start(new object[] { 10, "Thread2" });
            Console.WriteLine("Main Continuing its job...");
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine("Main Thread Beep#" + i);
                Thread.Sleep(1000);
            }
            Console.WriteLine("Main completed its job and waiting for the worker to exit");
        }
    }
}