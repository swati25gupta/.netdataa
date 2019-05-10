/*
 * Data types in C# are based on Common Type System of the .NET Framework. (.NET is language independent).
 * All data types of each programming language of .NET have to be derived from the types of the CTS.
 * The CTS types are structs and Classes which have methods and constants defined(Similar to wrapper classes of Java).
 * C# has keywords refereing to those classes and structs.
 * structs are value types and classes are reference types. 
 * Value types(Primitive Types):
 * integral: byte(Byte), short(Int16), int(Int32) , long(Int64)
 * floating: float(Single), double(Double), decimal(Decimal)
 * others: char(Char), bool(Boolean), DateTime
 * UDTs: enums and structs. 
 * 
 * Reference Types: Classes,Arrays, delegates, Strings are all reference types. 
 */
using System;
namespace SampleConApp
{
    class AppleExample
    {
        //pratical example of using object....
        static object createVariable(string varType)
        {
            switch (varType)
            {
                case "int":
                    return 123;
                case "float":
                    return 123.345f;
                case "double":
                    return 123.345;
                default:
                    return null;
            }
        }
        static void Main(string[] args)
        {
            //basicio();
            //conversionExample();
            //checkedExample();
            //objectExample();
            object value = createVariable("int");
            int v = (int)value;
            v = v + 123;
            Console.WriteLine("The result is " + v);

        }

        private static void objectExample()
        {
            //Every type in .NET is based on a class called System.Object. It is represented by a keyword object. Everything is object in .NET. 
            //Any variable of any type can be implicitly converted to object. object is similar to void* of C++. object is a reference type. 
            object simpleValue = 123;//int is implicitly converted to object..
            //This is called as BOXING....
            //If U want to create a function that returns any kind of data, then its return type would be object...
            //In such cases, if U want to perform any specific operations related to that type, U should type cast it to its own type...This is called UNBOXING. 
            //simpleValue++;//we know that the simpleValue is an integer, we cannot perform basic integer operations....
            int iValue = (int)simpleValue;
            iValue++;//U perform int related operations on the unboxed value..
            simpleValue = iValue;//BOXING is implicit and unboxing is explicit.
            long longValue = (long)simpleValue;
        }

        private static void checkedExample()
        {
            //checked is a keyword in C# for creating a block that checks for any overflow at the time of compilation only so that it would avoid a lot of unsafe type casting... If the casting is done at runtime, then it throws an OverFlow exception of the casting is improper...
            checked
            {
                Console.WriteLine("Enter a long value");
                int val = (int)long.Parse(Console.ReadLine());
                Console.WriteLine("The value entered is " + val);
            }
        }

        private static void conversionExample()
        {
            long age = 8768723423468776875;//Integers are implicitly convertable to long.
            //int sAge = (int)age;//Longer range variables have to be explicitly converted to the shorter range using C Style Type casting....
            //C Style casting is not safe as it might give abnormal results if the casting is not possible. Instead use the Convert class which has methods to convert from one type to another. In this case, if the casting is not possible, it throws an Exception and U could handle it...

            int sAge = Convert.ToInt32(age);
            Console.WriteLine("The age is {0}", sAge);//similar to printf kind of format....
        }

        private static void basicio()
        {
            Console.WriteLine("Enter the age");
            int age = int.Parse(Console.ReadLine());
            //Parse is a common method for all value types to convert from string to its type.. 
            //Parse throws a FormatException if the string is not a valid type to which it is converting....

            Console.WriteLine("Enter the salary");
            double salary = double.Parse(Console.ReadLine());

            Console.WriteLine($"The age is {age} and his salary is {salary}");//New syntax of C# 7.0...
        }
    }
}
