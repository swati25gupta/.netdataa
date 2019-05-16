using System;
/*
 * Method overriding is achieved in C# using a keywords virtual and override. 
 * Not all methods are allowed to be overriden in C#. Only the virtual methods can be overriden in the derived classes.
 * If the method is not marked as virtual, the derived class will not be able to override the method. However, it can still provide a new definition for the method which will be invoked thro Runtime polymorphism...It would rather considered as the new method of the derived class which is not associated with the base version.(Warning is given by the compiler). 
 * virtual is more like a permission given to the derived classes that they can override if required, but not mandatory. The overriding is done by accepting the permission using override. 
 * Overriden methods can further be overriden by its derived classes.
 * override keyword can be used on both virtual methods as well as override methods.
*/
namespace SampleConApp
{

    class BaseClass
    {
        public virtual void baseFunc(int v) => Console.WriteLine("The base func with arg: " + v);

        public void NormalFunc() => Console.WriteLine("Normal method of the base");
    }
    //Method overriding should have the same method signature of the base class....
    class DerivedClass : BaseClass
    {
        public override void baseFunc(int v)
        {
            //base.baseFunc(v);//If required U could continue to call the base version using base keyword.(super of java)...
            Console.WriteLine("The derived version of the method with arg:" + v);
        }
        //The method of the base class will no longer be usable from the object of the derived. When the compiler indicates a warning about this behavior, U could suppress the warning using new keyword, which implies to the compiler that the developer is intentionally providing a new implementation of the base method. It also indicates other developers who review the code understand that this method has a similar signature in its base class. 
        public new void NormalFunc() => Console.WriteLine("Normal Func of the derived");
    }
    class MethodOverridingExample
    {
        static void Main(string[] args)
        {
            BaseClass obj = new DerivedClass();
            obj.baseFunc(123);
            obj.NormalFunc();// it will call the base version.....
            obj = new BaseClass();
            obj.baseFunc(123);
            
            //Same object behaving in 2 different ways where the behavior is determined at runtime based on the object to which it is instantiated is what is called as RUNTIME POLYMORPHISM.....
        }
    }
}