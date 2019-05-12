using System;
using System.Diagnostics;
/*
 * Exceptions are raised as objects of a class derived from System.Exception. 
 * U should handle the exceptions under a try block, followed by one or more catch blocks and an optional finally block. 
 * catch blocks are created to handle different kinds of Exception, one-to-one catch block for every every exception. 
 * finally block executes on all conditions irrespective whether an Exception occurs or not. 
 * Every try block must have either a catch, finally or both.
 * try block could be nested. 
 * U cannot have any jump statements in a finally block: break, return, goto, throw. 
 * If U want to execute a statement at the time of the function returning, finally block would be executed.
 * U could create Custom Exceptions for app specific Exceptions, these Exceptions are created for handling logical mismatch within the App. This is specific to the App U R creating, so they are classes derived from the .NET Class called ApplicationException.
 * U could raise an Exception in code using throw keyword. There is no throws keyword in C#..
 * Commonly used Exceptions: FormatException, OverFlowException, DivideByZeroException, NullReferenceException, FileNotFoundException, InvalidArgException, SqlException(Databases)
 * For app specific Exceptions that U wish to raise, U could create an Exception of UR own which is basically a class derived from System.ApplicationException and add couple of constructors to call its base versions. U would raise the Exception using throw statement.
 */
namespace SampleConApp
{
    static class AppLogger
    {
        public static void logError(string errMsg)
        {
            EventLog log = new EventLog("CDACTraining", Environment.MachineName , "SampleConApp");
            log.WriteEntry(errMsg, EventLogEntryType.Error);
        }
    }
    class EmployeeNotFoundException : ApplicationException
    {
        public EmployeeNotFoundException() : base("Unidentified Exception was raised while finding the Employee")
        {
            AppLogger.logError("Unidentified Exception was raised while finding the Employee");
        }

        public EmployeeNotFoundException(string msg) : base(msg)
        {
            AppLogger.logError(msg);
        }

        public EmployeeNotFoundException(string msg, Exception innerException) : base(msg, innerException)
        {

        }
    }
    class ExceptionDemo
    {
        static void Main(string[] args)
        {
            //firstExample();
            //tryParseExample();
            //divideByZeroExample();
            try
            {
                Console.WriteLine("Enter the ID to find");
                int id = int.Parse(Console.ReadLine());
                if (id > 100)
                    throw new EmployeeNotFoundException("ID was not available");
            }
            catch (EmployeeNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static void divideByZeroExample()
        {
            int v1 = int.Parse(Console.ReadLine());
            Console.WriteLine("The divided value is " + 123 / v1);
        }

        private static void tryParseExample()
        {
            RETRY:
            Console.WriteLine("Enter a number");
            int no;
            if (!int.TryParse(Console.ReadLine(), out no))
            {
                Console.WriteLine("Invalid Format or Not in range of integer");
                goto RETRY;
            }
            Console.WriteLine("The value entered is " + no);
        }

        static void firstExample()
        {
        RETRY:
            try
            {
                Console.WriteLine("Enter a number");
                int value = int.Parse(Console.ReadLine());
            }
            catch (FormatException)
            {
                Console.WriteLine("Input should be a whole no");
                goto RETRY;
            }
            catch (OverflowException)
            {
                Console.WriteLine($"Value entered should be within the range of {int.MinValue} to {int.MaxValue}");
                goto RETRY;
            }
            catch (Exception ex)
            {
                //This is for un-anticipated exception....
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.WriteLine("Everything is ending here....");
            }
        }
    }
}