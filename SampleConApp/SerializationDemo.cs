using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
//Serialization is acheived in .NET using attributes. Attributes are optional properties that can be added and evaluated at runtime. Its an ability to save the state of the object so that it could be retrieved later. The process of saving is called serialization and the process of retriving is called Deserialization.
/* For serialization U have 3 things:
 * What to serialize? : Any object of a class that has an attribute called serializable. 
 * Where to serialize?: Streams, Memory, Files are used as locations of serialization. 
 * How to serialize? Format of serialization is done in 3 ways: Binary, XML and SOAP.
 * Binary for Windows OS, XML for Cross Platform, and SOAP for Web services.  
 */
namespace SampleConApp
{
    [Serializable]//Optional Properties
    class Customer
    {
        public int CustomerID { get; set; }
        public string CustomerName { get; set; }
        public string CustomerAddress { get; set; }
        public DateTime BillDate { get; set; }
        public double BillAmount { get; set; }
        public override string ToString()
        {
            return $"The Name:{CustomerName}\nAddress:{CustomerAddress}\nBillDate:{BillDate.ToString("dd-MM-yyyy hh:mm:ss")}\nTotal Amount:{BillAmount:C}";
        }
    }
    class SerializationDemo
    {
        static void Main(string[] args)
        {
            //serialize();
            deserialize();
        }

        private static void deserialize()
        {
            string filename = "Customer.Bin";
            if (!File.Exists(filename))
            {
                Console.WriteLine("No data is found");
                return;
            }
            FileStream fs = new FileStream(filename, FileMode.Open, FileAccess.Read);
            BinaryFormatter fm = new BinaryFormatter();
            object data = fm.Deserialize(fs);
            if(data is Customer)
            {
                Customer cst = data as Customer;
                Console.WriteLine(cst);
            }
        }

        private static void serialize()
        {
            Customer cst = new Customer
            {
                CustomerID = 1,
                CustomerName = "TestName",
                CustomerAddress = "Bangalore",
                BillAmount = 5600,
                BillDate = DateTime.Now.AddDays(-456)
            };
            FileStream fs = new FileStream("Customer.bin", FileMode.OpenOrCreate);//Location of serialization....
            BinaryFormatter fm = new BinaryFormatter();//Class used to serialize in binary format.
            fm.Serialize(fs, cst);
            fs.Close();
        }
    }
}//using the interface IDatabaseComponent apply serialization and store the data and write a WPF App that reads the data and display it as output. The Dal Component should be a DLL and is consumed by the WPF App...