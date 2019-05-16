using System;
//namespace can span across multiple files...
namespace SampleConApp
{
    class Employee
    {
        public int Salary { get; set; }
        public static Employee operator +(Employee emp, int amount)
        {
            emp.Salary += amount;
            return emp;
        }
    }
    class OperatorDemo
    {
        static void Main(string[] args)
        {
            Employee emp = new Employee { Salary = 45 };
            emp += 70;
            Console.WriteLine("The Current salary is " + emp.Salary);
        }
    }
    
}