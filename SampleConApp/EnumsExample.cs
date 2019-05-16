//Enumeration(or enum) is a value data type in C#. It is mainly used to assign the names or string values to integral constants, that make a program easy to read and maintain. 
//All Enums in .NET are objects of value types and are accessible programmatically thro System.Enum class. 
using System;
namespace SampleConApp
{
    enum Months
    {
        Jan = 1, Feb, Mar, Apr, May, Jun, Jul, Aug, Sep, Oct, Nov, Dec
    }//Named constants is another name given to enums. enums increment their next field by 1.  
    class EnumsDemo
    {
        static void Main(string[] args)
        {
            Console.WriteLine("The value of Jan is " + Months.Jan);
            Console.WriteLine("The integral value of Jan is " + (int)Months.Jan);
            //U could get all the possible values of an Enum using Enum class
            Array values = Enum.GetValues(typeof(Months)); //typeof operator in C# is used to get the type info about the User Defined type. 
            foreach(object val in values)
                Console.WriteLine(val);
            //To take the input from the Console:Enum.Parse method...
            Console.WriteLine("Enter the value from the List above");
            string value = Console.ReadLine();
            Months selected = (Months) Enum.Parse(typeof(Months), value);
            switch (selected)
            {
                case Months.Dec:
                case Months.Jan:
                case Months.Feb:
                    Console.WriteLine("Cold Winter");
                    break;
                case Months.Mar:
                    Console.WriteLine("Springs season");
                    break;
                case Months.Apr:
                case Months.May:
                    Console.WriteLine("Hot Summer");
                    break;
                case Months.Jun:
                case Months.Jul:
                case Months.Aug:
                    Console.WriteLine("Rainy Monsoon");
                    break;
                case Months.Sep:
                case Months.Oct:
                case Months.Nov:
                    Console.WriteLine("autumn season");
                    break;
            }
        }
    }
}