using System;
//namespace can span across multiple files...
//How to create Array in C#...
//All arrays are objects of a class called System.Array...With this class, U have methods and properties to get the info about the array object.
/*
 * Length: size of the Array
 * Rank : dimensions of the Array
 * GetLength(int dimension): Gets the length of the specified dimension(Function).
 * Copy, Clone are some of the other methods....
 */
namespace SampleConApp
{
    class ArraysDemo
    {
        static void Main(string[] args)
        {
            //singleDimensionalArray();
            //multiDimensionalArray();
            //jaggedArray();
            //arrayClassDemo();
            string[] data = { "Apple" };
            Console.WriteLine(data);//Internally calls ToString Data Type..
            foreach(String val in data)
                Console.WriteLine(val);
            
        }

        private static void arrayClassDemo()
        {
            //Array class has static methods to copy and create Arrays dynamically...
            Console.WriteLine("Enter the size of the array");
            int size = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter the CTS equivalent name of the array type:");
            string datatype = Console.ReadLine();

            Type className = Type.GetType(datatype);
            if(className == null)
            {
                Console.WriteLine("Invalid .NET type");
                return;
            }
            Array myArray = Array.CreateInstance(className, size);
            for (int i = 0; i < size; i++)
            {
                Console.WriteLine($"Enter the value of the type {className.Name} at the location {i}");
                object value = Convert.ChangeType(Console.ReadLine(), className);
                myArray.SetValue(value, i);
            }
            Console.WriteLine("All the values are set...");
            foreach(object value in myArray)
                Console.WriteLine(value);
                
        }

        private static void jaggedArray()
        {
            //Array of Arrays is called Jagged Array....
            int[][] school = new int[3][];
            school[0] = new int[] { 55, 66, 55, 44, 55, 66 };
            school[1] = new int[] { 67, 87, 67, 77, 87 };
            school[2] = new int[] { 88, 89, 98, 78, 88, 77, 67, 88, 67, 77, 55 };
            //A School is an array of classrooms, where each class has variable no of students in it...
            for (int i = 0; i < school.Length; i++)//No of classrooms
            {
                foreach(int score in school[i])
                    Console.Write(score + " ");
                Console.WriteLine();
            }
        }

        private static void multiDimensionalArray()
        {
            int[,] scores = new int[5, 5];
            for (int i = 0; i < scores.GetLength(0); i++)
            {
                Console.WriteLine($"Enter the scores for student {i}");
                for (int j = 0; j < scores.GetLength(1); j++)
                {
                    Console.WriteLine($"Enter the marks for the subject {j} for the student {i}");
                    scores[i, j] = int.Parse(Console.ReadLine());
                }
            }

            for (int i = 0; i < scores.GetLength(0); i++)
            {
                for(int j = 0; j <scores.GetLength(1); j++)
                    Console.Write(scores[i,j] + " ");
                Console.WriteLine();
            }
        }

        private static void singleDimensionalArray()
        {
            string[] fruits = { "Apple", "Mango", "Orange" };
            int[] scores = new int[] { 45, 56, 56, 56, 45, 66 };

            int[] elements = new int[5];
            for (int i = 0; i < elements.Length; i++)
            {
                elements[i] = i;
            }

            foreach (int e in elements)//forward only and read only....
                Console.WriteLine(e);//what is e?
        }
    }
}