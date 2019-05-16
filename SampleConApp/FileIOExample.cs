using System;
using System.IO;//System.IO is the namespace....
namespace SampleConApp
{
    class FileIOExample
    {
        //There are 2 types of File IO classes: Binary and Text.
        //BinaryReader and Writer
        //Text: StreamReader and StreamWriter. 
        static void Main(string[] args)
        {
            //fileReading();
            //fileWriting();
            readCSVFile();
        }

        private static void readCSVFile()
        {
            const string filename = "../../DataExample.csv";//Filename to read
            StreamReader reader = new StreamReader(filename);//create the reader object
            while (!reader.EndOfStream)//loop till the end of the file...
            {
                string line = reader.ReadLine();//extract each line into a string
                string[] words = line.Split(',');//split the string into words by ,
                string readingLine = "";//create a temp string
                foreach (var word in words)//copy each word into temp seperated by -
                {
                    readingLine += word + "-";
                    readingLine = readingLine.Trim('-');//Finally trim the -
                }
                Console.WriteLine(readingLine);//display the line
                Console.WriteLine();
            }
        }

        private static void fileWriting()
        {
            StreamWriter writer = new StreamWriter("../../DataExample.csv",true);//Appends the file
            writer.WriteLine("124,Suresh,Mysore");
            writer.Flush();//To clear the buffer before closing the file....
            writer.Close();
        }

        private static void fileReading()
        {
            StreamReader reader = new StreamReader("../../FileIOExample.cs");
            string content = reader.ReadToEnd();//Reads the whole file at one shot and returns the data as string....
            Console.WriteLine(content);
            //If U want to read each line, U could use ReadLine method.
        }
    }
}