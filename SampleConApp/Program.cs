using System;

namespace SampleConApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Sample Output Screen");
            Console.WriteLine("Enter the Name");
            string name = Console.ReadLine();//ReadLine is a static method of the Console to read a Text entered by the user on the Console. It returns string.  ReadLine reads the whole line until the user pressed return in the Console. 
            Console.WriteLine("The name entered is " + name);
        }//Ctrol + F5
    }
}
