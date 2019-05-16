using System;
//Delegates are like function pointers of C++. It allows to pass methods as arguments to a function. Delegates are reference types of methods...It is used to create callback functions in C#. 
//Delagates are widely used to provide callback functions, event handling, Multi Threading and scenarios where U want a method to be passed as arg to another func. 
//Steps of Using Delegates:
/*
 * Create a Delegate
 * Create a Func that uses the delegate as arg.
 * Call the func and pass the method that matches the delegate signature as arg...
 */
 //Func and Action were 2 delegates provided by .NET in v4.0 where it has generic capability Func is used for return type functions and Action is used for void Functions. 
namespace SampleConApp
{
    delegate void CallingFunc();//create the delegate
    delegate double mathOp(double v1, double v2);

    class DelegatesExample
    {
        static void InvokeFunc(mathOp op)
        {
            Console.WriteLine("enter v1");
            double v1 = double.Parse(Console.ReadLine());

            Console.WriteLine("enter v2");
            double v2 = double.Parse(Console.ReadLine());

            var res = op(v1, v2);
            Console.WriteLine("The result of this operation is " + res);
        }
        static void InvokeMe(CallingFunc func)
        {
            Console.WriteLine("Do U really want to invoke this func?");
            string msg = Console.ReadLine();

            if((func != null) && (msg.ToLower() == "yes"))
                func();
            else
                Console.WriteLine("No valid Func is passed or Func was not asked to Run");
        }

        static void CallThisFunc()
        {
            Console.WriteLine("Hello Delegate");
        }
        static void Main(string[] args)
        {
            //InvokeMe(CallThisFunc);
            //InvokeFunc(testFunc);
            //InvokeFunc(delegate (double a, double b)
            //{
            //    return a + b;
            //});//Anonymous methods in C# 2.0

            //In C# 3.0(2008)
            //InvokeFunc((x, y) => x * y);//Lambda Expressions...
            //usingFuncDelegate();
            usingActionDelegate();
        }

        private static void usingActionDelegate()
        {
            Action<string, int> action = (v , i) =>
            {
                for(int j =0; j < i; j++)
                    Console.WriteLine(v);
            };
            action("Test", 5);
        }

        private static void usingFuncDelegate()
        {
            //Func is a overloaded Generic Delegate that is used to associate functions with return types...
            Func<double, double, double> mathOp = (d1, d2)=> d1 - d2 ;
            var res = mathOp(123, 234);
            Console.WriteLine(res);
        }

        static double testFunc(double v1, double v2)
        {
            v1 = v1 + v2 - (v1 / v2) * (v2 - v1);
            return v1;
        }
    }
}