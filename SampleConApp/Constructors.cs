using System;
/*
 * Constructors work similar to that of C++ and Java..
 * All classes are derived from System.Object, so by default, C# would provide one Constructor if the class does not have one...All members are initialized to their default values. 
 * If the derived class constructor is invoked, it implicitly calls the base class's default constructor..However, if U want to invoke one of the overloaded constructors of the base class, U could use the base keyword.....
 * U could call other constructors of the class using this keyword using the : operator at the declaration of the constructor. 
 */
namespace SampleConApp
{
    class Vehicle
    {
        public Vehicle()
        {
            Console.WriteLine("Default");
        }
        public Vehicle(string type)
        {
            Console.WriteLine("Car Type:" + type);
        }
    }
    class Car :Vehicle
    {
        internal string regNo;//internal access specifier is like default of Java. It is accessible from anywhere within the project...
        internal DateTime dateOfRegistration;
        internal string ownername;
        //ctor for creating Constructor snippet...
        public Car()
        {
            Console.WriteLine("Car is created");
        }

        public Car(string reg, DateTime time, string owner) : base("HONDA")
        {
            this.regNo = reg;
            this.dateOfRegistration = time;
            this.ownername = owner;
        }
        public override string ToString()
        {
            return string.Format($"The Car RegNo:{regNo}\nOwner:{ownername}\nReg Date:{dateOfRegistration.ToShortDateString()}");
            //dateOfRegistration.ToString("dd-MM-yyyy hh:mm:ss")
        }
    }
    class ConstructorsDemo
    {
        static void Main(string[] args)
        {
            Car car = new Car();//default constructor
            car = new Car("KA05 MG 2317", DateTime.Now.AddDays(-2444), "Phaniraj");
            //car.dateOfRegistration = DateTime.Parse("06/05/2018 11:30");
            //Console.WriteLine("The reg no of car is " + car.regNo);
            //Console.WriteLine("The car was registered on " + car.dateOfRegistration);
            Console.WriteLine(car);//WriteLine will evaluate its arg to String
        }
    }
}