using System;
/*
 * C# supports Single inheritance only. 
 * It uses : to inherit a class.
 * It does not support private inheritance. All the public members will automatically become public members of the derived class. 
 * All private members will be inaccessible to the derived classes. 
 * All protected members will continue to be protected members for the dervied classes.
 */
namespace SampleConApp
{
    class BaseClass
    {
        public void TestFunc() => Console.WriteLine("Test Func");
    }

    class DerivedClass : BaseClass
    {
        public void DerivedFunc() => Console.WriteLine("Derived Func");
    }
    class InheritanceExample
    {
        static void Main(string[] args)
        {
            BaseClass obj = new BaseClass();//The object creation in C#...
            obj.TestFunc();

            obj = new DerivedClass();//Polymorphism
            obj.TestFunc();
            //((DerivedClass)obj).DerivedFunc();//Not safe, so better to check for the type before U type cast or convert...
            if(obj is DerivedClass)
            {
                DerivedClass cls = obj as DerivedClass;//as works only for reference types
                Console.WriteLine(cls == obj);
                cls.DerivedFunc();
            }
            else
            {
                Console.WriteLine("This is not an object of the derived class");
            }

            DerivedClass obj2 = new DerivedClass();
            obj2.TestFunc();
            obj2.DerivedFunc();
        }
    }
}
