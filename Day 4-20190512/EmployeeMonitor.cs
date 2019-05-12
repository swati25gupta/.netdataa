using System;
using System.Data;
using System.IO;

namespace Entities
{
    class Employee
    {
        public int EmpID { get; set; }
        public string EmpName { get; set; }
        public string EmpAddress { get; set; }
        public int EmpSalary { get; set; }

        public override string ToString()
        {
            return string.Format($"The Name:{EmpName}\nThe Address:{EmpAddress}\nThe Salary:{EmpSalary}\nThe EmpID:{EmpID}");
        }
    }
}

namespace DataLayer
{
    interface IDataComponent
    {
        void AddEmployee(int id, string name, string address, int salary);
        void UpdateEmployee(int id, string name, string address, int salary);
        void DeleteEmployee(int id);
        DataTable GetAllEmployees();
    }

    class DataComponent : IDataComponent
    {
        private DataTable table = new DataTable("Employees");
        public DataComponent()
        {
            table.Columns.Add("EmpID", typeof(int));
            table.Columns.Add("EmpName", typeof(string));
            table.Columns.Add("EmpAddress", typeof(string));
            table.Columns.Add("EmpSalary", typeof(int));
        }
        public void AddEmployee(int id, string name, string address, int salary)
        {
            //Create a Row initialized to the schema of the row
            DataRow row = table.NewRow();
            //set values to the row...
            row[0] = id;
            row[1] = name;
            row[2] = address;
            row[3] = salary;
            //add the row to the table
            table.Rows.Add(row);
            //update
            table.AcceptChanges();
        }

        public void DeleteEmployee(int id)
        {
            throw new NotImplementedException();
        }

        public DataTable GetAllEmployees()
        {
            return table;
        }

        public void UpdateEmployee(int id, string name, string address, int salary)
        {
            throw new NotImplementedException();
        }
    }

    class FileComponent : IDataComponent
    {
        public FileComponent()
        {
            table.Columns.Add("EmpID", typeof(int));
            table.Columns.Add("EmpName", typeof(string));
            table.Columns.Add("EmpAddress", typeof(string));
            table.Columns.Add("EmpSalary", typeof(int));
        }
        const string filename = "Employees.csv";
        private DataTable table = new DataTable("Employees");
        public void AddEmployee(int id, string name, string address, int salary)
        {
            StreamWriter writer = new StreamWriter(filename, true);
            string line = $"{id},{name},{address},{salary}";
            writer.WriteLine(line);
            writer.Flush();
            writer.Close();
        }
        //how to convert a CSV file data into a Table of records of a DataTable....
        private void populateData()
        {
            table.Rows.Clear();
            if (!File.Exists("Employees.csv"))
            {
                throw new Exception("No Data is stored...");
            }
            StreamReader reader = new StreamReader(filename);
            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                var words = line.Split(',');
                DataRow row = table.NewRow();//schema for the row...
                for (int i = 0; i < words.Length; i++)
                    row[i] = words[i];
                table.Rows.Add(row);
            }
            reader.Close();

        }
        public void DeleteEmployee(int id)
        {
            throw new NotImplementedException();
        }

        public DataTable GetAllEmployees()
        {
            try
            {
                populateData();
                return table;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public void UpdateEmployee(int id, string name, string address, int salary)
        {
            throw new NotImplementedException();
        }
    }
}

namespace BusinessLayer
{
    using Entities;
    using DataLayer;
    interface IBusinessComponent
    {
        void AddEmployee(Employee emp);
        void UpdateEmployee(Employee emp);
        void DeleteEmployee(int id);
        Employee[] GetAllEmployees();
    }

    class BusinessComponent : IBusinessComponent
    {
        private IDataComponent com = new FileComponent(); 
        public void AddEmployee(Employee emp)
        {
            if (com == null)
            {
                throw new Exception("The Details of the Database are not yet set");
            }
            if (emp.EmpID > 100)
                throw new Exception("Employee ID should be lesser than 100");
            com.AddEmployee(emp.EmpID, emp.EmpName, emp.EmpAddress, emp.EmpSalary); 
        }

        public void DeleteEmployee(int id)
        {
            if (com == null)
            {
                throw new Exception("The Details of the Database are not yet set");
            }
            com.DeleteEmployee(id);
        }

        public Employee[] GetAllEmployees()
        {
            if (com == null)
            {
                throw new Exception("The Details of the Database are not yet set");
            }
            DataTable records = com.GetAllEmployees();
            Employee[] employees = new Employee[0];//No employees yet....
            foreach(DataRow row in records.Rows)
            {
                Employee emp = new Employee();
                emp.EmpID = int.Parse(row[0].ToString());
                emp.EmpName = row[1].ToString();
                emp.EmpAddress = row[2].ToString();
                emp.EmpSalary = Convert.ToInt32(row[3]);
                Array backUp = employees.Clone() as Employee[];
                employees = new Employee[backUp.Length + 1];
                //copy one by one all the elements of backup to this new Array...
                if(backUp.Length != 0)
                   backUp.CopyTo(employees, 0);
                employees[employees.Length - 1] = emp;
            }
            return employees;
        }

        public void UpdateEmployee(Employee emp)
        {
            if (com == null)
            {
                throw new Exception("The Details of the Database are not yet set");
            }
        }
    }
}

namespace UILayer
{
    using Entities;
    using BusinessLayer;
    enum choice { Add = 1, Delete, Update, Find }
    class MainProgram
    {
        static IBusinessComponent bo = new BusinessComponent();
        static string getMenu()
        {
            string menu = "~~~~~~~~~~~~~~~~~~~~~~~EMPLOYEE MONITOR~~~~~~~~~~~~~~~\n";
            menu += "TO ADD NEW EMPLOYEE--------->PRESS 1\n";
            menu += "TO DELETE EMPLOYEE--------->PRESS 2\n";
            menu += "TO UPDATE EMPLOYEE--------->PRESS 3\n";
            menu += "TO FIND EMPLOYEE--------->PRESS 4\n";
            return menu;
        }
        static void Main(string[] args)
        {
            bool processing = true;
            string menu = getMenu();
            do
            {
                choice option = (choice)Helper.GetNumber(menu);
                processing = processMenu(option);
            } while (processing);
        }

        private static bool processMenu(choice option)
        {
            switch (option)
            {
                case choice.Add:
                    addingCode();
                    break;
                case choice.Delete:
                    deletingCode();
                    break;
                case choice.Update:
                    updatingCode();
                    break;
                case choice.Find:
                    findingCode();
                    break;
                default:
                    return false;
            }
            return true;
        }

        private static void addingCode()
        {
            RETRY:
            try
            {
                Employee emp = new Employee();
                emp.EmpID = Helper.GetNumber("Please enter the ID for this Employee");
                emp.EmpName = Helper.GetString("Please enter the Name");
                emp.EmpAddress = Helper.GetString("Please enter the Address");
                emp.EmpSalary = Helper.GetNumber("Enter the Salary of this Employee");
                bo.AddEmployee(emp);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                goto RETRY;
            }
        }

        private static void deletingCode()
        {
            int no = Helper.GetNumber("Enter the ID of the Employee to delete");
            try
            {
                bo.DeleteEmployee(no);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static void updatingCode()
        {
            throw new Exception("Do it urself...");
        }

        private static void findingCode()
        {
            string  nameToFind = Helper.GetString("Enter the Name or part of the name to search");
            try
            {
                Employee[] data = bo.GetAllEmployees();
                foreach (Employee emp in data)
                {
                    if (emp.EmpName.Contains(nameToFind))
                    {
                        Console.WriteLine(emp);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}