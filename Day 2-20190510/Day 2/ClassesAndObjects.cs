using System;
//namespace can span across multiple files...
namespace SampleConApp
{
    //In C#, a class can contain the following member types:
    /*
     * Fields(private to a class)
     * Properties(Getters and Setters)
     * Methods(Functions of the class, usually public)
     * Events: CallBack functions for the class. 
     * Nested Classes(Class inside another class).
     * All classes are expected to be designed as per the SOLID principles of the OOP. 
     * U can have entity classes, Data Classes, Repository classes, UI Classes. 
     * From C# 3.0 we have automatic properties which internally implement the default getters and setters, however U could still use the old format if U want to enforce some business logic while reading or writing to the property.
     */
    class Book
    {
        private int _bookID;//private members will be camelcasing...
        private string _bookTitle;
        private double _bookPrice;

        public int BookID//old syntax of C# 2.0 or earlier...
        {
            get { return _bookID; }
            set {
                if (value <= 0)
                    throw new Exception("Invalid bookid");
                _bookID = value; }
        }

        public string Title
        {
            get { return _bookTitle; }
            set { _bookTitle = value; }
        }

        public double Cost
        {
            get { return _bookPrice; }
            set { _bookPrice = value; }
        }
    }

    class Employee
    {
        public int EmpID { get; set; }//auto properties from C# 3.0....

        private double _sal;

        public double Salary
        {
            get { return _sal; }
            set
            {
                if (value <= 50000)
                    throw new Exception("I am not for sale");
                _sal = value;
            }
        }

    }
    class ClassesAndObjects
    {
        static void Main(string[] args)
        {
            Employee emp = new Employee();
            emp.Salary = 55000;

            Book book = new Book();
            book.BookID = 123;//set
            book.Title = "Professional C#";
            book.Cost = 650;

            Console.WriteLine("The Book {0} costs {1} and its ISBN is {2}", book.Title, book.Cost, book.BookID);
        
        }
    }
}