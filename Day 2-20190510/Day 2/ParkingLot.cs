using System;
using System.IO;

namespace Entities//Packages of Java....
{

    abstract class Vehicle
    {
        public abstract double generateParkingFee();//no impl....
        public string RegNo { get; set; }//property...
        public DateTime DateTime { get; set; }
        public int BaseFee { get; protected set; }
        public double ParkingBill { get; set; }
    }

    class Car : Vehicle//Inheritance Syntax in C#....
    {
        public override double generateParkingFee()
        {
            this.BaseFee = 40;
            TimeSpan span = DateTime.Now - DateTime;
            if (span.Hours <= 2)
                return 40;
            else
            {
                int amount = 20 * (span.Hours - 2);
                return 40 + amount ;
            }
        }
    }

    class Bike : Vehicle//Inheritance Syntax in C#....
    {
        public override double generateParkingFee()
        {
            this.BaseFee = 20;
            TimeSpan span = DateTime.Now - DateTime;
            if (span.Hours <= 2)
                return this.BaseFee;
            else
            {
                int amount = 10 * (span.Hours - 2);
                return this.BaseFee + amount;
            }
        }
    }

    class SUV : Vehicle//Inheritance Syntax in C#....
    {
        public override double generateParkingFee()
        {
            this.BaseFee = 60;
            TimeSpan span = DateTime.Now - DateTime;
            if (span.Hours <= 2)
                return BaseFee;
            else
            {
                int amount = 30 * (span.Hours - 2);
                return BaseFee + amount;
            }
        }
    }

    class Statistics
    {
        public static double CarAmount { get; set; }
        public static double BikeAmount { get; set; }
        public static double SUVAmount { get; set; }
    }

    class Helper
    {
        public static string GetString(string statement)
        {
            Console.WriteLine(statement);
            return Console.ReadLine();
        }
        public static int GetNumber(string statement)
        {
            return int.Parse(GetString(statement));
        }
        public static DateTime GetDate(string statement)
        {
            return DateTime.Parse(GetString(statement));
        }
    }
    //Repository Class that holds all the parking details......
    class ParkingLot
    {
        private Vehicle[] _vehicles = new Vehicle[100];//Arrays are fixed in size and cannot be dynamic.....

        public void AddVehicle(Vehicle vehicle)
        {
            //Iterate thro the array,
            for (int i = 0; i < _vehicles.Length; i++)
            {   //find the first occurance of null, and 
                if(_vehicles[i] == null)
                {
                    _vehicles[i] = vehicle;
                    return;
                }
            }
        }

        public Vehicle FindVehicle(String regNo)
        {
            foreach(Vehicle v in _vehicles)
            {
                if((v!= null) && (v.RegNo == regNo))
                {
                    double value = v.generateParkingFee();
                    v.ParkingBill = value;
                    return v;
                }
            }
            throw new Exception("No Vehicle found on this no");           
        }

        public void DisplayStatistics()
        {
            foreach(Vehicle vehicle in _vehicles)
            {
                if(vehicle is Car)
                {
                    Statistics.CarAmount += vehicle.ParkingBill;
                }else if(vehicle is Bike)
                {
                    Statistics.BikeAmount += vehicle.ParkingBill;
                }else if(vehicle is SUV)
                {
                    Statistics.SUVAmount += vehicle.ParkingBill;
                }
            };
            Console.WriteLine("The Final Statistics:");
            Console.WriteLine("Amount by Car: " + Statistics.CarAmount);
            Console.WriteLine("Amount by Bike: " + Statistics.BikeAmount);
            Console.WriteLine("Amount by SUVs: " + Statistics.SUVAmount);
        }

    }

    class MainProgram
    {
        //It is a singleton object....
        static ParkingLot parking = new ParkingLot();
        static void Main(string[] args)
        {
            string menu = getMenu(args[0]);
            bool processing = true;
            do
            {
                int choice = Helper.GetNumber(menu);
                processing = processMenu(choice);
            } while (processing);
        }

        private static bool processMenu(int choice)
        {
            switch (choice)
            {
                case 1:
                    bikeEntry();
                    return true;
                case 2:
                    carEntry();
                    return true;
                case 3:
                    suvEntry();
                    return true;
                case 4:
                    generateBill();
                    return true;
                case 5:
                    parking.DisplayStatistics();
                    return true;
                default:
                    return false;
            }
        }

        private static void generateBill()
        {
            string regNo = Helper.GetString("Enter the Reg no of the Vehicle");
            try
            {
                Vehicle vehicle = parking.FindVehicle(regNo);
                if (vehicle != null)
                {
                    Console.WriteLine($"The Vehicle No {vehicle.RegNo} has the Parking fee of {vehicle.ParkingBill:C}");
                }
            }
            catch
            {
                Console.WriteLine("OOPs! Something wrong happened");
            }
        }

        private static void suvEntry()
        {
            Vehicle suv = new SUV();
            suv.RegNo = Helper.GetString("Enter the Reg No of the SUV");
            suv.DateTime = DateTime.Now;
            parking.AddVehicle(suv);
            Console.WriteLine("SUV is added to the slot successfully");
        }

        private static void carEntry()
        {
            Vehicle car = new Car();
            car.RegNo = Helper.GetString("Enter the Reg No of the Car");
            car.DateTime = DateTime.Now;
            parking.AddVehicle(car);
            Console.WriteLine("Car is added to the slot successfully");
        }

        private static void bikeEntry()
        {
            Vehicle bike = new Bike();
            bike.RegNo = Helper.GetString("Enter the Reg No of the Bike");
            bike.DateTime = DateTime.Now;
            parking.AddVehicle(bike);
            Console.WriteLine("Bike is added to the slot successfully");
        }

        private static string getMenu(string v)
        {
            StreamReader reader = new StreamReader(v);
            return reader.ReadToEnd();
        }
    }
}